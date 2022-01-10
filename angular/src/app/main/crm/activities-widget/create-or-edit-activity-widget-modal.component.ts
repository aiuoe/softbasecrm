import { Component, Injector, Input, OnInit, Output, ViewChild, EventEmitter } from '@angular/core';
import { ActivitySharedService } from '@app/shared/common/crm/services/activity-shared.service';
import { ActivitySourceType, ActivityTaskType } from '@shared/AppEnums';
import { AppComponentBase } from '@shared/common/app-component-base';
import {
    AccountActivitiesServiceProxy,
    ActivityActivityPriorityLookupTableDto,
    ActivityActivitySourceTypeLookupTableDto,
    ActivityActivityStatusLookupTableDto,
    ActivityActivityTaskTypeLookupTableDto,
    ActivityLeadLookupTableDto,
    ActivityOpportunityLookupTableDto,
    ActivityUserLookupTableDto,
    CreateOrEditActivityDto,
    LeadActivitiesServiceProxy,
    OpportunityActivitiesServiceProxy
} from '@shared/service-proxies/service-proxies';
import { DateTime } from 'luxon';
import { ModalDirective } from 'ngx-bootstrap/modal';
import { finalize } from 'rxjs/operators';


/**
 * This component manages the activities creation on Leads, Accounts and Opportunities
 */
@Component({
    selector: 'app-create-or-edit-activity-widget-modal',
    templateUrl: './create-or-edit-activity-widget-modal.component.html'
})
export class CreateOrEditActivityWidgetModalComponent extends AppComponentBase implements OnInit {
    @ViewChild('createActivityModal', { static: true }) modal: ModalDirective;

    @Input() activityType = '';
    @Input() componentType = '';
    @Input() idToStore: any;
    @Input() canAssignAnyUser = false;
    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    activity: CreateOrEditActivityDto = new CreateOrEditActivityDto();

    opportunityName = '';
    leadCompanyName = '';
    userName = '';
    activitySourceTypeDescription = '';
    activityTaskTypeDescription = '';
    activityStatusDescription = '';
    activityPriorityDescription = '';

    allOpportunitys: ActivityOpportunityLookupTableDto[];
    allLeads: ActivityLeadLookupTableDto[];
    allUsers: ActivityUserLookupTableDto[];
    allActivitySourceTypes: ActivityActivitySourceTypeLookupTableDto[];
    allActivityTaskTypes: ActivityActivityTaskTypeLookupTableDto[];
    allActivityStatuss: ActivityActivityStatusLookupTableDto[];
    allActivityPrioritys: ActivityActivityPriorityLookupTableDto[];

    selectedDate: Date = new Date();
    selectedTime = '';
    durationItems = [];

    activityTypeEnum: typeof ActivityTaskType = ActivityTaskType;


    active = false;
    saving = false;

    isView = false;

    activityTypeCode = '';


    /**
     * Constructor
     * @param injector
     * @param _activitiesServiceProxy
     */
    constructor(injector: Injector,
                private _activitySharedService: ActivitySharedService,
                private _accountActivitiesServiceProxy: AccountActivitiesServiceProxy,
                private _leadActivitiesServiceProxy: LeadActivitiesServiceProxy,
                private _opportunityActivitiesServiceProxy: OpportunityActivitiesServiceProxy) {
        super(injector);
    }


    /***
     * NgOninit Event
     */
    ngOnInit(): void {
        this.callData();
    }

    /**
     * Close the modal
     */
    close() {
        this.active = false;
        this.activity = new CreateOrEditActivityDto();
        this.selectedDate = new Date();
        this.selectedTime = '';
        this.activityTypeCode = '';
        this.activityType = '';
        this.isView = false;
        this.modal.hide();
    }

    /**
     * Opens the modal for new Activities
     * @param activityType
     */
    show(activityTypeCode?: string) {
        this.activityTypeCode = activityTypeCode;
        this.activityType = this.allActivityTaskTypes.find(p => p.code == activityTypeCode).displayName;

        // Preset activity for creation mode
        this.activity = new CreateOrEditActivityDto();
        this.activity.durationMinutes = this._activitySharedService.getDefaultDuration(this.activityTypeCode);
        this.activity.activityPriorityId = this.allActivityPrioritys.find(x => x.isDefault).id;
        this.activity.activityStatusId = this.allActivityStatuss.find(x => x.isDefault).id;

        this.active = true;
        //Showing the modal
        this.modal.show();
    }

    /**
     *
     * @param activityId
     */
    showForViewEdit(activityId: number, isView: boolean) {
        switch (this.componentType) {
            case 'Lead':
                this.getLeadActivityForViewEdit(activityId);
                break;

            case 'Account':
                this.getAccountActivityForViewEdit(activityId);
                break;

            case 'Opportunity':
                this.getOpportunityActivityForViewEdit(activityId);
                break;
        }

        this.isView = isView;
        this.active = true;
        this.modal.show();
    }


    /**
     * Gets an activity given its id (Only for Leads module)
     * @param activityId
     */
    getLeadActivityForViewEdit(activityId: number) {
        this._leadActivitiesServiceProxy.getActivityForEdit(activityId).subscribe(result => {
            this.activity = result.activity;
            this.activityType = result.activityTaskTypeDescription;
            this.activityTypeCode = this.allActivityTaskTypes.find(p => p.id == result.activity.activityTaskTypeId).code;
            const { dueDate } = result.activity;
            this.selectedDate = dueDate.toJSDate();
            this.selectedTime = dueDate.toFormat('hh:mm a');
        });
    }

    /**
     * Gets an activity given its id (Only for Accounts module)
     * @param activityId
     */
    getAccountActivityForViewEdit(activityId: number) {
        this._accountActivitiesServiceProxy.getActivityForEdit(activityId).subscribe(result => {
            this.activity = result.activity;
            this.activityType = result.activityTaskTypeDescription;
            this.activityTypeCode = this.allActivityTaskTypes.find(p => p.id == result.activity.activityTaskTypeId).code;
            const { dueDate } = result.activity;
            this.selectedDate = dueDate.toJSDate();
            this.selectedTime = dueDate.toFormat('hh:mm a');
        });
    }

    /**
     * Gets an activity given its id (Only for Opportunity module)
     * @param activityId
     */
    getOpportunityActivityForViewEdit(activityId: number) {
        this._opportunityActivitiesServiceProxy.getActivityForEdit(activityId).subscribe(result => {
            this.activity = result.activity;
            this.activityType = result.activityTaskTypeDescription;
            this.activityTypeCode = this.allActivityTaskTypes.find(p => p.id == result.activity.activityTaskTypeId).code;
            const { dueDate } = result.activity;
            this.selectedDate = dueDate.toJSDate();
            this.selectedTime = dueDate.toFormat('hh:mm a');
        });
    }

    /**
     * Handles the saving action of an activity
     */
    save() {
        this.activity.activityTaskTypeId = this.allActivityTaskTypes.find(p => p.code == this.activityTypeCode).id;
        this.activity.taskName = this.activityType;

        switch (this.componentType) {
            case 'Lead':
                this.activity.leadId = this.idToStore;
                this.activity.activitySourceTypeId = this.allActivitySourceTypes.find(x => x.code == ActivitySourceType.LEAD).id;
                this.saveLeadActivity();
                break;

            case 'Account':
                this.activity.customerNumber = this.idToStore;
                this.activity.activitySourceTypeId = this.allActivitySourceTypes.find(x => x.code == ActivitySourceType.ACCOUNT).id;
                this.saveAccountActivity();
                break;

            case 'Opportunity':
                this.activity.opportunityId = this.idToStore;
                this.activity.activitySourceTypeId = this.allActivitySourceTypes.find(x => x.code == ActivitySourceType.OPPORTUNITY).id;
                this.saveOpportunityActivity();
                break;
        }
    }

    /**
     * Saves an activity related to an Account
     */
    saveAccountActivity() {
        this.processDataModel();
        this._accountActivitiesServiceProxy
            .createOrEdit(this.activity)
            .pipe(
                finalize(() => {
                    this.saving = false;
                })
            )
            .subscribe(() => {
                this.notifyService.info(this.l('SavedSuccessfully'));
                this.close();
                this.modalSave.emit(null);
            });
    }

    /**
     * Saves an activity related to an Opportunity
     */
    saveOpportunityActivity() {
        this.processDataModel();
        this._opportunityActivitiesServiceProxy
            .createOrEdit(this.activity)
            .pipe(
                finalize(() => {
                    this.saving = false;
                })
            )
            .subscribe(() => {
                this.notifyService.info(this.l('SavedSuccessfully'));
                this.close();
                this.modalSave.emit(null);
            });
    }


    /**
     * Saves an activity related to a Lead
     */
    saveLeadActivity() {
        this.processDataModel();
        this._leadActivitiesServiceProxy
            .createOrEdit(this.activity)
            .pipe(
                finalize(() => {
                    this.saving = false;
                })
            )
            .subscribe(() => {
                this.notifyService.info(this.l('SavedSuccessfully'));
                this.close();
                this.modalSave.emit(null);
            });
    }


    /**
     * Transform data before sent to the backend
     */
    processDataModel() {
        const selectedActivityType = this.allActivityTaskTypes.find((x) => x.id === this.activity.activityTaskTypeId);

        this.activity.taskName = selectedActivityType.displayName;

        this.activity.dueDate = DateTime.fromJSDate(this.selectedDate);

        if (this.activityTypeCode != ActivityTaskType.TODO_REMINDER && this.activityTypeCode != ActivityTaskType.EMAIL_REMINDER) {
            const time = DateTime.fromFormat(this.selectedTime, 'hh:mm a');

            this.activity.dueDate = this.activity.dueDate.set({
                hour: time.hour,
                minute: time.minute,
            });
        }

        this.activity.startsAt = this.activity.dueDate;
    }

    /**
     * Calls the data requiered to populate dropdowns
     */
    callData() {
        this.durationItems = this._activitySharedService.getActivityDurationItems();

        switch (this.componentType) {
            case 'Lead':
                this.callDataForLeadsModule();
                break;

            case 'Account':
                this.callDataForAccountsModule();
                break;

            case 'Opportunity':
                this.callDataForOpportunitiesModule();
                break;
        }
    }

    /**
     * Calls the data required to populate dropdowns (Only for Leads module)
     */
    callDataForLeadsModule() {
        this._leadActivitiesServiceProxy.getAllUserForTableDropdown().subscribe((result) => {
            this.allUsers = this.processUsersForTableDropdown(result);
        });
        this._leadActivitiesServiceProxy.getAllActivitySourceTypeForTableDropdown().subscribe((result) => {
            this.allActivitySourceTypes = result;
        });
        this._leadActivitiesServiceProxy.getAllActivityTaskTypeForTableDropdown().subscribe((result) => {
            this.allActivityTaskTypes = result;
        });
        this._leadActivitiesServiceProxy.getAllActivityStatusForTableDropdown().subscribe((result) => {
            this.allActivityStatuss = result;
        });
        this._leadActivitiesServiceProxy.getAllActivityPriorityForTableDropdown().subscribe((result) => {
            this.allActivityPrioritys = result;
        });
    }


    /**
     * Calls the data required to populate dropdowns (Only for Accounts module)
     */
    callDataForAccountsModule() {
        this._accountActivitiesServiceProxy.getAllUserForTableDropdown().subscribe((result) => {
            this.allUsers = this.processUsersForTableDropdown(result);
        });
        this._accountActivitiesServiceProxy.getAllActivitySourceTypeForTableDropdown().subscribe((result) => {
            this.allActivitySourceTypes = result;
        });
        this._accountActivitiesServiceProxy.getAllActivityTaskTypeForTableDropdown().subscribe((result) => {
            this.allActivityTaskTypes = result;
        });
        this._accountActivitiesServiceProxy.getAllActivityStatusForTableDropdown().subscribe((result) => {
            this.allActivityStatuss = result;
        });
        this._accountActivitiesServiceProxy.getAllActivityPriorityForTableDropdown().subscribe((result) => {
            this.allActivityPrioritys = result;
        });
    }

    /**
     * Calls the data required to populate dropdowns (Only for Opportunities module)
     */
    callDataForOpportunitiesModule() {
        this._opportunityActivitiesServiceProxy.getAllUserForTableDropdown().subscribe((result) => {
            this.allUsers = this.processUsersForTableDropdown(result);
        });
        this._opportunityActivitiesServiceProxy.getAllActivitySourceTypeForTableDropdown().subscribe((result) => {
            this.allActivitySourceTypes = result;
        });
        this._opportunityActivitiesServiceProxy.getAllActivityTaskTypeForTableDropdown().subscribe((result) => {
            this.allActivityTaskTypes = result;
        });
        this._opportunityActivitiesServiceProxy.getAllActivityStatusForTableDropdown().subscribe((result) => {
            this.allActivityStatuss = result;
        });
        this._opportunityActivitiesServiceProxy.getAllActivityPriorityForTableDropdown().subscribe((result) => {
            this.allActivityPrioritys = result;
        });
    }

    /**
     * Remove other users in the list if the current user is not allowed to assign others.
     * @param users The list of users that needs to be filtered.
     * @returns List of users
     */
    processUsersForTableDropdown(users: ActivityUserLookupTableDto[]): ActivityUserLookupTableDto[] {
        if (!users || users.length === 0) {
            return [];
        }
        return this.canAssignAnyUser ? users : users.filter((x) => x.id == this.appSession.userId);
    }

    /**
     * Get ActivityTaskType enum for html access
     */
    get getActivityTaskType(): typeof ActivityTaskType {
        return ActivityTaskType;
    }

}
