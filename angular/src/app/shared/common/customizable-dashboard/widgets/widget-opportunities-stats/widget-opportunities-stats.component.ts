import { Component, OnInit, Injector, ViewChild } from '@angular/core';
import { DateTimeService } from '@app/shared/common/timing/date-time.service';
import { OpportunitiesDashboardServiceProxy, OpportunityBranchLookupTableDto, OpportunityCustomerLookupTableDto, OpportunityDepartmentLookupTableDto, TenantDashboardServiceProxy } from '@shared/service-proxies/service-proxies';
import { DateTime } from 'luxon/src/datetime';
import { DashboardChartBase } from '../dashboard-chart-base';
import { WidgetComponentBaseComponent } from '../widget-component-base';

@Component({
    selector: 'app-opportunities-widget-top-stats',
    templateUrl: './widget-opportunities-stats.component.html',
    styleUrls: ['./widget-opportunities-stats.component.css'],
})
export class WidgetOpportunitiesTopStatsComponent extends WidgetComponentBaseComponent implements OnInit {

    opportunitesdashboard: OpportunitiesDashboardStats;
    branches: Array<OpportunityBranchLookupTableDto> = [];
    departments: Array<OpportunityDepartmentLookupTableDto> = [];
    accounts: Array<OpportunityCustomerLookupTableDto> = []; // aka customers
    accountFilter = null;
    branchFilter = null;
    departmentFilter = null;
    date: Date;
    selectedDateRange: DateTime[] = [
        this._dateTimeService.getStartOfMonth(),
        this._dateTimeService.getEndOfMonth(),
    ]; 

    constructor(injector: Injector,
        private _opportunitiesDashboardServiceProxy: OpportunitiesDashboardServiceProxy,
        private _dateTimeService: DateTimeService) {
        super(injector);
        this.opportunitesdashboard = new OpportunitiesDashboardStats();
    }

    ngOnInit() {
        this.loadTopOpportunitiesStatsData();
        this.loadBranches();
        this.loadDepartments();
        this.loadAccounts();
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

    onChange(dateRange){
        if (
            !dateRange ||
            dateRange.length !== 2 ||
            (this.selectedDateRange[0] === dateRange[0] && this.selectedDateRange[1] === dateRange[1])
        ) {
            return;
        }

        this.selectedDateRange[0] = dateRange[0];
        this.selectedDateRange[1] = dateRange[1];
    }

    onAccountChange($event){
        console.info(this.accountFilter);
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

