import { NgModule } from '@angular/core';
import { AppSharedModule } from '@app/shared/app-shared.module';
import { AdminSharedModule } from '@app/admin/shared/admin-shared.module';
import { ActivityPriorityRoutingModule } from './activityPriority-routing.module';
import { ActivityPrioritiesComponent } from './activityPriorities.component';
import { CreateOrEditActivityPriorityModalComponent } from './create-or-edit-activityPriority-modal.component';
import { ViewActivityPriorityModalComponent } from './view-activityPriority-modal.component';

@NgModule({
    declarations: [
        ActivityPrioritiesComponent,
        CreateOrEditActivityPriorityModalComponent,
        ViewActivityPriorityModalComponent,
    ],
    imports: [AppSharedModule, ActivityPriorityRoutingModule, AdminSharedModule],
})
export class ActivityPriorityModule {}
