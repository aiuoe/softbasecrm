import { NgModule } from '@angular/core';
import { AppSharedModule } from '@app/shared/app-shared.module';
import { AdminSharedModule } from '@app/admin/shared/admin-shared.module';
import { CheckboxModule } from 'primeng/checkbox';
import { TabViewModule } from 'primeng/tabview';
import { CheckFormatSetupCompanyRoutingModule } from './company-check-format-setup-routing.module';
import { CheckFormatSetupCompanyComponent } from './company-check-format-setup.component';
import { PreviewFormatCheckFormatSetupCompanyModalComponent } from '../company-check-format-setup/company-check-format-setup-preview-format/company-check-format-setup-preview-format-modal.component';
import { CheckCheckFormatSetupCompanyTabComponent } from '../company-check-format-setup/company-check-format-setup-check/company-check-format-setup-check-tab.component';
import { RemittanceCheckFormatSetupCompanyTabComponent } from '../company-check-format-setup/company-check-format-setup-remittance/company-check-format-setup-remittance-tab.component';
import { StubCheckFormatSetupCompanyTabComponent } from '../company-check-format-setup/company-check-format-setup-stub/company-check-format-setup-stub-tab.component';

@NgModule({
    declarations: [
        CheckFormatSetupCompanyComponent,
        PreviewFormatCheckFormatSetupCompanyModalComponent,
        CheckCheckFormatSetupCompanyTabComponent,
        RemittanceCheckFormatSetupCompanyTabComponent,
        StubCheckFormatSetupCompanyTabComponent,
    ],
    imports: [
        AppSharedModule,
        CheckFormatSetupCompanyRoutingModule,
        AdminSharedModule,
        CheckboxModule,
        TabViewModule,
    ],
})
export class CheckFormatSetupCompanyModule {}
