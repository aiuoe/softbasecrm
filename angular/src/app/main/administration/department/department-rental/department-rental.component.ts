import { Component, Injector, OnInit } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';

@Component({
  selector: 'app-department-rental',
  templateUrl: './department-rental.component.html',
  styleUrls: ['./department-rental.component.scss']
})
export class DepartmentRentalComponent extends AppComponentBase implements OnInit {

  constructor(
    injector: Injector
  ) { 
    super(injector);
  }

  returnStatuses: string[];
  BOs: string[];
  stocks: string[];
  emergencyCostPriorities: string[];
  disableReturnStatus: boolean;
  disableBOs: boolean;
  disableStock: boolean;
  disableEmergencyCostPriority: boolean;

  ngOnInit(): void {
    this.disableReturnStatus = true;
    this.disableBOs = true;
    this.disableStock = true;
    this.disableEmergencyCostPriority = true;
  }

}
