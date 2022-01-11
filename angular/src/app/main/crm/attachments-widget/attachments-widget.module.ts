import { NgModule } from '@angular/core';
import { AppSharedModule } from '@app/shared/app-shared.module';
import { AdminSharedModule } from '@app/admin/shared/admin-shared.module';
import { AttachmentsWidgetRoutingModule } from './attachments-widget-routing.module';
import { AttachmentsWidgetComponent } from './attachments-widget.component';
import { CreateOrEditAttachmentsWidgetModalComponent } from './create-or-edit-attachments-widget-modal.component';
import { ViewAttachmentsWidgetModalComponent } from './view-attachments-widget-modal.component';
import { CustomerAttachmentsServiceProxy, LeadAttachmentsServiceProxy, OpportunityAttachmentsServiceProxy } from '@shared/service-proxies/service-proxies';

@NgModule({
    declarations: [
        AttachmentsWidgetComponent,
        CreateOrEditAttachmentsWidgetModalComponent,
        ViewAttachmentsWidgetModalComponent,
    ],
    imports: [AppSharedModule, AttachmentsWidgetRoutingModule, AdminSharedModule],
    exports: [AttachmentsWidgetComponent, CreateOrEditAttachmentsWidgetModalComponent],
    providers: [LeadAttachmentsServiceProxy, OpportunityAttachmentsServiceProxy, CustomerAttachmentsServiceProxy]
})
export class AttachmentsWidgetModule {}
