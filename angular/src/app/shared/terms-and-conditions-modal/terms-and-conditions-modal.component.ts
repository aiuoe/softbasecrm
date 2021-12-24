import { Component, OnInit, ViewChild } from '@angular/core';
import { AppSessionService } from '@shared/common/session/app-session.service';
import { UserServiceProxy } from '@shared/service-proxies/service-proxies';
import { ModalDirective } from 'ngx-bootstrap/modal/modal.directive';
import { Subject } from 'rxjs';

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
   * Closes the modal and if theres is a user logged that hasnt accepted the terms and
   * conditions, will send an update to accept them.
   */
  close(): void {
    if (this._sessionService.user
      && !this._sessionService.user.hasAcceptedTermsAndConditions) {
      this._userServiceProxy.acceptTermsAndConditions()
      .subscribe((_) => _);
    }
    this.modal.hide();
  }

 /**
  * Shows the modal
  */
  show() {
    this.modal.show();
  }
}
