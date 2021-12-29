import { Component, ViewChild, Injector, Output, EventEmitter, OnInit, ElementRef, Input } from '@angular/core';
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
} from '@shared/service-proxies/service-proxies';
import { AppComponentBase } from '@shared/common/app-component-base';
import { DateTime } from 'luxon';

import { DateTimeService } from '@app/shared/common/timing/date-time.service';
import { ActivityDuration, ActivitySourceType, ActivityTaskType, getActivityDurationIitems } from '@shared/AppEnums';

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

    sourceType: ActivitySourceType;

    activity: CreateOrEditActivityDto = new CreateOrEditActivityDto();

    opportunityCustomerNumber: string = '';
    selectedDate: string = '';
    selectedTime: string = '';

    allLeads: ActivityLeadLookupTableDto[];
    allAccounts: ActivityCustomerLookupTableDto[];
    allOpportunities: ActivityOpportunityLookupTableDto[];
    allUsers: ActivityUserLookupTableDto[];
    allActivitySourceTypes: ActivityActivitySourceTypeLookupTableDto[];
    allActivityTaskTypes: ActivityActivityTaskTypeLookupTableDto[];
    allActivityStatuses: ActivityActivityStatusLookupTableDto[];
    allActivityPriorities: ActivityActivityPriorityLookupTableDto[];

    durationItems = [];

    /**
     * Constructor method
     */
    constructor(
        injector: Injector,
        private _activitiesServiceProxy: ActivitiesServiceProxy,
        private _dateTimeService: DateTimeService
    ) {
        super(injector);
    }

    /**
     * Show the form dialog
     */
    show(sourceType: ActivitySourceType, activityId?: number): void {
        this.sourceType = sourceType;

        const isCreate = !activityId;

        if (isCreate) {
            this.activity = new CreateOrEditActivityDto();
            this.activity.id = activityId;
            this.activity.dueDate = this._dateTimeService.getStartOfDay();
            this.activity.startsAt = this._dateTimeService.getStartOfDay();
            this.activity.durationMinutes = getActivityDurationIitems().find(
                (x) => x.enumValue === ActivityDuration.OneHour
            ).value;

            this.active = true;
            this.modal.show();
        } else {
            this._activitiesServiceProxy.getActivityForEdit(activityId).subscribe((result) => {
                this.activity = result.activity;

                this.active = true;
                this.modal.show();
            });
        }

        switch (sourceType) {
            case ActivitySourceType.Lead:
                this._activitiesServiceProxy.getAllLeadForTableDropdown().subscribe((result) => {
                    this.allLeads = result;
                });
                break;
            case ActivitySourceType.Account:
                this._activitiesServiceProxy.getAllAccountsForTableDropdown().subscribe((result) => {
                    this.allAccounts = result;
                });
                break;
            case ActivitySourceType.Opportunity:
                this._activitiesServiceProxy.getAllOpportunityForTableDropdown().subscribe((result) => {
                    this.allOpportunities = result;
                });

                this._activitiesServiceProxy.getAllAccountRelatedToOpportunityForTableDropdown().subscribe((result) => {
                    this.allAccounts = result;
                });
                break;
        }

        this._activitiesServiceProxy.getAllUserForTableDropdown().subscribe((result) => {
            this.allUsers = result;
            if (result.length === 1) {
                this.activity.userId = result[0].id;
            }
        });

        this._activitiesServiceProxy.getAllActivitySourceTypeForTableDropdown().subscribe((result) => {
            this.allActivitySourceTypes = result;
            if (isCreate && result.length > 0) {
                this.activity.activitySourceTypeId = result.find((x) => x.enumValue === this.sourceType)?.id;
            }
        });

        this._activitiesServiceProxy.getAllActivityTaskTypeForTableDropdown().subscribe((result) => {
            this.allActivityTaskTypes = result;
            if (isCreate && result.length > 0) {
                this.activity.activityTaskTypeId = result.find((x) => x.isDefault)?.id || result[0].id;
            }
        });

        this._activitiesServiceProxy.getAllActivityStatusForTableDropdown().subscribe((result) => {
            this.allActivityStatuses = result;
            if (isCreate && result.length > 0) {
                this.activity.activityStatusId = result.find((x) => x.isDefault)?.id || result[0].id;
            }
        });

        this._activitiesServiceProxy.getAllActivityPriorityForTableDropdown().subscribe((result) => {
            this.allActivityPriorities = result;
            if (isCreate && result.length > 0) {
                this.activity.activityPriorityId = result.find((x) => x.isDefault)?.id || result[0].id;
            }
        });
    }

    processDataModel(): void {
        const selectedActivityType = this.allActivityTaskTypes.find((x) => x.id === this.activity.activityTaskTypeId);
        console.log(selectedActivityType);

        this.activity.taskName = selectedActivityType.displayName;

        const time = DateTime.fromFormat(this.selectedTime, 'hh:mm a');

        this.activity.dueDate = DateTime.fromISO(this.selectedDate).set({
            hour: time.hour,
            minute: time.minute,
        });

        this.activity.startsAt = this.activity.dueDate;
    }

    /**
     * Save changes
     */
    save(): void {
        // this.saving = true;

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
        this.modal.hide();
    }

    /**
     * Initialize Component
     */
    ngOnInit(): void {
        this.durationItems = getActivityDurationIitems();
    }

    /**
     * Returns the filtered opportunities based on the selected company
     */
    get getFilteredOpportunities(): ActivityOpportunityLookupTableDto[] {
        if (!this.opportunityCustomerNumber) return [];

        return this.allOpportunities.filter((x) => x.customerNumber == this.opportunityCustomerNumber);
    }

    /**
     * Get ActivitySourceType enum for accessing in the component's html file
     */
    get getActivitySourceTypeEnum(): typeof ActivitySourceType {
        return ActivitySourceType;
    }

    /**
     * Returns whether the activity is a reminder type
     */
    get isReminder(): boolean {
        const id = this.activity.activityTaskTypeId;

        if (!id) {
            return false;
        }

        let value = <ActivityTaskType>this.allActivityTaskTypes.find((x) => x.id == id).enumValue;
        return value === ActivityTaskType.EmailReminder || value === ActivityTaskType.ToDoReminder;
    }

    /**
     * Returns the form title text based on the Activity source type
     */
    get formTitle(): string {
        switch (this.sourceType) {
            case ActivitySourceType.Lead:
                return this.l('CreateNewActivityByLead');
            case ActivitySourceType.Account:
                return this.l('CreateNewActivityByAccount');
            case ActivitySourceType.Opportunity:
                return this.l('CreateNewActivityByOpportunity');
            default:
                return this.l('CreateNewActivity');
        }
    }
}
