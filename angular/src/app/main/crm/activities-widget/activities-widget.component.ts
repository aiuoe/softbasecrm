import { Component, Injector, Input, OnInit, ViewChild, ViewEncapsulation } from '@angular/core';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { AppComponentBase } from '@shared/common/app-component-base';
import { ActivitiesServiceProxy } from '@shared/service-proxies/service-proxies';
import { LazyLoadEvent } from 'primeng/api';
import { Paginator } from 'primeng/paginator';
import { Table } from 'primeng/table';
import { CreateActivityModalComponent } from './create-activity-modal.component';

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
  @ViewChild('createActivityModal', { static: true }) createActivityModal: CreateActivityModalComponent;


  @Input() componentType = '';
  @Input() idToStore: any;

  advancedFiltersAreShown = false;
  filterText = '';
  userNameFilter = '';
  saving = false;
  activityType = '';

  /**
   * 
   * @param injector Constructor
   */
  constructor(injector: Injector,
    private _activitiesServiceProxy: ActivitiesServiceProxy) { 
    super(injector);
  }

  ngOnInit(): void {
  }

  /***
   * Handles the data to populate on the table
   */
  loadDataTable(event?: LazyLoadEvent){
    switch(this.componentType){
      case 'Lead':
        // To do
        break;

      case 'Account':
        //To do
        break;
      
      case 'Opportunity':
        //To do
        break;
    }
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
   * Handles de deletetion of an activity
   */
  deleteActivity(){
    // TO DO
  }

}
