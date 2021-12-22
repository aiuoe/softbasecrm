import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CustomerContactsComponent } from '@app/main/legacy/customerContacts/customer-contacts.component';

const routes: Routes = [
    {
        path: '',
        component: CustomerContactsComponent,
        pathMatch: 'full'
    }
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule],
})
export class CustomerContactsRoutingModule {
}
