﻿import {
    AfterContentInit,
    AfterViewInit,
    ChangeDetectorRef,
    Component,
    Injector,
    OnInit,
    ViewChild,
    ViewEncapsulation
} from '@angular/core';
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
    ZipCodeDto, AccountUsersServiceProxy, CustomerCountryLookupTableDto
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
export class CreateOrEditCustomerComponent extends AppComponentBase implements OnInit, AfterViewInit, AfterContentInit {
    @ViewChild('customerForm', { static: true }) customerForm: NgForm;
    @ViewChild('opportunitiesDataTable', { static: true }) opportunitiesDataTable: Table;
    @ViewChild('opportunitiesPaginator', { static: true }) opportunitiesPaginator: Paginator;
    @ViewChild('customerInvoicesDataTable', { static: true }) customerInvoicesDataTable: Table;
    @ViewChild('CustomerInvoicesPaginator', { static: true }) paginator: Paginator;
    @ViewChild('customerEquipmentsDataTable', { static: true }) customerEquipmentsDataTable: Table;
    @ViewChild('customerEquipmentsPaginator', { static: true }) customerEquipmentsPaginator: Paginator;
    @ViewChild('customerWipDataTable', { static: true }) customerWipDataTable: Table;
    @ViewChild('customerWipPaginator', { static: true }) customerWipPaginator: Paginator;
    @ViewChild('entityTypeHistory', { static: true }) entityTypeHistory: EntityTypeHistoryComponent;

    routerLink = '/app/main/business/accounts';
    opportunitiesRouterLink = '/app/main/crm/opportunities/createOrEdit';
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
    countries: CustomerCountryLookupTableDto[] = [];
    selectedAccountType: CustomerAccountTypeLookupTableDto;
    allLeadSources: CustomerLeadSourceLookupTableDto[] = [];
    usZipCodes: GetZipCodeForViewDto[] = [];

    invoicesDateRange: DateTime[] = [this._dateTimeService.getStartOfDayMinusDays(30), this._dateTimeService.getEndOfDay()];
    customerNumber: string;
    primengTableHelperOpportunities = new PrimengTableHelper();
    primengTableHelperEquipments = new PrimengTableHelper();
    primengTableHelperWip = new PrimengTableHelper();

    wipQuotes = false;
    wipAcceptedQuotes = false;
    wipCanceledQuotes = false;
    isPageLoading = true;
    showOpportunitiesTab = false;
    showInvoicesTab = false;
    showEquipmentsTab = false;
    showWipTab = false;
    showEventsTab = false;

    /***
     * Main constructor
     * @param injector
     * @param _activatedRoute
     * @param _customerServiceProxy
     * @param _zipCodeServiceProxy
     * @param _router
     * @param _dateTimeService
     */
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

    ngAfterContentInit(): void {
    }

    ngAfterViewInit(): void {
    }



    /***
     * Initialize component
     */
    ngOnInit(): void {
        this.pageMode = this._activatedRoute.snapshot.routeConfig.path.toLowerCase();
        this.isReadOnlyMode = this.pageMode === 'view';
        this.customerNumber = this._activatedRoute.snapshot.queryParams['number'];
        this.isNew = !!!this.customerNumber;

        this.setPermissions();

        this.show(this.customerNumber);

    }

    setPermissions() {
        this.showOpportunitiesTab = this.isGrantedAny('Pages.Customer.ViewOpportunities');
        this.showInvoicesTab = this.isGrantedAny('Pages.Customer.ViewInvoices');
        this.showEquipmentsTab = this.isGrantedAny('Pages.Customer.ViewEquipments');
        this.showWipTab = this.isGrantedAny('Pages.Customer.ViewWip');
        this.showEventsTab = this.isGrantedAny('Pages.Customer.ViewEvents');
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
            this._customerServiceProxy.getAllCountriesForTableDropdown()
        ];

        if (!customerId) {
            forkJoin([...requests])
                .subscribe(([accountTypes, leadSources, countries]: [
                    CustomerAccountTypeLookupTableDto[],
                    CustomerLeadSourceLookupTableDto[],
                    CustomerCountryLookupTableDto[]]) => {
                    this.isPageLoading = false;
                    this.active = true;

                    this.customer = new CreateOrEditCustomerDto();
                    this.allAccountTypes = accountTypes;
                    this.selectedAccountType = this.allAccountTypes.find(x => x.isDefault);
                    this.customer.accountTypeId = this.selectedAccountType?.id;
                    this.allLeadSources = leadSources;
                    this.countries = countries;

                    this.showSaveButton = !this.isReadOnlyMode;
                }, (_) => {
                    this.goToAccounts();
                });
            this.breadcrumbs.push(new BreadcrumbItem(this.isNew ? this.l('CreateNewCustomer') : this.l('EditCustomer')));
        } else {
            this.entityTypeHistory.show({
                entityId: this.customerNumber,
                entityName: 'Account'
            });
            if (this.isReadOnlyMode) {
                requests.push(this._customerServiceProxy.getCustomerForView(customerId));
            } else {
                requests.push(this._customerServiceProxy.getCustomerForEdit(customerId));
            }
            forkJoin([...requests])
                .subscribe(([accountTypes, leadSources, countries, customerForEdit]: [
                    CustomerAccountTypeLookupTableDto[],
                    CustomerLeadSourceLookupTableDto[],
                    CustomerCountryLookupTableDto[],
                    GetCustomerForEditOutput]) => {
                    this.isPageLoading = false;
                    this.active = true;

                    this.customer = customerForEdit.customer;
                    this.accountTypeDescription = customerForEdit.accountTypeDescription;
                    this.allAccountTypes = accountTypes;
                    this.selectedAccountType = this.allAccountTypes.find(x => x.isDefault);
                    this.allLeadSources = leadSources;
                    this.countries = countries;

                    this.showSaveButton = !this.isReadOnlyMode;
                    this.breadcrumbs.push(new BreadcrumbItem(this.isNew ? this.l('CreateNewCustomer') : this.customer?.name));
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
     * Add opportunity
     */
    addOpportunity() {
        this._router.navigate([this.opportunitiesRouterLink], { queryParams: { customerNumber: this.customerNumber }});
    }

    /***
     * Get customer opportunities
     * @param event
     */
    getOpportunities(event?: LazyLoadEvent) {
        if (!this.isNew && this.showOpportunitiesTab) {
            if (this.primengTableHelperOpportunities.shouldResetPaging(event)) {
                this.opportunitiesPaginator.changePage(0);
                return;
            }

            this.primengTableHelperOpportunities.showLoadingIndicator();

            this._customerServiceProxy.getAllOpportunities(
                this.customerNumber,
                this.primengTableHelperOpportunities.getSorting(this.opportunitiesDataTable),
                this.primengTableHelperOpportunities.getSkipCount(this.opportunitiesPaginator, event),
                this.primengTableHelperOpportunities.getMaxResultCount(this.opportunitiesPaginator, event)
            ).subscribe((result) => {
                this.primengTableHelperOpportunities.totalRecordsCount = result.totalCount;
                this.primengTableHelperOpportunities.records = result.items;
                this.primengTableHelperOpportunities.hideLoadingIndicator();
            });
        }
    }

    /***
     * Get customer invoices
     * @param event
     */
    getCustomerInvoices(event?: LazyLoadEvent) {
        if (!this.isNew && this.showInvoicesTab) {
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
        if (!this.isNew && this.showEquipmentsTab) {
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
        if (!this.isNew && this.showWipTab) {
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
