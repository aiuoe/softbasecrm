import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CustomerComponent } from './customer.component';
import { CreateOrEditCustomerComponent } from './create-or-edit-customer.component';
import { ViewCustomerComponent } from './view-customer.component';

const routes: Routes = [
    {
        path: '',
        component: CustomerComponent,
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
