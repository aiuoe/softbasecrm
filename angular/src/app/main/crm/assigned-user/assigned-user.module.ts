import {NgModule} from '@angular/core';
import {AppSharedModule} from '@app/shared/app-shared.module';
import {AdminSharedModule} from '@app/admin/shared/admin-shared.module';
import {AssignedUserRoutingModule} from './assigned-user-routing.module';
import {AssignedUserComponent} from './assigned-user.component';
import {CreateOrEditAssignedUserModalComponent} from './create-or-edit-assined-user-modal.component';
import {ViewAssignedUserModalComponent} from './view-assigned-user-modal.component';



@NgModule({
    declarations: [
        AssignedUserComponent,
        CreateOrEditAssignedUserModalComponent,
        ViewAssignedUserModalComponent,
        
    ],
    imports: [AppSharedModule, AssignedUserRoutingModule , AdminSharedModule ],
    exports: [AssignedUserComponent]
    
})
export class AssignedUserModule {
}
