import { Component, Injector } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';

@Component({
    selector: 'finance',
    templateUrl: './finance.component.html'
})

export class FinanceComponent extends AppComponentBase {

    constructor(
        injector: Injector
    ) {
        super(injector);
    }
}