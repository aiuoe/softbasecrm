import { Component, Injector, OnInit } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';

/***
 * Component for print fields
 */
@Component({
    selector: 'printFieldsCompanyTab',
    templateUrl: './company-print-fields-tab.component.html',
})
export class PrintFieldsCompanyTabComponent extends AppComponentBase implements OnInit {
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
