import { Component, Injector, Input } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';
import { UpsertBranchDto } from '@shared/service-proxies/service-proxies';

/**
 * Sub component for branch email tab
 */
@Component({
    selector: 'branchEmail',
    templateUrl: './branch-email.component.html',
})

export class BranchEmailComponent extends AppComponentBase {

    @Input() isViewMode: boolean;
    @Input() upsertBranchDto: UpsertBranchDto;

    /**
     * constructor
     */
    constructor(
        injector: Injector
    ) {
        super(injector);
    }
}