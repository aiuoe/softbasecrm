import { Component, Injector } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';

@Component({
    selector: 'branchTvh',
    templateUrl: './branch-tvh.component.html'
})

export class BranchTvhComponent extends AppComponentBase {

    constructor(
        injector: Injector
    ) {
        super(injector);
    }
}