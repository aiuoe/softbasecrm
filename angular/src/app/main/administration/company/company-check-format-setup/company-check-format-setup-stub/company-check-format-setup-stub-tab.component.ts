import { Component, Injector, OnInit } from '@angular/core';
import { SelectItem } from 'primeng/api';
import { AppComponentBase } from '@shared/common/app-component-base';

/***
 * Component for stub tab
 */
@Component({
    selector: 'stubCheckFormatSetupCompanyTab',
    templateUrl: './company-check-format-setup-stub-tab.component.html',
})
export class StubCheckFormatSetupCompanyTabComponent extends AppComponentBase implements OnInit {
    coNameFontSelectItems: SelectItem[] = [
        { label: 'Font 1', value: 'Font 1' },
        { label: 'Font 2', value: 'Font 2' },
    ];
    coNameSizeSelectItems: SelectItem[] = [
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
    summaryFontSelectItems: SelectItem[] = [
        { label: 'Font 1', value: 'Font 1' },
        { label: 'Font 2', value: 'Font 2' },
    ];
    summarySizeSelectItems: SelectItem[] = [
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
