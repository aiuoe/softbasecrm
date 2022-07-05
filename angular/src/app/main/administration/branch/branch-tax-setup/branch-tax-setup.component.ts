import { Component, Injector, Input } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';
import { ITaxCodeInBranchDto } from '@shared/service-proxies/service-proxies';

@Component({
    selector: 'branchTaxSetup',
    templateUrl: './branch-tax-setup.component.html'
})

export class BranchTaxSetupComponent extends AppComponentBase {

    @Input() taxCodes: ITaxCodeInBranchDto[] = [];

    constructor(
        injector: Injector
    ) {
        super(injector);
    }
}