import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import {
    CustomizableDashboardComponent
} from '@app/shared/common/customizable-dashboard/customizable-dashboard.component';
import {
    WidgetGeneralStatsComponent
} from '@app/shared/common/customizable-dashboard/widgets/widget-general-stats/widget-general-stats.component';
import {
    DashboardViewConfigurationService
} from '@app/shared/common/customizable-dashboard/dashboard-view-configuration.service';
import { GridsterModule } from 'angular-gridster2';
import {
    WidgetDailySalesComponent
} from '@app/shared/common/customizable-dashboard/widgets/widget-daily-sales/widget-daily-sales.component';
import {
    WidgetEditionStatisticsComponent
} from '@app/shared/common/customizable-dashboard/widgets/widget-edition-statistics/widget-edition-statistics.component';
import {
    WidgetHostTopStatsComponent
} from '@app/shared/common/customizable-dashboard/widgets/widget-host-top-stats/widget-host-top-stats.component';
import {
    WidgetIncomeStatisticsComponent
} from '@app/shared/common/customizable-dashboard/widgets/widget-income-statistics/widget-income-statistics.component';
import {
    WidgetMemberActivityComponent
} from '@app/shared/common/customizable-dashboard/widgets/widget-member-activity/widget-member-activity.component';
import {
    WidgetProfitShareComponent
} from '@app/shared/common/customizable-dashboard/widgets/widget-profit-share/widget-profit-share.component';
import {
    WidgetRecentTenantsComponent
} from '@app/shared/common/customizable-dashboard/widgets/widget-recent-tenants/widget-recent-tenants.component';
import {
    WidgetRegionalStatsComponent
} from '@app/shared/common/customizable-dashboard/widgets/widget-regional-stats/widget-regional-stats.component';
import {
    WidgetSalesSummaryComponent
} from '@app/shared/common/customizable-dashboard/widgets/widget-sales-summary/widget-sales-summary.component';
import {
    WidgetSubscriptionExpiringTenantsComponent
} from '@app/shared/common/customizable-dashboard/widgets/widget-subscription-expiring-tenants/widget-subscription-expiring-tenants.component';
import {
    WidgetTopStatsComponent
} from '@app/shared/common/customizable-dashboard/widgets/widget-top-stats/widget-top-stats.component';
import {
    FilterDateRangePickerComponent
} from '@app/shared/common/customizable-dashboard/filters/filter-date-range-picker/filter-date-range-picker.component';
import {
    AddWidgetModalComponent
} from '@app/shared/common/customizable-dashboard/add-widget-modal/add-widget-modal.component';
import { PieChartModule, AreaChartModule, LineChartModule, BarChartModule } from '@swimlane/ngx-charts';
import { WidgetComponentBaseComponent } from './widgets/widget-component-base';
import { UtilsModule } from '@shared/utils/utils.module';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { ModalModule } from 'ngx-bootstrap/modal';
import { FormsModule } from '@angular/forms';
import { TabsModule } from 'ngx-bootstrap/tabs';
import { PerfectScrollbarModule } from 'ngx-perfect-scrollbar';
import { AppBsModalModule } from '@shared/common/appBsModal/app-bs-modal.module';
import { CountoModule } from 'angular2-counto';
import { TableModule } from 'primeng/table';
import { CalendarModule } from 'primeng/calendar';
import { PaginatorModule } from 'primeng/paginator';
import { BsDatepickerModule } from 'ngx-bootstrap/datepicker';
import { SubheaderModule } from '../sub-header/subheader.module';
import {
    WidgetOpportunitiesListComponent
} from './widgets/widget-opportunities-list/widget-opportunities-list.component';
import {
    WidgetOpportunitiesTopStatsComponent
} from './widgets/widget-opportunities-stats/widget-opportunities-stats.component';
import { DropdownModule } from 'primeng/dropdown';
import { MultiSelectModule } from 'primeng/multiselect';
import { OpportunityRoutingModule } from '@app/main/crm/opportunities/opportunity-routing.module';
import { TooltipModule } from 'primeng/tooltip';

@NgModule({
    imports: [
        CommonModule,
        FormsModule,
        UtilsModule,
        GridsterModule,
        PieChartModule,
        AreaChartModule,
        LineChartModule,
        BarChartModule,
        BsDropdownModule,
        ModalModule,
        TabsModule,
        PerfectScrollbarModule,
        AppBsModalModule,
        CountoModule,
        TableModule,
        BsDatepickerModule,
        SubheaderModule,
        DropdownModule,
        MultiSelectModule,
        OpportunityRoutingModule,
        PaginatorModule,
        CalendarModule,
        TooltipModule
    ],

    declarations: [
        CustomizableDashboardComponent,
        WidgetGeneralStatsComponent,
        WidgetDailySalesComponent,
        WidgetEditionStatisticsComponent,
        WidgetHostTopStatsComponent,
        WidgetIncomeStatisticsComponent,
        WidgetMemberActivityComponent,
        WidgetProfitShareComponent,
        WidgetRecentTenantsComponent,
        WidgetRegionalStatsComponent,
        WidgetSalesSummaryComponent,
        WidgetSubscriptionExpiringTenantsComponent,
        WidgetTopStatsComponent,
        FilterDateRangePickerComponent,
        AddWidgetModalComponent,
        WidgetComponentBaseComponent,
        WidgetOpportunitiesListComponent,
        WidgetOpportunitiesTopStatsComponent
    ],

    providers: [DashboardViewConfigurationService],

    exports: [
        CustomizableDashboardComponent,
        WidgetGeneralStatsComponent,
        WidgetDailySalesComponent,
        WidgetEditionStatisticsComponent,
        WidgetHostTopStatsComponent,
        WidgetIncomeStatisticsComponent,
        WidgetMemberActivityComponent,
        WidgetProfitShareComponent,
        WidgetRecentTenantsComponent,
        WidgetRegionalStatsComponent,
        WidgetSalesSummaryComponent,
        WidgetSubscriptionExpiringTenantsComponent,
        WidgetTopStatsComponent,
        FilterDateRangePickerComponent,
        AddWidgetModalComponent,
        WidgetOpportunitiesListComponent,
        WidgetOpportunitiesTopStatsComponent
    ],
})
export class CustomizableDashboardModule {
}
