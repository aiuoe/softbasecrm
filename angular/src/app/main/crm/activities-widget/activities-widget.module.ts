import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ActivitiesWidgetComponent } from './activities-widget.component';
import { ActivitiesWidgetRoutingModule } from './activities-widget-routing.module';
import { UtilsModule } from '@shared/utils/utils.module';
import { AppSharedModule } from '@app/shared/app-shared.module';
import { AdminSharedModule } from '@app/admin/shared/admin-shared.module';
import { CreateOrEditActivityWidgetModalComponent } from './create-or-edit-activity-widget-modal.component';
import { CalendarModule } from 'primeng/calendar';
import { ActivitySharedService } from '@app/shared/common/crm/services/activity-shared.service';
import { AccountActivitiesServiceProxy, LeadActivitiesServiceProxy } from '@shared/service-proxies/service-proxies';



@NgModule({
  declarations: [
    ActivitiesWidgetComponent,
    CreateOrEditActivityWidgetModalComponent
  ],
  imports: [
    CommonModule,
    ActivitiesWidgetRoutingModule,
    UtilsModule,
    AppSharedModule,
    AdminSharedModule ,
    CalendarModule
  ],
  providers: [ActivitySharedService, LeadActivitiesServiceProxy, AccountActivitiesServiceProxy],
  exports: [ActivitiesWidgetComponent]
})
export class ActivitiesWidgetModule { }
