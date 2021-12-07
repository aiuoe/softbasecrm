import { NgModule } from '@angular/core';
import { AppSharedModule } from '@app/shared/app-shared.module';
import { AdminSharedModule } from '@app/admin/shared/admin-shared.module';
import { LeadRoutingModule } from './lead-routing.module';
import { LeadsComponent } from './leads.component';
import { CreateOrEditLeadComponent } from './create-or-edit-lead.component';
import { ViewLeadComponent } from './view-lead.component';
import { SplitButtonModule } from 'primeng/splitbutton';
import { DividerModule } from 'primeng/divider';
import { FieldsetModule } from 'primeng/fieldset';
import { PanelModule } from 'primeng/panel';
import {InputTextareaModule} from 'primeng/inputtextarea';

@NgModule({
    declarations: [LeadsComponent, CreateOrEditLeadComponent, ViewLeadComponent],
    imports: [AppSharedModule, LeadRoutingModule, AdminSharedModule, SplitButtonModule, DividerModule, FieldsetModule, PanelModule, InputTextareaModule],
})
export class LeadModule { }
