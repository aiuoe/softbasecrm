import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { BranchUpsertComponent } from './branch-upsert/branch-upsert.component';
import { BrowseMode } from './branch.model';
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
        data: { browseMode: BrowseMode.Add },
        pathMatch: 'full'
    },
    {
        path: ':id/view',
        component: BranchUpsertComponent,
        data: { browseMode: BrowseMode.View },
        pathMatch: 'full'
    },
    {
        path: ':id/edit',
        component: BranchUpsertComponent,
        data: { browseMode: BrowseMode.Edit },
        pathMatch: 'full'
    },
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule],
})
export class BranchRoutingModule { }