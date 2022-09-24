import { NgModule } from '@angular/core';
import { AppSharedModule } from '@app/shared/app-shared.module';
import { AdminSharedModule } from '@app/admin/shared/admin-shared.module';
import { PriorityRoutingModule } from './priority-routing.module';
import { PrioritiesComponent } from './priorities.component';
import { CreateOrEditPriorityModalComponent } from './create-or-edit-priority-modal.component';
import { ViewPriorityModalComponent } from './view-priority-modal.component';

@NgModule({
    declarations: [PrioritiesComponent, CreateOrEditPriorityModalComponent, ViewPriorityModalComponent],
    imports: [AppSharedModule, PriorityRoutingModule, AdminSharedModule],
})
export class PriorityModule {}
