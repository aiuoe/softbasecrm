import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ActivityPrioritiesComponent } from './activityPriorities.component';

const routes: Routes = [
    {
        path: '',
        component: ActivityPrioritiesComponent,
        pathMatch: 'full',
    },
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule],
})
export class ActivityPriorityRoutingModule {}
