import { NgModule } from '@angular/core';
import { AppSharedModule } from '@app/shared/app-shared.module';
import { AdminSharedModule } from '@app/admin/shared/admin-shared.module';
import { CustomerRoutingModule } from './customer-routing.module';
import { CustomersComponent } from './customers.component';
import { CreateOrEditCustomerComponent } from './create-or-edit-customer.component';
import { ViewCustomerComponent } from './view-customer.component';
import {
    AccountTypesServiceProxy,
    CountriesServiceProxy,
    ZipCodesServiceProxy
} from '@shared/service-proxies/service-proxies';
import { MultiSelectModule } from '@node_modules/primeng/multiselect';
import { CheckboxModule } from '@node_modules/primeng/checkbox';
import { AssignedUserModule } from '@app/main/crm/assigned-user/assigned-user.module';

@NgModule({
    providers: [AccountTypesServiceProxy, ZipCodesServiceProxy, CountriesServiceProxy],
    declarations: [CustomersComponent, CreateOrEditCustomerComponent, ViewCustomerComponent],
  imports: [AppSharedModule, CustomerRoutingModule, AdminSharedModule, MultiSelectModule, CheckboxModule, AssignedUserModule]
})

export class CustomerModule {}
