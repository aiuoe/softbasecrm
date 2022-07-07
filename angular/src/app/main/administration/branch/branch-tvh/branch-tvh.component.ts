import { Component, Injector, Input } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';
import { BranchForEditDto } from '@shared/service-proxies/service-proxies';

@Component({
    selector: 'branchTvh',
    templateUrl: './branch-tvh.component.html'
})

export class BranchTvhComponent extends AppComponentBase {

    @Input() branchForEdit: BranchForEditDto;
    @Input() countries: BranchForEditDto;
    @Input() tvhWarehouses: BranchForEditDto;

    constructor(
        injector: Injector
    ) {
        super(injector);
    }
}