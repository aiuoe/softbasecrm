import { Component, Injector, OnInit, ViewChild, ViewEncapsulation } from '@angular/core';
import { finalize } from 'rxjs/operators';
import {
    CustomerServiceProxy,
    CreateOrEditCustomerDto,
    CustomerAccountTypeLookupTableDto, CustomerLeadSourceLookupTableDto, ZipCodesServiceProxy, GetZipCodeForViewDto
} from '@shared/service-proxies/service-proxies';
import { AppComponentBase } from '@shared/common/app-component-base';
import { ActivatedRoute, Router } from '@angular/router';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { BreadcrumbItem } from '@app/shared/common/sub-header/sub-header.component';
import { DateTimeService } from '@app/shared/common/timing/date-time.service';
import { NgForm } from '@angular/forms';
import { DateTime } from 'luxon';
import { LazyLoadEvent } from 'primeng/api';
import { Paginator } from 'primeng/paginator';
import { Table } from 'primeng/table';

@Component({
    templateUrl: './create-or-edit-customer.component.html',
    encapsulation: ViewEncapsulation.None,
    animations: [appModuleAnimation()]
})
export class CreateOrEditCustomerComponent extends AppComponentBase implements OnInit {
    @ViewChild('customerForm', { static: true }) customerForm: NgForm;
    @ViewChild('dataTable', { static: true }) dataTable: Table;
    @ViewChild('CustomerInvoicesPaginator', { static: true }) paginator: Paginator;

    active = false;
    saving = false;
    isNew = true;
    isReadOnlyMode = false;
    customer: CreateOrEditCustomerDto = new CreateOrEditCustomerDto();
    accountTypeDescription = '';
    allAccountTypes: CustomerAccountTypeLookupTableDto[] = [];
    allLeadSources: CustomerLeadSourceLookupTableDto[] = [];
    usZipCodes: GetZipCodeForViewDto[] = [];
    routerLink = '/app/main/business/accounts';
    breadcrumbs: BreadcrumbItem[] = [
        new BreadcrumbItem(this.l('Customer'), this.routerLink)
    ];
    dateRange: DateTime[] = [this._dateTimeService.getStartOfDayMinusDays(30), this._dateTimeService.getEndOfDay()];
    // primengTableHelperAuditLogs = new PrimengTableHelper();

    constructor(
        injector: Injector,
        private _activatedRoute: ActivatedRoute,
        private _customerServiceProxy: CustomerServiceProxy,
        private _zipCodeServiceProxy: ZipCodesServiceProxy,
        private _router: Router,
        private _dateTimeService: DateTimeService
    ) {
        super(injector);
    }

    ngOnInit(): void {
        this.primengTableHelper.adjustScroll(this.dataTable);
        // this.primengTableHelper.adjustScroll(this.dataTableEntityChanges);

        this.isReadOnlyMode = this._activatedRoute.snapshot.routeConfig.path === 'view';
        const customerNumber = this._activatedRoute.snapshot.queryParams['number'];
        this.isNew = !!!customerNumber;
        this.show(customerNumber);
        this.breadcrumbs.push(new BreadcrumbItem(this.isNew ? this.l('CreateNewCustomer') : this.l('EditCustomer')));
    }

    show(customerId?: string): void {
        if (!customerId) {
            this.customer = new CreateOrEditCustomerDto();
            this.active = true;
        } else {
            this._customerServiceProxy.getCustomerForEdit(customerId).subscribe((result) => {
                this.customer = result.customer;
                this.accountTypeDescription = result.accountTypeDescription;
                this.active = true;
            });
        }

        //TODO ForkJoin
        this._customerServiceProxy.getAllAccountTypeForTableDropdown()
            .subscribe((result) => {
                this.allAccountTypes = result;
            });
        this._customerServiceProxy.getAllLeadSourceForTableDropdown()
            .subscribe((result) => {
                this.allLeadSources = result;
            });
        this._zipCodeServiceProxy.getAll('', '', 0, 100_000_000)
            .subscribe((result) => {
                this.usZipCodes = result.items;
            });
    }

    save(): void {
        if (!this.customerForm.form.valid) {
            this.customerForm.form.markAllAsTouched();
            this.message.warn(this.l('InvalidFormMessage'));
            return;
        }
        this.saving = true;
        this._customerServiceProxy
            .createOrEdit(this.customer)
            .pipe(
                finalize(() => {
                    this.saving = false;
                })
            )
            .subscribe((x) => {
                this.saving = false;
                this.notify.info(this.l('SavedSuccessfully'));
                this._router.navigate([this.routerLink]);
            });
    }

    goToAccounts() {
        this._router.navigate([this.routerLink]);
    }

    /***
     * Get customer invoices
     * @param event
     */
    getCustomerInvoices(event?: LazyLoadEvent) {
        if (!this.isNew) {
            if (this.primengTableHelper.shouldResetPaging(event)) {
                this.paginator.changePage(0);
                return;
            }

            this.primengTableHelper.showLoadingIndicator();

            this._customerServiceProxy.getAllCustomerInvoices(
                this.customer.number,
                this.dateRange[0],
                this.dateRange[1],
                this.primengTableHelper.getSorting(this.dataTable),
                this.primengTableHelper.getSkipCount(this.paginator, event),
                this.primengTableHelper.getMaxResultCount(this.paginator, event)
            ).subscribe((result) => {
                this.primengTableHelper.totalRecordsCount = result.totalCount;
                this.primengTableHelper.records = result.items;
                this.primengTableHelper.hideLoadingIndicator();
            });
        }
    }


}
