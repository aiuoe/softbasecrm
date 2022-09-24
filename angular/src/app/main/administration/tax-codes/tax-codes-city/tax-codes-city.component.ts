import { Component, Injector } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';

/***
 * Sub Component to manage tax codes city
 */
@Component({
    selector: 'taxCodesCity',
    templateUrl: './tax-codes-city.component.html'
})

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