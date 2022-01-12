import { Component, Injector, Input, OnInit, ViewChild, ViewEncapsulation } from '@angular/core';
import { ActivitySharedService } from '@app/shared/common/crm/services/activity-shared.service';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { ActivitySourceType, ActivityTaskType } from '@shared/AppEnums';
import { AppComponentBase } from '@shared/common/app-component-base';
import { AccountActivitiesServiceProxy, ActivityActivityTaskTypeLookupTableDto, ActivityDto, LeadActivitiesServiceProxy, OpportunityActivitiesServiceProxy, GetActivityForViewDto } from '@shared/service-proxies/service-proxies';
import { LazyLoadEvent } from 'primeng/api';
import { Paginator } from 'primeng/paginator';
import { Table } from 'primeng/table';
import { forkJoin, Observable } from 'rxjs';
import { CreateOrEditActivityWidgetModalComponent } from './create-or-edit-activity-widget-modal.component';

/**
 * This component manages the activities creation on Leads, Accounts and Opportunities
 */
@Component({
  selector: 'app-activities-widget',
  templateUrl: './activities-widget.component.html',
  encapsulation: ViewEncapsulation.None,
  animations: [appModuleAnimation()]
})
export class ActivitiesWidgetComponent extends AppComponentBase implements OnInit {
  @ViewChild('dataTable', { static: true }) dataTable: Table;
  @ViewChild('paginator', { static: true }) paginator: Paginator;
  @ViewChild('createActivityModal', { static: true }) createActivityModal: CreateOrEditActivityWidgetModalComponent;


  @Input() componentType = '';
  @Input() idToStore: any;
  
  @Input() allowCreate = false;
  @Input() showScheduleMeetingOption = false;
  @Input() showScheduleCallOption = false;
  @Input() showEmailReminderOption = false;
  @Input() showToDoReminderOption = false;
  @Input() allowEdit = false;
  @Input() canAssignAnyUser = false;

  advancedFiltersAreShown = false;
  filterText = '';
  userNameFilter = '';
  saving = false;
  activityType = '';

  opportunityNameFilter = '';
  leadCompanyNameFilter = '';
  activitySourceTypeDescriptionFilter = '';
  activityTaskTypeDescriptionFilter = '';
  activityStatusDescriptionFilter = '';
  activityPriorityDescriptionFilter = '';
  customerNameFilter = '';
  
  allActivityTaskTypes: ActivityActivityTaskTypeLookupTableDto[];

  /**
   * 
   * @param injector Constructor
   */
  constructor(injector: Injector,
    private _activitySharedService: ActivitySharedService,
    private _accountActivitiesServiceProxy: AccountActivitiesServiceProxy,
    private _leadActivitiesServiceProxy: LeadActivitiesServiceProxy,
    private _opportunityActivitiesServiceProxy: OpportunityActivitiesServiceProxy) { 
    super(injector);
  }

  /**
   * NgOninit event 
   */
  ngOnInit(): void {
  }

  /***
   * Handles the data to populate on the table
   */
  loadDataTable(event?: LazyLoadEvent){
    const requests: Observable<any>[] = [];

    switch(this.componentType){
      case 'Lead':
        this.getAllActivitiesForLead(event);
        requests.push(this._leadActivitiesServiceProxy.getAllActivityTaskTypeForTableDropdown());
        break;

      case 'Account':
        this.getAllActivitiesForAccount(event);
        requests.push(this._accountActivitiesServiceProxy.getAllActivityTaskTypeForTableDropdown());
        break;
      
      case 'Opportunity':
        this.getAllActivitiesForOpportunity(event);
        requests.push(this._opportunityActivitiesServiceProxy.getAllActivityTaskTypeForTableDropdown());
        break;
    }

    forkJoin([...requests]).subscribe(([activityTaskTypes]: [ActivityActivityTaskTypeLookupTableDto[]]) => {
      this.allActivityTaskTypes = activityTaskTypes;
    });
  }

/**
 * Gets all the activities connected to a specific Lead
 * @param event 
 * @returns 
 */
 getAllActivitiesForLead(event?: LazyLoadEvent){
  if (this.primengTableHelper.shouldResetPaging(event)) {
    this.paginator.changePage(0);
    return;
  }

  this.primengTableHelper.showLoadingIndicator();

  this._leadActivitiesServiceProxy.getAll(
    this.filterText,
    this.opportunityNameFilter,
    this.leadCompanyNameFilter,
    this.userNameFilter,
    '',
    '',
    '',
    '',
    this.customerNameFilter,
    this.idToStore,
    this.primengTableHelper.getSorting(this.dataTable),
    this.primengTableHelper.getSkipCount(this.paginator, event),
    this.primengTableHelper.getMaxResultCount(this.paginator, event)
  ).subscribe( result =>{
    this.primengTableHelper.totalRecordsCount = result.totalCount;
    this.primengTableHelper.records = result.items;
    this.primengTableHelper.hideLoadingIndicator();
  });
}


  /**
   * Gets all the activities connected to an specific Account
   * @param event 
   * @returns 
   */
  getAllActivitiesForAccount(event?: LazyLoadEvent){
    if (this.primengTableHelper.shouldResetPaging(event)) {
      this.paginator.changePage(0);
      return;
    }

    this.primengTableHelper.showLoadingIndicator();

    this._accountActivitiesServiceProxy.getAll(
      this.filterText,
      this.opportunityNameFilter,
      this.leadCompanyNameFilter,
      this.userNameFilter,
      '',
      '',
      '',
      '',
      this.customerNameFilter,
      this.idToStore,
      this.primengTableHelper.getSorting(this.dataTable),
      this.primengTableHelper.getSkipCount(this.paginator, event),
      this.primengTableHelper.getMaxResultCount(this.paginator, event)
    ).subscribe( result =>{
      this.primengTableHelper.totalRecordsCount = result.totalCount;
      this.primengTableHelper.records = result.items;
      this.primengTableHelper.hideLoadingIndicator();
    });
  }

  /**
   * Gets all the activities connected to an specific Opportunity
   * @param event 
   * @returns 
   */
   getAllActivitiesForOpportunity(event?: LazyLoadEvent){
    if (this.primengTableHelper.shouldResetPaging(event)) {
      this.paginator.changePage(0);
      return;
    }

    this.primengTableHelper.showLoadingIndicator();

    this._opportunityActivitiesServiceProxy.getAll(
      this.filterText,
      this.opportunityNameFilter,
      this.leadCompanyNameFilter,
      this.userNameFilter,
      '',
      '',
      '',
      '',
      this.customerNameFilter,
      this.idToStore,
      this.primengTableHelper.getSorting(this.dataTable),
      this.primengTableHelper.getSkipCount(this.paginator, event),
      this.primengTableHelper.getMaxResultCount(this.paginator, event)
    ).subscribe( result =>{
      this.primengTableHelper.totalRecordsCount = result.totalCount;
      this.primengTableHelper.records = result.items;
      this.primengTableHelper.hideLoadingIndicator();
    });
  }

  /**
   * Opens modal to create an activity given an activity type for Schedule Call
   */
   createActivityScheduleCallHandler(){
    // Open modal
    this.createActivityModal.show(ActivityTaskType.SCHEDULE_CALL);
  }

  /**
 * Opens modal to create an activity given an activity type - for Schedule Meeting
 */
  createActivityScheduleMeetingHandler(){
    // Open modal
    this.createActivityModal.show(ActivityTaskType.SCHEDULE_MEETING);
  }

  /**
 * Opens modal to create an activity given an activity type - for Email Reminder
 */
  createActivityEmailReminderHandler(){
    // Open modal
    this.createActivityModal.show(ActivityTaskType.EMAIL_REMINDER);
  }

  /**
 * Opens modal to create an activity given an activity type - for To-Do Reminder
 */
  createActivityToDoReminderHandler(){
    // Open modal
    this.createActivityModal.show(ActivityTaskType.TODO_REMINDER);
  }

  /**
   * Opens modal to view an activity given its activityId
   * @param activity 
   */
  viewActivity(activity: ActivityDto){
    this.createActivityModal.showForViewEdit(activity.id, true);
  }

  /**
   * Opens modal to edit an activity given its activityId
   * @param activity 
   */
  editActivity(activity: ActivityDto){
    this.createActivityModal.showForViewEdit(activity.id, false);
  }

  /**
   * Refreshes the table
   */
  reloadPage(): void {
    this.paginator.changePage(this.paginator.getPage());
  }

  /**
   * Check whether an activity is a reminder type or not.
   * @param item the Activity item
   * @returns True if the Activty item is a reminder type, otherwise False.
   */
  isReminderTypeActivity(item: GetActivityForViewDto): boolean {
    return this._activitySharedService.isReminderTypeActivity(this.allActivityTaskTypes, item.activity);
  }
}
