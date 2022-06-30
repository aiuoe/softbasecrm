import { Component, Injector } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';

@Component({
    selector: 'taxCodesStandard',
    templateUrl: './tax-codes-standard.component.html'
})

export class TaxCodesStandardComponent extends AppComponentBase {

    saving: boolean = false;
    taxCodes: any[];

    constructor(
        injector: Injector
    ) {
        super(injector);
    }

    add() {

    }

    delete() {

    }

    update() {

    }
}