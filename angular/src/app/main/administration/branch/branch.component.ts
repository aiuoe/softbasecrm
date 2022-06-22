import { Component, Injector } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { BreadcrumbItem } from '@app/shared/common/sub-header/sub-header.component';
import { CustomerCountryLookupTableDto } from '@shared/service-proxies/service-proxies';

@Component({
    templateUrl: './branch.component.html',
    animations: [appModuleAnimation()]
})

export class BranchComponent extends AppComponentBase {

    saving: boolean = false;    
    breadcrumbs: BreadcrumbItem[] = [
        new BreadcrumbItem(this.l('Administration')),
        new BreadcrumbItem(this.l('Branch'))
    ];
    
    branches: any[];
    countries: CustomerCountryLookupTableDto[] = [];
    arAccounts: any[];
    warehouses: any[];
    currencies: any[];

    constructor(
        injector: Injector
    ) {
        super(injector);
    }

    add() {

    }

    delete() {

    }

    update() {

    }

    logoGraphicClear(){
        
    }
}