import { Component, ViewChild, Injector, OnInit } from '@angular/core';
import { ModalDirective } from 'ngx-bootstrap/modal';
import { Table } from 'primeng/table';
import { AppComponentBase } from '@shared/common/app-component-base';

/***
 * Component for customer search
 */
@Component({
    selector: 'customerSearchModal',
    templateUrl: './customer-search-modal.component.html',
})
export class CustomerSearchModalComponent extends AppComponentBase implements OnInit {
    @ViewChild('customerSearchModal', { static: true }) modal: ModalDirective;
    @ViewChild('dataTable', { static: true }) dataTable: Table;

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

    ngOnInit(): void {
        this.primengTableHelper.showLoadingIndicator();
        this.primengTableHelper.hideLoadingIndicator();
    }
}
