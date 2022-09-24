import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {OpportunityTypesComponent} from './opportunityTypes.component';



const routes: Routes = [
    {
        path: '',
        component: OpportunityTypesComponent,
        pathMatch: 'full'
    },
    
    
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule],
})
export class OpportunityTypeRoutingModule {
}
