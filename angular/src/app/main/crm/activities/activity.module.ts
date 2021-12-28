﻿import { NgModule } from '@angular/core';
import { AppSharedModule } from '@app/shared/app-shared.module';
import { AdminSharedModule } from '@app/admin/shared/admin-shared.module';
import { ActivityRoutingModule } from './activity-routing.module';
import { ActivitiesComponent } from './activities.component';
import { CreateOrEditActivityModalComponent } from './create-or-edit-activity-modal.component';
import { ViewActivityModalComponent } from './view-activity-modal.component';
import { MultiSelectModule } from 'primeng/multiselect';
import { DropdownModule } from 'primeng/dropdown';
import { CheckboxModule } from 'primeng/checkbox';
import { ChipModule } from 'primeng/chip';
import { ButtonModule } from 'primeng/button';

@NgModule({
    declarations: [ActivitiesComponent, CreateOrEditActivityModalComponent, ViewActivityModalComponent],
    imports: [
        AppSharedModule,
        ActivityRoutingModule,
        AdminSharedModule,
        MultiSelectModule,
        DropdownModule,
        CheckboxModule,
        ChipModule,
        ButtonModule,
    ],
})
export class ActivityModule {}