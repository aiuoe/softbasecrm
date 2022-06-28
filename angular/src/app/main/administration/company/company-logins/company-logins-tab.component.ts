import { Component, Injector, OnInit } from '@angular/core';
import { SelectItem } from 'primeng/api';
import { AppComponentBase } from '@shared/common/app-component-base';

/***
 * Component for logins
 */
@Component({
    selector: 'loginsCompanyTab',
    templateUrl: './company-logins-tab.component.html',
})
export class LoginsCompanyTabComponent extends AppComponentBase implements OnInit {
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
