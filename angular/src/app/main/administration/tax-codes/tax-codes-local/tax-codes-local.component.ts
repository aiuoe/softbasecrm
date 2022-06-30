import { Component, Injector } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';

@Component({
    selector: 'taxCodesLocal',
    templateUrl: './tax-codes-local.component.html'
})

export class TaxCodesLocalComponent extends AppComponentBase {

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