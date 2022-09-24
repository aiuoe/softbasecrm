import { Component, ViewChild, Injector, OnInit } from '@angular/core';
import { ModalDirective } from 'ngx-bootstrap/modal';
import { SelectItem } from 'primeng/api';
import { AppComponentBase } from '@shared/common/app-component-base';

/***
 * Component for equipment group distribution
 */
@Component({
    selector: 'eqGroupDistSaleCodesModal',
    templateUrl: './sale-codes-equipment-group-distribution-modal.component.html',
})
export class EqGroupDistSaleCodesModalComponent extends AppComponentBase implements OnInit {
    groupSelectItems: SelectItem[] = [
        { label: 'Group 1', value: 'Group 1' },
        { label: 'Group 2', value: 'Group 2' },
    ];

    @ViewChild('eqGroupDistModal', { static: true }) modal: ModalDirective;

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
