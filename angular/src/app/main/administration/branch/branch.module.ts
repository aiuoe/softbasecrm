import {NgModule} from '@angular/core';
import { AdminSharedModule } from '@app/admin/shared/admin-shared.module';
import {AppSharedModule} from '@app/shared/app-shared.module';
import { CheckboxModule } from 'primeng/checkbox';
import { MultiSelectModule } from 'primeng/multiselect';
import {BranchRoutingModule} from './branch-routing.module';
import { BranchComponent } from './branch.component';

@NgModule({
    declarations: [
        BranchComponent
    ],
    imports: [
        AdminSharedModule,
        AppSharedModule, 
        BranchRoutingModule,
        CheckboxModule,
        MultiSelectModule
    ]
})
export class BranchModule {}