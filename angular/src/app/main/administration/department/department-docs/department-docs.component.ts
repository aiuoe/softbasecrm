import { Component, Injector, OnInit } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';

@Component({
  selector: 'app-department-docs',
  templateUrl: './department-docs.component.html',
  styleUrls: ['./department-docs.component.scss']
})
export class DepartmentDocsComponent extends AppComponentBase implements OnInit {

  constructor(
    injector: Injector
  ) { 
    super(injector);
  }

  fromDate: Date; // TODO
  toDate: Date; // TODO

  ngOnInit(): void {
  }

  setAll(): void {
    
  }
}
