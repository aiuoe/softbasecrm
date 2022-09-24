import { Component, Injector } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';

/***
 * Sub Component to manage tax codes sales default
 */
@Component({
    selector: 'taxCodesDefaultTaxCode',
    templateUrl: './tax-codes-default-tax-code.component.html'
})

export class TaxCodesDefaultTaxCodeComponent extends AppComponentBase {
    saving: boolean;

    // constructor
    constructor(
        injector: Injector
    ) {
        super(injector);
    }

    // TODO: replace placeholder function during implementation
    update(){

    }

    // TODO: replace placeholder function during implementation
    delete(){
        
    }
}