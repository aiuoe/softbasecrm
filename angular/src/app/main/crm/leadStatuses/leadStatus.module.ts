import { NgModule } from '@angular/core';
import { AppSharedModule } from '@app/shared/app-shared.module';
import { AdminSharedModule } from '@app/admin/shared/admin-shared.module';
import { LeadStatusRoutingModule } from './leadStatus-routing.module';
import { LeadStatusesComponent } from './leadStatuses.component';
import { CreateOrEditLeadStatusModalComponent } from './create-or-edit-leadStatus-modal.component';
import { ViewLeadStatusModalComponent } from './view-leadStatus-modal.component';
import { ColorPickerModule } from "primeng/colorpicker";

@NgModule({
    declarations: [LeadStatusesComponent, CreateOrEditLeadStatusModalComponent, ViewLeadStatusModalComponent],
    imports: [AppSharedModule, LeadStatusRoutingModule, AdminSharedModule, ColorPickerModule],
})
export class LeadStatusModule {}
