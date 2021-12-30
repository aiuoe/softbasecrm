import { Component, ViewChild } from '@angular/core';
import { AppSessionService } from '@shared/common/session/app-session.service';
import { UserServiceProxy } from '@shared/service-proxies/service-proxies';
import { ModalDirective } from 'ngx-bootstrap/modal/modal.directive';

/**
 * Terms and coditions component
 */
@Component({
  selector: 'terms-and-conditions-modal',
  templateUrl: './terms-and-conditions-modal.component.html',
  styleUrls: ['./terms-and-conditions-modal.component.less']
})
export class TermsAndConditionsModalComponent {

  @ViewChild('termsModal', { static: true }) modal: ModalDirective;

  /**
   * Main constructor
   * @param _sessionService session service
   * @param _userServiceProxy users service proxy
   */
  constructor(
    private _sessionService: AppSessionService,
    private _userServiceProxy: UserServiceProxy
  ) { }

  /**
   * Closes the modal 
   */
  close(): void {
    this.modal.hide();
  }

 /**
  * Shows the modal
  */
  show() {
    this.modal.show();
  }
}
