import { Component, ViewChild, Injector, OnInit } from '@angular/core';
import { ModalDirective } from 'ngx-bootstrap/modal';
import { AppComponentBase } from '@shared/common/app-component-base';

/***
 * Component to replicate sale codes
 */
@Component({
    selector: 'replicateSaleCodesModal',
    templateUrl: './replicate-saleCodes-modal.component.html',
})
export class ReplicateSaleCodesModalComponent extends AppComponentBase implements OnInit {
    @ViewChild('replicateModal', { static: true }) modal: ModalDirective;

    constructor(
        injector: Injector,
    ) {
        super(injector);
    }

    /***
     * Method that shows the modal
     */
    show(): void {
        this.modal.show();
    }

    /***
     * Method that saves the replica in the database
     */
    save(): void {
        this.close();
    }

    /***
     * Method that closes the modal
     */
    close(): void {
        this.modal.hide();
    }

    ngOnInit(): void {}
}
