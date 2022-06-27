import { Component, Injector, OnInit } from '@angular/core';
import { SelectItem } from 'primeng/api';
import { AppComponentBase } from '@shared/common/app-component-base';

/***
 * Component for remittance tab
 */
@Component({
    selector: 'remittanceCheckFormatSetupCompanyTab',
    templateUrl: './company-check-format-setup-remittance-tab.component.html',
})
export class RemittanceCheckFormatSetupCompanyTabComponent extends AppComponentBase implements OnInit {
    amountFontSelectItems: SelectItem[] = [
        { label: 'Font 1', value: 'Font 1' },
        { label: 'Font 2', value: 'Font 2' },
    ];
    amountSizeSelectItems: SelectItem[] = [
        { label: 'Size 1', value: 'Size 1' },
        { label: 'Size 2', value: 'Size 2' },
    ];
    remitBottomFontSelectItems: SelectItem[] = [
        { label: 'Font 1', value: 'Font 1' },
        { label: 'Font 2', value: 'Font 2' },
    ];
    remitBottomSizeSelectItems: SelectItem[] = [
        { label: 'Size 1', value: 'Size 1' },
        { label: 'Size 2', value: 'Size 2' },
    ];
    sumCheckNumberFontSelectItems: SelectItem[] = [
        { label: 'Font 1', value: 'Font 1' },
        { label: 'Font 2', value: 'Font 2' },
    ];
    sumCheckNumberSizeSelectItems: SelectItem[] = [
        { label: 'Size 1', value: 'Size 1' },
        { label: 'Size 2', value: 'Size 2' },
    ];
    sumDateFontSelectItems: SelectItem[] = [
        { label: 'Font 1', value: 'Font 1' },
        { label: 'Font 2', value: 'Font 2' },
    ];
    sumDateSizeSelectItems: SelectItem[] = [
        { label: 'Size 1', value: 'Size 1' },
        { label: 'Size 2', value: 'Size 2' },
    ];
    sumAmountFontSelectItems: SelectItem[] = [
        { label: 'Font 1', value: 'Font 1' },
        { label: 'Font 2', value: 'Font 2' },
    ];
    sumAmountSizeSelectItems: SelectItem[] = [
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
