import { Component, Injector, Input } from '@angular/core';
import { AppConsts } from '@shared/AppConsts';
import { AppComponentBase } from '@shared/common/app-component-base';
import { UpsertBranchDto } from '@shared/service-proxies/service-proxies';
import { debounce as _debounce } from 'lodash-es';

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

    printFinalCcValid = true;
    printFinalBccValid = true;

    /**
     * constructor
     */
    constructor(
        injector: Injector
    ) {
        super(injector);
    }

    /**
     * print final cc on input action
     */
    printFinalCcOnInput = _debounce(this.setPrintFinalCcValidity, AppConsts.SearchBarDelayMilliseconds);

    /**
    * print final bcc on input action
    */
    printFinalBccOnInput = _debounce(this.setPrintFinalBccValidity, AppConsts.SearchBarDelayMilliseconds);

    /**
    * set print final cc validity
    */
    private setPrintFinalCcValidity(): void {
        this.printFinalCcValid = this.upsertBranchDto.printFinalCc.split(',').map(x => x.trim())
            .every(x => x.length !== 0 && x.match(AppConsts.ValidEmailRegex));
    }

    /**
    * set print final bcc validity
    */
    private setPrintFinalBccValidity(): void {
        this.printFinalBccValid = this.upsertBranchDto.printFinalBcc.split(',').map(x => x.trim())
            .every(x => x.length !== 0 && x.match(AppConsts.ValidEmailRegex));
    }
}