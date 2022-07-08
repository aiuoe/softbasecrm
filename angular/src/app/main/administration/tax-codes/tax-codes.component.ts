import { Component, Injector } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { BreadcrumbItem } from '@app/shared/common/sub-header/sub-header.component';

/***
 * Component to manage tax codes
 */
@Component({
    templateUrl: './tax-codes.component.html',
    animations: [appModuleAnimation()]
})
export class TaxCodesComponent extends AppComponentBase {

    breadcrumbs: BreadcrumbItem[] = [
        new BreadcrumbItem(this.l('Administration')),
        new BreadcrumbItem(this.l('TaxCodes'))
    ];

    // constructor
    constructor(
        injector: Injector
    ) {
        super(injector);
    }
}