import { NgModule } from '@angular/core';
import { AppSharedModule } from '@app/shared/app-shared.module';
import { AdminSharedModule } from '@app/admin/shared/admin-shared.module';
import { CustomerRoutingModule } from './customer-routing.module';
import { CustomerComponent } from './customer.component';
import { CreateOrEditCustomerComponent } from './create-or-edit-customer.component';
import { ViewCustomerComponent } from './view-customer.component';

@NgModule({
    declarations: [CustomerComponent, CreateOrEditCustomerComponent, ViewCustomerComponent],
    imports: [AppSharedModule, CustomerRoutingModule, AdminSharedModule],
})
export class CustomerModule {}
