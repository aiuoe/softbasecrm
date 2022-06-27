import { Component, Injector } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';

@Component({
    selector: 'branchFinance',
    templateUrl: './branch-finance.component.html'
})

export class BranchFinanceComponent extends AppComponentBase {

    constructor(
        injector: Injector
    ) {
        super(injector);
    }
}