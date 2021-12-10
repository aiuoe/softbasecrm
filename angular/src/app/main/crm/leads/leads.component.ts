import { AppConsts } from '@shared/AppConsts';
import { Component, Injector, ViewEncapsulation, ViewChild } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { LeadsServiceProxy, LeadDto, LeadStatusesServiceProxy } from '@shared/service-proxies/service-proxies';
import { NotifyService } from 'abp-ng2-module';
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
import { ConsoleLogger } from '@microsoft/signalr/dist/esm/Utils';

@Component({
    templateUrl: './leads.component.html',
    encapsulation: ViewEncapsulation.None,
    animations: [appModuleAnimation()],
})
export class LeadsComponent extends AppComponentBase {
    @ViewChild('dataTable', { static: true }) dataTable: Table;
    @ViewChild('paginator', { static: true }) paginator: Paginator;

    
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

    constructor(
        injector: Injector,
        private _leadsServiceProxy: LeadsServiceProxy,
        private _leadStatusesServiceProxy : LeadStatusesServiceProxy,
        private _notifyService: NotifyService,
        private _tokenAuth: TokenAuthServiceProxy,
        private _activatedRoute: ActivatedRoute,
        private _fileDownloadService: FileDownloadService,
        private _router: Router,
        private _dateTimeService: DateTimeService
    ) {
        super(injector);
    }    

    selectedStatusFilter = "All";

    statusFilterOptions = [];

    readOnlyOptions = ["Converted"];

    getLeadsStatuses(event?: LazyLoadEvent) {
        this._leadStatusesServiceProxy
            .getAll(
                undefined,
                undefined,
                undefined,
                undefined,
                undefined
            ).subscribe((result) => {
                let resultItems = result.items;
                resultItems.forEach( (item) => {
                    this.statusFilterOptions.push(item.leadStatus.description)
                });
            });
        this.statusFilterOptions.push("All");
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

    filterByStatus(statusSelected): void {
        this.selectedStatusFilter = statusSelected;
        if (statusSelected == "All")
            statusSelected = '';
        this.leadStatusDescriptionFilter = statusSelected;
        this.getLeads();
    }

    leadCanBeEdittedOrConverted(event: any) : boolean {
        return this.readOnlyOptions.includes(event);
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
                this.priorityDescriptionFilter
            )
            .subscribe((result) => {
                this._fileDownloadService.downloadTempFile(result);                
            });
    } 

    /* 
    Below there are methods that act as placeholder for
    rows selections, currently there are not valid actions
    as 12/7/2021 - lead summary story
    */

    onTableHeaderCheckboxToggle(event: any) {
        console.log("Not implemented");
    }

    onRowSelect(event) {
        console.log("Not implemented");
    }

    onRowUnselect(event) {      
        console.log("Not implemented");  
    }
}
