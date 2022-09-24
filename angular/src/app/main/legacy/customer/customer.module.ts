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
    LeadUsersServiceProxy,
    OpportunityUsersServiceProxy,
    ZipCodesServiceProxy
} from '@shared/service-proxies/service-proxies';
import { MultiSelectModule } from '@node_modules/primeng/multiselect';
import { CheckboxModule } from '@node_modules/primeng/checkbox';
import { AssignedUserModule } from '@app/main/crm/assigned-user/assigned-user.module';
import { CustomerContactsModule } from '@app/main/legacy/customerContacts/customer-contacts.module';
import { ActivitiesWidgetModule } from '@app/main/crm/activities-widget/activities-widget.module';
import { AttachmentsWidgetModule } from '@app/main/crm/attachments-widget/attachments-widget.module';

@NgModule({
    providers: [
        AccountTypesServiceProxy,
        ZipCodesServiceProxy,
        CountriesServiceProxy,
        LeadUsersServiceProxy,
        OpportunityUsersServiceProxy
    ],
    declarations: [
        CustomersComponent,
        CreateOrEditCustomerComponent,
        ViewCustomerComponent
    ],
    imports: [
        AppSharedModule,
        CustomerRoutingModule,
        AdminSharedModule,
        MultiSelectModule,
        CheckboxModule,
        AssignedUserModule,
        AttachmentsWidgetModule,
        CustomerContactsModule,
        ActivitiesWidgetModule
    ]
})

export class CustomerModule {
}
