using Abp.Application.Services.Dto;
using System;

namespace SBCRM.Legacy.Dtos
{
    public class GetAllCustomerInput : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }

        public string NumberFilter { get; set; }

        public string BillToFilter { get; set; }

        public string NameFilter { get; set; }

        public string SearchNameFilter { get; set; }

        public string SubNameFilter { get; set; }

        public string POBoxFilter { get; set; }

        public string AddressFilter { get; set; }

        public string CityFilter { get; set; }

        public string StateFilter { get; set; }

        public string ZipCodeFilter { get; set; }

        public string CountryFilter { get; set; }

        public string SalutationFilter { get; set; }

        public string PhoneFilter { get; set; }

        public string ExtentionFilter { get; set; }

        public string Phone2Filter { get; set; }

        public string CellularFilter { get; set; }

        public string BeeperFilter { get; set; }

        public string HomePhoneFilter { get; set; }

        public string FaxFilter { get; set; }

        public string ResaleNoFilter { get; set; }

        public string EMailFilter { get; set; }

        public string WWWAddressFilter { get; set; }

        public string ParentCompanyFilter { get; set; }

        public string MapLocationFilter { get; set; }

        public string Salesman1Filter { get; set; }

        public string Salesman2Filter { get; set; }

        public string Salesman3Filter { get; set; }

        public string Salesman4Filter { get; set; }

        public string Salesman5Filter { get; set; }

        public string Salesman6Filter { get; set; }

        public short? MaxLockAPR1Filter { get; set; }
        public short? MinLockAPR1Filter { get; set; }

        public short? MaxLockAPR2Filter { get; set; }
        public short? MinLockAPR2Filter { get; set; }

        public short? MaxLockAPR3Filter { get; set; }
        public short? MinLockAPR3Filter { get; set; }

        public short? MaxLockAPR4Filter { get; set; }
        public short? MinLockAPR4Filter { get; set; }

        public short? MaxLockAPR5Filter { get; set; }
        public short? MinLockAPR5Filter { get; set; }

        public short? MaxLockAPR6Filter { get; set; }
        public short? MinLockAPR6Filter { get; set; }

        public short? MaxSalesGroup1Filter { get; set; }
        public short? MinSalesGroup1Filter { get; set; }

        public short? MaxSalesGroup2Filter { get; set; }
        public short? MinSalesGroup2Filter { get; set; }

        public short? MaxSalesGroup3Filter { get; set; }
        public short? MinSalesGroup3Filter { get; set; }

        public short? MaxSalesGroup4Filter { get; set; }
        public short? MinSalesGroup4Filter { get; set; }

        public short? MaxSalesGroup5Filter { get; set; }
        public short? MinSalesGroup5Filter { get; set; }

        public short? MaxSalesGroup6Filter { get; set; }
        public short? MinSalesGroup6Filter { get; set; }

        public string TermsFilter { get; set; }

        public string FiscalEndFilter { get; set; }

        public string DunsCodeFilter { get; set; }

        public string SICCodeFilter { get; set; }

        public string MailingGroupFilter { get; set; }

        public string MakesFilter { get; set; }

        public short? MaxPOReqFilter { get; set; }
        public short? MinPOReqFilter { get; set; }

        public short? MaxPrevShipFilter { get; set; }
        public short? MinPrevShipFilter { get; set; }

        public short? MaxTaxableFilter { get; set; }
        public short? MinTaxableFilter { get; set; }

        public string TaxCodeFilter { get; set; }

        public string LaborRateFilter { get; set; }

        public string ShopLaborRateFilter { get; set; }

        public short? MaxShowLaborRateFilter { get; set; }
        public short? MinShowLaborRateFilter { get; set; }

        public string RentalRateFilter { get; set; }

        public short? MaxShowPartNoAliasFilter { get; set; }
        public short? MinShowPartNoAliasFilter { get; set; }

        public string PartsRateFilter { get; set; }

        public double? MaxPartsRateDiscountFilter { get; set; }
        public double? MinPartsRateDiscountFilter { get; set; }

        public DateTime? MaxAddedFilter { get; set; }
        public DateTime? MinAddedFilter { get; set; }

        public string AddedByFilter { get; set; }

        public DateTime? MaxChangedFilter { get; set; }
        public DateTime? MinChangedFilter { get; set; }

        public string ChangedByFilter { get; set; }

        public string SalesContactFilter { get; set; }

        public string CSContactFilter { get; set; }

        public string AccountingContactFilter { get; set; }

        public short? MaxInternalCustomerFilter { get; set; }
        public short? MinInternalCustomerFilter { get; set; }

        public short? MaxEquipmentBidFilter { get; set; }
        public short? MinEquipmentBidFilter { get; set; }

        public string CommentsFilter { get; set; }

        public string ARCommentsFilter { get; set; }

        public string CompanyCommentsFilter { get; set; }

        public DateTime? MaxCompanyCommentsDateFilter { get; set; }
        public DateTime? MinCompanyCommentsDateFilter { get; set; }

        public string CompanyCommentsByFilter { get; set; }

        public string BusinessCategoryFilter { get; set; }

        public string BusinessDescriptionFilter { get; set; }

        public string SICCode2Filter { get; set; }

        public string SICCode3Filter { get; set; }

        public string SICCode4Filter { get; set; }

        public short? MaxShiftsFilter { get; set; }
        public short? MinShiftsFilter { get; set; }

        public string CategoryFilter { get; set; }

        public DateTime? MaxHoursOfOpStartFilter { get; set; }
        public DateTime? MinHoursOfOpStartFilter { get; set; }

        public DateTime? MaxHoursOfOpEndFilter { get; set; }
        public DateTime? MinHoursOfOpEndFilter { get; set; }

        public string DeliveryInfoFilter { get; set; }

        public string CustomerTerritoryFilter { get; set; }

        public short? MaxCreditHoldFlagFilter { get; set; }
        public short? MinCreditHoldFlagFilter { get; set; }

        public string CreditRating1Filter { get; set; }

        public string CreditRating2Filter { get; set; }

        public short? MaxStatementsFilter { get; set; }
        public short? MinStatementsFilter { get; set; }

        public short? MaxCreditHoldDaysFilter { get; set; }
        public short? MinCreditHoldDaysFilter { get; set; }

        public short? MaxFinanceChargeFilter { get; set; }
        public short? MinFinanceChargeFilter { get; set; }

        public DateTime? MaxResaleExpDateFilter { get; set; }
        public DateTime? MinResaleExpDateFilter { get; set; }

        public string StateTaxCodeFilter { get; set; }

        public string CountyTaxCodeFilter { get; set; }

        public string CityTaxCodeFilter { get; set; }

        public short? MaxAbsoluteTaxCodesFilter { get; set; }
        public short? MinAbsoluteTaxCodesFilter { get; set; }

        public string MFGPermitNoFilter { get; set; }

        public DateTime? MaxMFGPermitExpDateFilter { get; set; }
        public DateTime? MinMFGPermitExpDateFilter { get; set; }

        public short? MaxBranchFilter { get; set; }
        public short? MinBranchFilter { get; set; }

        public short? MaxShowLaborHoursFilter { get; set; }
        public short? MinShowLaborHoursFilter { get; set; }

        public string VendorNoFilter { get; set; }

        public string LocalTaxCodeFilter { get; set; }

        public string CurrencyTypeFilter { get; set; }

        public string CreditCardNoFilter { get; set; }

        public string CreditCardCVVFilter { get; set; }

        public string CreditCardExpDateFilter { get; set; }

        public string CreditCardTypeFilter { get; set; }

        public string NameOnCreditCardFilter { get; set; }

        public string RFCFilter { get; set; }

        public string OldNumberFilter { get; set; }

        public short? MaxSuppressPartsPricingFilter { get; set; }
        public short? MinSuppressPartsPricingFilter { get; set; }

        public decimal? MaxServiceChargeFilter { get; set; }
        public decimal? MinServiceChargeFilter { get; set; }

        public string ServiceChargeDescriptionFilter { get; set; }

        public short? MaxFinalCopiesFilter { get; set; }
        public short? MinFinalCopiesFilter { get; set; }

        public short? MaxPOBoxAndAddressFilter { get; set; }
        public short? MinPOBoxAndAddressFilter { get; set; }

        public string InsuranceNoFilter { get; set; }

        public DateTime? MaxInsuranceNoDateFilter { get; set; }
        public DateTime? MinInsuranceNoDateFilter { get; set; }

        public DateTime? MaxInsuranceNoRecvDateFilter { get; set; }
        public DateTime? MinInsuranceNoRecvDateFilter { get; set; }

        public string CreditCardAddressFilter { get; set; }

        public string CreditCardPOBoxFilter { get; set; }

        public string CreditCardCityFilter { get; set; }

        public string CreditCardStateFilter { get; set; }

        public string CreditCardZipCodeFilter { get; set; }

        public string CreditCardCountryFilter { get; set; }

        public string PMLaborRateFilter { get; set; }

        public string ReferenceNo1Filter { get; set; }

        public string ReferenceNo2Filter { get; set; }

        public short? MaxGMSummaryFilter { get; set; }
        public short? MinGMSummaryFilter { get; set; }

        public string OB10NoFilter { get; set; }

        public string OldNameFilter { get; set; }

        public short? MaxCustomerBillToFilter { get; set; }
        public short? MinCustomerBillToFilter { get; set; }

        public string ShipViaFilter { get; set; }

        public short? MaxNoAddMiscFilter { get; set; }
        public short? MinNoAddMiscFilter { get; set; }

        public string LaborDiscountFilter { get; set; }

        public string TaxRateFilter { get; set; }

        public string TMHUNoFilter { get; set; }

        public short? MaxLockTaxCodeFilter { get; set; }
        public short? MinLockTaxCodeFilter { get; set; }

        public string TaxCodeImportFilter { get; set; }

        public string ShippingCommentsFilter { get; set; }

        public short? MaxNoShippingChargeFilter { get; set; }
        public short? MinNoShippingChargeFilter { get; set; }

        public string ShippingCompanyFilter { get; set; }

        public string ShippingAccountFilter { get; set; }

        public string EMailInvoiceAddressFilter { get; set; }

        public string EMailInvoiceAttentionFilter { get; set; }

        public short? MaxEMailInvoiceFilter { get; set; }
        public short? MinEMailInvoiceFilter { get; set; }

        public short? MaxNoPrintInvoiceFilter { get; set; }
        public short? MinNoPrintInvoiceFilter { get; set; }

        public short? MaxBackupRequiredFilter { get; set; }
        public short? MinBackupRequiredFilter { get; set; }

        public string OldSalesman1Filter { get; set; }

        public string OldSalesman2Filter { get; set; }

        public string OldSalesman3Filter { get; set; }

        public string OldSalesman4Filter { get; set; }

        public string OldSalesman5Filter { get; set; }

        public string OldSalesman6Filter { get; set; }

        public DateTime? MaxLastAutoSalesmanUpdateFilter { get; set; }
        public DateTime? MinLastAutoSalesmanUpdateFilter { get; set; }

        public DateTime? MaxLastAutoSalesmanUpdate1Filter { get; set; }
        public DateTime? MinLastAutoSalesmanUpdate1Filter { get; set; }

        public DateTime? MaxLastAutoSalesmanUpdate2Filter { get; set; }
        public DateTime? MinLastAutoSalesmanUpdate2Filter { get; set; }

        public DateTime? MaxLastAutoSalesmanUpdate3Filter { get; set; }
        public DateTime? MinLastAutoSalesmanUpdate3Filter { get; set; }

        public DateTime? MaxLastAutoSalesmanUpdate4Filter { get; set; }
        public DateTime? MinLastAutoSalesmanUpdate4Filter { get; set; }

        public DateTime? MaxLastAutoSalesmanUpdate5Filter { get; set; }
        public DateTime? MinLastAutoSalesmanUpdate5Filter { get; set; }

        public DateTime? MaxLastAutoSalesmanUpdate6Filter { get; set; }
        public DateTime? MinLastAutoSalesmanUpdate6Filter { get; set; }

        public string InvoiceLanguageFilter { get; set; }

        public int? PeopleSoftFilter { get; set; }

        public string PSCompanyFilter { get; set; }

        public string PSAccountFilter { get; set; }

        public string PSLocationFilter { get; set; }

        public string PSDeptFilter { get; set; }

        public string PSProductFilter { get; set; }

        public string AltCustomerNoFilter { get; set; }

        public short? MaxOverRideShipToFilter { get; set; }
        public short? MinOverRideShipToFilter { get; set; }

        public short? MaxOnFileResaleFilter { get; set; }
        public short? MinOnFileResaleFilter { get; set; }

        public short? MaxOnFileMFGPermitFilter { get; set; }
        public short? MinOnFileMFGPermitFilter { get; set; }

        public short? MaxOnFileInsuranceFilter { get; set; }
        public short? MinOnFileInsuranceFilter { get; set; }

        public int? MaxInactiveFilter { get; set; }
        public int? MinInactiveFilter { get; set; }

        public int? MaxOverRideShipToRatesFilter { get; set; }
        public int? MinOverRideShipToRatesFilter { get; set; }

        public short? MaxSuppressPartsListFilter { get; set; }
        public short? MinSuppressPartsListFilter { get; set; }

        public string MarketingSourceFilter { get; set; }

        public int? MaxCreditCardLastTransIDFilter { get; set; }
        public int? MinCreditCardLastTransIDFilter { get; set; }

        public string EmailRoadServiceFilter { get; set; }

        public string EmailShopServiceFilter { get; set; }

        public string EmailPMServiceFilter { get; set; }

        public string EmailRentalPMServiceFilter { get; set; }

        public string EmailPartsCounterFilter { get; set; }

        public string EmailEquipmentSalesFilter { get; set; }

        public string EmailRentalsFilter { get; set; }

        public int? MaxIDFilter { get; set; }
        public int? MinIDFilter { get; set; }

        public string ARStatementsEmailAddressFilter { get; set; }

        public string AccountTypeDescriptionFilter { get; set; }

    }
}