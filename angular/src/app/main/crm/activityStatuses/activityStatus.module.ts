import { NgModule } from '@angular/core';
import { AppSharedModule } from '@app/shared/app-shared.module';
import { AdminSharedModule } from '@app/admin/shared/admin-shared.module';
import { ActivityStatusRoutingModule } from './activityStatus-routing.module';
import { ActivityStatusesComponent } from './activityStatuses.component';
import { CreateOrEditActivityStatusModalComponent } from './create-or-edit-activityStatus-modal.component';
import { ViewActivityStatusModalComponent } from './view-activityStatus-modal.component';
import { ColorPickerModule } from 'primeng/colorpicker';

@NgModule({
    declarations: [
        ActivityStatusesComponent,
        CreateOrEditActivityStatusModalComponent,
        ViewActivityStatusModalComponent,
    ],
    imports: [AppSharedModule, ActivityStatusRoutingModule, AdminSharedModule, ColorPickerModule],
})
export class ActivityStatusModule {}
