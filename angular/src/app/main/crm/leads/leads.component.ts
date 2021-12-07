import { AppConsts } from '@shared/AppConsts';
import { Component, Injector, ViewEncapsulation, ViewChild, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { LeadsServiceProxy, LeadDto, LeadLeadSourceLookupTableDto, UserServiceProxy } from '@shared/service-proxies/service-proxies';
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

@Component({
    templateUrl: './leads.component.html',
    encapsulation: ViewEncapsulation.None,
    animations: [appModuleAnimation()],
})
export class LeadsComponent extends AppComponentBase implements OnInit {
    @ViewChild('dataTable', { static: true }) dataTable: Table;
    @ViewChild('paginator', { static: true }) paginator: Paginator;

    advancedFiltersAreShown = false;
    filterText = '';
    companyNameFilter = '';
    contactNameFilter = '';
    contactPositionFilter = '';
    webSiteFilter = '';
    addressFilter = '';
    countryFilter = '';
    stateFilter = '';
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

    displayModal: boolean = false;
    allLeadSources: LeadLeadSourceLookupTableDto[];
    leadSourceDescription = '';
    leadSourceId: number;
    formData = new FormData();

    public uploader: FileUploader;
    private _uploaderOptions: FileUploaderOptions = {}
    public saving = false;

    constructor(
        injector: Injector,
        private _leadsServiceProxy: LeadsServiceProxy,
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
                this.companyNameFilter,
                this.contactNameFilter,
                this.contactPositionFilter,
                this.webSiteFilter,
                this.addressFilter,
                this.countryFilter,
                this.stateFilter,
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
                this.companyNameFilter,
                this.contactNameFilter,
                this.contactPositionFilter,
                this.webSiteFilter,
                this.addressFilter,
                this.countryFilter,
                this.stateFilter,
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
                this.priorityDescriptionFilter
            )
            .subscribe((result) => {
                this._fileDownloadService.downloadTempFile(result);
            });
    }

    showModalDialog() {
        this.displayModal = true;
        this.initFileUploader();
    }

    uploadFile(files){
        if (files.length === 0) {
			return;
		}
        this.formData = new FormData();
		for (const file of files) {
			this.formData.append(file.name, file);
		}

        const uploadReq = new HttpRequest('POST', ` https://localhost:44301/api/services/app/LeadImport/UploadLeadsAsync`, this.formData, {
			reportProgress: true,
		});

        this.http.request(uploadReq).subscribe( response =>{
            console.log(response);
        });
    }

    ////////////////////// Another solution /////////////////////////////////

    guid(): string {
        function s4() {
            return Math.floor((1 + Math.random()) * 0x10000)
                .toString(16)
                .substring(1);
        }

        return s4() + s4() + '-' + s4() + '-' + s4() + '-' + s4() + '-' + s4() + s4() + s4();
    }

    initFileUploader(): void {
        this.uploader = new FileUploader({ url: AppConsts.remoteServiceBaseUrl + '/LeadImport/UploadLeads' });
        this._uploaderOptions.autoUpload = false;
        this._uploaderOptions.authToken = 'Bearer ' + this._tokenService.getToken();
        this._uploaderOptions.removeAfterUpload = true;
        this.uploader.onAfterAddingFile = (file) => {
            file.withCredentials = false;
        };

        this.uploader.onBuildItemForm = (fileItem: FileItem, form: any) => {
            form.append('FileType', fileItem.file.type);
            form.append('FileName', 'ProfilePicture');
            form.append('FileToken', this.guid());
        };

        this.uploader.onSuccessItem = (item, response, status) => {
            const resp = <IAjaxResponse>JSON.parse(response);
            if (resp.success) {
                this.uploadLeadsFromFile(resp.result.fileToken);
            } else {
                this.message.error(resp.error.message);
            }
        };

        this.uploader.setOptions(this._uploaderOptions);
    }

    
    uploadLeadsFromFile(fileToken: string): void {
        const input = {
            fileToken: fileToken,
            x: 0,
            y: 0,
            width: 0,
            height: 0
        }

        this.saving = true;
        this._leadsServiceProxy
            .uploadLeadsFromFile(input)
            .pipe(
                finalize(() => {
                    this.saving = false;
                })
            )
            .subscribe(() => {

            });
    }

    fileChangeEvent(event: any): void {
        if (event.target.files[0].size > 6242880) {
            //5MB
            this.message.warn(this.l('ProfilePicture_Warn_SizeLimit', 6));
            return;
        }
    }

    save(){
        this.uploader.uploadAll();
    }
}
