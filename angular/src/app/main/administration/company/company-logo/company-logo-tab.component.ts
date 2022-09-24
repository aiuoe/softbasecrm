import { Component, Injector, OnInit } from '@angular/core';
import { AppConsts } from '@shared/AppConsts';
import { AppComponentBase } from '@shared/common/app-component-base';

/***
 * Component for logo
 */
@Component({
    selector: 'logoCompanyTab',
    templateUrl: './company-logo-tab.component.html',
})
export class LogoCompanyTabComponent extends AppComponentBase implements OnInit {
    logo = AppConsts.appBaseUrl + '/assets/common/images/logo-default.png';

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
