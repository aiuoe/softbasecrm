﻿import {NgModule} from '@angular/core';
import {AppSharedModule} from '@app/shared/app-shared.module';
import {AdminSharedModule} from '@app/admin/shared/admin-shared.module';
import {AccountUserRoutingModule} from './accountUser-routing.module';
import {AccountUsersComponent} from './accountUsers.component';
import {CreateOrEditAccountUserModalComponent} from './create-or-edit-accountUser-modal.component';
import {ViewAccountUserModalComponent} from './view-accountUser-modal.component';
import {AccountUserUserLookupTableModalComponent} from './accountUser-user-lookup-table-modal.component';
    					


@NgModule({
    declarations: [
        AccountUsersComponent,
        CreateOrEditAccountUserModalComponent,
        ViewAccountUserModalComponent,
        
    					AccountUserUserLookupTableModalComponent,
    ],
    imports: [AppSharedModule, AccountUserRoutingModule , AdminSharedModule ],
    
})
export class AccountUserModule {
}
