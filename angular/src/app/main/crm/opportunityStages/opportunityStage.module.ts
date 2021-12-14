import { NgModule } from '@angular/core';
import { AppSharedModule } from '@app/shared/app-shared.module';
import { AdminSharedModule } from '@app/admin/shared/admin-shared.module';
import { OpportunityStageRoutingModule } from './opportunityStage-routing.module';
import { OpportunityStagesComponent } from './opportunityStages.component';
import { CreateOrEditOpportunityStageComponent } from './create-or-edit-opportunityStage.component';
import { ViewOpportunityStageComponent } from './view-opportunityStage.component';

@NgModule({
    declarations: [OpportunityStagesComponent, CreateOrEditOpportunityStageComponent, ViewOpportunityStageComponent],
    imports: [AppSharedModule, OpportunityStageRoutingModule, AdminSharedModule],
})
export class OpportunityStageModule {}
