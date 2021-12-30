import { NgModule } from '@angular/core';
import { AppSharedModule } from '@app/shared/app-shared.module';
import { AdminSharedModule } from '@app/admin/shared/admin-shared.module';
import { OpportunityStageRoutingModule } from './opportunityStage-routing.module';
import { OpportunityStagesComponent } from './opportunityStages.component';
import { CreateOrEditOpportunityStageModalComponent } from './create-or-edit-opportunityStage-modal.component';
import { ViewOpportunityStageModalComponent } from './view-opportunityStage-modal.component';
import { ColorPickerModule } from "primeng/colorpicker";

@NgModule({
    declarations: [
        OpportunityStagesComponent,
        CreateOrEditOpportunityStageModalComponent,
        ViewOpportunityStageModalComponent,
    ],
    imports: [AppSharedModule, OpportunityStageRoutingModule, AdminSharedModule, ColorPickerModule],
})
export class OpportunityStageModule {}
