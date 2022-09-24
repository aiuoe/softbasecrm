import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LeadStatusesComponent } from './leadStatuses.component';

const routes: Routes = [
    {
        path: '',
        component: LeadStatusesComponent,
        pathMatch: 'full',
    },
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule],
})
export class LeadStatusRoutingModule {}
