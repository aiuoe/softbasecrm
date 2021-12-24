import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ActivityStatusesComponent } from './activityStatuses.component';

const routes: Routes = [
    {
        path: '',
        component: ActivityStatusesComponent,
        pathMatch: 'full',
    },
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule],
})
export class ActivityStatusRoutingModule {}
