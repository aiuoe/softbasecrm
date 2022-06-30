import { Component, Injector } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';

@Component({
    selector: 'taxCodesCountryProv',
    templateUrl: './tax-codes-country-prov.component.html'
})

// Used for displaying the Tax Codes - Country/Prov Details
export class TaxCodesCountryProvComponent extends AppComponentBase {

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