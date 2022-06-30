import { Component, Injector } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';

@Component({
    selector: 'taxCodesDefaultTaxCode',
    templateUrl: './tax-codes-default-tax-code.component.html'
})

export class TaxCodesDefaultTaxCodeComponent extends AppComponentBase {
    saving: boolean;

    constructor(
        injector: Injector
    ) {
        super(injector);
    }

    update(){

    }

    delete(){

    }
}