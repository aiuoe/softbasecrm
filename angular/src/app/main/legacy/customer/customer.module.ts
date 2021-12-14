import { NgModule } from '@angular/core';
import { AppSharedModule } from '@app/shared/app-shared.module';
import { AdminSharedModule } from '@app/admin/shared/admin-shared.module';
import { CustomerRoutingModule } from './customer-routing.module';
import { CustomerComponent } from './customer.component';
import { CreateOrEditCustomerComponent } from './create-or-edit-customer.component';
import { ViewCustomerComponent } from './view-customer.component';
import { AccountTypesServiceProxy, ZipCodesServiceProxy } from '@shared/service-proxies/service-proxies';
import { MultiSelectModule } from '@node_modules/primeng/multiselect';
import { AssignedUserModule } from '@app/main/crm/assigned-user/assigned-user.module';

@NgModule({
    providers: [AccountTypesServiceProxy, ZipCodesServiceProxy],
    declarations: [CustomerComponent, CreateOrEditCustomerComponent, ViewCustomerComponent],
    imports: [AppSharedModule, CustomerRoutingModule, AdminSharedModule, MultiSelectModule, AssignedUserModule]
})
export class CustomerModule {}
