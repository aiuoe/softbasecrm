import { Component, ViewChild, Injector, OnInit } from '@angular/core';
import { ModalDirective } from 'ngx-bootstrap/modal';
import { SelectItem } from 'primeng/api';
import { AppComponentBase } from '@shared/common/app-component-base';

/***
 * Component to replicate sale codes
 */
@Component({
    selector: 'replicateSaleCodesModal',
    templateUrl: './sale-codes-replicate-modal.component.html',
})
export class ReplicateSaleCodesModalComponent extends AppComponentBase implements OnInit {
    branchSelectItems: SelectItem[] = [
        { label: 'Branch 1', value: 'Branch 1' },
        { label: 'Branch 2', value: 'Branch 2' },
    ];
    departmentSelectItems: SelectItem[] = [
        { label: 'Department 1', value: 'Department 1' },
        { label: 'Department 2', value: 'Department 2' },
    ];
    
    @ViewChild('replicateModal', { static: true }) modal: ModalDirective;

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
}
