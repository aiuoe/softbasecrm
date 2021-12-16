import { NgModule } from '@angular/core';
import { AppSharedModule } from '@app/shared/app-shared.module';
import { AdminSharedModule } from '@app/admin/shared/admin-shared.module';
import { OpportunityRoutingModule } from './opportunity-routing.module';
import { OpportunitiesComponent } from './opportunities.component';
import { CreateOrEditOpportunityComponent } from './create-or-edit-opportunity.component';
import { ViewOpportunityComponent } from './view-opportunity.component';
import { MultiSelectModule } from 'primeng/multiselect';

@NgModule({
    declarations: [OpportunitiesComponent, CreateOrEditOpportunityComponent, ViewOpportunityComponent],
    imports: [AppSharedModule, OpportunityRoutingModule, AdminSharedModule,MultiSelectModule],
})
export class OpportunityModule {}
