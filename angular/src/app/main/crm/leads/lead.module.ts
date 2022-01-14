import { NgModule } from '@angular/core';
import { AppSharedModule } from '@app/shared/app-shared.module';
import { AdminSharedModule } from '@app/admin/shared/admin-shared.module';
import { LeadRoutingModule } from './lead-routing.module';
import { LeadsComponent } from './leads.component';
import { CreateOrEditLeadComponent } from './create-or-edit-lead.component';
import { InputTextareaModule } from 'primeng/inputtextarea';
import { MultiSelectModule } from 'primeng/multiselect';
import { DialogModule } from 'primeng/dialog';
import { DropdownModule } from 'primeng/dropdown';
import { ImportLeadsModalComponent } from '@app/main/crm/leads/import-leads-modal.component';
import { AssignedUserModule } from '../assigned-user/assigned-user.module';
import {
    LeadUsersServiceProxy,
    OpportunityUsersServiceProxy,
    ZipCodesServiceProxy
} from '@shared/service-proxies/service-proxies';
import { ActivitiesWidgetModule } from '../activities-widget/activities-widget.module';
import { AttachmentsWidgetModule } from '../attachments-widget/attachments-widget.module';

@NgModule({
    declarations: [
        LeadsComponent,
        CreateOrEditLeadComponent,
        ImportLeadsModalComponent
    ],
    imports: [
        AppSharedModule,
        LeadRoutingModule,
        AdminSharedModule,
        InputTextareaModule,
        DialogModule,
        DropdownModule,
        MultiSelectModule,
        AssignedUserModule,
        ActivitiesWidgetModule,
        AttachmentsWidgetModule
    ],
    providers: [
        ZipCodesServiceProxy,
        LeadUsersServiceProxy,
        OpportunityUsersServiceProxy
    ]
})
export class LeadModule {
}

