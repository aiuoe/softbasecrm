import { Component, Injector } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';

@Component({
    selector: 'taxCodesSalesTax',
    templateUrl: './tax-codes-sales-tax.component.html'
})

export class TaxCodesSalesTaxComponent extends AppComponentBase {

    saving: boolean;
    salesTaxProvider: any[];
    companyCodes: any[];

    constructor(
        injector: Injector
    ) {
        super(injector);
    }

    update(){

    }

    delete(){

    }

    testConnection(){

    }

    viewLog(){
        
    }
}