import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PageMode } from '@shared/AppEnums';
import { BranchUpsertComponent } from './branch-upsert/branch-upsert.component';
import { BranchesComponent } from './branches.component';

const routes: Routes = [
    {
        path: '',
        component: BranchesComponent,
        pathMatch: 'full'
    },
    {
        path: 'add',
        component: BranchUpsertComponent,
        data: { pageMode: PageMode.Add },
        pathMatch: 'full'
    },
    {
        path: ':id/view',
        component: BranchUpsertComponent,
        data: { pageMode: PageMode.View },
        pathMatch: 'full'
    },
    {
        path: ':id/edit',
        component: BranchUpsertComponent,
        data: { pageMode: PageMode.Edit },
        pathMatch: 'full'
    },
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule],
})
export class BranchRoutingModule { }