import { Component, OnInit, Injector, ViewChild } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { GetOpportunityForViewDto, OpportunitiesServiceProxy, OpportunityDto, OpportunityOpportunityStageLookupTableDto, OpportunityStageDto, OpportunityStagesServiceProxy, OpportunityUserUserLookupTableDto, PagedResultDtoOfGetOpportunityStageForViewDto } from '@shared/service-proxies/service-proxies';
import { NotifyService } from 'abp-ng2-module';
import { AppComponentBase } from '@shared/common/app-component-base';
import { TokenAuthServiceProxy } from '@shared/service-proxies/service-proxies';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { Paginator } from 'primeng/paginator';
import { LazyLoadEvent } from 'primeng/api';
import { FileDownloadService } from '@shared/utils/file-download.service';
import { filter as _filter } from 'lodash-es';
import { DateTime } from 'luxon';
import { Table } from 'primeng/table';
import { DateTimeService } from '@app/shared/common/timing/date-time.service';
import { LocalStorageService } from '@shared/utils/local-storage.service';
import {CustomizableDashboardModule} from '@app/shared/common/customizable-dashboard/customizable-dashboard.module';
import { WidgetComponentBaseComponent } from '../widget-component-base';
import { AppConsts } from '@shared/AppConsts';


@Component({
    selector: 'app-opportunities-widget-list',
    templateUrl: './widget-opportunities-list.component.html',
    styleUrls: ['./widget-opportunities-list.component.css'],
})
export class WidgetOpportunitiesListComponent extends WidgetComponentBaseComponent implements OnInit {
    @ViewChild('dataTable', { static: true }) dataTable: Table;
    @ViewChild('paginator', { static: true }) paginator: Paginator;

    opportunityStages: OpportunityOpportunityStageLookupTableDto[];
    selectedOpportunityStage: OpportunityOpportunityStageLookupTableDto;
    selectedOpportunityStages: OpportunityOpportunityStageLookupTableDto[];
    allStagesFilter : OpportunityOpportunityStageLookupTableDto = new OpportunityOpportunityStageLookupTableDto;

    advancedFiltersAreShown = false;
    filterText = '';
    timeZone = '';
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
    contactName = '';
    selectedDateRange: DateTime[] = [
        this._dateTimeService.getStartOfMonth(),
        this._dateTimeService.getEndOfMonth(),
    ];
    rangeDates: DateTime[];

    allUsers: OpportunityUserUserLookupTableDto[];   
    selectedUsers: OpportunityUserUserLookupTableDto[];
    noAssignedUsersOption: OpportunityUserUserLookupTableDto = new OpportunityUserUserLookupTableDto;
    defaultUser: OpportunityUserUserLookupTableDto = new OpportunityUserUserLookupTableDto    

    /***
     * Main constructor
     * @param injector
     * @param _opportunityServiceProxy
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
        private _notifyService: NotifyService,
        private _tokenAuth: TokenAuthServiceProxy,
        private _activatedRoute: ActivatedRoute,
        private _fileDownloadService: FileDownloadService,
        private _router: Router,
        private _dateTimeService: DateTimeService,
        private _localStorageService: LocalStorageService
    ) {
        super(injector);
    }


    /***
    * Initialize component
    */
     ngOnInit(){
        this._opportunitiesServiceProxy.getAllOpportunityStageForTableDropdown()
        .subscribe((result) => {
            this.opportunityStages = result;
            this.allStagesFilter.displayName = 'All';
            this.opportunityStages.unshift(this.allStagesFilter);
        });

        this._opportunitiesServiceProxy.getAllUsersForTableDropdown().subscribe((result) => {
            this.allUsers = result;    
            this.noAssignedUsersOption.id = -1;
            this.noAssignedUsersOption.displayName = "None"   
            this.allUsers.unshift(this.noAssignedUsersOption);
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

        
        this.minCloseDateFilter = this.rangeDates != null ? (this.rangeDates[0] ?? undefined) : undefined;
        this.maxCloseDateFilter = this.rangeDates != null ? (this.rangeDates[1] ?? undefined) : undefined;
    

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
                this.contactName,
                this.selectedOpportunityStage?.id,
                this.selectedUsers?.map(x => x.id),
                this.primengTableHelper.getSorting(this.dataTable),
                this.primengTableHelper.getSkipCount(this.paginator, event),
                this.primengTableHelper.getMaxResultCount(this.paginator, event)
            )
            .subscribe((result) => {
                this.primengTableHelper.totalRecordsCount = result.totalCount;
                this.primengTableHelper.records = result.items;
                this.setUsersProfilePictureUrl(this.primengTableHelper.records);
                this.primengTableHelper.hideLoadingIndicator();
            });
    }

    /***
     * Get opportunities by name filter changed
     * @param event
     */
    getOpportunityByNameFilter(event: KeyboardEvent) {
        const textFilterHasMoreThan1Characters = this.nameFilter && this.nameFilter?.trim().length >= 1;
        const keyDownIsBackspace = event && event.key === 'Backspace';
        if (textFilterHasMoreThan1Characters || keyDownIsBackspace) {
            this.getOpportunities();
        }
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

        this.timeZone =  this._dateTimeService.getLocalTimeZone(); 

        this._opportunitiesServiceProxy
            .getOpportunitiesToExcel(
                this.filterText,
                this.timeZone,
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
                this.contactName,
                this.selectedOpportunityStage?.id,
                this.selectedUsers?.map(x => x.id),
            )
            .subscribe((result) => {
                this._fileDownloadService.downloadTempFile(result);
            });
    }

     /***
     * Set user image profile reference
     * @param users
     */
      setUsersProfilePictureUrl(users: GetOpportunityForViewDto[]): void {
        for (let i = 0; i < users.length; i++) {
            let user = users[i];
            if (user.firstUserAssignedId) {
                this._localStorageService.getItem(AppConsts.authorization.encrptedAuthTokenName, function(err, value) {
                    let profilePictureUrl =
                        AppConsts.remoteServiceBaseUrl +
                        '/Profile/GetProfilePictureByUser?userId=' +
                        user.firstUserAssignedId +
                        '&' +
                        AppConsts.authorization.encrptedAuthTokenName +
                        '=' +
                        encodeURIComponent(value.token);
                    (user as any).profilePictureUrl = profilePictureUrl;
                });
            }
        }
    }
}

