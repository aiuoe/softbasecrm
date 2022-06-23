import { Component, Injector } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';

@Component({
    selector: 'tvh',
    templateUrl: './tvh.component.html'
})

export class TvhComponent extends AppComponentBase {

    constructor(
        injector: Injector
    ) {
        super(injector);
    }
}