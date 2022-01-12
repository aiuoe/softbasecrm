import { Component, OnInit, Injector } from '@angular/core';
import { DateTimeService } from '@app/shared/common/timing/date-time.service';
import {
    OpportunitiesDashboardServiceProxy,
    BranchLookupTableDto,
    OpportunityCustomerLookupTableDto,
    DepartmentLookupTableDto
} from '@shared/service-proxies/service-proxies';
import { FileDownloadService } from '@shared/utils/file-download.service';
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
    branches: Array<BranchLookupTableDto> = [];
    departments: Array<DepartmentLookupTableDto> = [];
    accounts: Array<OpportunityCustomerLookupTableDto> = []; // aka customers
    accountFilter = undefined;
    branchFilter = undefined;
    departmentFilter = undefined;
    date: Date;
    selectedDateRange: DateTime[] = [
        this._dateTimeService.getStartOfMonth(),
        this._dateTimeService.getEndOfMonth(),
    ];

    constructor(injector: Injector,
                private _opportunitiesDashboardServiceProxy: OpportunitiesDashboardServiceProxy,
                private _dateTimeService: DateTimeService,
                private _fileDownloadService: FileDownloadService) {
        super(injector);
        this.opportunitesdashboard = new OpportunitiesDashboardStats();
    }

    ngOnInit() {
        this.loadTopOpportunitiesStatsData(this.selectedDateRange[0], this.selectedDateRange[1], undefined, undefined, undefined);
        this.loadBranches();
        this.loadDepartments();
        this.loadAccounts();
    }

    loadTopOpportunitiesStatsData(fromDate, toDate, account, branches, departments) {
        this._opportunitiesDashboardServiceProxy
            .get(fromDate, toDate, account, branches, departments)
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

    onChange(dateRange) {
        if (
            !dateRange ||
            dateRange.length !== 2 ||
            (this.selectedDateRange[0] === dateRange[0] && this.selectedDateRange[1] === dateRange[1])
        ) {
            this.onFilterChange();
            return;
        }

        this.selectedDateRange[0] = dateRange[0];
        this.selectedDateRange[1] = dateRange[1];
        this.onFilterChange();
    }

    onFilterChange() {
        this.loadTopOpportunitiesStatsData(this.selectedDateRange[0], this.selectedDateRange[1], this.accountFilter, this.branchFilter, this.departmentFilter);
    }

    /***
     * Export to excel
     */
    exportToExcel(): void {
        this._opportunitiesDashboardServiceProxy.getOpportunitiesDashboardToExcel(
            this.selectedDateRange[0],
            this.selectedDateRange[1],
            this.accountFilter,
            this.branchFilter,
            this.departmentFilter)
            .subscribe((result) => {
                this._fileDownloadService.downloadTempFile(result);
            });
    }

    /***
     * Export to excel Closed/Won
     */
    exportToExcelClosedWon(): void {
        this._opportunitiesDashboardServiceProxy.getClosedWonOpportunitiesDashboardToExcel(
            this.selectedDateRange[0],
            this.selectedDateRange[1],
            this.accountFilter,
            this.branchFilter,
            this.departmentFilter)
            .subscribe((result) => {
                this._fileDownloadService.downloadTempFile(result);
            });
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

