import { Component, Injector, OnInit, ViewChild, ViewEncapsulation } from '@angular/core';
import { SelectItem } from 'primeng/api';
import { AppComponentBase } from '@shared/common/app-component-base';
import { AccountSearchModalComponent } from '../../../common/account-search/account-search-modal.component';

/***
 * Component for accounting
 */
@Component({
    selector: 'accountingCompanyTab',
    encapsulation: ViewEncapsulation.None,
    templateUrl: './company-accounting-tab.component.html'
})
export class AccountingCompanyTabComponent extends AppComponentBase implements OnInit {
    invoiceCutOffDaySelectItems: SelectItem[] = [
        { label: 'Day 1', value: 'Day 1' },
        { label: 'Day 2', value: 'Day 2' },
    ];
    apCheckFormatSelectItems: SelectItem[] = [
        { label: 'Fornat 1', value: 'Fornat 1' },
        { label: 'Fornat 2', value: 'Fornat 2' },
    ];
    canadianDateFormatSelectItems: SelectItem[] = [
        { label: 'Format 1', value: 'Format 1' },
        { label: 'Format 2', value: 'Format 2' },
    ];



    @ViewChild('accountSearchModal', { static: true })
    accountSearchModal: AccountSearchModalComponent;

    constructor(
        injector: Injector,
    ) {
        super(injector);
    }

    ngOnInit(): void {
    }

    /***
     * Method that shows the account search modal
     */
    accountSearch(): void {
        this.accountSearchModal.show();
    }
}
