import { Component, Injector, OnInit, ViewChild } from '@angular/core';
import { SelectItem } from 'primeng/api';
import { Table } from 'primeng/table';
import { AppComponentBase } from '@shared/common/app-component-base';

/***
 * Component for marketing
 */
@Component({
    selector: 'marketingCompanyTab',
    templateUrl: './company-marketing-tab.component.html',
})
export class MarketingCompanyTabComponent extends AppComponentBase implements OnInit {
    defaultTermsSelectItems: SelectItem[] = [
        { label: 'Term 1', value: 'Term 1' },
        { label: 'Term 2', value: 'Term 2' },
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
