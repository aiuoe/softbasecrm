import { NgModule } from '@angular/core';
import { AppSharedModule } from '@app/shared/app-shared.module';
import { AdminSharedModule } from '@app/admin/shared/admin-shared.module';
import { OpportunityTypeRoutingModule } from './opportunityType-routing.module';
import { OpportunityTypesComponent } from './opportunityTypes.component';
import { CreateOrEditOpportunityTypeModalComponent } from './create-or-edit-opportunityType-modal.component';
import { ViewOpportunityTypeModalComponent } from './view-opportunityType-modal.component';

@NgModule({
    declarations: [
        OpportunityTypesComponent,
        CreateOrEditOpportunityTypeModalComponent,
        ViewOpportunityTypeModalComponent,
    ],
    imports: [AppSharedModule, OpportunityTypeRoutingModule, AdminSharedModule],
})
export class OpportunityTypeModule {}
