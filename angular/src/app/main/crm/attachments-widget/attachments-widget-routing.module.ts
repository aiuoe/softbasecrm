import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AttachmentsWidgetComponent } from './attachments-widget.component';

const routes: Routes = [
    {
        path: '',
        component: AttachmentsWidgetComponent,
        pathMatch: 'full',
    },
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule],
})
export class AttachmentsWidgetRoutingModule {}
