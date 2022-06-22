import { Component, ViewChild, Injector, OnInit } from '@angular/core';
import { ModalDirective } from 'ngx-bootstrap/modal';
import { AppComponentBase } from '@shared/common/app-component-base';

/***
 * Component for equipment group distribution
 */
@Component({
    selector: 'eqGroupDistSaleCodesModal',
    templateUrl: './eq-group-dist-saleCodes-modal.component.html',
})
export class EqGroupDistSaleCodesModalComponent extends AppComponentBase implements OnInit {
    @ViewChild('eqGroupDistModal', { static: true }) modal: ModalDirective;

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
