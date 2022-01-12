import { AppConsts } from '@shared/AppConsts';
import { Component, Injector, ViewEncapsulation, ViewChild, OnInit, forwardRef } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Calendar } from '@fullcalendar/core';
import dayGridPlugin from '@fullcalendar/daygrid';
import interactionPlugin from '@fullcalendar/interaction';
import { FullCalendarComponent } from '@fullcalendar/angular';
import {
    ActivitiesServiceProxy,
    ActivityActivitySourceTypeLookupTableDto,
    ActivityActivityStatusLookupTableDto,
    ActivityActivityTaskTypeLookupTableDto,
    ActivityDto,
    ActivityUserLookupTableDto,
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
import { debounce } from 'lodash-es';
import { MomentFormatPipe } from '@shared/utils/moment-format.pipe';
import { ActivitySharedService } from '@app/shared/common/crm/services/activity-shared.service';

/***
 * Component to manage the activities summary grid
 */
@Component({
    templateUrl: './activities.component.html',
    encapsulation: ViewEncapsulation.None,
    animations: [appModuleAnimation()],
    styleUrls: ['./activities.component.scss']
})
export class ActivitiesComponent extends AppComponentBase implements OnInit {
    @ViewChild('viewActivityModalComponent', { static: true }) viewActivityModal: ViewActivityModalComponent;
    @ViewChild('createOrEditActivityModal', { static: true })
    createOrEditActivityModal: CreateOrEditActivityModalComponent;

    @ViewChild('dataTable', { static: true }) dataTable: Table;
    @ViewChild('paginator', { static: true }) paginator: Paginator;
    @ViewChild('fullcalendar') fullcalendar: FullCalendarComponent;

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

    summaryTableIsShown = true;
    summaryCalendarIsShown = false;

    selectedAssignedUsersFilter: ActivityUserLookupTableDto[] = [];
    selectedActivitySourceTypesFilter: ActivityActivitySourceTypeLookupTableDto;
    selectedActivityTaskTypesFilter: ActivityActivityTaskTypeLookupTableDto;
    selectedActivityStatusesFilter: ActivityActivityStatusLookupTableDto;
    excludeCompletedFilter = false;

    // Filter data sources
    allUsers: ActivityUserLookupTableDto[];
    activitySourceTypes: ActivityActivitySourceTypeLookupTableDto[];
    activityTaskTypes: ActivityActivityTaskTypeLookupTableDto[];
    activityTaskTypesForCalendar: ActivityActivityTaskTypeLookupTableDto[];
    activityStatuses: ActivityActivityStatusLookupTableDto[];
    activitySourceTypeFilters: ActivityActivitySourceTypeLookupTableDto[];

    /**
     * Used to delay the search and wait for the user to finish typing.
     */
    delaySearchActivity = debounce(this.getActivities, AppConsts.SearchBarDelayMilliseconds);

    /**
     * Constructor method
     */
    constructor(
        injector: Injector,
        private _activitiesServiceProxy: ActivitiesServiceProxy,
        private _activitySharedService: ActivitySharedService,
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

    calendarOptions: any;

    /***
     * Initialize component
     */
    ngOnInit(): void {
        this.loadUsers();
        this.loadActivitySourceTypes();
        this.loadActivityTaskTypes();
        this.loadActivityStatuses();

        const routeParams = this._activatedRoute.snapshot.queryParamMap;
        if (routeParams.has('view')) {
            const activityId = Number(routeParams.get('view'));
            if (!isNaN(activityId)) {
                this.createOrEditActivityModal.show('', activityId, true);
            }
        }

        forwardRef(() => Calendar);

        this.calendarOptions = {
            initialView: 'dayGridMonth',
            plugins: [dayGridPlugin, interactionPlugin],
            editable: false,
            headerToolbar: {
                left: 'prev,next,today',
                center: 'title',
                right: 'dayGridMonth,dayGridWeek'
            },
            buttonText: {
                today: 'Today',
                month: 'Month',
                week: 'Week',
            },
            eventClick: this.handleDateClick.bind(this)
        };
    }

    /**
     * Method for rendering calendar
     */
    initializeCalendar() {
        this.fullcalendar.getApi().render();
        setTimeout(() => this.fullcalendar.getApi().render());
    }

    /**
     * Method for handle click events on an event
     */
    handleDateClick(event) {
        this.createOrEditActivityModal.show(this.primengTableHelper.records[parseInt(event.event.id)].sourceTypeCode,
            this.primengTableHelper.records[parseInt(event.event.id)].activity.id,
            true);
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

        // Check if the 'None' option is selected in the 'Assigned Users' filter
        const isUnassignedSelected = this.selectedAssignedUsersFilter.some((x) => x.id == AppConsts.activityModule.noAssignedUserFilterId);
        const selectedUserIds = this.selectedAssignedUsersFilter.map((x) => x.id);
        const dateNow = this._dateTimeService.getDate();

        this._activitiesServiceProxy
            .getAll(
                this.filterText,
                this.opportunityNameFilter,
                this.leadCompanyNameFilter,
                this.userNameFilter,
                this.customerNameFilter,
                selectedUserIds,
                this.excludeCompletedFilter,
                this.selectedActivitySourceTypesFilter?.id,
                this.selectedActivityTaskTypesFilter?.id,
                this.selectedActivityStatusesFilter?.id,
                isUnassignedSelected,
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
                this.fullcalendar.getApi().removeAllEvents();
                let momentPipe = new MomentFormatPipe(window.navigator.language);
                result.items.forEach((result, i) => {
                    const eventObject = {
                        title: result.activity.userId? result.userName : this.l('NotAssigned'),
                        allDay: true,
                        start: momentPipe.transform(result.activity.startsAt),
                        // end: result.activity.dueDate.toString(),
                        color: result.activityTaskTypeColor ?? '#263950',
                        id: i.toString()
                    };
                    this.fullcalendar.getApi().addEvent(eventObject);
                });
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
     * Shows the form dialog for creating or updating an Activity
     */
    createActivity(sourceTypeCode: string): void {
        this.createOrEditActivityModal.show(sourceTypeCode);
    }

    /**
     * (Currently Unused) Delete activity.
     */
    deleteActivity(activity: ActivityDto): void {
        this.message.confirm('', this.l('AreYouSure'), (isConfirmed) => {
            if (isConfirmed) {
                this._activitiesServiceProxy.delete(activity.id).subscribe(() => {
                    this.reloadPage();
                    this.notifyService.success(this.l('SuccessfullyDeleted'));
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
                this.customerNameFilter,
                this.selectedAssignedUsersFilter.map((x) => x.id),
                this.excludeCompletedFilter,
                this.selectedActivitySourceTypesFilter?.id,
                this.selectedActivityTaskTypesFilter?.id,
                this.selectedActivityStatusesFilter?.id,
                this.selectedAssignedUsersFilter.some((x) => x.id == AppConsts.activityModule.noAssignedUserFilterId),
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
            const noneOption = new ActivityUserLookupTableDto();
            noneOption.init({ displayName: this.l('None'), id: AppConsts.activityModule.noAssignedUserFilterId });
            this.allUsers.unshift(noneOption);
        });
    }

    /**
     * Load the list of activity source types
     */
    loadActivitySourceTypes(): void {
        this._activitiesServiceProxy.getAllActivitySourceTypeForTableDropdown().subscribe((res) => {
            this.activitySourceTypes = res;

            this.activitySourceTypeFilters = Array.from(res);
            const allOption = new ActivityActivitySourceTypeLookupTableDto();
            allOption.displayName = AppConsts.All;
            this.activitySourceTypeFilters.unshift(allOption);
        });
    }

    /**
     * Load the list of activity task types
     */
    loadActivityTaskTypes(): void {
        this._activitiesServiceProxy.getAllActivityTaskTypeForTableDropdown().subscribe((res) => {
            this.activityTaskTypes = res;
            this.activityTaskTypesForCalendar = [...res];
            const allOption = new ActivityActivityTaskTypeLookupTableDto();
            allOption.displayName = AppConsts.All;
            this.activityTaskTypes.unshift(allOption);
        });
    }

    /**
     * Load the list of activity status
     */
    loadActivityStatuses(): void {
        this._activitiesServiceProxy.getAllActivityStatusForTableDropdown().subscribe((res) => {
            this.activityStatuses = res;
            const allOption = new ActivityActivityStatusLookupTableDto();
            allOption.displayName = AppConsts.All;
            this.activityStatuses.unshift(allOption);
        });
    }

    /**
     * Load the profile picture of the assinged users
     */
    setUsersProfilePictureUrl(records: any[]): void {
        for (let i = 0; i < records.length; i++) {
            let record = records[i];

            if (!record.activity.userId) {
                continue;
            }

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

    /***
     * Handle See as List
     */
    doSeeAsListView() {
        this.summaryTableIsShown = true;
        this.summaryCalendarIsShown = false;
    }

    /***
     * Handle See as List
     */
    doSeeAsCalendarView() {
        this.summaryTableIsShown = false;
        this.summaryCalendarIsShown = true;
        this.initializeCalendar();
    }

    /**
     * Check whether an activity is a Reminder-Type or not.
     * @param item the ActivityDto item
     * @returns True if the ActivityDto item is a Reminder-Type, otherwise False.
     */
     isReminderTypeActivity(item: ActivityDto): boolean {
        return this._activitySharedService.isReminderTypeActivity(this.activityTaskTypes, item);
    }
}
