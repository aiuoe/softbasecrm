import { Component, Injector, OnInit, ViewEncapsulation } from '@angular/core';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { AppComponentBase } from '@shared/common/app-component-base';

@Component({
  selector: 'app-department-quote',
  templateUrl: './department-quote.component.html',
  styleUrls: ['./department-quote.component.scss'],
  encapsulation: ViewEncapsulation.None,
  animations: [appModuleAnimation()],
})
export class DepartmentQuoteComponent extends AppComponentBase implements OnInit {

  constructor(
    injector: Injector
  ) { 
    super(injector);
  }

  ngOnInit(): void {
  }

}
