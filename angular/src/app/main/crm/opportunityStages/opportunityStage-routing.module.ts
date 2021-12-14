import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { OpportunityStagesComponent } from './opportunityStages.component';
import { CreateOrEditOpportunityStageComponent } from './create-or-edit-opportunityStage.component';
import { ViewOpportunityStageComponent } from './view-opportunityStage.component';

const routes: Routes = [
    {
        path: '',
        component: OpportunityStagesComponent,
        pathMatch: 'full',
    },

    {
        path: 'createOrEdit',
        component: CreateOrEditOpportunityStageComponent,
        pathMatch: 'full',
    },

    {
        path: 'view',
        component: ViewOpportunityStageComponent,
        pathMatch: 'full',
    },
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule],
})
export class OpportunityStageRoutingModule {}
