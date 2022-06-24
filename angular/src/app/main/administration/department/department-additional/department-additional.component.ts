import { Component, Injector, OnInit, ViewEncapsulation } from '@angular/core';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { AppComponentBase } from '@shared/common/app-component-base';
import { BranchLookupTableDto, CreateOrEditDepartmentDto } from '@shared/service-proxies/service-proxies';

@Component({
  selector: 'app-department-additional',
  templateUrl: './department-additional.component.html',
  styleUrls: ['./department-additional.component.scss'],
  encapsulation: ViewEncapsulation.None,
  animations: [appModuleAnimation()],
})
export class DepartmentAdditionalComponent extends AppComponentBase implements OnInit {

  miscDescriptions: BranchLookupTableDto[]; // TODO
  department: CreateOrEditDepartmentDto = new CreateOrEditDepartmentDto();

  constructor(
    injector: Injector
  ) { 
    super(injector);
  }

  ngOnInit(): void {
  }

  searchAccount(): void {

  }
}
