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
} from '@shared/service-proxies/service-proxies';
import { AppComponentBase } from '@shared/common/app-component-base';
import { DateTime } from 'luxon';

import { DateTimeService } from '@app/shared/common/timing/date-time.service';
import { ActivityDuration, ActivitySourceType, getActivityDurationIitems } from '@shared/AppEnums';

/**
 * Component for creating or updating an activity
 */
@Component({
    selector: 'createOrEditActivityModal',
    templateUrl: './create-or-edit-activity-modal.component.html',
})
export class CreateOrEditActivityModalComponent extends AppComponentBase implements OnInit {
    @ViewChild('createOrEditModal', { static: true }) modal: ModalDirective;

    @Input() sourceType: ActivitySourceType;
    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    active = false;
    saving = false;

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
    show(activityId?: number): void {
        const isCreate = !activityId;
        if (isCreate) {
            this.activity = new CreateOrEditActivityDto();
            this.activity.id = activityId;
            this.activity.dueDate = this._dateTimeService.getStartOfDay();
            this.activity.startsAt = this._dateTimeService.getStartOfDay();
            this.activity.durationMinutes = getActivityDurationIitems().find(
                (x) => x.enumValue === ActivityDuration.OneHour
            ).value;
            this.opportunityName = '';
            this.leadCompanyName = '';
            this.userName = '';
            this.activitySourceTypeDescription = '';
            this.activityTaskTypeDescription = '';
            this.activityStatusDescription = '';
            this.activityPriorityDescription = '';

            this.active = true;
            this.modal.show();
        } else {
            this._activitiesServiceProxy.getActivityForEdit(activityId).subscribe((result) => {
                this.activity = result.activity;

                this.opportunityName = result.opportunityName;
                this.leadCompanyName = result.leadCompanyName;
                this.userName = result.userName;
                this.activitySourceTypeDescription = result.activitySourceTypeDescription;
                this.activityTaskTypeDescription = result.activityTaskTypeDescription;
                this.activityStatusDescription = result.activityStatusDescription;
                this.activityPriorityDescription = result.activityPriorityDescription;

                this.active = true;
                this.modal.show();
            });
        }
        this._activitiesServiceProxy.getAllOpportunityForTableDropdown().subscribe((result) => {
            this.allOpportunitys = result;
        });
        this._activitiesServiceProxy.getAllLeadForTableDropdown().subscribe((result) => {
            this.allLeads = result;
        });
        this._activitiesServiceProxy.getAllUserForTableDropdown().subscribe((result) => {
            this.allUsers = result;
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
            this.allActivityStatuss = result;
            if (isCreate && result.length > 0) {
                this.activity.activityStatusId = result.find((x) => x.isDefault)?.id || result[0].id;
            }
        });
        this._activitiesServiceProxy.getAllActivityPriorityForTableDropdown().subscribe((result) => {
            this.allActivityPrioritys = result;
            if (isCreate && result.length > 0) {
                this.activity.activityPriorityId = result.find((x) => x.isDefault)?.id || result[0].id;
            }
        });
    }

    /**
     * Save changes
     */
    save(): void {
        this.saving = true;

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

    ngOnInit(): void {
        this.durationItems = getActivityDurationIitems();
    }

    get activitySourceTypeEnum(): typeof ActivitySourceType {
        return ActivitySourceType;
    }

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
