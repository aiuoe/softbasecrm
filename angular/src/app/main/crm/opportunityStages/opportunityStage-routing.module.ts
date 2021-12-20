import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {OpportunityStagesComponent} from './opportunityStages.component';



const routes: Routes = [
    {
        path: '',
        component: OpportunityStagesComponent,
        pathMatch: 'full'
    },
    
    
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule],
})
export class OpportunityStageRoutingModule {
}
