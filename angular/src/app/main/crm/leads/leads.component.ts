import { AppConsts } from '@shared/AppConsts';
import { Component, Injector, ViewEncapsulation, ViewChild, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { LeadsServiceProxy, LeadDto, LeadStatusesServiceProxy, LeadLeadSourceLookupTableDto, UserServiceProxy, LeadStatusDto, PagedResultDtoOfGetLeadStatusForViewDto } from '@shared/service-proxies/service-proxies';
import { IAjaxResponse, NotifyService, TokenService } from 'abp-ng2-module';
import { AppComponentBase } from '@shared/common/app-component-base';
import { TokenAuthServiceProxy } from '@shared/service-proxies/service-proxies';

import { appModuleAnimation } from '@shared/animations/routerTransition';
import { Table } from 'primeng/table';
import { Paginator } from 'primeng/paginator';
import { LazyLoadEvent } from 'primeng/api';
import { FileDownloadService } from '@shared/utils/file-download.service';
import { filter as _filter } from 'lodash-es';
import { DateTime } from 'luxon';

import { DateTimeService } from '@app/shared/common/timing/date-time.service';
import { HttpClient, HttpRequest } from '@angular/common/http';
import { FileItem, FileUploader, FileUploaderOptions } from 'ng2-file-upload';
import { finalize } from 'rxjs/operators';
import { base64ToFile } from '@node_modules/ngx-image-cropper';
import { ChangeProfilePictureModalComponent } from '@app/shared/layout/profile/change-profile-picture-modal.component';
import { ImportLeadsModalComponent } from '@app/main/crm/leads/import-leads-modal.component';
import { ConsoleLogger } from '@microsoft/signalr/dist/esm/Utils';
import { read } from 'fs';

@Component({
    templateUrl: './leads.component.html',
    encapsulation: ViewEncapsulation.None,
    animations: [appModuleAnimation()],
})
export class LeadsComponent extends AppComponentBase implements OnInit {
    @ViewChild('dataTable', { static: true }) dataTable: Table;
    @ViewChild('paginator', { static: true }) paginator: Paginator;

    @ViewChild('importLeadsModalComponent', { static: true })

    importLeadsModalComponent: ImportLeadsModalComponent;
    leadStatuses: LeadStatusDto[];
    selectedLeadStatus: LeadStatusDto;
    selectedLeadStatuses: LeadStatusDto[];
    readOnlyStatus : string[];
    
    advancedFiltersAreShown = false;
    filterText = '';
    companyOrContactNameFilter = '';
    contactNameFilter = '';
    contactPositionFilter = '';
    webSiteFilter = '';
    addressFilter = '';
    countryFilter = '';
    stateFilter = '';
    cityFilter = '';
    descriptionFilter = '';
    companyPhoneFilter = '';
    companyEmailFilter = '';
    poBoxFilter = '';
    zipCodeFilter = '';
    contactPhoneFilter = '';
    contactPhoneExtensionFilter = '';
    contactCellPhoneFilter = '';
    contactFaxNumberFilter = '';
    pagerNumberFilter = '';
    contactEmailFilter = '';
    leadSourceDescriptionFilter = '';
    leadStatusDescriptionFilter = '';
    priorityDescriptionFilter = '';

    displayModal = false;
    allLeadSources: LeadLeadSourceLookupTableDto[];
    leadSourceDescription = '';
    leadSourceId: number;
    formData = new FormData();
    importFile: File;

    public uploader: FileUploader;
    private _uploaderOptions: FileUploaderOptions = {}
    public saving = false;

    constructor(
        injector: Injector,
        private _leadsServiceProxy: LeadsServiceProxy,
        private _leadStatusesServiceProxy : LeadStatusesServiceProxy,
        private _notifyService: NotifyService,
        private _tokenAuth: TokenAuthServiceProxy,
        private _activatedRoute: ActivatedRoute,
        private _fileDownloadService: FileDownloadService,
        private _router: Router,
        private _dateTimeService: DateTimeService,
        private http: HttpClient,
        private _tokenService: TokenService
    ) {
        super(injector);
    }    

    ngOnInit(){
        this._leadsServiceProxy.getAllLeadSourceForTableDropdown().subscribe((result) => {
            this.allLeadSources = result;
        });
        this._leadStatusesServiceProxy.getAll(undefined,
            undefined,
            undefined,
            undefined,
            undefined)
        .subscribe((result: PagedResultDtoOfGetLeadStatusForViewDto) => {
            this.leadStatuses = result.items.map(x => x.leadStatus);
            this.leadStatuses.forEach( (leadStatus) => {
                if (!leadStatus.isLeadConversionValid)
                    this.readOnlyStatus.push(leadStatus.description);
            })
        });
    }

    getLeads(event?: LazyLoadEvent) {
        if (this.primengTableHelper.shouldResetPaging(event)) {
            this.paginator.changePage(0);
            return;
        }

        this.primengTableHelper.showLoadingIndicator();

        this._leadsServiceProxy
            .getAll(
                this.filterText,
                this.companyOrContactNameFilter,
                this.contactNameFilter,
                this.contactPositionFilter,
                this.webSiteFilter,
                this.addressFilter,
                this.countryFilter,
                this.stateFilter, 
                this.cityFilter,
                this.descriptionFilter,
                this.companyPhoneFilter,
                this.companyEmailFilter,
                this.poBoxFilter,
                this.zipCodeFilter,
                this.contactPhoneFilter,
                this.contactPhoneExtensionFilter,
                this.contactCellPhoneFilter,
                this.contactFaxNumberFilter,
                this.pagerNumberFilter,
                this.contactEmailFilter,
                this.leadSourceDescriptionFilter,
                this.leadStatusDescriptionFilter,
                this.priorityDescriptionFilter,
                this.selectedLeadStatuses?.map(x => x.id),
                this.primengTableHelper.getSorting(this.dataTable),
                this.primengTableHelper.getSkipCount(this.paginator, event),
                this.primengTableHelper.getMaxResultCount(this.paginator, event)
            )
            .subscribe((result) => {                
                this.primengTableHelper.totalRecordsCount = result.totalCount;
                this.primengTableHelper.records = result.items;
                this.primengTableHelper.hideLoadingIndicator();
            });
    }

    leadCanBeEdittedOrConverted(event: any) : boolean {
        return !(this.readOnlyStatus.includes(event));
    }

    reloadPage(): void {
        this.paginator.changePage(this.paginator.getPage());
    }

    createLead(): void {
        this._router.navigate(['/app/main/crm/leads/createOrEdit']);
    }

    deleteLead(lead: LeadDto): void {
        this.message.confirm('', this.l('AreYouSure'), (isConfirmed) => {
            if (isConfirmed) {
                this._leadsServiceProxy.delete(lead.id).subscribe(() => {
                    this.reloadPage();
                    this.notify.success(this.l('SuccessfullyDeleted'));
                });
            }
        });
    }

    exportToExcel(): void {
        this._leadsServiceProxy
            .getLeadsToExcel(
                this.filterText,
                this.companyOrContactNameFilter,
                this.contactNameFilter,
                this.contactPositionFilter,
                this.webSiteFilter,
                this.addressFilter,
                this.countryFilter,
                this.stateFilter,
                this.cityFilter, 
                this.descriptionFilter,
                this.companyPhoneFilter,
                this.companyEmailFilter,
                this.poBoxFilter,
                this.zipCodeFilter,
                this.contactPhoneFilter,
                this.contactPhoneExtensionFilter,
                this.contactCellPhoneFilter,
                this.contactFaxNumberFilter,
                this.pagerNumberFilter,
                this.contactEmailFilter,
                this.leadSourceDescriptionFilter,
                this.leadStatusDescriptionFilter,
                this.priorityDescriptionFilter,
                this.selectedLeadStatuses?.map(x => x.id)
            )
            .subscribe((result) => {
                this._fileDownloadService.downloadTempFile(result);                
            });
    } 

    /* 
    Below there are methods that act as placeholder for
    rows selections, currently there are not valid actions
    as 13/12/2021 - lead summary story
    */

    onTableHeaderCheckboxToggle(event: any) {
        console.log('Not implemented');
    }

    onRowSelect(event) {
        console.log('Not implemented');
    }

    onRowUnselect(event) {      
        console.log('Not implemented');  
    }

    showModalDialog() {
        this.importLeadsModalComponent.show();
    }
}
