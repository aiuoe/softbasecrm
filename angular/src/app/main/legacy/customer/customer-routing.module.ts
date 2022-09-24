import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CustomersComponent } from './customers.component';
import { CreateOrEditCustomerComponent } from './create-or-edit-customer.component';

const routes: Routes = [
    {
        path: '',
        component: CustomersComponent,
        pathMatch: 'full',
    },

    {
        path: 'createOrEdit',
        component: CreateOrEditCustomerComponent,
        pathMatch: 'full',
    },

    {
        path: 'view',
        component: CreateOrEditCustomerComponent,
        pathMatch: 'full',
    },
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule],
})
export class CustomerRoutingModule {}
