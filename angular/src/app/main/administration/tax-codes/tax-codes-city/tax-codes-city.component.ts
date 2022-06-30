import { Component, Injector } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';

@Component({
    selector: 'taxCodesCity',
    templateUrl: './tax-codes-city.component.html'
})

// Used for displaying the Tax Codes - City Details
export class TaxCodesCityComponent extends AppComponentBase {

    saving: boolean;
    taxCodes: any[];

    // contructor
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