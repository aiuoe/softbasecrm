import { Component, OnInit, ViewChild } from '@angular/core';
import { ModalDirective } from 'ngx-bootstrap/modal/modal.directive';

@Component({
  selector: 'terms-and-conditions-modal',
  templateUrl: './terms-and-conditions-modal.component.html'
})
export class TermsAndConditionsModalComponent implements OnInit {

  @ViewChild('termsModal', { static: true }) modal: ModalDirective;

  constructor() { }

  ngOnInit(): void {
  }

  close(): void {
    this.modal.hide();
  }

  show(){
    this.modal.show();
  }
}
