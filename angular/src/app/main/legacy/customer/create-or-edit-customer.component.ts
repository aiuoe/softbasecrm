import { Component, ElementRef, Injector, OnInit, ViewChild, ViewEncapsulation } from '@angular/core';
import { finalize } from 'rxjs/operators';
import {
    CustomerServiceProxy,
    CreateOrEditCustomerDto,
    CustomerAccountTypeLookupTableDto,
    CustomerLeadSourceLookupTableDto,
    ZipCodesServiceProxy,
    GetZipCodeForViewDto,
    GetCustomerForEditOutput, PagedResultDtoOfGetZipCodeForViewDto
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
import { PrimengTableHelper } from '@shared/helpers/PrimengTableHelper';
import { Observable, forkJoin } from 'rxjs';

@Component({
    templateUrl: './create-or-edit-customer.component.html',
    encapsulation: ViewEncapsulation.None,
    animations: [appModuleAnimation()]
})
export class CreateOrEditCustomerComponent extends AppComponentBase implements OnInit {
    @ViewChild('customerForm', { static: true }) customerForm: NgForm;
    @ViewChild('customerInvoicesDataTable', { static: true }) customerInvoicesDataTable: Table;
    @ViewChild('CustomerInvoicesPaginator', { static: true }) paginator: Paginator;
    @ViewChild('customerEquipmentsDataTable', { static: true }) customerEquipmentsDataTable: Table;
    @ViewChild('customerEquipmentsPaginator', { static: true }) customerEquipmentsPaginator: Paginator;
    @ViewChild('customerWipDataTable', { static: true }) customerWipDataTable: Table;
    @ViewChild('customerWipPaginator', { static: true }) customerWipPaginator: Paginator;

    active = false;
    saving = false;
    isNew = true;
    showSaveButton = false;
    isReadOnlyMode = false;
    customer: CreateOrEditCustomerDto = new CreateOrEditCustomerDto();
    accountTypeDescription = '';
    allAccountTypes: CustomerAccountTypeLookupTableDto[] = [];
    selectedAccountType: CustomerAccountTypeLookupTableDto;
    allLeadSources: CustomerLeadSourceLookupTableDto[] = [];
    usZipCodes: GetZipCodeForViewDto[] = [];
    routerLink = '/app/main/business/accounts';
    breadcrumbs: BreadcrumbItem[] = [
        new BreadcrumbItem(this.l('Customer'), this.routerLink)
    ];
    dateRange: DateTime[] = [this._dateTimeService.getStartOfDayMinusDays(30), this._dateTimeService.getEndOfDay()];
    customerNumber: string;
    primengTableHelperEquipments = new PrimengTableHelper();
    primengTableHelperWip = new PrimengTableHelper();

    selectedValues: string[] = [];
    wipQuotes = false;
    wipAcceptedQuotes = false;
    wipCanceledQuotes = false;

    // Tab permissions
    showInvoiceTab = true;
    showEquipmentTab = true;
    showWipTab = true;
    isPageLoading = true;

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
        this.showInvoiceTab = this.isGrantedAny('Pages.Customer.ViewInvoices');
        this.showEquipmentTab = this.isGrantedAny('Pages.Customer.ViewEquipments');
        this.showWipTab = this.isGrantedAny('Pages.Customer.ViewWip');

        this.isReadOnlyMode = this._activatedRoute.snapshot.routeConfig.path === 'view';
        this.customerNumber = this._activatedRoute.snapshot.queryParams['number'];
        this.isNew = !!!this.customerNumber;
        this.show(this.customerNumber);
        this.breadcrumbs.push(new BreadcrumbItem(this.isNew ? this.l('CreateNewCustomer') : this.l('EditCustomer')));
    }

    show(customerId?: string): void {

        const requests: Observable<any>[] = [
            this._customerServiceProxy.getAllAccountTypeForTableDropdown(),
            this._customerServiceProxy.getAllLeadSourceForTableDropdown(),
            this._zipCodeServiceProxy.getAllZipCodesForTableDropdown()
        ];

        if (!customerId) {

            forkJoin([...requests])
                .subscribe(([accountTypes, leadSources, zipCodes]: [
                    CustomerAccountTypeLookupTableDto[],
                    CustomerLeadSourceLookupTableDto[],
                    PagedResultDtoOfGetZipCodeForViewDto]) => {
                    this.isPageLoading = false;
                    this.active = true;

                    this.customer = new CreateOrEditCustomerDto();
                    this.allAccountTypes = accountTypes;
                    this.selectedAccountType = this.allAccountTypes.find(x => x.isDefault);
                    this.customer.accountTypeId = this.selectedAccountType?.id;
                    this.allLeadSources = leadSources;
                    this.usZipCodes = zipCodes.items;

                    this.showSaveButton = true;
                });

        } else {

            requests.push(this._customerServiceProxy.getCustomerForEdit(customerId));
            forkJoin([...requests])
                .subscribe(([accountTypes, leadSources, zipCodes, customerForEdit]: [
                    CustomerAccountTypeLookupTableDto[],
                    CustomerLeadSourceLookupTableDto[],
                    PagedResultDtoOfGetZipCodeForViewDto,
                    GetCustomerForEditOutput]) => {
                    this.isPageLoading = false;
                    this.active = true;

                    this.customer = customerForEdit.customer;
                    this.accountTypeDescription = customerForEdit.accountTypeDescription;
                    this.allAccountTypes = accountTypes;
                    this.selectedAccountType = this.allAccountTypes.find(x => x.isDefault);
                    this.allLeadSources = leadSources;
                    this.usZipCodes = zipCodes.items;

                    this.showSaveButton = true;
                });
        }
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
                this.primengTableHelper.getSorting(this.customerInvoicesDataTable),
                this.primengTableHelper.getSkipCount(this.paginator, event),
                this.primengTableHelper.getMaxResultCount(this.paginator, event)
            ).subscribe((result) => {
                this.primengTableHelper.totalRecordsCount = result.totalCount;
                this.primengTableHelper.records = result.items;
                this.primengTableHelper.hideLoadingIndicator();
            });
        }
    }


    /***
     * Get customer equipments
     * @param event
     */
    getCustomerEquipments(event?: LazyLoadEvent) {
        if (!this.isNew) {
            if (this.primengTableHelperEquipments.shouldResetPaging(event)) {
                this.customerEquipmentsPaginator.changePage(0);
                return;
            }

            this.primengTableHelperEquipments.showLoadingIndicator();

            this._customerServiceProxy.getAllCustomerEquipments(
                this.customerNumber,
                this.primengTableHelperEquipments.getSorting(this.customerEquipmentsDataTable),
                this.primengTableHelperEquipments.getSkipCount(this.customerEquipmentsPaginator, event),
                this.primengTableHelperEquipments.getMaxResultCount(this.customerEquipmentsPaginator, event)
            ).subscribe((result) => {
                this.primengTableHelperEquipments.totalRecordsCount = result.totalCount;
                this.primengTableHelperEquipments.records = result.items;
                this.primengTableHelperEquipments.hideLoadingIndicator();
            });
        }
    }


    /***
     * Get customer WIP
     * @param event
     */
    getCustomerWip(event?: LazyLoadEvent) {
        if (!this.isNew) {
            if (this.primengTableHelperWip.shouldResetPaging(event)) {
                this.customerWipPaginator.changePage(0);
                return;
            }

            this.primengTableHelperWip.showLoadingIndicator();

            this._customerServiceProxy.getAllCustomerWip(
                this.customerNumber,
                this.wipQuotes,
                this.wipAcceptedQuotes,
                this.wipCanceledQuotes,
                this.primengTableHelperWip.getSorting(this.customerWipDataTable),
                this.primengTableHelperWip.getSkipCount(this.customerWipPaginator, event),
                this.primengTableHelperWip.getMaxResultCount(this.customerWipPaginator, event)
            ).subscribe((result) => {
                this.primengTableHelperWip.totalRecordsCount = result.totalCount;
                this.primengTableHelperWip.records = result.items;
                this.primengTableHelperWip.hideLoadingIndicator();
            });
        }
    }


}
