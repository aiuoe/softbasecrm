import { Component, Injector, Input, OnInit, Output, ViewChild, EventEmitter } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';
import { ActivitiesServiceProxy, ActivityActivityPriorityLookupTableDto, ActivityActivitySourceTypeLookupTableDto, ActivityActivityStatusLookupTableDto, ActivityActivityTaskTypeLookupTableDto, ActivityLeadLookupTableDto, ActivityOpportunityLookupTableDto, ActivityUserLookupTableDto, CreateOrEditActivityDto, CreateOrEditOpportunityDto } from '@shared/service-proxies/service-proxies';
import { ModalDirective } from 'ngx-bootstrap/modal';


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


  active = false;
  saving = false;


  /**
   * Constructor
   * @param injector 
   * @param _activitiesServiceProxy 
   */
  constructor( injector: Injector,
    private _activitiesServiceProxy: ActivitiesServiceProxy) {
    super(injector);
   }

  ngOnInit(): void {
    this.callData();
  }

  /**
   * Close the modal
   */
  close(){
    this.active = false;
    this.activity = new CreateOrEditActivityDto();
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
   * Handles the savong action of an activity
   */
  save(){
    this.activity.activityTaskTypeId = this.allActivityTaskTypes.find(p => p.displayName == this.activityType).id;

    switch(this.componentType){
      case 'Lead':
        this.activity.leadId = this.idToStore;
        break;

      case 'Account':
        this.activity.customerNumber = this.idToStore;
        break;
      
      case 'Opportunity':
        this.activity.opportunityId = this.idToStore;
        break;
    }

    // To do: Save activity

    // Refresh data table
    this.modalSave.emit(null);
  }

  /**
   * Calls the data requiered to populate dropdowns
   */
  callData(){
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
    });
    this._activitiesServiceProxy.getAllActivityTaskTypeForTableDropdown().subscribe((result) => {
        this.allActivityTaskTypes = result;
    });
    this._activitiesServiceProxy.getAllActivityStatusForTableDropdown().subscribe((result) => {
        this.allActivityStatuss = result;
    });
    this._activitiesServiceProxy.getAllActivityPriorityForTableDropdown().subscribe((result) => {
        this.allActivityPrioritys = result;
    });
  }

}
