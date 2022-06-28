import { Component, Injector, OnInit } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';

/***
 * Component for invoice comments
 */
@Component({
    selector: 'invoiceCommentsCompanyTab',
    templateUrl: './company-invoice-comments-tab.component.html',
})
export class InvoiceCommentsCompanyTabComponent extends AppComponentBase implements OnInit {
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
