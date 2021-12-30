import { NgModule } from '@angular/core';
import { AppSharedModule } from '@app/shared/app-shared.module';
import { AdminSharedModule } from '@app/admin/shared/admin-shared.module';
import { OpportunityRoutingModule } from './opportunity-routing.module';
import { OpportunitiesComponent } from './opportunities.component';
import { CreateOrEditOpportunityComponent } from './create-or-edit-opportunity.component';
import { ViewOpportunityComponent } from './view-opportunity.component';
import { MultiSelectModule } from 'primeng/multiselect';
import { InputNumberModule } from 'primeng/inputNumber';
import { CalendarModule } from 'primeng/calendar';
import { AssignedUserModule } from '../assigned-user/assigned-user.module';
import { LeadUsersServiceProxy, OpportunityUsersServiceProxy } from '@shared/service-proxies/service-proxies';
import { MomentFormatPipe } from '@shared/utils/moment-format.pipe';

@NgModule({
    declarations: [
        OpportunitiesComponent,
        CreateOrEditOpportunityComponent,
        ViewOpportunityComponent,
        MomentFormatPipe
    ],
    imports: [
        AppSharedModule,
        OpportunityRoutingModule,
        AdminSharedModule,
        MultiSelectModule,
        InputNumberModule,
        CalendarModule,
        AssignedUserModule],

    providers: [LeadUsersServiceProxy, OpportunityUsersServiceProxy]
})

export class OpportunityModule {
}
