import { Component, Injector, Input } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';
import { UpsertBranchDto } from '@shared/service-proxies/service-proxies';

/**
 * Sub component for branch logo tab
 */
@Component({
    selector: 'branchLogoGraphic',
    templateUrl: './branch-logo-graphic.component.html',
})

export class BranchLogoGraphicComponent extends AppComponentBase {

    @Input() isViewMode: boolean;
    @Input() upsertBranchDto: UpsertBranchDto;
    saving: boolean = false;
    logoGraphicFile: any;

    constructor(
        injector: Injector
    ) {
        super(injector);
    }

    logoGraphicClear() {

    }
}