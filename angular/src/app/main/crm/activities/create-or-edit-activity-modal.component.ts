import { Component, ViewChild, Injector, Output, EventEmitter, OnInit } from '@angular/core';
import { ModalDirective } from 'ngx-bootstrap/modal';
import { finalize } from 'rxjs/operators';
import {
    ActivitiesServiceProxy,
    CreateOrEditActivityDto,
    ActivityOpportunityLookupTableDto,
    ActivityLeadLookupTableDto,
    ActivityUserLookupTableDto,
    ActivityActivitySourceTypeLookupTableDto,
    ActivityActivityTaskTypeLookupTableDto,
    ActivityActivityStatusLookupTableDto,
    ActivityActivityPriorityLookupTableDto,
    ActivityCustomerLookupTableDto,
    GetActivityForViewDto,
    ActivityDto,
    GetActivityForEditOutput,
} from '@shared/service-proxies/service-proxies';
import { AppComponentBase } from '@shared/common/app-component-base';
import { DateTime } from 'luxon';
import { DateTimeService } from '@app/shared/common/timing/date-time.service';
import { ActivityDuration, ActivitySourceType, ActivityTaskType } from '@shared/AppEnums';
import { ActivitySharedService } from '@app/shared/common/crm/services/activity-shared.service';
import { forkJoin, Observable } from '@node_modules/rxjs';
import { of } from 'rxjs';

/**
 * Component for creating or updating an activity
 */
@Component({
    selector: 'createOrEditActivityModal',
    templateUrl: './create-or-edit-activity-modal.component.html',
})
export class CreateOrEditActivityModalComponent extends AppComponentBase implements OnInit {
    @ViewChild('createOrEditModal', { static: true }) modal: ModalDirective;

    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    active = false;
    saving = false;
    isEditMode = false;
    readonly = false;
    canAssignOtherUsers = false;

    sourceTypeCode: string;

    activity: CreateOrEditActivityDto = new CreateOrEditActivityDto();

    opportunityCustomerNumber = '';
    selectedDate: Date = new Date();
    selectedTime = '';

    allLeads: ActivityLeadLookupTableDto[];
    allAccounts: ActivityCustomerLookupTableDto[];
    allOpportunities: ActivityOpportunityLookupTableDto[];
    allUsers: ActivityUserLookupTableDto[];
    allActivitySourceTypes: ActivityActivitySourceTypeLookupTableDto[];
    allActivityTaskTypes: ActivityActivityTaskTypeLookupTableDto[];
    allActivityStatuses: ActivityActivityStatusLookupTableDto[];
    allActivityPriorities: ActivityActivityPriorityLookupTableDto[];

    durationItems = [];

    item: GetActivityForViewDto;

    /**
     * Constructor method
     */
    constructor(
        injector: Injector,
        private _activitySharedService: ActivitySharedService,
        private _activitiesServiceProxy: ActivitiesServiceProxy,
        private _dateTimeService: DateTimeService
    ) {
        super(injector);
        this.item = new GetActivityForViewDto();
        this.item.activity = new ActivityDto();
        this.durationItems = this._activitySharedService.getActivityDurationItems();
    }

    /**
     * Show the modal dialog
     */
    showDialog(item: GetActivityForViewDto): void {
        this.item = item;
        this.active = true;
        this.modal.show();
    }

    /**
     * Show the form dialog
     */
    async show(sourceTypeCode: string, activityId?: number, readonly: boolean = false): Promise<void> {
        this.readonly = readonly;
        const isCreate = !activityId;
        this.isEditMode = !isCreate;

        // Common requests
        const requests: Observable<any>[] = [
            this._activitiesServiceProxy.getAllUserForTableDropdown(),
            this._activitiesServiceProxy.getAllActivitySourceTypeForTableDropdown(),
            this._activitiesServiceProxy.getAllActivityTaskTypeForTableDropdown(),
            this._activitiesServiceProxy.getAllActivityStatusForTableDropdown(),
            this._activitiesServiceProxy.getAllActivityPriorityForTableDropdown(),
        ];

        // Preset activity for creation mode
        this.activity = new CreateOrEditActivityDto();
        this.activity.id = activityId;
        this.activity.dueDate = this._dateTimeService.getStartOfDay();
        this.activity.startsAt = this._dateTimeService.getStartOfDay();
        this.activity.durationMinutes = this.durationItems.find((x) => x.enumValue === ActivityDuration.OneHour).value;

        if (!isCreate) {
            // We needed to await this in order to get the source type of the activity we are editing or viewing.
            await this._activitiesServiceProxy
                .getActivityForEdit(activityId)
                .toPromise()
                .then((res) => {
                    if (res && res.activity) {
                        this.activity = res.activity;

                        // Make sure that source type code has value.
                        // This is because we cannot know the source type if coming from the global search.
                        if (!sourceTypeCode) {
                            sourceTypeCode = res.sourceTypeCode;
                        }

                        const { dueDate } = res.activity;
                        this.selectedDate = dueDate.toJSDate();
                        this.selectedTime = dueDate.toFormat('hh:mm a');
                    }
                });
        }

        // Assign the source type code after loading the data in case we are viewing from global search.
        this.sourceTypeCode = sourceTypeCode;

        switch (sourceTypeCode) {
            case ActivitySourceType.LEAD:
                requests.push(this._activitiesServiceProxy.getAllLeadForTableDropdown(isCreate));
                forkJoin([...requests]).subscribe(
                    ([availableUsers, sourceTypes, activityTypes, statuses, priorities, leads]) => {
                        this.populateCommonDataResponse(
                            availableUsers,
                            sourceTypes,
                            activityTypes,
                            statuses,
                            priorities,
                            sourceTypeCode
                        );
                        this.allLeads = isCreate ? leads : leads.filter((x) => x.id === this.activity.leadId);
                        this.showModal();
                    }
                );
                break;
            case ActivitySourceType.ACCOUNT:
                requests.push(this._activitiesServiceProxy.getAllAccountsForTableDropdown(isCreate));
                forkJoin([...requests]).subscribe(
                    ([availableUsers, sourceTypes, activityTypes, statuses, priorities, accounts]) => {
                        this.populateCommonDataResponse(
                            availableUsers,
                            sourceTypes,
                            activityTypes,
                            statuses,
                            priorities,
                            sourceTypeCode
                        );
                        this.allAccounts = isCreate
                            ? accounts
                            : accounts.filter((x) => x.number === this.activity.customerNumber);
                        this.showModal();
                    }
                );
                break;
            case ActivitySourceType.OPPORTUNITY:
                requests.push(this._activitiesServiceProxy.getAllOpportunityForTableDropdown(isCreate));
                requests.push(this._activitiesServiceProxy.getAllAccountRelatedToOpportunityForTableDropdown());
                forkJoin([...requests]).subscribe(
                    ([availableUsers, sourceTypes, activityTypes, statuses, priorities, opportunities, accounts]) => {
                        this.populateCommonDataResponse(
                            availableUsers,
                            sourceTypes,
                            activityTypes,
                            statuses,
                            priorities,
                            sourceTypeCode
                        );
                        this.allOpportunities = isCreate
                            ? opportunities
                            : opportunities.filter((x) => x.id === this.activity.opportunityId);

                        // Assign the customer number based on the Opportunity id
                        this.opportunityCustomerNumber = opportunities.find(
                            (x: ActivityOpportunityLookupTableDto) => x.id == this.activity.opportunityId
                        )?.customerNumber;

                        this.allAccounts = isCreate
                            ? accounts
                            : accounts.filter((x) => x.number === this.opportunityCustomerNumber);
                        this.showModal();
                    }
                );
                break;
        }
    }

    /***
     * Show modal
     * @private
     */
    private showModal() {
        this.active = true;
        this.modal.show();
    }

    /***
     * Handle the common response when load the page
     * @param availableUsers
     * @param sourceTypes
     * @param activityTypes
     * @param statuses
     * @param priorities
     * @param sourceTypeCode
     * @private
     */
    private populateCommonDataResponse(
        availableUsers: ActivityUserLookupTableDto[],
        sourceTypes: ActivityActivitySourceTypeLookupTableDto[],
        activityTypes: ActivityActivityTaskTypeLookupTableDto[],
        statuses: ActivityActivityStatusLookupTableDto[],
        priorities: ActivityActivityPriorityLookupTableDto[],
        sourceTypeCode: string
    ) {
        this.allUsers = availableUsers;
        this.allActivitySourceTypes = sourceTypes;
        this.allActivityTaskTypes = activityTypes;
        this.allActivityStatuses = statuses;
        this.allActivityPriorities = priorities;

        if (!this.isEditMode) {
            this.activity.userId = !this.canAssignOtherUsers ? availableUsers[0].id : null;
            this.activity.activitySourceTypeId = sourceTypes.length > 0 ? sourceTypes.find((x) => x.code === sourceTypeCode)?.id : null;
            this.activity.activityTaskTypeId = activityTypes.length > 0 ? activityTypes.find((x) => x.isDefault)?.id || activityTypes[0].id : null;
            this.activity.activityStatusId = statuses.length > 0 ? statuses.find((x) => x.isDefault)?.id || statuses[0].id : null;
            this.activity.activityPriorityId = priorities.length > 0 ? priorities.find((x) => x.isDefault)?.id || priorities[0].id : null;   
        }
    }

    /***
     * Transform data before sent to the backend
     */
    processDataModel(): void {
        const selectedActivityType = this.allActivityTaskTypes.find((x) => x.id === this.activity.activityTaskTypeId);
        this.activity.taskName = selectedActivityType.displayName;
        this.activity.dueDate = DateTime.fromJSDate(this.selectedDate);

        if (!this.isReminder) {
            const time = DateTime.fromFormat(this.selectedTime, 'hh:mm a');

            this.activity.dueDate = this.activity.dueDate.set({
                hour: time.hour,
                minute: time.minute,
            });
        }

        this.activity.startsAt = this.activity.dueDate;
    }

    /**
     * Save changes
     */
    save(): void {
        this.processDataModel();
        this._activitiesServiceProxy
            .createOrEdit(this.activity)
            .pipe(
                finalize(() => {
                    this.saving = false;
                })
            )
            .subscribe(() => {
                this.notify.info(this.l('SavedSuccessfully'));
                this.close();
                this.modalSave.emit(null);
            });
    }

    /**
     * Close the form dialog
     */
    close(): void {
        this.active = false;
        this.allAccounts = [];
        this.modal.hide();
    }

    /**
     * Initialize Component
     */
    ngOnInit(): void {
        this.canAssignOtherUsers = this.isGranted('Pages.Activities.Create.Assign_Other_Users__Dynamic');
    }

    /**
     * Returns the filtered opportunities based on the selected company
     */
    get getFilteredOpportunities(): ActivityOpportunityLookupTableDto[] {
        if (!this.opportunityCustomerNumber) {
            return [];
        }
        return this.allOpportunities.filter((x) => x.customerNumber === this.opportunityCustomerNumber);
    }

    /**
     * Get ActivitySourceType enum for accessing in the component's html file
     */
    get getActivitySourceType(): typeof ActivitySourceType {
        return ActivitySourceType;
    }

    /**
     * Returns whether the activity is a reminder type
     */
    get isReminder(): boolean {
        const id = this.activity.activityTaskTypeId;

        if (!id || !this.allActivityTaskTypes || this.allActivityTaskTypes.length === 0) {
            return false;
        }

        let code = <ActivityTaskType>this.allActivityTaskTypes.find((x) => x.id === id).code;
        return code === ActivityTaskType.EMAIL_REMINDER || code === ActivityTaskType.TODO_REMINDER;
    }

    /**
     * Returns the form title text based on the Activity source type
     */
    get formTitle(): string {
        switch (this.sourceTypeCode) {
            case ActivitySourceType.LEAD:
                return this.l('CreateNewActivityByLead');
            case ActivitySourceType.ACCOUNT:
                return this.l('CreateNewActivityByAccount');
            case ActivitySourceType.OPPORTUNITY:
                return this.l('CreateNewActivityByOpportunity');
            default:
                return this.l('CreateNewActivity');
        }
    }
}
