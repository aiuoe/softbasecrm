import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ActivityTaskTypesComponent } from './activityTaskTypes.component';

const routes: Routes = [
    {
        path: '',
        component: ActivityTaskTypesComponent,
        pathMatch: 'full',
    },
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule],
})
export class ActivityTaskTypeRoutingModule {}
