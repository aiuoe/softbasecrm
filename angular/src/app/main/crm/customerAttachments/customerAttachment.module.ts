import { NgModule } from '@angular/core';
import { AppSharedModule } from '@app/shared/app-shared.module';
import { AdminSharedModule } from '@app/admin/shared/admin-shared.module';
import { CustomerAttachmentRoutingModule } from './customerAttachment-routing.module';
import { CustomerAttachmentsComponent } from './customerAttachments.component';
import { CreateOrEditCustomerAttachmentModalComponent } from './create-or-edit-customerAttachment-modal.component';
import { ViewCustomerAttachmentModalComponent } from './view-customerAttachment-modal.component';

@NgModule({
    declarations: [
        CustomerAttachmentsComponent,
        CreateOrEditCustomerAttachmentModalComponent,
        ViewCustomerAttachmentModalComponent,
    ],
    imports: [AppSharedModule, CustomerAttachmentRoutingModule, AdminSharedModule],
})
export class CustomerAttachmentModule {}
