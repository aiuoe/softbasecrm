import { Component, Injector } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';

@Component({
    selector: 'taxCodesSalesTax',
    templateUrl: './tax-codes-sales-tax.component.html'
})

// Used for displaying the Sales Tax Codes Details
export class TaxCodesSalesTaxComponent extends AppComponentBase {

    saving: boolean;
    salesTaxProvider: any[];
    companyCodes: any[];

    constructor(
        injector: Injector
    ) {
        super(injector);
    }

    // TODO: replace placeholder update function
    update(){

    }

    // TODO: replace placeholder delete function
    delete(){
        
    }

    // TODO: replace placeholder test connection function during implementation
    testConnection(){

    }

    // TODO: replace placeholder function durnig implementation
    viewLog(){
        
    }
}