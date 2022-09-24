import { Component, ViewChild, Injector, OnInit } from '@angular/core';
import { ModalDirective } from 'ngx-bootstrap/modal';
import { SelectItem } from 'primeng/api';
import { AppComponentBase } from '@shared/common/app-component-base';

/***
 * Component for equipment make distribution
 */
@Component({
    selector: 'eqMakeDistSaleCodesModal',
    templateUrl: './sale-codes-equipment-make-distribution-modal.component.html',
})
export class EqMakeDistSaleCodesModalComponent extends AppComponentBase implements OnInit {
    makeSelectItems: SelectItem[] = [
        { label: 'Make 1', value: 'Make 1' },
        { label: 'Make 2', value: 'Make 2' },
    ];

    @ViewChild('eqMakeDistModal', { static: true }) modal: ModalDirective;

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
