﻿import { AppConsts } from '@shared/AppConsts';
import { Component, Injector, ViewEncapsulation, ViewChild } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { OpportunitiesServiceProxy, OpportunityDto, OpportunityStageDto, OpportunityStagesServiceProxy, PagedResultDtoOfGetOpportunityStageForViewDto } from '@shared/service-proxies/service-proxies';
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

/***
 * Component to manage the opportunity summary grid
 */
@Component({
    templateUrl: './opportunities.component.html',
    encapsulation: ViewEncapsulation.None,
    animations: [appModuleAnimation()],
})
export class OpportunitiesComponent extends AppComponentBase {
    @ViewChild('dataTable', { static: true }) dataTable: Table;
    @ViewChild('paginator', { static: true }) paginator: Paginator;

    opportunityStages: OpportunityStageDto[];
    selectedOpportunityStage: OpportunityStageDto;
    selectedOpportunityStages: OpportunityStageDto[];

    advancedFiltersAreShown = false;
    filterText = '';
    nameFilter = '';
    maxAmountFilter: number;
    maxAmountFilterEmpty: number;
    minAmountFilter: number;
    minAmountFilterEmpty: number;
    maxProbabilityFilter: number;
    maxProbabilityFilterEmpty: number;
    minProbabilityFilter: number;
    minProbabilityFilterEmpty: number;
    maxCloseDateFilter: DateTime;
    minCloseDateFilter: DateTime;
    descriptionFilter = '';
    branchFilter = '';
    departmentFilter = '';
    opportunityStageDescriptionFilter = '';
    leadSourceDescriptionFilter = '';
    opportunityTypeDescriptionFilter = '';
    customerName = '';

    /***
     * Main constructor
     * @param injector
     * @param _opportunityServiceProxy
     * @param _opportunityStageServiceProxy
     * @param _notifyService
     * @param _tokenAuth
     * @param _activatedRoute
     * @param _fileDownloadService
     * @param _router
     * @param _dateTimeService
     */
    constructor(
        injector: Injector,
        private _opportunitiesServiceProxy: OpportunitiesServiceProxy,
        private _opportunityStagesServiceProxy: OpportunityStagesServiceProxy,
        private _notifyService: NotifyService,
        private _tokenAuth: TokenAuthServiceProxy,
        private _activatedRoute: ActivatedRoute,
        private _fileDownloadService: FileDownloadService,
        private _router: Router,
        private _dateTimeService: DateTimeService
    ) {
        super(injector);
    }

    
    /***
    * Initialize component
    */
     ngOnInit(){
        this._opportunityStagesServiceProxy.getAll(
            undefined,
            undefined,
            undefined,
            undefined,
            undefined)
        .subscribe((result: PagedResultDtoOfGetOpportunityStageForViewDto) => {
            this.opportunityStages = result.items.map(x => x.opportunityStage);
        });
    }

    /***
    * Get opportunities on page load/filter changes
    * @param event
    */
    getOpportunities(event?: LazyLoadEvent) {
        if (this.primengTableHelper.shouldResetPaging(event)) {
            this.paginator.changePage(0);
            return;
        }

        this.primengTableHelper.showLoadingIndicator();

        this._opportunitiesServiceProxy
            .getAll(
                this.filterText,
                this.nameFilter,
                this.maxAmountFilter == null ? this.maxAmountFilterEmpty : this.maxAmountFilter,
                this.minAmountFilter == null ? this.minAmountFilterEmpty : this.minAmountFilter,
                this.maxProbabilityFilter == null ? this.maxProbabilityFilterEmpty : this.maxProbabilityFilter,
                this.minProbabilityFilter == null ? this.minProbabilityFilterEmpty : this.minProbabilityFilter,
                this.maxCloseDateFilter === undefined
                    ? this.maxCloseDateFilter
                    : this._dateTimeService.getEndOfDayForDate(this.maxCloseDateFilter),
                this.minCloseDateFilter === undefined
                    ? this.minCloseDateFilter
                    : this._dateTimeService.getStartOfDayForDate(this.minCloseDateFilter),
                this.descriptionFilter,
                this.branchFilter,
                this.departmentFilter,
                this.opportunityStageDescriptionFilter,
                this.leadSourceDescriptionFilter,
                this.opportunityTypeDescriptionFilter,
                this.customerName,
                this.selectedOpportunityStages?.map(x => x.id),
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

    /***
    * Reload page
    */
    reloadPage(): void {
        this.paginator.changePage(this.paginator.getPage());
    }

    /***
    * Go to create lead page
    */    
    createOpportunity(): void {
        this._router.navigate(['/app/main/crm/opportunities/createOrEdit']);
    }

    /***
    * Export to excel
    */
    exportToExcel(): void {
        this._opportunitiesServiceProxy
            .getOpportunitiesToExcel(
                this.filterText,
                this.nameFilter,
                this.maxAmountFilter == null ? this.maxAmountFilterEmpty : this.maxAmountFilter,
                this.minAmountFilter == null ? this.minAmountFilterEmpty : this.minAmountFilter,
                this.maxProbabilityFilter == null ? this.maxProbabilityFilterEmpty : this.maxProbabilityFilter,
                this.minProbabilityFilter == null ? this.minProbabilityFilterEmpty : this.minProbabilityFilter,
                this.maxCloseDateFilter === undefined
                    ? this.maxCloseDateFilter
                    : this._dateTimeService.getEndOfDayForDate(this.maxCloseDateFilter),
                this.minCloseDateFilter === undefined
                    ? this.minCloseDateFilter
                    : this._dateTimeService.getStartOfDayForDate(this.minCloseDateFilter),
                this.descriptionFilter,
                this.branchFilter,
                this.departmentFilter,
                this.opportunityStageDescriptionFilter,
                this.leadSourceDescriptionFilter,
                this.opportunityTypeDescriptionFilter,
                this.customerName,
                this.selectedOpportunityStages?.map(x => x.id)
            )
            .subscribe((result) => {
                this._fileDownloadService.downloadTempFile(result);
            });
    }
}
