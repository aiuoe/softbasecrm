import { Component, Injector } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';

/***
 * Sub Component to manage tax codes country prov
 */
@Component({
    selector: 'taxCodesCountryProv',
    templateUrl: './tax-codes-country-prov.component.html'
})

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