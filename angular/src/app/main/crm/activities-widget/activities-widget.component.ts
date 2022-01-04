import { Component, Injector, Input, OnInit, ViewChild, ViewEncapsulation } from '@angular/core';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { AppComponentBase } from '@shared/common/app-component-base';
import { AccountActivitiesServiceProxy, ActivityDto, LeadActivitiesServiceProxy } from '@shared/service-proxies/service-proxies';
import { LazyLoadEvent } from 'primeng/api';
import { Paginator } from 'primeng/paginator';
import { Table } from 'primeng/table';
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

  /**
   * 
   * @param injector Constructor
   */
  constructor(injector: Injector,
    private _accountActivitiesServiceProxy: AccountActivitiesServiceProxy,
    private _leadActivitiesServiceProxy: LeadActivitiesServiceProxy) { 
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
    switch(this.componentType){
      case 'Lead':
        this.getAllActivitiesForLead(event);
        break;

      case 'Account':
        this.getAllActivitiesForAccount(event);
        break;
      
      case 'Opportunity':
        //To do
        break;
    }
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
    console.log(result.items);
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
      console.log(result.items);
    });
  }

  /**
   * Opens modal to create an activity given an activity type
   * @param activityType 
   */
  createActivityHandlder(activityType: string){
    // Open modal
    this.createActivityModal.show(activityType);
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
   * Handles de deletetion of an activity
   */
  deleteAccountActivity(activity: ActivityDto){
    this.message.confirm(
      '',
      this.l('AreYouSure'),
      (isConfirmed) => {
          if (isConfirmed) {
              this._accountActivitiesServiceProxy.delete(activity.id)
                  .subscribe(() => {
                      this.reloadPage();
                      this.notify.success(this.l('SuccessfullyDeleted'));
                  });
          }
      }
    );
  }

  /**
 * Handles de deletetion of an activity
 */
  deleteLeadActivity(activity: ActivityDto){
  this.message.confirm(
    '',
    this.l('AreYouSure'),
    (isConfirmed) => {
        if (isConfirmed) {
            this._leadActivitiesServiceProxy.delete(activity.id)
                .subscribe(() => {
                    this.reloadPage();
                    this.notify.success(this.l('SuccessfullyDeleted'));
                });
        }
    }
  );
}

  /**
   * Refreshes the table
   */
  reloadPage(): void {
    this.paginator.changePage(this.paginator.getPage());
  }

}
