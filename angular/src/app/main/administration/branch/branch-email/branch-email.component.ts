import { Component, Injector } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';

@Component({
    selector: 'branchEmail',
    templateUrl: './branch-email.component.html',
})

export class BranchEmailComponent extends AppComponentBase {

    constructor(
        injector: Injector
    ) {
        super(injector);
    }
}