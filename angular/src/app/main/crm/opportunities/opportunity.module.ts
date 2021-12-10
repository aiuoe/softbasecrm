import { NgModule } from '@angular/core';
import { AppSharedModule } from '@app/shared/app-shared.module';
import { AdminSharedModule } from '@app/admin/shared/admin-shared.module';
import { OpportunityRoutingModule } from './opportunity-routing.module';
import { OpportunitiesComponent } from './opportunities.component';
import { CreateOrEditOpportunityModalComponent } from './create-or-edit-opportunity-modal.component';
import { ViewOpportunityModalComponent } from './view-opportunity-modal.component';
import { OpportunityOpportunityStageLookupTableModalComponent } from './opportunity-opportunityStage-lookup-table-modal.component';
import { OpportunityLeadSourceLookupTableModalComponent } from './opportunity-leadSource-lookup-table-modal.component';
import { OpportunityOpportunityTypeLookupTableModalComponent } from './opportunity-opportunityType-lookup-table-modal.component';

@NgModule({
    declarations: [
        OpportunitiesComponent,
        CreateOrEditOpportunityModalComponent,
        ViewOpportunityModalComponent,

        OpportunityOpportunityStageLookupTableModalComponent,
        OpportunityLeadSourceLookupTableModalComponent,
        OpportunityOpportunityTypeLookupTableModalComponent,
    ],
    imports: [AppSharedModule, OpportunityRoutingModule, AdminSharedModule],
})
export class OpportunityModule {}
