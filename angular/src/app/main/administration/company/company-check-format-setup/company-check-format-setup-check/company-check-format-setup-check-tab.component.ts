import { Component, Injector, OnInit } from '@angular/core';
import { SelectItem } from 'primeng/api';
import { AppComponentBase } from '@shared/common/app-component-base';

/***
 * Component for check tab
 */
@Component({
    selector: 'checkCheckFormatSetupCompanyTab',
    templateUrl: './company-check-format-setup-check-tab.component.html',
})
export class CheckCheckFormatSetupCompanyTabComponent extends AppComponentBase implements OnInit {
    amountFontSelectItems: SelectItem[] = [
        { label: 'Font 1', value: 'Font 1' },
        { label: 'Font 2', value: 'Font 2' },
    ];
    amountSizeSelectItems: SelectItem[] = [
        { label: 'Size 1', value: 'Size 1' },
        { label: 'Size 2', value: 'Size 2' },
    ];
    dateFontSelectItems: SelectItem[] = [
        { label: 'Font 1', value: 'Font 1' },
        { label: 'Font 2', value: 'Font 2' },
    ];
    dateSizeSelectItems: SelectItem[] = [
        { label: 'Size 1', value: 'Size 1' },
        { label: 'Size 2', value: 'Size 2' },
    ];
    checkNumberFontSelectItems: SelectItem[] = [
        { label: 'Font 1', value: 'Font 1' },
        { label: 'Font 2', value: 'Font 2' },
    ];
    checkNumberSizeSelectItems: SelectItem[] = [
        { label: 'Size 1', value: 'Size 1' },
        { label: 'Size 2', value: 'Size 2' },
    ];
    payToFontSelectItems: SelectItem[] = [
        { label: 'Font 1', value: 'Font 1' },
        { label: 'Font 2', value: 'Font 2' },
    ];
    payToSizeSelectItems: SelectItem[] = [
        { label: 'Size 1', value: 'Size 1' },
        { label: 'Size 2', value: 'Size 2' },
    ];
    amountVerboseFontSelectItems: SelectItem[] = [
        { label: 'Font 1', value: 'Font 1' },
        { label: 'Font 2', value: 'Font 2' },
    ];
    amountVerboseSizeSelectItems: SelectItem[] = [
        { label: 'Size 1', value: 'Size 1' },
        { label: 'Size 2', value: 'Size 2' },
    ];
    vendorFontSelectItems: SelectItem[] = [
        { label: 'Font 1', value: 'Font 1' },
        { label: 'Font 2', value: 'Font 2' },
    ];
    vendorSizeSelectItems: SelectItem[] = [
        { label: 'Size 1', value: 'Size 1' },
        { label: 'Size 2', value: 'Size 2' },
    ];
    memoFontSelectItems: SelectItem[] = [
        { label: 'Font 1', value: 'Font 1' },
        { label: 'Font 2', value: 'Font 2' },
    ];
    memoSizeSelectItems: SelectItem[] = [
        { label: 'Size 1', value: 'Size 1' },
        { label: 'Size 2', value: 'Size 2' },
    ];
    
    constructor(
        injector: Injector,
    ) {
        super(injector);
    }

    ngOnInit(): void {
        this.primengTableHelper.showLoadingIndicator();
        this.primengTableHelper.hideLoadingIndicator();
    }
}
