import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { OpportunitiesComponent } from './opportunities.component';
import { CreateOrEditOpportunityComponent } from './create-or-edit-opportunity.component';

const routes: Routes = [
    {
        path: '',
        component: OpportunitiesComponent,
        pathMatch: 'full',
    },

    {
        path: 'createOrEdit',
        component: CreateOrEditOpportunityComponent,
        pathMatch: 'full',
    },

    {
        path: 'view',
        component: CreateOrEditOpportunityComponent,
        pathMatch: 'full',
    },
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule],
})
export class OpportunityRoutingModule {}
