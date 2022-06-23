import { Component, Injector } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';

@Component({
    selector: 'email',
    templateUrl: './email.component.html',
})

export class EmailComponent extends AppComponentBase {

    constructor(
        injector: Injector
    ) {
        super(injector);
    }
}