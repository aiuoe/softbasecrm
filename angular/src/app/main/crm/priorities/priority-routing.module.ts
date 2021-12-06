import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PrioritiesComponent } from './priorities.component';

const routes: Routes = [
    {
        path: '',
        component: PrioritiesComponent,
        pathMatch: 'full',
    },
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule],
})
export class PriorityRoutingModule {}
