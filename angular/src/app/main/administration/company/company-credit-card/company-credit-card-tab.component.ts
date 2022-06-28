import { Component, Injector, OnInit, ViewChild } from '@angular/core';
import { SelectItem } from 'primeng/api';
import { Table } from 'primeng/table';
import { AppComponentBase } from '@shared/common/app-component-base';

/***
 * Component for credit card
 */
@Component({
    selector: 'creditCardCompanyTab',
    templateUrl: './company-credit-card-tab.component.html',
})
export class CreditCardCompanyTabComponent extends AppComponentBase implements OnInit {
    creditCardVendorSelectItems: SelectItem[] = [
        { label: 'Vendor 1', value: 'Vendor 1' },
        { label: 'Vendor 2', value: 'Vendor 2' },
    ];
    apiEventSelectItems: SelectItem[] = [
        { label: 'Event 1', value: 'Event 1' },
        { label: 'Event 2', value: 'Event 2' },
    ];
    
    @ViewChild('dataTable', { static: true }) dataTable: Table;

    constructor(
        injector: Injector,
    ) {
        super(injector);
    }

    ngOnInit(): void {
        this.primengTableHelper.showLoadingIndicator();
        this.primengTableHelper.hideLoadingIndicator();
    }
}
