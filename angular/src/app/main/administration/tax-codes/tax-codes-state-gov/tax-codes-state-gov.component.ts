import { Component, Injector } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';

@Component({
    selector: 'taxCodesStateGov',
    templateUrl: './tax-codes-state-gov.component.html'
})

// Used for displaying the Tax Codes - state Details
export class TaxCodesStateGovComponent extends AppComponentBase {

    saving: boolean;
    taxCodes: any[];

    // constructor
    constructor(
        injector: Injector
    ) {
        super(injector);
    }

    // TODO: replace placeholder function during implementation
    add(){

    }

    // TODO: replace placeholder function during implementation
    update(){

    }

    // TODO: replace placeholder function during implementation
    delete(){
        
    }
}