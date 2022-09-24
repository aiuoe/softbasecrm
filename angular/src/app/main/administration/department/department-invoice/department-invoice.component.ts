import { Component, Injector, OnInit } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';

@Component({
  selector: 'app-department-invoice',
  templateUrl: './department-invoice.component.html',
  styleUrls: ['./department-invoice.component.scss']
})
export class DepartmentInvoiceComponent extends AppComponentBase implements OnInit {

  constructor(
    injector: Injector
  ) { 
    super(injector);
  }

  ngOnInit(): void {
  }

}
