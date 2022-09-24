import { NgModule } from '@angular/core';
import { AppSharedModule } from '@app/shared/app-shared.module';
import { AdminSharedModule } from '@app/admin/shared/admin-shared.module';
import { OpportunitiesServiceProxy } from '@shared/service-proxies/service-proxies';
import { CheckboxModule } from 'primeng/checkbox';
import { TabViewModule } from 'primeng/tabview';
import { CalendarModule } from 'primeng/calendar';

import { DepartmentRoutingModule } from './department-routing.module';
import { DepartmentComponent } from './department.component';
import { DepartmentTabsComponent } from './department-tabs/department-tabs.component';
import { DepartmentAdditionalComponent } from './department-additional/department-additional.component';
import { DepartmentDocsComponent } from './department-docs/department-docs.component';
import { DepartmentRentalComponent } from './department-rental/department-rental.component';
import { DepartmentQuoteComponent } from './department-quote/department-quote.component';
import { DepartmentInvoiceComponent } from './department-invoice/department-invoice.component';
import { DepartmentMobileComponent } from './department-mobile/department-mobile.component';
import { InputTextareaModule } from 'primeng/inputtextarea';
import { TaxCodeSearchModalComponent } from '../../common/tax-codes-search/tax-code-search-modal.component';


@NgModule({
  declarations: [
    DepartmentComponent,
    DepartmentTabsComponent,
    DepartmentAdditionalComponent,
    DepartmentDocsComponent,
    DepartmentRentalComponent,
    DepartmentQuoteComponent,
    DepartmentInvoiceComponent,
    DepartmentMobileComponent,
    TaxCodeSearchModalComponent
  ],
  imports: [
    AppSharedModule,
    DepartmentRoutingModule,
    AdminSharedModule,
    CheckboxModule,
    TabViewModule,
    CalendarModule,
    InputTextareaModule
  ],
  providers: [
    OpportunitiesServiceProxy
  ]
})
export class DepartmentModule { }
