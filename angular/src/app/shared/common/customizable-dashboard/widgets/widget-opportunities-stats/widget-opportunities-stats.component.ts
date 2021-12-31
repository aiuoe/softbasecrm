import { Component, OnInit, Injector } from '@angular/core';
import { OpportunitiesDashboardServiceProxy, OpportunityBranchLookupTableDto, OpportunityCustomerLookupTableDto, OpportunityDepartmentLookupTableDto, TenantDashboardServiceProxy } from '@shared/service-proxies/service-proxies';
import { DashboardChartBase } from '../dashboard-chart-base';
import { WidgetComponentBaseComponent } from '../widget-component-base';

@Component({
    selector: 'app-opportunities-widget-top-stats',
    templateUrl: './widget-opportunities-stats.component.html',
    styleUrls: ['./widget-opportunities-stats.component.css'],
})
export class WidgetOpportunitiesTopStatsComponent extends WidgetComponentBaseComponent implements OnInit {
    dashboardTopStats: OpportunitiesTopStats;
    opportunitesdashboard: OpportunitiesDashboardStats;
    branches: Array<OpportunityBranchLookupTableDto> = [];
    departments: Array<OpportunityDepartmentLookupTableDto> = [];
    accounts: Array<OpportunityCustomerLookupTableDto> = []; // aka customers
    defualtValue = { name: "All", id: null };
    accountFilter = { name: "All", number: null };
    branchFilter = this.defualtValue;
    departmentFilter = this.defualtValue;
    constructor(injector: Injector,
        private _tenantDashboardServiceProxy: TenantDashboardServiceProxy,
        private _opportunitiesDashboardServiceProxy: OpportunitiesDashboardServiceProxy) {
        super(injector);
        this.dashboardTopStats = new OpportunitiesTopStats();
        this.opportunitesdashboard = new OpportunitiesDashboardStats();
    }

    ngOnInit() {
        this.loadTopStatsData();
        this.loadTopOpportunitiesStatsData();
        this.loadBranches();
        this.loadDepartments();
        this.loadAccounts();
    }

    loadTopStatsData() {
        this._tenantDashboardServiceProxy.getTopStats().subscribe((data) => {
            this.dashboardTopStats.init(data.totalProfit, data.newFeedbacks, data.newOrders, data.newUsers);
        });
    }

    loadTopOpportunitiesStatsData() {
        this._opportunitiesDashboardServiceProxy.get(undefined, undefined, undefined, undefined, undefined)
            .subscribe((data) => {
                this.opportunitesdashboard.init(data.averageSales, data.closeRate, data.averageDealSize, data.totalClosedSales);
            });
    }

    loadBranches() {
        this._opportunitiesDashboardServiceProxy.getAllBranchForTableDropdown()
            .subscribe((data) => {
                this.branches = [...data];
            });
    }

    loadDepartments() {
        this._opportunitiesDashboardServiceProxy.getAllDepartmentForTableDropdown()
            .subscribe((data) => {
                this.departments = [...data];
            });
    }

    loadAccounts() {
        this._opportunitiesDashboardServiceProxy.getAllCustomerForTableDropdown()
            .subscribe((data) => {
                this.accounts = [...data];
            });
    }
}

class OpportunitiesTopStats extends DashboardChartBase {
    totalProfit = 0;
    totalProfitCounter = 0;
    newFeedbacks = 0;
    newFeedbacksCounter = 0;
    newOrders = 0;
    newOrdersCounter = 0;
    newUsers = 0;
    newUsersCounter = 0;

    totalProfitChange = 76;
    totalProfitChangeCounter = 0;
    newFeedbacksChange = 85;
    newFeedbacksChangeCounter = 0;
    newOrdersChange = 45;
    newOrdersChangeCounter = 0;
    newUsersChange = 57;
    newUsersChangeCounter = 0;

    init(totalProfit, newFeedbacks, newOrders, newUsers) {
        this.totalProfit = totalProfit;
        this.newFeedbacks = newFeedbacks;
        this.newOrders = newOrders;
        this.newUsers = newUsers;
        this.hideLoading();
    }
}

class OpportunitiesDashboardStats extends DashboardChartBase {
    averageSales = 0;
    closeRate = 0;
    averageDealSize = 0;
    totalClosedSales = 0;

    init(averageSales, closeRate, averageDealSize, totalClosedSales) {
        this.averageSales = averageSales;
        this.closeRate = closeRate;
        this.averageDealSize = averageDealSize;
        this.totalClosedSales = totalClosedSales;
        this.hideLoading();
    }
}

