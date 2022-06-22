import { Component, ViewChild, Injector, OnInit } from '@angular/core';
import { ModalDirective } from 'ngx-bootstrap/modal';
import { SelectItem } from 'primeng/api';
import { AppComponentBase } from '@shared/common/app-component-base';

/***
 * Component for additional parts distribution
 */
@Component({
    selector: 'addlDistSaleCodesModal',
    templateUrl: './addl-dist-saleCodes-modal.component.html',
})
export class AddlDistSaleCodesModalComponent extends AppComponentBase implements OnInit {
    partsGroupSelectItems: SelectItem[] = [
        { label: 'Group 1', value: 'Group 1' },
        { label: 'Group 2', value: 'Group 2' },
    ];
    availableGroupsSelectItems: SelectItem[] = [
        { label: 'Group 1', value: 'Group 1' },
        { label: 'Group 2', value: 'Group 2' },
    ];

    @ViewChild('addlDistModal', { static: true }) modal: ModalDirective;

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
