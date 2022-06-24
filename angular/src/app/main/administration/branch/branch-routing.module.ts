import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {BranchComponent} from './branch.component';

const routes: Routes = [{
    path: '',
    component: BranchComponent,
    pathMatch: 'full'
}];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule],
})
export class BranchRoutingModule {}