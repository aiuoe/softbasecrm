import { NgModule } from '@angular/core';
import { AppSharedModule } from '@app/shared/app-shared.module';
import { AdminSharedModule } from '@app/admin/shared/admin-shared.module';
import { ActivitySourceTypeRoutingModule } from './activitySourceType-routing.module';
import { ActivitySourceTypesComponent } from './activitySourceTypes.component';
import { CreateOrEditActivitySourceTypeModalComponent } from './create-or-edit-activitySourceType-modal.component';
import { ViewActivitySourceTypeModalComponent } from './view-activitySourceType-modal.component';

@NgModule({
    declarations: [
        ActivitySourceTypesComponent,
        CreateOrEditActivitySourceTypeModalComponent,
        ViewActivitySourceTypeModalComponent,
    ],
    imports: [AppSharedModule, ActivitySourceTypeRoutingModule, AdminSharedModule],
})
export class ActivitySourceTypeModule {}
