import { Component, Injector, OnInit, ViewEncapsulation } from '@angular/core';
import { forkJoin } from '@node_modules/rxjs';

import { appModuleAnimation } from '@shared/animations/routerTransition';
import { AppComponentBase } from '@shared/common/app-component-base';
// import { OpportunitiesServiceProxy } from '@shared/service-proxies/report-service-proxies';
import { BranchLookupTableDto, CreateOrEditDepartmentDto, DepartmentLookupTableDto } from '@shared/service-proxies/service-proxies';

@Component({
  selector: 'app-department',
  templateUrl: './department.component.html',
  styleUrls: ['./department.component.scss'],
  encapsulation: ViewEncapsulation.None,
  animations: [appModuleAnimation()],
})
export class DepartmentComponent extends AppComponentBase implements OnInit {
  subheaderDescription: string = `${this.l('Administration')} - ${this.l('Department')}`;
  allowAdd: boolean;
  allowDelete: boolean;
  allowUpdate: boolean;

  branches: BranchLookupTableDto[];
  departments: DepartmentLookupTableDto[];

  department: CreateOrEditDepartmentDto = new CreateOrEditDepartmentDto();

  constructor(
    injector: Injector,
    // private _opportunitiesServiceProxy: OpportunitiesServiceProxy
  ) { 
    super(injector);
  }

  ngOnInit(): void {
    this.loadDropdowns();
  }

  loadDropdowns(): void {
    // const requests = [
    //   this._opportunitiesServiceProxy.getAllBranchesForTableDropdown()
    // ];

    // forkJoin([...requests]).subscribe(([branches]) => {
    //   this.branches = branches;
    // });
  }

  close(): void {

  }

  add(): void {

  }

  delete(): void {

  }

  update(): void {

  }

  getDepartments(): void {

  }

  onBranchChange(): void {

  }

  onDepartmentChange(): void {
    
  }

  searchAccount(): void {

  }
}
