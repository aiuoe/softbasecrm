import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-department-docs',
  templateUrl: './department-docs.component.html',
  styleUrls: ['./department-docs.component.scss']
})
export class DepartmentDocsComponent implements OnInit {

  constructor() { }

  fromDate: Date; // TODO
  toDate: Date; // TODO

  ngOnInit(): void {
  }

  setAll(): void {
    
  }
}
