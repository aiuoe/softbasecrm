import { Component, Injector, ViewEncapsulation, ViewChild, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import {
    CustomerServiceProxy,
    AccountUserDto,
    CustomerAccountTypeLookupTableDto,
    AccountUserLookupTableDto
} from '@shared/service-proxies/service-proxies';
import { NotifyService } from 'abp-ng2-module';
import { AppComponentBase } from '@shared/common/app-component-base';
import { TokenAuthServiceProxy } from '@shared/service-proxies/service-proxies';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { Table } from 'primeng/table';
import { Paginator } from 'primeng/paginator';
import { LazyLoadEvent } from 'primeng/api';
import { FileDownloadService } from '@shared/utils/file-download.service';
import { DateTimeService } from '@app/shared/common/timing/date-time.service';
import { LocalStorageService } from '@shared/utils/local-storage.service';

@Component({
    templateUrl: './global-search.component.html',
    encapsulation: ViewEncapsulation.None,
    animations: [appModuleAnimation()],
})
export class GlobalSearchComponent extends AppComponentBase implements OnInit {

    @ViewChild('dataTable', { static: true }) dataTable: Table;
    @ViewChild('paginator', { static: true }) paginator: Paginator;

    advancedFiltersAreShown = false;
    textFilter = '';
    accountTypes: CustomerAccountTypeLookupTableDto[];
    selectedAccountType: CustomerAccountTypeLookupTableDto;
    selectedAccountTypes: CustomerAccountTypeLookupTableDto[];
    accountUsers: AccountUserDto[] = [];
    assignedUsersFilter: AccountUserLookupTableDto[] = [];

    constructor(
        injector: Injector,
        private _customerServiceProxy: CustomerServiceProxy,
        private _notifyService: NotifyService,
        private _tokenAuth: TokenAuthServiceProxy,
        private _activatedRoute: ActivatedRoute,
        private _fileDownloadService: FileDownloadService,
        private _router: Router,
        private _dateTimeService: DateTimeService,
        private _localStorageService: LocalStorageService
    ) {
        super(injector);
        this._router.routeReuseStrategy.shouldReuseRoute = function () {
            return false;
        };
    }

    ngOnInit(): void {
        this.textFilter = this._activatedRoute.snapshot.queryParams['filter'];

        this._customerServiceProxy.getAllAccountTypeForTableDropdown()
            .subscribe((result: CustomerAccountTypeLookupTableDto[]) => {
                this.accountTypes = result;
            });
    }

    getGlobalSearch(event?: LazyLoadEvent) {
        if (this.primengTableHelper.shouldResetPaging(event)) {
            this.paginator.changePage(0);
            return;
        }

        this.primengTableHelper.showLoadingIndicator();

        this._customerServiceProxy
            .getAll(
                this.textFilter,
                this.selectedAccountTypes?.map(x => x.id),
                this.assignedUsersFilter?.map(x => x.id),
                this.primengTableHelper.getSorting(this.dataTable),
                this.primengTableHelper.getSkipCount(this.paginator, event),
                this.primengTableHelper.getMaxResultCount(this.paginator, event)
            )
            .subscribe((result) => {
                this.primengTableHelper.totalRecordsCount = result.totalCount;
                this.primengTableHelper.records = result.items;
                this.primengTableHelper.hideLoadingIndicator();
            });
    }
}
