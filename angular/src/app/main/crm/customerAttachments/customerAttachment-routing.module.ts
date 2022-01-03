import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CustomerAttachmentsComponent } from './customerAttachments.component';

const routes: Routes = [
    {
        path: '',
        component: CustomerAttachmentsComponent,
        pathMatch: 'full',
    },
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule],
})
export class CustomerAttachmentRoutingModule {}
