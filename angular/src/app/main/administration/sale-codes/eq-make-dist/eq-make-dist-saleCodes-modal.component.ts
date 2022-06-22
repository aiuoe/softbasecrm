import { Component, ViewChild, Injector, OnInit } from '@angular/core';
import { ModalDirective } from 'ngx-bootstrap/modal';
import { AppComponentBase } from '@shared/common/app-component-base';

/***
 * Component for equipment make distribution
 */
@Component({
    selector: 'eqMakeDistSaleCodesModal',
    templateUrl: './eq-make-dist-saleCodes-modal.component.html',
})
export class EqMakeDistSaleCodesModalComponent extends AppComponentBase implements OnInit {
    @ViewChild('eqMakeDistModal', { static: true }) modal: ModalDirective;

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
     * Method that closes the modal
     */
    close(): void {
        this.modal.hide();
    }

    ngOnInit(): void {}
}
