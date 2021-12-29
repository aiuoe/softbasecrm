import { Component, Injector, Input, OnInit, ViewChild, ViewEncapsulation } from '@angular/core';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { AppComponentBase } from '@shared/common/app-component-base';
import { LazyLoadEvent } from 'primeng/api';
import { Paginator } from 'primeng/paginator';
import { Table } from 'primeng/table';

@Component({
  selector: 'app-activities-widget',
  templateUrl: './activities-widget.component.html',
  encapsulation: ViewEncapsulation.None,
  animations: [appModuleAnimation()]
})
export class ActivitiesWidgetComponent extends AppComponentBase implements OnInit {
  @ViewChild('dataTable', { static: true }) dataTable: Table;
  @ViewChild('paginator', { static: true }) paginator: Paginator;


  @Input() componentType = '';
  @Input() idToStore: any;

  advancedFiltersAreShown = false;
  filterText = '';
  userNameFilter = '';
  saving = false;
  activityType = '';

  constructor(injector: Injector) { 
    super(injector);
  }

  ngOnInit(): void {
  }

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

  createActivityHandlder(activityType: string){
    this.activityType = activityType;
    // Open modal
  }


  deleteActivity(){
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

}
