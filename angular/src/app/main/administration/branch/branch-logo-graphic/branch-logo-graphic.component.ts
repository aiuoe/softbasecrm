import { Component, Injector } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';

@Component({
    selector: 'branchLogoGraphic',
    templateUrl: './branch-logo-graphic.component.html',    
})

export class BranchLogoGraphicComponent extends AppComponentBase {

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