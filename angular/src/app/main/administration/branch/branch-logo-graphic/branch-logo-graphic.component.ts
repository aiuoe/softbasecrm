import { Component, Injector, Input } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';
import { BranchForEditDto } from '@shared/service-proxies/service-proxies';

@Component({
    selector: 'branchLogoGraphic',
    templateUrl: './branch-logo-graphic.component.html',    
})

export class BranchLogoGraphicComponent extends AppComponentBase {

    @Input() isViewMode: boolean;
    @Input() branchForEdit: BranchForEditDto;
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