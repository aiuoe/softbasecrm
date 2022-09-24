import { Component, ViewChild, Injector, OnInit } from '@angular/core';
import { ModalDirective } from 'ngx-bootstrap/modal';
import { AppComponentBase } from '@shared/common/app-component-base';

/***
 * Component for check format preview modal
 */
@Component({
    selector: 'previewFormatCheckFormatSetupCompanyModal',
    templateUrl: './company-check-format-setup-preview-format-modal.component.html',
})
export class PreviewFormatCheckFormatSetupCompanyModalComponent extends AppComponentBase implements OnInit {
    @ViewChild('previewFormatModal', { static: true }) modal: ModalDirective;

    constructor(
        injector: Injector,
    ) {
        super(injector);
    }

    ngOnInit(): void {}

    /***
     * Method that shows the modal
     */
    show(): void {
        this.modal.show();
    }

    /***
     * Method that closes the modal
     */
    close(): void {
        this.modal.hide();
    }
}
