import { Component, Injector, OnInit, ViewEncapsulation } from '@angular/core';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { AppComponentBase } from '@shared/common/app-component-base';

@Component({
  selector: 'app-department-tabs',
  templateUrl: './department-tabs.component.html',
  styleUrls: ['./department-tabs.component.scss'],
  encapsulation: ViewEncapsulation.None,
  animations: [appModuleAnimation()],
})
export class DepartmentTabsComponent extends AppComponentBase implements OnInit {

  constructor(
    injector: Injector
  ) { 
    super(injector);
  }

  ngOnInit(): void {
  }

}
