import { Component, Injector, ViewEncapsulation, ViewChild, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import {
    CustomerServiceProxy,
    CustomerDto,
    AccountTypesServiceProxy,
    PagedResultDtoOfGetAccountTypeForViewDto,
    AccountTypeDto
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


@Component({
    templateUrl: './customer.component.html',
    encapsulation: ViewEncapsulation.None,
    animations: [appModuleAnimation()]
})
export class CustomerComponent extends AppComponentBase implements OnInit {
    @ViewChild('dataTable', { static: true }) dataTable: Table;
    @ViewChild('paginator', { static: true }) paginator: Paginator;

    advancedFiltersAreShown = false;
    filterText = '';
    accountTypes: AccountTypeDto[];
    selectedAccountType: AccountTypeDto;

    constructor(
        injector: Injector,
        private _customerServiceProxy: CustomerServiceProxy,
        private _accountTypeServiceProxy: AccountTypesServiceProxy,
        private _notifyService: NotifyService,
        private _tokenAuth: TokenAuthServiceProxy,
        private _activatedRoute: ActivatedRoute,
        private _fileDownloadService: FileDownloadService,
        private _router: Router,
        private _dateTimeService: DateTimeService
    ) {
        super(injector);
    }

    ngOnInit(): void {

        this._accountTypeServiceProxy.getAll('', '', 0 , 100)
            .subscribe((result: PagedResultDtoOfGetAccountTypeForViewDto) => {
                this.accountTypes = result.items.map(x => x.accountType);
                const allAccountType = new AccountTypeDto();
                allAccountType.id = 0;
                allAccountType.description = 'All';
                this.accountTypes.unshift(allAccountType);
            });

    }

    getCustomer(event?: LazyLoadEvent) {
        if (this.primengTableHelper.shouldResetPaging(event)) {
            this.paginator.changePage(0);
            return;
        }

        this.primengTableHelper.showLoadingIndicator();

        this._customerServiceProxy
            .getAll(
                this.filterText,
                this.selectedAccountType?.id,
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

    reloadPage(): void {
        this.paginator.changePage(this.paginator.getPage());
    }

    createCustomer(): void {
        this._router.navigate(['/app/main/business/accounts/createOrEdit']);
    }

    deleteCustomer(customer: CustomerDto): void {
        // this.message.confirm('', this.l('AreYouSure'), (isConfirmed) => {
        //     if (isConfirmed) {
        //         this._customerServiceProxy.delete(customer.id).subscribe(() => {
        //             this.reloadPage();
        //             this.notify.success(this.l('SuccessfullyDeleted'));
        //         });
        //     }
        // });
    }

    exportToExcel(): void {
        this._customerServiceProxy
            .getCustomerToExcel(
                this.filterText,
                this.selectedAccountType?.id,
            )
            .subscribe((result) => {
                this._fileDownloadService.downloadTempFile(result);
            });
    }

}
