import { Component, Injector, Input } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';
import { BranchForEditDto } from '@shared/service-proxies/service-proxies';

@Component({
    selector: 'branchFinance',
    templateUrl: './branch-finance.component.html'
})

export class BranchFinanceComponent extends AppComponentBase {

    @Input() branchForEdit: BranchForEditDto;
    
    constructor(
        injector: Injector
    ) {
        super(injector);
    }
}