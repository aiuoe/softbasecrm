import { NgModule } from '@angular/core';
import { AppSharedModule } from '@app/shared/app-shared.module';
import { AdminSharedModule } from '@app/admin/shared/admin-shared.module';
import { ActivityTaskTypeRoutingModule } from './activityTaskType-routing.module';
import { ActivityTaskTypesComponent } from './activityTaskTypes.component';
import { CreateOrEditActivityTaskTypeModalComponent } from './create-or-edit-activityTaskType-modal.component';
import { ViewActivityTaskTypeModalComponent } from './view-activityTaskType-modal.component';

@NgModule({
    declarations: [
        ActivityTaskTypesComponent,
        CreateOrEditActivityTaskTypeModalComponent,
        ViewActivityTaskTypeModalComponent,
    ],
    imports: [AppSharedModule, ActivityTaskTypeRoutingModule, AdminSharedModule],
})
export class ActivityTaskTypeModule {}
