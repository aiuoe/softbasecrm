import { Component, Injector } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';

@Component({
    selector: 'taxCodesCountryProv',
    templateUrl: './tax-codes-country-prov.component.html'
})

export class TaxCodesCountryProvComponent extends AppComponentBase {

    saving: boolean;
    taxCodes: any[];

    constructor(
        injector: Injector
    ) {
        super(injector);
    }

    add(){

    }

    update(){

    }

    delete(){

    }
}