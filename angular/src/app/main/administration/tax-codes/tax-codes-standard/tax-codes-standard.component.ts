import { Component, Injector } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';

@Component({
    selector: 'taxCodesStandard',
    templateUrl: './tax-codes-standard.component.html'
})

// Used for displaying the Standard Tax Codes Details
export class TaxCodesStandardComponent extends AppComponentBase {

    saving: boolean = false;
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