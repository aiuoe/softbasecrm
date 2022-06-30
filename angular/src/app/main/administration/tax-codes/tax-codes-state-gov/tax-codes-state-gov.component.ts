import { Component, Injector } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';

@Component({
    selector: 'taxCodesStateGov',
    templateUrl: './tax-codes-state-gov.component.html'
})

export class TaxCodesStateGovComponent extends AppComponentBase {

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