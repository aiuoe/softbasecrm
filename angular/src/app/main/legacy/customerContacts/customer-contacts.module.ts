import { NgModule } from '@angular/core';
import { AppSharedModule } from '@app/shared/app-shared.module';
import { AdminSharedModule } from '@app/admin/shared/admin-shared.module';
import { CustomerContactsComponent } from './customer-contacts.component';
import { CustomerContactsRoutingModule } from './customer-contacts-routing.module';
import { ContactsServiceProxy } from '@shared/service-proxies/service-proxies';
import {
    CreateOrEditCustomerContactModalComponent
} from '@app/main/legacy/customerContacts/create-or-edit-customer-contact-modal.component';

@NgModule({
    providers: [
        ContactsServiceProxy
    ],
    declarations: [
        CustomerContactsComponent,
        CreateOrEditCustomerContactModalComponent
    ],
    imports: [AppSharedModule, CustomerContactsRoutingModule, AdminSharedModule],
    exports: [CustomerContactsComponent]

})

export class CustomerContactsModule {
}
