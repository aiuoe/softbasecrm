import { NgModule } from '@angular/core';
import { AppSharedModule } from '@app/shared/app-shared.module';
import { AdminSharedModule } from '@app/admin/shared/admin-shared.module';
import { CheckboxModule } from 'primeng/checkbox';
import { RadioButtonModule } from 'primeng/radiobutton';
import { InputTextareaModule } from 'primeng/inputtextarea';
import { CompanyRoutingModule } from './company-routing.module';
import { CompanyComponent } from './company.component';
import { AccountingCompanyTabComponent } from './company-accounting/company-accounting-tab.component';
import { AccountSearchModalComponent } from '../../common/account-search/account-search-modal.component';
import { CreditCardCompanyTabComponent } from './company-credit-card/company-credit-card-tab.component';
import { SMTPCompanyTabComponent } from './company-smtp/company-smtp-tab.component';
import { InvoicingCompanyTabComponent } from './company-invoicing/company-invoicing-tab.component';
import { LoginsCompanyTabComponent } from './company-logins/company-logins-tab.component';
import { MarketingCompanyTabComponent } from './company-marketing/company-marketing-tab.component';
import { PrintFieldsCompanyTabComponent } from './company-print-fields/company-print-fields-tab.component';
import { EquipmentCommentsCompanyTabComponent } from './company-equipment-comments/company-equipment-comments-tab.component';
import { InvoiceCommentsCompanyTabComponent } from './company-invoice-comments/company-invoice-comments-tab.component';
import { LogoCompanyTabComponent } from './company-logo/company-logo-tab.component';

@NgModule({
    declarations: [
        CompanyComponent,
        AccountingCompanyTabComponent,
        AccountSearchModalComponent,
        CreditCardCompanyTabComponent,
        SMTPCompanyTabComponent,
        InvoicingCompanyTabComponent,
        LoginsCompanyTabComponent,
        MarketingCompanyTabComponent,
        PrintFieldsCompanyTabComponent,
        EquipmentCommentsCompanyTabComponent,
        InvoiceCommentsCompanyTabComponent,
        LogoCompanyTabComponent,
    ],
    imports: [
        AppSharedModule,
        CompanyRoutingModule,
        AdminSharedModule,
        CheckboxModule,
        RadioButtonModule,
        InputTextareaModule,
    ],
})
export class CompanyModule {}
