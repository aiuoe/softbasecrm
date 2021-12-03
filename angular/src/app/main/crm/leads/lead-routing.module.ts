import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LeadsComponent } from './leads.component';
import { CreateOrEditLeadComponent } from './create-or-edit-lead.component';
import { ViewLeadComponent } from './view-lead.component';

const routes: Routes = [
    {
        path: '',
        component: LeadsComponent,
        pathMatch: 'full',
    },

    {
        path: 'createOrEdit',
        component: CreateOrEditLeadComponent,
        pathMatch: 'full',
    },

    {
        path: 'view',
        component: ViewLeadComponent,
        pathMatch: 'full',
    },
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule],
})
export class LeadRoutingModule {}
