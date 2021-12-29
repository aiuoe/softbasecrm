import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ActivitiesWidgetComponent } from './activities-widget.component';
import { ActivitiesWidgetRoutingModule } from './activities-widget-routing.module';
import { UtilsModule } from '@shared/utils/utils.module';
import { AppSharedModule } from '@app/shared/app-shared.module';
import { AdminSharedModule } from '@app/admin/shared/admin-shared.module';



@NgModule({
  declarations: [
    ActivitiesWidgetComponent
  ],
  imports: [
    CommonModule,
    ActivitiesWidgetRoutingModule,
    UtilsModule,
    AppSharedModule,
    AdminSharedModule 
  ],
  exports: [ActivitiesWidgetComponent]
})
export class ActivitiesWidgetModule { }
