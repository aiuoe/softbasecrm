import { Component, Injector, OnInit, ViewChild, ViewEncapsulation } from '@angular/core';
import { finalize } from 'rxjs/operators';
import {
    CustomerServiceProxy,
    CreateOrEditCustomerDto,
    CustomerAccountTypeLookupTableDto,
    CustomerLeadSourceLookupTableDto,
    ZipCodesServiceProxy,
    GetZipCodeForViewDto,
    GetCustomerForEditOutput,
    PagedResultDtoOfGetZipCodeForViewDto,
    CountriesServiceProxy,
    GetCountryForViewDto,
    CountryDto, ZipCodeDto, AccountUsersServiceProxy
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
import { EntityTypeHistoryComponent } from '@app/shared/common/entityHistory/entity-type-history.component';

/***
 * Component to manage the customers/accounts create/edit mode
 */
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
    @ViewChild('entityTypeHistory', { static: true }) entityTypeHistory: EntityTypeHistoryComponent;

    routerLink = '/app/main/business/accounts';
    breadcrumbs: BreadcrumbItem[] = [
        new BreadcrumbItem(this.l('Customer'), this.routerLink)
    ];

    pageMode = '';
    active = false;
    saving = false;
    isNew = true;
    showSaveButton = false;
    isReadOnlyMode = false;
    customer: CreateOrEditCustomerDto = new CreateOrEditCustomerDto();
    accountTypeDescription = '';
    allAccountTypes: CustomerAccountTypeLookupTableDto[] = [];
    countries: CountryDto[] = [];
    selectedAccountType: CustomerAccountTypeLookupTableDto;
    allLeadSources: CustomerLeadSourceLookupTableDto[] = [];
    usZipCodes: GetZipCodeForViewDto[] = [];

    invoicesDateRange: DateTime[] = [this._dateTimeService.getStartOfDayMinusDays(30), this._dateTimeService.getEndOfDay()];
    customerNumber: string;
    primengTableHelperEquipments = new PrimengTableHelper();
    primengTableHelperWip = new PrimengTableHelper();

    wipQuotes = false;
    wipAcceptedQuotes = false;
    wipCanceledQuotes = false;

    // Tab permissions
    showInvoiceTab = true;
    showEquipmentTab = true;
    showWipTab = true;
    isPageLoading = true;

    /***
     * Main constructor
     * @param injector
     * @param _activatedRoute
     * @param _customerServiceProxy
     * @param _accountUserServiceProxy
     * @param _zipCodeServiceProxy
     * @param _countriesServiceProxy
     * @param _router
     * @param _dateTimeService
     */
    constructor(
        injector: Injector,
        private _activatedRoute: ActivatedRoute,
        private _customerServiceProxy: CustomerServiceProxy,
        private _accountUserServiceProxy: AccountUsersServiceProxy,
        private _zipCodeServiceProxy: ZipCodesServiceProxy,
        private _countriesServiceProxy: CountriesServiceProxy,
        private _router: Router,
        private _dateTimeService: DateTimeService
    ) {
        super(injector);
    }

    /***
     * Initialize component
     */
    ngOnInit(): void {
        this.showInvoiceTab = this.isGrantedAny('Pages.Customer.ViewInvoices');
        this.showEquipmentTab = this.isGrantedAny('Pages.Customer.ViewEquipments');
        this.showWipTab = this.isGrantedAny('Pages.Customer.ViewWip');

        this.pageMode = this._activatedRoute.snapshot.routeConfig.path.toLowerCase();
        this.isReadOnlyMode = this.pageMode === 'view';
        this.customerNumber = this._activatedRoute.snapshot.queryParams['number'];
        this.isNew = !!!this.customerNumber;
        this.show(this.customerNumber);
        this.breadcrumbs.push(new BreadcrumbItem(this.isNew ? this.l('CreateNewCustomer') : this.l('EditCustomer')));
    }

    /***
     * Initialize show visualization
     * @param customerId
     */
    show(customerId?: string): void {

        if ((this.pageMode === 'view') && !this.customerNumber) {
            this.goToAccounts();
        }

        const requests: Observable<any>[] = [
            this._customerServiceProxy.getAllAccountTypeForTableDropdown(),
            this._customerServiceProxy.getAllLeadSourceForTableDropdown(),
            this._countriesServiceProxy.getAllForTableDropdown()
        ];

        if (!customerId) {
            forkJoin([...requests])
                .subscribe(([accountTypes, leadSources, countries]: [
                    CustomerAccountTypeLookupTableDto[],
                    CustomerLeadSourceLookupTableDto[],
                    GetCountryForViewDto[]]) => {
                    this.isPageLoading = false;
                    this.active = true;

                    this.customer = new CreateOrEditCustomerDto();
                    this.allAccountTypes = accountTypes;
                    this.selectedAccountType = this.allAccountTypes.find(x => x.isDefault);
                    this.customer.accountTypeId = this.selectedAccountType?.id;
                    this.allLeadSources = leadSources;
                    this.countries = countries.map(x => x.country);

                    this.showSaveButton = !this.isReadOnlyMode;
                }, (_) => {
                    this.goToAccounts();
                });

        } else {
            this.entityTypeHistory.show({
                entityId: this.customerNumber,
                entityTypeFullName: 'SBCRM.Legacy.Customer',
                entityTypeDescription: '',
            });
            requests.push(this._customerServiceProxy.getCustomerForEdit(customerId));
            forkJoin([...requests])
                .subscribe(([accountTypes, leadSources, countries, customerForEdit]: [
                    CustomerAccountTypeLookupTableDto[],
                    CustomerLeadSourceLookupTableDto[],
                    GetCountryForViewDto[],
                    GetCustomerForEditOutput]) => {
                    this.isPageLoading = false;
                    this.active = true;

                    this.customer = customerForEdit.customer;
                    this.accountTypeDescription = customerForEdit.accountTypeDescription;
                    this.allAccountTypes = accountTypes;
                    this.selectedAccountType = this.allAccountTypes.find(x => x.isDefault);
                    this.allLeadSources = leadSources;
                    this.countries = countries.map(x => x.country);

                    this.showSaveButton = !this.isReadOnlyMode;
                }, (_) => {
                    this.goToAccounts();
                });
        }

        this._zipCodeServiceProxy.getAllZipCodesForTableDropdown()
            .subscribe((zipCodes: PagedResultDtoOfGetZipCodeForViewDto) => {
                this.usZipCodes = zipCodes.items;
            });
    }

    reloadEvents() {
        this.entityTypeHistory.refreshTable();
    }

    /***
     * Save customer/account
     */
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
            .subscribe((_) => {
                this.saving = false;
                this.notify.info(this.l('SavedSuccessfully'));
                this.goToAccounts();
            });
    }

    /***
     * Open internal edition mode
     */
    openEditionMode() {
        this.isReadOnlyMode = false;
        this.showSaveButton = true;
    }

    /***
     * Go to accounts page
     */
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
                this.invoicesDateRange[0],
                this.invoicesDateRange[1],
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

    getZipCode(event: KeyboardEvent) {
        const zipCodeHasMoreThan5Characters = this.customer.zipCode?.trim().length >= 5 && this.customer.zipCode;
        const keyDownIsBackspace = event && event.key === 'Backspace';
        if (zipCodeHasMoreThan5Characters || keyDownIsBackspace) {
            const zipCodeFound: ZipCodeDto = this.usZipCodes.map(x => x.zipCode).find(x => x.zipCode === this.customer.zipCode);
            if (zipCodeFound) {
                this.customer.city = zipCodeFound.city;
                this.customer.state = zipCodeFound.state;
                this.customer.country = 'US';
            }
        }
    }
}
