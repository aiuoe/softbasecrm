﻿import { AppConsts } from '@shared/AppConsts';
import { Component, Injector, ViewEncapsulation, ViewChild, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import {
    ActivitiesServiceProxy,
    ActivityActivitySourceTypeLookupTableDto,
    ActivityActivityStatusLookupTableDto,
    ActivityActivityTaskTypeLookupTableDto,
    ActivityDto, ActivityUserLookupTableDto,
    ProfileServiceProxy,
} from '@shared/service-proxies/service-proxies';
import { NotifyService } from 'abp-ng2-module';
import { AppComponentBase } from '@shared/common/app-component-base';
import { TokenAuthServiceProxy } from '@shared/service-proxies/service-proxies';
import { CreateOrEditActivityModalComponent } from './create-or-edit-activity-modal.component';
import { ViewActivityModalComponent } from './view-activity-modal.component';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { Table } from 'primeng/table';
import { Paginator } from 'primeng/paginator';
import { LazyLoadEvent } from 'primeng/api';
import { FileDownloadService } from '@shared/utils/file-download.service';
import { DateTimeService } from '@app/shared/common/timing/date-time.service';
import { LocalStorageService } from '@shared/utils/local-storage.service';

/***
 * Component to manage the activities summary grid
 */
@Component({
    templateUrl: './activities.component.html',
    encapsulation: ViewEncapsulation.None,
    animations: [appModuleAnimation()],
})
export class ActivitiesComponent extends AppComponentBase implements OnInit {
    @ViewChild('createOrEditActivityModal', { static: true })
    createOrEditActivityModal: CreateOrEditActivityModalComponent;
    @ViewChild('viewActivityModalComponent', { static: true }) viewActivityModal: ViewActivityModalComponent;

    @ViewChild('dataTable', { static: true }) dataTable: Table;
    @ViewChild('paginator', { static: true }) paginator: Paginator;

    advancedFiltersAreShown = false;
    filterText = '';
    opportunityNameFilter = '';
    leadCompanyNameFilter = '';
    userNameFilter = '';
    activitySourceTypeDescriptionFilter = '';
    activityTaskTypeDescriptionFilter = '';
    activityStatusDescriptionFilter = '';
    activityPriorityDescriptionFilter = '';
    customerNameFilter = '';

    selectedAssignedUsersFilter: ActivityUserLookupTableDto[] = [];
    selectedActivitySourceTypesFilter: ActivityActivitySourceTypeLookupTableDto;
    selectedActivityTaskTypesFilter: ActivityActivityTaskTypeLookupTableDto;
    selectedActivityStatusesFilter: ActivityActivityStatusLookupTableDto;
    excludeCompletedFilter = false;

    // Filter data sources
    allUsers: ActivityUserLookupTableDto[];
    activitySourceTypes: ActivityActivitySourceTypeLookupTableDto[];
    activityTaskTypes: ActivityActivityTaskTypeLookupTableDto[];
    activityStatuses: ActivityActivityStatusLookupTableDto[];

    /**
     * Constructor method
     */
    constructor(
        injector: Injector,
        private _activitiesServiceProxy: ActivitiesServiceProxy,
        private _notifyService: NotifyService,
        private _tokenAuth: TokenAuthServiceProxy,
        private _activatedRoute: ActivatedRoute,
        private _fileDownloadService: FileDownloadService,
        private _localStorageService: LocalStorageService,
        private _profileService: ProfileServiceProxy,
        private _dateTimeService: DateTimeService
    ) {
        super(injector);
    }

    /***
     * Initialize component
     */
    ngOnInit(): void {
        this.loadUsers();
        this.loadActivitySourceTypes();
        this.loadActivityTaskTypes();
        this.loadActivityStatuses();
    }

    /**
     * Load the activities from the back-end
     */
    getActivities(event?: LazyLoadEvent) {
        if (this.primengTableHelper.shouldResetPaging(event)) {
            this.paginator.changePage(0);
            return;
        }

        this.primengTableHelper.showLoadingIndicator();

        const selectedUserIds = this.selectedAssignedUsersFilter.map((x) => x.id);
        const dateNow = this._dateTimeService.getDate();

        this._activitiesServiceProxy
            .getAll(
                this.filterText,
                this.opportunityNameFilter,
                this.leadCompanyNameFilter,
                this.userNameFilter,
                this.selectedActivitySourceTypesFilter?.displayName || '',
                this.selectedActivityTaskTypesFilter?.displayName || '',
                this.selectedActivityStatusesFilter?.displayName || '',
                this.activityPriorityDescriptionFilter,
                this.customerNameFilter,
                selectedUserIds,
                this.excludeCompletedFilter,
                this.primengTableHelper.getSorting(this.dataTable),
                this.primengTableHelper.getSkipCount(this.paginator, event),
                this.primengTableHelper.getMaxResultCount(this.paginator, event)
            )
            .subscribe((result) => {
                this.primengTableHelper.totalRecordsCount = result.totalCount;
                this.primengTableHelper.records = result.items.map((x) => ({
                    ...x,
                    isPastDue: dateNow > x.activity.startsAt,
                }));
                this.setUsersProfilePictureUrl(this.primengTableHelper.records);
                this.primengTableHelper.hideLoadingIndicator();
            });
    }

    /**
     * Reload page
     */
    reloadPage(): void {
        this.paginator.changePage(this.paginator.getPage());
    }

    /**
     * Shows the form dialog for creating a new Activity
     */
    createActivity(): void {
        this.createOrEditActivityModal.show();
    }

    /**
     * (Currently Unused) Delete activity.
     */
    deleteActivity(activity: ActivityDto): void {
        this.message.confirm('', this.l('AreYouSure'), (isConfirmed) => {
            if (isConfirmed) {
                this._activitiesServiceProxy.delete(activity.id).subscribe(() => {
                    this.reloadPage();
                    this.notify.success(this.l('SuccessfullyDeleted'));
                });
            }
        });
    }

    /**
     * Export the activities to excel file
     */
    exportToExcel(): void {
        this._activitiesServiceProxy
            .getActivitiesToExcel(
                this.filterText,
                this.opportunityNameFilter,
                this.leadCompanyNameFilter,
                this.userNameFilter,
                this.selectedActivitySourceTypesFilter?.displayName || '',
                this.selectedActivityTaskTypesFilter?.displayName || '',
                this.selectedActivityStatusesFilter?.displayName || '',
                this.activityPriorityDescriptionFilter,
                this.customerNameFilter,
                this.selectedAssignedUsersFilter.map((x) => x.id),
                this.excludeCompletedFilter,
                this.primengTableHelper.getSorting(this.dataTable),
                this.primengTableHelper.getSkipCount(this.paginator, null),
                this.primengTableHelper.getMaxResultCount(this.paginator, null)
            )
            .subscribe((result) => {
                this._fileDownloadService.downloadTempFile(result);
            });
    }

    /**
     * Load the list of users
     */
    loadUsers(): void {
        this._activitiesServiceProxy.getAllUserForTableDropdown().subscribe((result) => {
            this.allUsers = result;
        });
    }

    /**
     * Load the list of activity source types
     */
    loadActivitySourceTypes(): void {
        this._activitiesServiceProxy.getAllActivitySourceTypeForTableDropdown().subscribe((res) => {
            this.activitySourceTypes = res;
        });
    }

    /**
     * Load the list of activity task types
     */
    loadActivityTaskTypes(): void {
        this._activitiesServiceProxy.getAllActivityTaskTypeForTableDropdown().subscribe((res) => {
            this.activityTaskTypes = res;
        });
    }

    /**
     * Load the list of activity status
     */
    loadActivityStatuses(): void {
        this._activitiesServiceProxy.getAllActivityStatusForTableDropdown().subscribe((res) => {
            this.activityStatuses = res;
        });
    }

    /**
     * Load the profile picture of the assinged users
     */
    setUsersProfilePictureUrl(records: any[]): void {
        for (let i = 0; i < records.length; i++) {
            let record = records[i];
            this._localStorageService.getItem(AppConsts.authorization.encrptedAuthTokenName, function (err, value) {
                let profilePictureUrl =
                    AppConsts.remoteServiceBaseUrl +
                    '/Profile/GetProfilePictureByUser?userId=' +
                    record.activity.userId +
                    '&' +
                    AppConsts.authorization.encrptedAuthTokenName +
                    '=' +
                    encodeURIComponent(value.token);
                (record as any).profilePictureUrl = profilePictureUrl;
            });
        }
    }
}