import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AssignedUserComponent } from './assigned-user.component';


const routes: Routes = [
    {
        path: '',
        component: AssignedUserComponent,
        pathMatch: 'full'
    }
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule],
})
export class AssignedUserRoutingModule {
}
