import { Component, Injector, OnInit } from '@angular/core';
import { SelectItem } from 'primeng/api';
import { AppComponentBase } from '@shared/common/app-component-base';

/***
 * Component for invoicing
 */
@Component({
    selector: 'invoicingCompanyTab',
    templateUrl: './company-invoicing-tab.component.html',
})
export class InvoicingCompanyTabComponent extends AppComponentBase implements OnInit {
    financialInvoiceCopiesSelectItems: SelectItem[] = [
        { label: 'Copy 1', value: 'Copy 1' },
        { label: 'Copy 2', value: 'Copy 2' },
    ];
    pastCurrencyFormatSelectItems: SelectItem[] = [
        { label: 'Format 1', value: 'Format 1' },
        { label: 'Format 2', value: 'Format 2' },
    ];
    laborImportRoundingSelectItems: SelectItem[] = [
        { label: 'Minute 1', value: 'Minute 1' },
        { label: 'Minute 2', value: 'Minute 2' },
    ];
    
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
