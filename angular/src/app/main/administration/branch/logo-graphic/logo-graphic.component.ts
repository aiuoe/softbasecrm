import { Component, Injector } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';

@Component({
    selector: 'logoGraphic',
    templateUrl: './logo-graphic.component.html',    
})

export class LogoGraphicComponent extends AppComponentBase {

    saving: boolean = false;
    logoGraphicFile: any;

    constructor(
        injector: Injector
    ) {
        super(injector);
    }

    logoGraphicClear(){
        
    }
}