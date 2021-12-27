import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ActivitySourceTypesComponent } from './activitySourceTypes.component';

const routes: Routes = [
    {
        path: '',
        component: ActivitySourceTypesComponent,
        pathMatch: 'full',
    },
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule],
})
export class ActivitySourceTypeRoutingModule {}
