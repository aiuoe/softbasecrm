import { Component, Injector, ViewChild, ViewEncapsulation } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { SelectItem } from 'primeng/api';
import { PreviewFormatCheckFormatSetupCompanyModalComponent } from '../company-check-format-setup/company-check-format-setup-preview-format/company-check-format-setup-preview-format-modal.component';
import { CheckCheckFormatSetupCompanyTabComponent } from '../company-check-format-setup/company-check-format-setup-check/company-check-format-setup-check-tab.component';
import { RemittanceCheckFormatSetupCompanyTabComponent } from '../company-check-format-setup/company-check-format-setup-remittance/company-check-format-setup-remittance-tab.component';
import { StubCheckFormatSetupCompanyTabComponent } from '../company-check-format-setup/company-check-format-setup-stub/company-check-format-setup-stub-tab.component';

/***
 * Component for check format setup
 */
@Component({
    templateUrl: './company-check-format-setup.component.html',
    encapsulation: ViewEncapsulation.None,
    animations: [appModuleAnimation()],
})
export class CheckFormatSetupCompanyComponent extends AppComponentBase {
    checkFormatSelectItems: SelectItem[] = [
        { label: 'Format 1', value: 'Format 1' },
        { label: 'Format 2', value: 'Format 2' },
    ];
    format1SelectItems: SelectItem[] = [
        { label: 'Format 1', value: 'Format 1' },
        { label: 'Format 2', value: 'Format 2' },
    ];
    format2SelectItems: SelectItem[] = [
        { label: 'Format 1', value: 'Format 1' },
        { label: 'Format 2', value: 'Format 2' },
    ];
    
    @ViewChild('previewFormatCheckFormatSetupCompanyModal', { static: true })
    previewFormatCheckFormatSetupCompanyModal: PreviewFormatCheckFormatSetupCompanyModalComponent;
    @ViewChild('checkCheckFormatSetupCompanyTab', { static: true })
    checkCheckFormatSetupCompanyTab: CheckCheckFormatSetupCompanyTabComponent;
    @ViewChild('remittanceCheckFormatSetupCompanyTab', { static: true })
    remittanceCheckFormatSetupCompanyTab: RemittanceCheckFormatSetupCompanyTabComponent;
    @ViewChild('stubCheckFormatSetupCompanyTab', { static: true })
    stubCheckFormatSetupCompanyTab: StubCheckFormatSetupCompanyTabComponent;

    /***
     * Class constructor
     * @param injector
     */
    constructor(
        injector: Injector,
    ) {
        super(injector);
    }

    /***
     * Method that shows check format preview
     */
    previewFormat() {
        this.previewFormatCheckFormatSetupCompanyModal.show();
    }
}
