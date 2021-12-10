import { AppConsts } from '@shared/AppConsts';
import { Component, Injector, ViewEncapsulation, ViewChild, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { CustomerServiceProxy, CustomerDto, AccountTypesServiceProxy } from '@shared/service-proxies/service-proxies';
import { NotifyService } from 'abp-ng2-module';
import { AppComponentBase } from '@shared/common/app-component-base';
import { TokenAuthServiceProxy } from '@shared/service-proxies/service-proxies';

import { appModuleAnimation } from '@shared/animations/routerTransition';
import { Table } from 'primeng/table';
import { Paginator } from 'primeng/paginator';
import { LazyLoadEvent } from 'primeng/api';
import { FileDownloadService } from '@shared/utils/file-download.service';
import { filter as _filter } from 'lodash-es';
import { DateTime } from 'luxon';

import { DateTimeService } from '@app/shared/common/timing/date-time.service';

interface City {
    name: string,
    code: string
}

@Component({
    templateUrl: './customer.component.html',
    encapsulation: ViewEncapsulation.None,
    animations: [appModuleAnimation()],
})
export class CustomerComponent extends AppComponentBase implements OnInit {
    @ViewChild('dataTable', { static: true }) dataTable: Table;
    @ViewChild('paginator', { static: true }) paginator: Paginator;

    advancedFiltersAreShown = false;
    filterText = '';
    numberFilter = '';
    billToFilter = '';
    nameFilter = '';
    searchNameFilter = '';
    subNameFilter = '';
    poBoxFilter = '';
    addressFilter = '';
    cityFilter = '';
    stateFilter = '';
    zipCodeFilter = '';
    countryFilter = '';
    salutationFilter = '';
    phoneFilter = '';
    extentionFilter = '';
    phone2Filter = '';
    cellularFilter = '';
    beeperFilter = '';
    homePhoneFilter = '';
    faxFilter = '';
    resaleNoFilter = '';
    eMailFilter = '';
    wwwAddressFilter = '';
    parentCompanyFilter = '';
    mapLocationFilter = '';
    salesman1Filter = '';
    salesman2Filter = '';
    salesman3Filter = '';
    salesman4Filter = '';
    salesman5Filter = '';
    salesman6Filter = '';
    maxLockAPR1Filter: number;
    maxLockAPR1FilterEmpty: number;
    minLockAPR1Filter: number;
    minLockAPR1FilterEmpty: number;
    maxLockAPR2Filter: number;
    maxLockAPR2FilterEmpty: number;
    minLockAPR2Filter: number;
    minLockAPR2FilterEmpty: number;
    maxLockAPR3Filter: number;
    maxLockAPR3FilterEmpty: number;
    minLockAPR3Filter: number;
    minLockAPR3FilterEmpty: number;
    maxLockAPR4Filter: number;
    maxLockAPR4FilterEmpty: number;
    minLockAPR4Filter: number;
    minLockAPR4FilterEmpty: number;
    maxLockAPR5Filter: number;
    maxLockAPR5FilterEmpty: number;
    minLockAPR5Filter: number;
    minLockAPR5FilterEmpty: number;
    maxLockAPR6Filter: number;
    maxLockAPR6FilterEmpty: number;
    minLockAPR6Filter: number;
    minLockAPR6FilterEmpty: number;
    maxSalesGroup1Filter: number;
    maxSalesGroup1FilterEmpty: number;
    minSalesGroup1Filter: number;
    minSalesGroup1FilterEmpty: number;
    maxSalesGroup2Filter: number;
    maxSalesGroup2FilterEmpty: number;
    minSalesGroup2Filter: number;
    minSalesGroup2FilterEmpty: number;
    maxSalesGroup3Filter: number;
    maxSalesGroup3FilterEmpty: number;
    minSalesGroup3Filter: number;
    minSalesGroup3FilterEmpty: number;
    maxSalesGroup4Filter: number;
    maxSalesGroup4FilterEmpty: number;
    minSalesGroup4Filter: number;
    minSalesGroup4FilterEmpty: number;
    maxSalesGroup5Filter: number;
    maxSalesGroup5FilterEmpty: number;
    minSalesGroup5Filter: number;
    minSalesGroup5FilterEmpty: number;
    maxSalesGroup6Filter: number;
    maxSalesGroup6FilterEmpty: number;
    minSalesGroup6Filter: number;
    minSalesGroup6FilterEmpty: number;
    termsFilter = '';
    fiscalEndFilter = '';
    dunsCodeFilter = '';
    sicCodeFilter = '';
    mailingGroupFilter = '';
    makesFilter = '';
    maxPOReqFilter: number;
    maxPOReqFilterEmpty: number;
    minPOReqFilter: number;
    minPOReqFilterEmpty: number;
    maxPrevShipFilter: number;
    maxPrevShipFilterEmpty: number;
    minPrevShipFilter: number;
    minPrevShipFilterEmpty: number;
    maxTaxableFilter: number;
    maxTaxableFilterEmpty: number;
    minTaxableFilter: number;
    minTaxableFilterEmpty: number;
    taxCodeFilter = '';
    laborRateFilter = '';
    shopLaborRateFilter = '';
    maxShowLaborRateFilter: number;
    maxShowLaborRateFilterEmpty: number;
    minShowLaborRateFilter: number;
    minShowLaborRateFilterEmpty: number;
    rentalRateFilter = '';
    maxShowPartNoAliasFilter: number;
    maxShowPartNoAliasFilterEmpty: number;
    minShowPartNoAliasFilter: number;
    minShowPartNoAliasFilterEmpty: number;
    partsRateFilter = '';
    maxPartsRateDiscountFilter: number;
    maxPartsRateDiscountFilterEmpty: number;
    minPartsRateDiscountFilter: number;
    minPartsRateDiscountFilterEmpty: number;
    maxAddedFilter: DateTime;
    minAddedFilter: DateTime;
    addedByFilter = '';
    maxChangedFilter: DateTime;
    minChangedFilter: DateTime;
    changedByFilter = '';
    salesContactFilter = '';
    csContactFilter = '';
    accountingContactFilter = '';
    maxInternalCustomerFilter: number;
    maxInternalCustomerFilterEmpty: number;
    minInternalCustomerFilter: number;
    minInternalCustomerFilterEmpty: number;
    maxEquipmentBidFilter: number;
    maxEquipmentBidFilterEmpty: number;
    minEquipmentBidFilter: number;
    minEquipmentBidFilterEmpty: number;
    commentsFilter = '';
    arCommentsFilter = '';
    companyCommentsFilter = '';
    maxCompanyCommentsDateFilter: DateTime;
    minCompanyCommentsDateFilter: DateTime;
    companyCommentsByFilter = '';
    businessCategoryFilter = '';
    businessDescriptionFilter = '';
    sicCode2Filter = '';
    sicCode3Filter = '';
    sicCode4Filter = '';
    maxShiftsFilter: number;
    maxShiftsFilterEmpty: number;
    minShiftsFilter: number;
    minShiftsFilterEmpty: number;
    categoryFilter = '';
    maxHoursOfOpStartFilter: DateTime;
    minHoursOfOpStartFilter: DateTime;
    maxHoursOfOpEndFilter: DateTime;
    minHoursOfOpEndFilter: DateTime;
    deliveryInfoFilter = '';
    customerTerritoryFilter = '';
    maxCreditHoldFlagFilter: number;
    maxCreditHoldFlagFilterEmpty: number;
    minCreditHoldFlagFilter: number;
    minCreditHoldFlagFilterEmpty: number;
    creditRating1Filter = '';
    creditRating2Filter = '';
    maxStatementsFilter: number;
    maxStatementsFilterEmpty: number;
    minStatementsFilter: number;
    minStatementsFilterEmpty: number;
    maxCreditHoldDaysFilter: number;
    maxCreditHoldDaysFilterEmpty: number;
    minCreditHoldDaysFilter: number;
    minCreditHoldDaysFilterEmpty: number;
    maxFinanceChargeFilter: number;
    maxFinanceChargeFilterEmpty: number;
    minFinanceChargeFilter: number;
    minFinanceChargeFilterEmpty: number;
    maxResaleExpDateFilter: DateTime;
    minResaleExpDateFilter: DateTime;
    stateTaxCodeFilter = '';
    countyTaxCodeFilter = '';
    cityTaxCodeFilter = '';
    maxAbsoluteTaxCodesFilter: number;
    maxAbsoluteTaxCodesFilterEmpty: number;
    minAbsoluteTaxCodesFilter: number;
    minAbsoluteTaxCodesFilterEmpty: number;
    mfgPermitNoFilter = '';
    maxMFGPermitExpDateFilter: DateTime;
    minMFGPermitExpDateFilter: DateTime;
    maxBranchFilter: number;
    maxBranchFilterEmpty: number;
    minBranchFilter: number;
    minBranchFilterEmpty: number;
    maxShowLaborHoursFilter: number;
    maxShowLaborHoursFilterEmpty: number;
    minShowLaborHoursFilter: number;
    minShowLaborHoursFilterEmpty: number;
    vendorNoFilter = '';
    localTaxCodeFilter = '';
    currencyTypeFilter = '';
    creditCardNoFilter = '';
    creditCardCVVFilter = '';
    creditCardExpDateFilter = '';
    creditCardTypeFilter = '';
    nameOnCreditCardFilter = '';
    rfcFilter = '';
    oldNumberFilter = '';
    maxSuppressPartsPricingFilter: number;
    maxSuppressPartsPricingFilterEmpty: number;
    minSuppressPartsPricingFilter: number;
    minSuppressPartsPricingFilterEmpty: number;
    maxServiceChargeFilter: number;
    maxServiceChargeFilterEmpty: number;
    minServiceChargeFilter: number;
    minServiceChargeFilterEmpty: number;
    serviceChargeDescriptionFilter = '';
    maxFinalCopiesFilter: number;
    maxFinalCopiesFilterEmpty: number;
    minFinalCopiesFilter: number;
    minFinalCopiesFilterEmpty: number;
    maxPOBoxAndAddressFilter: number;
    maxPOBoxAndAddressFilterEmpty: number;
    minPOBoxAndAddressFilter: number;
    minPOBoxAndAddressFilterEmpty: number;
    insuranceNoFilter = '';
    maxInsuranceNoDateFilter: DateTime;
    minInsuranceNoDateFilter: DateTime;
    maxInsuranceNoRecvDateFilter: DateTime;
    minInsuranceNoRecvDateFilter: DateTime;
    creditCardAddressFilter = '';
    creditCardPOBoxFilter = '';
    creditCardCityFilter = '';
    creditCardStateFilter = '';
    creditCardZipCodeFilter = '';
    creditCardCountryFilter = '';
    pmLaborRateFilter = '';
    referenceNo1Filter = '';
    referenceNo2Filter = '';
    maxGMSummaryFilter: number;
    maxGMSummaryFilterEmpty: number;
    minGMSummaryFilter: number;
    minGMSummaryFilterEmpty: number;
    oB10NoFilter = '';
    oldNameFilter = '';
    maxCustomerBillToFilter: number;
    maxCustomerBillToFilterEmpty: number;
    minCustomerBillToFilter: number;
    minCustomerBillToFilterEmpty: number;
    shipViaFilter = '';
    maxNoAddMiscFilter: number;
    maxNoAddMiscFilterEmpty: number;
    minNoAddMiscFilter: number;
    minNoAddMiscFilterEmpty: number;
    laborDiscountFilter = '';
    taxRateFilter = '';
    tmhuNoFilter = '';
    maxLockTaxCodeFilter: number;
    maxLockTaxCodeFilterEmpty: number;
    minLockTaxCodeFilter: number;
    minLockTaxCodeFilterEmpty: number;
    taxCodeImportFilter = '';
    shippingCommentsFilter = '';
    maxNoShippingChargeFilter: number;
    maxNoShippingChargeFilterEmpty: number;
    minNoShippingChargeFilter: number;
    minNoShippingChargeFilterEmpty: number;
    shippingCompanyFilter = '';
    shippingAccountFilter = '';
    eMailInvoiceAddressFilter = '';
    eMailInvoiceAttentionFilter = '';
    maxEMailInvoiceFilter: number;
    maxEMailInvoiceFilterEmpty: number;
    minEMailInvoiceFilter: number;
    minEMailInvoiceFilterEmpty: number;
    maxNoPrintInvoiceFilter: number;
    maxNoPrintInvoiceFilterEmpty: number;
    minNoPrintInvoiceFilter: number;
    minNoPrintInvoiceFilterEmpty: number;
    maxBackupRequiredFilter: number;
    maxBackupRequiredFilterEmpty: number;
    minBackupRequiredFilter: number;
    minBackupRequiredFilterEmpty: number;
    oldSalesman1Filter = '';
    oldSalesman2Filter = '';
    oldSalesman3Filter = '';
    oldSalesman4Filter = '';
    oldSalesman5Filter = '';
    oldSalesman6Filter = '';
    maxLastAutoSalesmanUpdateFilter: DateTime;
    minLastAutoSalesmanUpdateFilter: DateTime;
    maxLastAutoSalesmanUpdate1Filter: DateTime;
    minLastAutoSalesmanUpdate1Filter: DateTime;
    maxLastAutoSalesmanUpdate2Filter: DateTime;
    minLastAutoSalesmanUpdate2Filter: DateTime;
    maxLastAutoSalesmanUpdate3Filter: DateTime;
    minLastAutoSalesmanUpdate3Filter: DateTime;
    maxLastAutoSalesmanUpdate4Filter: DateTime;
    minLastAutoSalesmanUpdate4Filter: DateTime;
    maxLastAutoSalesmanUpdate5Filter: DateTime;
    minLastAutoSalesmanUpdate5Filter: DateTime;
    maxLastAutoSalesmanUpdate6Filter: DateTime;
    minLastAutoSalesmanUpdate6Filter: DateTime;
    invoiceLanguageFilter = '';
    peopleSoftFilter = -1;
    psCompanyFilter = '';
    psAccountFilter = '';
    psLocationFilter = '';
    psDeptFilter = '';
    psProductFilter = '';
    altCustomerNoFilter = '';
    maxOverRideShipToFilter: number;
    maxOverRideShipToFilterEmpty: number;
    minOverRideShipToFilter: number;
    minOverRideShipToFilterEmpty: number;
    maxOnFileResaleFilter: number;
    maxOnFileResaleFilterEmpty: number;
    minOnFileResaleFilter: number;
    minOnFileResaleFilterEmpty: number;
    maxOnFileMFGPermitFilter: number;
    maxOnFileMFGPermitFilterEmpty: number;
    minOnFileMFGPermitFilter: number;
    minOnFileMFGPermitFilterEmpty: number;
    maxOnFileInsuranceFilter: number;
    maxOnFileInsuranceFilterEmpty: number;
    minOnFileInsuranceFilter: number;
    minOnFileInsuranceFilterEmpty: number;
    maxInactiveFilter: number;
    maxInactiveFilterEmpty: number;
    minInactiveFilter: number;
    minInactiveFilterEmpty: number;
    maxOverRideShipToRatesFilter: number;
    maxOverRideShipToRatesFilterEmpty: number;
    minOverRideShipToRatesFilter: number;
    minOverRideShipToRatesFilterEmpty: number;
    maxSuppressPartsListFilter: number;
    maxSuppressPartsListFilterEmpty: number;
    minSuppressPartsListFilter: number;
    minSuppressPartsListFilterEmpty: number;
    marketingSourceFilter = '';
    maxCreditCardLastTransIDFilter: number;
    maxCreditCardLastTransIDFilterEmpty: number;
    minCreditCardLastTransIDFilter: number;
    minCreditCardLastTransIDFilterEmpty: number;
    emailRoadServiceFilter = '';
    emailShopServiceFilter = '';
    emailPMServiceFilter = '';
    emailRentalPMServiceFilter = '';
    emailPartsCounterFilter = '';
    emailEquipmentSalesFilter = '';
    emailRentalsFilter = '';
    maxIDFilter: number;
    maxIDFilterEmpty: number;
    minIDFilter: number;
    minIDFilterEmpty: number;
    arStatementsEmailAddressFilter = '';
    accountTypeDescriptionFilter = '';

    cities: City[];
    selectedCity: City;

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
        this.cities = [
            {name: 'New York', code: 'NY'},
            {name: 'Rome', code: 'RM'},
            {name: 'London', code: 'LDN'},
            {name: 'Istanbul', code: 'IST'},
            {name: 'Paris', code: 'PRS'}
        ];
    }

    ngOnInit(): void {

        // this._accountTypeServiceProxy.getAll()
        //     .subscribe()

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
        this._router.navigate(['/app/main/legacy/customer/createOrEdit']);
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
                this.numberFilter,
                this.billToFilter,
                this.nameFilter,
                this.searchNameFilter,
                this.subNameFilter,
                this.poBoxFilter,
                this.addressFilter,
                this.cityFilter,
                this.stateFilter,
                this.zipCodeFilter,
                this.countryFilter,
                this.salutationFilter,
                this.phoneFilter,
                this.extentionFilter,
                this.phone2Filter,
                this.cellularFilter,
                this.beeperFilter,
                this.homePhoneFilter,
                this.faxFilter,
                this.resaleNoFilter,
                this.eMailFilter,
                this.wwwAddressFilter,
                this.parentCompanyFilter,
                this.mapLocationFilter,
                this.salesman1Filter,
                this.salesman2Filter,
                this.salesman3Filter,
                this.salesman4Filter,
                this.salesman5Filter,
                this.salesman6Filter,
                this.maxLockAPR1Filter == null ? this.maxLockAPR1FilterEmpty : this.maxLockAPR1Filter,
                this.minLockAPR1Filter == null ? this.minLockAPR1FilterEmpty : this.minLockAPR1Filter,
                this.maxLockAPR2Filter == null ? this.maxLockAPR2FilterEmpty : this.maxLockAPR2Filter,
                this.minLockAPR2Filter == null ? this.minLockAPR2FilterEmpty : this.minLockAPR2Filter,
                this.maxLockAPR3Filter == null ? this.maxLockAPR3FilterEmpty : this.maxLockAPR3Filter,
                this.minLockAPR3Filter == null ? this.minLockAPR3FilterEmpty : this.minLockAPR3Filter,
                this.maxLockAPR4Filter == null ? this.maxLockAPR4FilterEmpty : this.maxLockAPR4Filter,
                this.minLockAPR4Filter == null ? this.minLockAPR4FilterEmpty : this.minLockAPR4Filter,
                this.maxLockAPR5Filter == null ? this.maxLockAPR5FilterEmpty : this.maxLockAPR5Filter,
                this.minLockAPR5Filter == null ? this.minLockAPR5FilterEmpty : this.minLockAPR5Filter,
                this.maxLockAPR6Filter == null ? this.maxLockAPR6FilterEmpty : this.maxLockAPR6Filter,
                this.minLockAPR6Filter == null ? this.minLockAPR6FilterEmpty : this.minLockAPR6Filter,
                this.maxSalesGroup1Filter == null ? this.maxSalesGroup1FilterEmpty : this.maxSalesGroup1Filter,
                this.minSalesGroup1Filter == null ? this.minSalesGroup1FilterEmpty : this.minSalesGroup1Filter,
                this.maxSalesGroup2Filter == null ? this.maxSalesGroup2FilterEmpty : this.maxSalesGroup2Filter,
                this.minSalesGroup2Filter == null ? this.minSalesGroup2FilterEmpty : this.minSalesGroup2Filter,
                this.maxSalesGroup3Filter == null ? this.maxSalesGroup3FilterEmpty : this.maxSalesGroup3Filter,
                this.minSalesGroup3Filter == null ? this.minSalesGroup3FilterEmpty : this.minSalesGroup3Filter,
                this.maxSalesGroup4Filter == null ? this.maxSalesGroup4FilterEmpty : this.maxSalesGroup4Filter,
                this.minSalesGroup4Filter == null ? this.minSalesGroup4FilterEmpty : this.minSalesGroup4Filter,
                this.maxSalesGroup5Filter == null ? this.maxSalesGroup5FilterEmpty : this.maxSalesGroup5Filter,
                this.minSalesGroup5Filter == null ? this.minSalesGroup5FilterEmpty : this.minSalesGroup5Filter,
                this.maxSalesGroup6Filter == null ? this.maxSalesGroup6FilterEmpty : this.maxSalesGroup6Filter,
                this.minSalesGroup6Filter == null ? this.minSalesGroup6FilterEmpty : this.minSalesGroup6Filter,
                this.termsFilter,
                this.fiscalEndFilter,
                this.dunsCodeFilter,
                this.sicCodeFilter,
                this.mailingGroupFilter,
                this.makesFilter,
                this.maxPOReqFilter == null ? this.maxPOReqFilterEmpty : this.maxPOReqFilter,
                this.minPOReqFilter == null ? this.minPOReqFilterEmpty : this.minPOReqFilter,
                this.maxPrevShipFilter == null ? this.maxPrevShipFilterEmpty : this.maxPrevShipFilter,
                this.minPrevShipFilter == null ? this.minPrevShipFilterEmpty : this.minPrevShipFilter,
                this.maxTaxableFilter == null ? this.maxTaxableFilterEmpty : this.maxTaxableFilter,
                this.minTaxableFilter == null ? this.minTaxableFilterEmpty : this.minTaxableFilter,
                this.taxCodeFilter,
                this.laborRateFilter,
                this.shopLaborRateFilter,
                this.maxShowLaborRateFilter == null ? this.maxShowLaborRateFilterEmpty : this.maxShowLaborRateFilter,
                this.minShowLaborRateFilter == null ? this.minShowLaborRateFilterEmpty : this.minShowLaborRateFilter,
                this.rentalRateFilter,
                this.maxShowPartNoAliasFilter == null
                    ? this.maxShowPartNoAliasFilterEmpty
                    : this.maxShowPartNoAliasFilter,
                this.minShowPartNoAliasFilter == null
                    ? this.minShowPartNoAliasFilterEmpty
                    : this.minShowPartNoAliasFilter,
                this.partsRateFilter,
                this.maxPartsRateDiscountFilter == null
                    ? this.maxPartsRateDiscountFilterEmpty
                    : this.maxPartsRateDiscountFilter,
                this.minPartsRateDiscountFilter == null
                    ? this.minPartsRateDiscountFilterEmpty
                    : this.minPartsRateDiscountFilter,
                this.maxAddedFilter === undefined
                    ? this.maxAddedFilter
                    : this._dateTimeService.getEndOfDayForDate(this.maxAddedFilter),
                this.minAddedFilter === undefined
                    ? this.minAddedFilter
                    : this._dateTimeService.getStartOfDayForDate(this.minAddedFilter),
                this.addedByFilter,
                this.maxChangedFilter === undefined
                    ? this.maxChangedFilter
                    : this._dateTimeService.getEndOfDayForDate(this.maxChangedFilter),
                this.minChangedFilter === undefined
                    ? this.minChangedFilter
                    : this._dateTimeService.getStartOfDayForDate(this.minChangedFilter),
                this.changedByFilter,
                this.salesContactFilter,
                this.csContactFilter,
                this.accountingContactFilter,
                this.maxInternalCustomerFilter == null
                    ? this.maxInternalCustomerFilterEmpty
                    : this.maxInternalCustomerFilter,
                this.minInternalCustomerFilter == null
                    ? this.minInternalCustomerFilterEmpty
                    : this.minInternalCustomerFilter,
                this.maxEquipmentBidFilter == null ? this.maxEquipmentBidFilterEmpty : this.maxEquipmentBidFilter,
                this.minEquipmentBidFilter == null ? this.minEquipmentBidFilterEmpty : this.minEquipmentBidFilter,
                this.commentsFilter,
                this.arCommentsFilter,
                this.companyCommentsFilter,
                this.maxCompanyCommentsDateFilter === undefined
                    ? this.maxCompanyCommentsDateFilter
                    : this._dateTimeService.getEndOfDayForDate(this.maxCompanyCommentsDateFilter),
                this.minCompanyCommentsDateFilter === undefined
                    ? this.minCompanyCommentsDateFilter
                    : this._dateTimeService.getStartOfDayForDate(this.minCompanyCommentsDateFilter),
                this.companyCommentsByFilter,
                this.businessCategoryFilter,
                this.businessDescriptionFilter,
                this.sicCode2Filter,
                this.sicCode3Filter,
                this.sicCode4Filter,
                this.maxShiftsFilter == null ? this.maxShiftsFilterEmpty : this.maxShiftsFilter,
                this.minShiftsFilter == null ? this.minShiftsFilterEmpty : this.minShiftsFilter,
                this.categoryFilter,
                this.maxHoursOfOpStartFilter === undefined
                    ? this.maxHoursOfOpStartFilter
                    : this._dateTimeService.getEndOfDayForDate(this.maxHoursOfOpStartFilter),
                this.minHoursOfOpStartFilter === undefined
                    ? this.minHoursOfOpStartFilter
                    : this._dateTimeService.getStartOfDayForDate(this.minHoursOfOpStartFilter),
                this.maxHoursOfOpEndFilter === undefined
                    ? this.maxHoursOfOpEndFilter
                    : this._dateTimeService.getEndOfDayForDate(this.maxHoursOfOpEndFilter),
                this.minHoursOfOpEndFilter === undefined
                    ? this.minHoursOfOpEndFilter
                    : this._dateTimeService.getStartOfDayForDate(this.minHoursOfOpEndFilter),
                this.deliveryInfoFilter,
                this.customerTerritoryFilter,
                this.maxCreditHoldFlagFilter == null ? this.maxCreditHoldFlagFilterEmpty : this.maxCreditHoldFlagFilter,
                this.minCreditHoldFlagFilter == null ? this.minCreditHoldFlagFilterEmpty : this.minCreditHoldFlagFilter,
                this.creditRating1Filter,
                this.creditRating2Filter,
                this.maxStatementsFilter == null ? this.maxStatementsFilterEmpty : this.maxStatementsFilter,
                this.minStatementsFilter == null ? this.minStatementsFilterEmpty : this.minStatementsFilter,
                this.maxCreditHoldDaysFilter == null ? this.maxCreditHoldDaysFilterEmpty : this.maxCreditHoldDaysFilter,
                this.minCreditHoldDaysFilter == null ? this.minCreditHoldDaysFilterEmpty : this.minCreditHoldDaysFilter,
                this.maxFinanceChargeFilter == null ? this.maxFinanceChargeFilterEmpty : this.maxFinanceChargeFilter,
                this.minFinanceChargeFilter == null ? this.minFinanceChargeFilterEmpty : this.minFinanceChargeFilter,
                this.maxResaleExpDateFilter === undefined
                    ? this.maxResaleExpDateFilter
                    : this._dateTimeService.getEndOfDayForDate(this.maxResaleExpDateFilter),
                this.minResaleExpDateFilter === undefined
                    ? this.minResaleExpDateFilter
                    : this._dateTimeService.getStartOfDayForDate(this.minResaleExpDateFilter),
                this.stateTaxCodeFilter,
                this.countyTaxCodeFilter,
                this.cityTaxCodeFilter,
                this.maxAbsoluteTaxCodesFilter == null
                    ? this.maxAbsoluteTaxCodesFilterEmpty
                    : this.maxAbsoluteTaxCodesFilter,
                this.minAbsoluteTaxCodesFilter == null
                    ? this.minAbsoluteTaxCodesFilterEmpty
                    : this.minAbsoluteTaxCodesFilter,
                this.mfgPermitNoFilter,
                this.maxMFGPermitExpDateFilter === undefined
                    ? this.maxMFGPermitExpDateFilter
                    : this._dateTimeService.getEndOfDayForDate(this.maxMFGPermitExpDateFilter),
                this.minMFGPermitExpDateFilter === undefined
                    ? this.minMFGPermitExpDateFilter
                    : this._dateTimeService.getStartOfDayForDate(this.minMFGPermitExpDateFilter),
                this.maxBranchFilter == null ? this.maxBranchFilterEmpty : this.maxBranchFilter,
                this.minBranchFilter == null ? this.minBranchFilterEmpty : this.minBranchFilter,
                this.maxShowLaborHoursFilter == null ? this.maxShowLaborHoursFilterEmpty : this.maxShowLaborHoursFilter,
                this.minShowLaborHoursFilter == null ? this.minShowLaborHoursFilterEmpty : this.minShowLaborHoursFilter,
                this.vendorNoFilter,
                this.localTaxCodeFilter,
                this.currencyTypeFilter,
                this.creditCardNoFilter,
                this.creditCardCVVFilter,
                this.creditCardExpDateFilter,
                this.creditCardTypeFilter,
                this.nameOnCreditCardFilter,
                this.rfcFilter,
                this.oldNumberFilter,
                this.maxSuppressPartsPricingFilter == null
                    ? this.maxSuppressPartsPricingFilterEmpty
                    : this.maxSuppressPartsPricingFilter,
                this.minSuppressPartsPricingFilter == null
                    ? this.minSuppressPartsPricingFilterEmpty
                    : this.minSuppressPartsPricingFilter,
                this.maxServiceChargeFilter == null ? this.maxServiceChargeFilterEmpty : this.maxServiceChargeFilter,
                this.minServiceChargeFilter == null ? this.minServiceChargeFilterEmpty : this.minServiceChargeFilter,
                this.serviceChargeDescriptionFilter,
                this.maxFinalCopiesFilter == null ? this.maxFinalCopiesFilterEmpty : this.maxFinalCopiesFilter,
                this.minFinalCopiesFilter == null ? this.minFinalCopiesFilterEmpty : this.minFinalCopiesFilter,
                this.maxPOBoxAndAddressFilter == null
                    ? this.maxPOBoxAndAddressFilterEmpty
                    : this.maxPOBoxAndAddressFilter,
                this.minPOBoxAndAddressFilter == null
                    ? this.minPOBoxAndAddressFilterEmpty
                    : this.minPOBoxAndAddressFilter,
                this.insuranceNoFilter,
                this.maxInsuranceNoDateFilter === undefined
                    ? this.maxInsuranceNoDateFilter
                    : this._dateTimeService.getEndOfDayForDate(this.maxInsuranceNoDateFilter),
                this.minInsuranceNoDateFilter === undefined
                    ? this.minInsuranceNoDateFilter
                    : this._dateTimeService.getStartOfDayForDate(this.minInsuranceNoDateFilter),
                this.maxInsuranceNoRecvDateFilter === undefined
                    ? this.maxInsuranceNoRecvDateFilter
                    : this._dateTimeService.getEndOfDayForDate(this.maxInsuranceNoRecvDateFilter),
                this.minInsuranceNoRecvDateFilter === undefined
                    ? this.minInsuranceNoRecvDateFilter
                    : this._dateTimeService.getStartOfDayForDate(this.minInsuranceNoRecvDateFilter),
                this.creditCardAddressFilter,
                this.creditCardPOBoxFilter,
                this.creditCardCityFilter,
                this.creditCardStateFilter,
                this.creditCardZipCodeFilter,
                this.creditCardCountryFilter,
                this.pmLaborRateFilter,
                this.referenceNo1Filter,
                this.referenceNo2Filter,
                this.maxGMSummaryFilter == null ? this.maxGMSummaryFilterEmpty : this.maxGMSummaryFilter,
                this.minGMSummaryFilter == null ? this.minGMSummaryFilterEmpty : this.minGMSummaryFilter,
                this.oB10NoFilter,
                this.oldNameFilter,
                this.maxCustomerBillToFilter == null ? this.maxCustomerBillToFilterEmpty : this.maxCustomerBillToFilter,
                this.minCustomerBillToFilter == null ? this.minCustomerBillToFilterEmpty : this.minCustomerBillToFilter,
                this.shipViaFilter,
                this.maxNoAddMiscFilter == null ? this.maxNoAddMiscFilterEmpty : this.maxNoAddMiscFilter,
                this.minNoAddMiscFilter == null ? this.minNoAddMiscFilterEmpty : this.minNoAddMiscFilter,
                this.laborDiscountFilter,
                this.taxRateFilter,
                this.tmhuNoFilter,
                this.maxLockTaxCodeFilter == null ? this.maxLockTaxCodeFilterEmpty : this.maxLockTaxCodeFilter,
                this.minLockTaxCodeFilter == null ? this.minLockTaxCodeFilterEmpty : this.minLockTaxCodeFilter,
                this.taxCodeImportFilter,
                this.shippingCommentsFilter,
                this.maxNoShippingChargeFilter == null
                    ? this.maxNoShippingChargeFilterEmpty
                    : this.maxNoShippingChargeFilter,
                this.minNoShippingChargeFilter == null
                    ? this.minNoShippingChargeFilterEmpty
                    : this.minNoShippingChargeFilter,
                this.shippingCompanyFilter,
                this.shippingAccountFilter,
                this.eMailInvoiceAddressFilter,
                this.eMailInvoiceAttentionFilter,
                this.maxEMailInvoiceFilter == null ? this.maxEMailInvoiceFilterEmpty : this.maxEMailInvoiceFilter,
                this.minEMailInvoiceFilter == null ? this.minEMailInvoiceFilterEmpty : this.minEMailInvoiceFilter,
                this.maxNoPrintInvoiceFilter == null ? this.maxNoPrintInvoiceFilterEmpty : this.maxNoPrintInvoiceFilter,
                this.minNoPrintInvoiceFilter == null ? this.minNoPrintInvoiceFilterEmpty : this.minNoPrintInvoiceFilter,
                this.maxBackupRequiredFilter == null ? this.maxBackupRequiredFilterEmpty : this.maxBackupRequiredFilter,
                this.minBackupRequiredFilter == null ? this.minBackupRequiredFilterEmpty : this.minBackupRequiredFilter,
                this.oldSalesman1Filter,
                this.oldSalesman2Filter,
                this.oldSalesman3Filter,
                this.oldSalesman4Filter,
                this.oldSalesman5Filter,
                this.oldSalesman6Filter,
                this.maxLastAutoSalesmanUpdateFilter === undefined
                    ? this.maxLastAutoSalesmanUpdateFilter
                    : this._dateTimeService.getEndOfDayForDate(this.maxLastAutoSalesmanUpdateFilter),
                this.minLastAutoSalesmanUpdateFilter === undefined
                    ? this.minLastAutoSalesmanUpdateFilter
                    : this._dateTimeService.getStartOfDayForDate(this.minLastAutoSalesmanUpdateFilter),
                this.maxLastAutoSalesmanUpdate1Filter === undefined
                    ? this.maxLastAutoSalesmanUpdate1Filter
                    : this._dateTimeService.getEndOfDayForDate(this.maxLastAutoSalesmanUpdate1Filter),
                this.minLastAutoSalesmanUpdate1Filter === undefined
                    ? this.minLastAutoSalesmanUpdate1Filter
                    : this._dateTimeService.getStartOfDayForDate(this.minLastAutoSalesmanUpdate1Filter),
                this.maxLastAutoSalesmanUpdate2Filter === undefined
                    ? this.maxLastAutoSalesmanUpdate2Filter
                    : this._dateTimeService.getEndOfDayForDate(this.maxLastAutoSalesmanUpdate2Filter),
                this.minLastAutoSalesmanUpdate2Filter === undefined
                    ? this.minLastAutoSalesmanUpdate2Filter
                    : this._dateTimeService.getStartOfDayForDate(this.minLastAutoSalesmanUpdate2Filter),
                this.maxLastAutoSalesmanUpdate3Filter === undefined
                    ? this.maxLastAutoSalesmanUpdate3Filter
                    : this._dateTimeService.getEndOfDayForDate(this.maxLastAutoSalesmanUpdate3Filter),
                this.minLastAutoSalesmanUpdate3Filter === undefined
                    ? this.minLastAutoSalesmanUpdate3Filter
                    : this._dateTimeService.getStartOfDayForDate(this.minLastAutoSalesmanUpdate3Filter),
                this.maxLastAutoSalesmanUpdate4Filter === undefined
                    ? this.maxLastAutoSalesmanUpdate4Filter
                    : this._dateTimeService.getEndOfDayForDate(this.maxLastAutoSalesmanUpdate4Filter),
                this.minLastAutoSalesmanUpdate4Filter === undefined
                    ? this.minLastAutoSalesmanUpdate4Filter
                    : this._dateTimeService.getStartOfDayForDate(this.minLastAutoSalesmanUpdate4Filter),
                this.maxLastAutoSalesmanUpdate5Filter === undefined
                    ? this.maxLastAutoSalesmanUpdate5Filter
                    : this._dateTimeService.getEndOfDayForDate(this.maxLastAutoSalesmanUpdate5Filter),
                this.minLastAutoSalesmanUpdate5Filter === undefined
                    ? this.minLastAutoSalesmanUpdate5Filter
                    : this._dateTimeService.getStartOfDayForDate(this.minLastAutoSalesmanUpdate5Filter),
                this.maxLastAutoSalesmanUpdate6Filter === undefined
                    ? this.maxLastAutoSalesmanUpdate6Filter
                    : this._dateTimeService.getEndOfDayForDate(this.maxLastAutoSalesmanUpdate6Filter),
                this.minLastAutoSalesmanUpdate6Filter === undefined
                    ? this.minLastAutoSalesmanUpdate6Filter
                    : this._dateTimeService.getStartOfDayForDate(this.minLastAutoSalesmanUpdate6Filter),
                this.invoiceLanguageFilter,
                this.peopleSoftFilter,
                this.psCompanyFilter,
                this.psAccountFilter,
                this.psLocationFilter,
                this.psDeptFilter,
                this.psProductFilter,
                this.altCustomerNoFilter,
                this.maxOverRideShipToFilter == null ? this.maxOverRideShipToFilterEmpty : this.maxOverRideShipToFilter,
                this.minOverRideShipToFilter == null ? this.minOverRideShipToFilterEmpty : this.minOverRideShipToFilter,
                this.maxOnFileResaleFilter == null ? this.maxOnFileResaleFilterEmpty : this.maxOnFileResaleFilter,
                this.minOnFileResaleFilter == null ? this.minOnFileResaleFilterEmpty : this.minOnFileResaleFilter,
                this.maxOnFileMFGPermitFilter == null
                    ? this.maxOnFileMFGPermitFilterEmpty
                    : this.maxOnFileMFGPermitFilter,
                this.minOnFileMFGPermitFilter == null
                    ? this.minOnFileMFGPermitFilterEmpty
                    : this.minOnFileMFGPermitFilter,
                this.maxOnFileInsuranceFilter == null
                    ? this.maxOnFileInsuranceFilterEmpty
                    : this.maxOnFileInsuranceFilter,
                this.minOnFileInsuranceFilter == null
                    ? this.minOnFileInsuranceFilterEmpty
                    : this.minOnFileInsuranceFilter,
                this.maxInactiveFilter == null ? this.maxInactiveFilterEmpty : this.maxInactiveFilter,
                this.minInactiveFilter == null ? this.minInactiveFilterEmpty : this.minInactiveFilter,
                this.maxOverRideShipToRatesFilter == null
                    ? this.maxOverRideShipToRatesFilterEmpty
                    : this.maxOverRideShipToRatesFilter,
                this.minOverRideShipToRatesFilter == null
                    ? this.minOverRideShipToRatesFilterEmpty
                    : this.minOverRideShipToRatesFilter,
                this.maxSuppressPartsListFilter == null
                    ? this.maxSuppressPartsListFilterEmpty
                    : this.maxSuppressPartsListFilter,
                this.minSuppressPartsListFilter == null
                    ? this.minSuppressPartsListFilterEmpty
                    : this.minSuppressPartsListFilter,
                this.marketingSourceFilter,
                this.maxCreditCardLastTransIDFilter == null
                    ? this.maxCreditCardLastTransIDFilterEmpty
                    : this.maxCreditCardLastTransIDFilter,
                this.minCreditCardLastTransIDFilter == null
                    ? this.minCreditCardLastTransIDFilterEmpty
                    : this.minCreditCardLastTransIDFilter,
                this.emailRoadServiceFilter,
                this.emailShopServiceFilter,
                this.emailPMServiceFilter,
                this.emailRentalPMServiceFilter,
                this.emailPartsCounterFilter,
                this.emailEquipmentSalesFilter,
                this.emailRentalsFilter,
                this.maxIDFilter == null ? this.maxIDFilterEmpty : this.maxIDFilter,
                this.minIDFilter == null ? this.minIDFilterEmpty : this.minIDFilter,
                this.arStatementsEmailAddressFilter,
                this.accountTypeDescriptionFilter
            )
            .subscribe((result) => {
                this._fileDownloadService.downloadTempFile(result);
            });
    }
}
