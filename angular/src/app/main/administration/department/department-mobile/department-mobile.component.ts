import { Component, Injector, OnInit, ViewEncapsulation } from '@angular/core';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { AppComponentBase } from '@shared/common/app-component-base';

@Component({
  selector: 'app-department-mobile',
  templateUrl: './department-mobile.component.html',
  styleUrls: ['./department-mobile.component.scss'],
  encapsulation: ViewEncapsulation.None,
  animations: [appModuleAnimation()],
})
export class DepartmentMobileComponent extends AppComponentBase implements OnInit {

  constructor(
    injector: Injector
  ) { 
    super(injector);
  }

  ngOnInit(): void {
  }

}
