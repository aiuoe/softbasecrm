import { Component, Injector } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';

@Component({
    selector: 'taxCodesCity',
    templateUrl: './tax-codes-city.component.html'
})

export class TaxCodesCityComponent extends AppComponentBase {

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