import { Component, Injector } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';

@Component({
    selector: 'taxSetup',
    templateUrl: './tax-setup.component.html'
})

export class TaxSetupComponent extends AppComponentBase {

    constructor(
        injector: Injector
    ) {
        super(injector);
    }
}