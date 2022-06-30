import { Component, Injector } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';

@Component({
    selector: 'taxCodesLocal',
    templateUrl: './tax-codes-local.component.html'
})

// Used for displaying the Local Tax Codes Details
export class TaxCodesLocalComponent extends AppComponentBase {

    saving: boolean;
    taxCodes: any[];

    //constructor
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