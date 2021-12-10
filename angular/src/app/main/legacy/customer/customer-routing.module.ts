import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CustomerComponent } from './customer.component';
import { CreateOrEditCustomerComponent } from './create-or-edit-customer.component';
import { ViewCustomerComponent } from './view-customer.component';
import { AccountTypesServiceProxy } from '@shared/service-proxies/service-proxies';

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
        component: ViewCustomerComponent,
        pathMatch: 'full',
    },
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    providers: [AccountTypesServiceProxy],
    exports: [RouterModule],
})
export class CustomerRoutingModule {}
