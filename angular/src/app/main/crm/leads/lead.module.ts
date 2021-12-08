import { NgModule } from '@angular/core';
import { AppSharedModule } from '@app/shared/app-shared.module';
import { AdminSharedModule } from '@app/admin/shared/admin-shared.module';
import { LeadRoutingModule } from './lead-routing.module';
import { LeadsComponent } from './leads.component';
import { CreateOrEditLeadComponent } from './create-or-edit-lead.component';
import { ViewLeadComponent } from './view-lead.component';

import { DialogModule } from 'primeng/dialog';
import { DropdownModule } from 'primeng/dropdown';
import { ImportLeadsModalComponent } from '@app/main/crm/leads/import-leads-modal.component';

@NgModule({
    declarations: [LeadsComponent, CreateOrEditLeadComponent, ViewLeadComponent, ImportLeadsModalComponent],
    imports: [AppSharedModule, LeadRoutingModule, AdminSharedModule, DialogModule, DropdownModule]
})
export class LeadModule {
}
