import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { OpportunitiesComponent } from './opportunities.component';

const routes: Routes = [
    {
        path: '',
        component: OpportunitiesComponent,
        pathMatch: 'full',
    },
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule],
})
export class OpportunityRoutingModule {}
