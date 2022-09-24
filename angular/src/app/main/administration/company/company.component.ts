import { Component, Injector, ViewEncapsulation, ViewChild } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { SelectItem } from 'primeng/api';
import { AccountingCompanyTabComponent } from './company-accounting/company-accounting-tab.component';
import { CreditCardCompanyTabComponent } from './company-credit-card/company-credit-card-tab.component';
import { SMTPCompanyTabComponent } from './company-smtp/company-smtp-tab.component';
import { InvoicingCompanyTabComponent } from './company-invoicing/company-invoicing-tab.component';
import { LoginsCompanyTabComponent } from './company-logins/company-logins-tab.component';
import { MarketingCompanyTabComponent } from './company-marketing/company-marketing-tab.component';
import { PrintFieldsCompanyTabComponent } from './company-print-fields/company-print-fields-tab.component';
import { EquipmentCommentsCompanyTabComponent } from './company-equipment-comments/company-equipment-comments-tab.component';
import { InvoiceCommentsCompanyTabComponent } from './company-invoice-comments/company-invoice-comments-tab.component';
import { LogoCompanyTabComponent } from './company-logo/company-logo-tab.component';

/***
 * Component to manage sale codes
 */
@Component({
    templateUrl: './company.component.html',
    encapsulation: ViewEncapsulation.None,
    animations: [appModuleAnimation()],
})
export class CompanyComponent extends AppComponentBase {
    countrySelectItems: SelectItem[] = [
        { label: 'Country 1', value: 'Country 1' },
        { label: 'Country 2', value: 'Country 2' },
    ];

    @ViewChild('accountingCompanyTab', { static: true })
    accountingCompanyTab: AccountingCompanyTabComponent;
    @ViewChild('creditCardCompanyTab', { static: true })
    creditCardCompanyTab: CreditCardCompanyTabComponent;
    @ViewChild('smtpCompanyTab', { static: true })
    smtpCompanyTab: SMTPCompanyTabComponent;
    @ViewChild('invoicingCompanyTab', { static: true })
    invoicingCompanyTab: InvoicingCompanyTabComponent;
    @ViewChild('loginsCompanyTab', { static: true })
    loginsCompanyTab: LoginsCompanyTabComponent;
    @ViewChild('marketingCompanyTab', { static: true })
    marketingCompanyTab: MarketingCompanyTabComponent;
    @ViewChild('printFieldsCompanyTab', { static: true })
    printFieldsCompanyTab: PrintFieldsCompanyTabComponent;
    @ViewChild('equipmentCommentsCompanyTab', { static: true })
    equipmentCommentsCompanyTab: EquipmentCommentsCompanyTabComponent;
    @ViewChild('invoiceCommentsCompanyTab', { static: true })
    invoiceCommentsCompanyTab: InvoiceCommentsCompanyTabComponent;
    @ViewChild('logoCompanyTab', { static: true })
    logoCompanyTab: LogoCompanyTabComponent;

    /***
     * Class constructor
     * @param injector
     */
    constructor(
        injector: Injector,
    ) {
        super(injector);
    }
}
