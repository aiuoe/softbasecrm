import { Component, Injector, Input, OnInit, Output, ViewChild, EventEmitter } from '@angular/core';
import { ActivitySharedService } from '@app/shared/common/crm/services/activity-shared.service';
import { ActivitySourceType } from '@shared/AppEnums';
import { AppComponentBase } from '@shared/common/app-component-base';
import { AccountActivitiesServiceProxy, ActivitiesServiceProxy, ActivityActivityPriorityLookupTableDto, ActivityActivitySourceTypeLookupTableDto, ActivityActivityStatusLookupTableDto, ActivityActivityTaskTypeLookupTableDto, ActivityLeadLookupTableDto, ActivityOpportunityLookupTableDto, ActivityUserLookupTableDto, CreateOrEditActivityDto, CreateOrEditOpportunityDto, LeadActivitiesServiceProxy } from '@shared/service-proxies/service-proxies';
import { DateTime } from 'luxon';
import { ModalDirective } from 'ngx-bootstrap/modal';
import { finalize } from 'rxjs/operators';


/**
 * This component manages the activities creation on Leads, Accounts and Opportunities
 */
@Component({
  selector: 'app-create-activity-modal',
  templateUrl: './create-activity-modal.component.html'
})
export class CreateActivityModalComponent extends AppComponentBase implements OnInit {
  @ViewChild('createActivityModal', { static: true }) modal: ModalDirective;

  @Input() activityType = '';
  @Input() componentType = '';
  @Input() idToStore: any;
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


  active = false;
  saving = false;


  /**
   * Constructor
   * @param injector 
   * @param _activitiesServiceProxy 
   */
  constructor( injector: Injector,
    private _activitySharedService: ActivitySharedService,
    private _accountActivitiesServiceProxy: AccountActivitiesServiceProxy,
    private _leadActivitiesServiceProxy: LeadActivitiesServiceProxy) {
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
  close(){
    this.active = false;
    this.activity = new CreateOrEditActivityDto();
    this.selectedDate = new Date();
    this.selectedTime = '';
    this.modal.hide();
  }

  /**
   * Opens the modal
   * @param activityType 
   */
  show(activityType?: string){
    this.activityType = activityType;
    this.active = true;
    this.modal.show();
  }

  /**
   * Handles the saving action of an activity
   */
  save(){
    this.activity.activityTaskTypeId = this.allActivityTaskTypes.find(p => p.displayName == this.activityType).id;
    this.activity.taskName = this.activityType;

    switch(this.componentType){
      case 'Lead':
        this.activity.leadId = this.idToStore;
        this.activity.activitySourceTypeId = this.allActivitySourceTypes.find(x => x.code == ActivitySourceType.LEAD).id;
        break;

      case 'Account':
        this.activity.customerNumber = this.idToStore;
        this.activity.activitySourceTypeId = this.allActivitySourceTypes.find(x => x.code == ActivitySourceType.ACCOUNT).id;
        break;
      
      case 'Opportunity':
        this.activity.opportunityId = this.idToStore;
        this.activity.activitySourceTypeId = this.allActivitySourceTypes.find(x => x.code == ActivitySourceType.OPPORTUNITY).id;
        break;
    }

    this.saveActivity();
  }


  /**
   * Saves an activity
   */
   saveActivity(){
    this.processDataModel();

    switch(this.componentType){
      case 'Lead':
        this.saveLeadActivity();
        break;

      case 'Account':
        this.saveAccountActivity();
        break;

      case 'Opportunity':
        //TO DO
        break;
    }
  }

  /**
   * 
   */
  saveAccountActivity(){
    this._accountActivitiesServiceProxy
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
   * 
   */
  saveLeadActivity(){
    this._leadActivitiesServiceProxy
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
   * Transform data before sent to the backend
   */
  processDataModel(){
    const selectedActivityType = this.allActivityTaskTypes.find((x) => x.id === this.activity.activityTaskTypeId);
    this.activity.taskName = selectedActivityType.displayName;
    this.activity.dueDate = DateTime.fromJSDate(this.selectedDate);

    this.activity.startsAt = this.activity.dueDate;
  }

  /**
   * Calls the data requiered to populate dropdowns
   */
  callData(){
    this.durationItems = this._activitySharedService.getActivityDurationItems();

    switch(this.componentType){
      case 'Lead':
        this.callDataForLeadsModule();
        break;

      case 'Account':
        this.callDataForAccountsModule();
        break;

      case 'Opportunity':
        //TO DO
        break;
    }
  }

  /**
   * 
   */
  callDataForLeadsModule(){
    this._leadActivitiesServiceProxy.getAllUserForTableDropdown().subscribe((result) => {
      this.allUsers = result;
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
   * 
   */
  callDataForAccountsModule(){
    this._accountActivitiesServiceProxy.getAllUserForTableDropdown().subscribe((result) => {
      this.allUsers = result;
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

}
