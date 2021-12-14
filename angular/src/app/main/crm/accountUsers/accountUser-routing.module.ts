import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {AccountUsersComponent} from './accountUsers.component';



const routes: Routes = [
    {
        path: '',
        component: AccountUsersComponent,
        pathMatch: 'full'
    },
    
    
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule],
})
export class AccountUserRoutingModule {
}
