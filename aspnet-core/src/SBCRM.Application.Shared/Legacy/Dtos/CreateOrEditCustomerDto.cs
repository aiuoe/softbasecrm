using System;
using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace SBCRM.Legacy.Dtos
{
    public class CreateOrEditCustomerDto
    {

        [Required]
        [StringLength(CustomerConsts.MaxNumberLength, MinimumLength = CustomerConsts.MinNumberLength)]
        public string Number { get; set; }

        [StringLength(CustomerConsts.MaxBillToLength, MinimumLength = CustomerConsts.MinBillToLength)]
        public string BillTo { get; set; }

        [StringLength(CustomerConsts.MaxNameLength, MinimumLength = CustomerConsts.MinNameLength)]
        public string Name { get; set; }

        [StringLength(CustomerConsts.MaxSearchNameLength, MinimumLength = CustomerConsts.MinSearchNameLength)]
        public string SearchName { get; set; }

        [StringLength(CustomerConsts.MaxSubNameLength, MinimumLength = CustomerConsts.MinSubNameLength)]
        public string SubName { get; set; }

        [StringLength(CustomerConsts.MaxPOBoxLength, MinimumLength = CustomerConsts.MinPOBoxLength)]
        public string POBox { get; set; }

        [StringLength(CustomerConsts.MaxAddressLength, MinimumLength = CustomerConsts.MinAddressLength)]
        public string Address { get; set; }

        [StringLength(CustomerConsts.MaxCityLength, MinimumLength = CustomerConsts.MinCityLength)]
        public string City { get; set; }

        [StringLength(CustomerConsts.MaxStateLength, MinimumLength = CustomerConsts.MinStateLength)]
        public string State { get; set; }

        [StringLength(CustomerConsts.MaxZipCodeLength, MinimumLength = CustomerConsts.MinZipCodeLength)]
        public string ZipCode { get; set; }

        [StringLength(CustomerConsts.MaxCountryLength, MinimumLength = CustomerConsts.MinCountryLength)]
        public string Country { get; set; }

        [StringLength(CustomerConsts.MaxSalutationLength, MinimumLength = CustomerConsts.MinSalutationLength)]
        public string Salutation { get; set; }

        [StringLength(CustomerConsts.MaxPhoneLength, MinimumLength = CustomerConsts.MinPhoneLength)]
        public string Phone { get; set; }

        [StringLength(CustomerConsts.MaxExtentionLength, MinimumLength = CustomerConsts.MinExtentionLength)]
        public string Extention { get; set; }

        [StringLength(CustomerConsts.MaxPhone2Length, MinimumLength = CustomerConsts.MinPhone2Length)]
        public string Phone2 { get; set; }

        [StringLength(CustomerConsts.MaxCellularLength, MinimumLength = CustomerConsts.MinCellularLength)]
        public string Cellular { get; set; }

        [StringLength(CustomerConsts.MaxBeeperLength, MinimumLength = CustomerConsts.MinBeeperLength)]
        public string Beeper { get; set; }

        [StringLength(CustomerConsts.MaxHomePhoneLength, MinimumLength = CustomerConsts.MinHomePhoneLength)]
        public string HomePhone { get; set; }

        [StringLength(CustomerConsts.MaxFaxLength, MinimumLength = CustomerConsts.MinFaxLength)]
        public string Fax { get; set; }

        [StringLength(CustomerConsts.MaxResaleNoLength, MinimumLength = CustomerConsts.MinResaleNoLength)]
        public string ResaleNo { get; set; }

        [StringLength(CustomerConsts.MaxEMailLength, MinimumLength = CustomerConsts.MinEMailLength)]
        public string EMail { get; set; }

        [StringLength(CustomerConsts.MaxWWWAddressLength, MinimumLength = CustomerConsts.MinWWWAddressLength)]
        public string WWWAddress { get; set; }

        [StringLength(CustomerConsts.MaxParentCompanyLength, MinimumLength = CustomerConsts.MinParentCompanyLength)]
        public string ParentCompany { get; set; }

        [StringLength(CustomerConsts.MaxMapLocationLength, MinimumLength = CustomerConsts.MinMapLocationLength)]
        public string MapLocation { get; set; }

        [StringLength(CustomerConsts.MaxSalesman1Length, MinimumLength = CustomerConsts.MinSalesman1Length)]
        public string Salesman1 { get; set; }

        [StringLength(CustomerConsts.MaxSalesman2Length, MinimumLength = CustomerConsts.MinSalesman2Length)]
        public string Salesman2 { get; set; }

        [StringLength(CustomerConsts.MaxSalesman3Length, MinimumLength = CustomerConsts.MinSalesman3Length)]
        public string Salesman3 { get; set; }

        [StringLength(CustomerConsts.MaxSalesman4Length, MinimumLength = CustomerConsts.MinSalesman4Length)]
        public string Salesman4 { get; set; }

        [StringLength(CustomerConsts.MaxSalesman5Length, MinimumLength = CustomerConsts.MinSalesman5Length)]
        public string Salesman5 { get; set; }

        [StringLength(CustomerConsts.MaxSalesman6Length, MinimumLength = CustomerConsts.MinSalesman6Length)]
        public string Salesman6 { get; set; }

        public short? LockAPR1 { get; set; }

        public short? LockAPR2 { get; set; }

        public short? LockAPR3 { get; set; }

        public short? LockAPR4 { get; set; }

        public short? LockAPR5 { get; set; }

        public short? LockAPR6 { get; set; }

        public short? SalesGroup1 { get; set; }

        public short? SalesGroup2 { get; set; }

        public short? SalesGroup3 { get; set; }

        public short? SalesGroup4 { get; set; }

        public short? SalesGroup5 { get; set; }

        public short? SalesGroup6 { get; set; }

        [StringLength(CustomerConsts.MaxTermsLength, MinimumLength = CustomerConsts.MinTermsLength)]
        public string Terms { get; set; }

        [StringLength(CustomerConsts.MaxFiscalEndLength, MinimumLength = CustomerConsts.MinFiscalEndLength)]
        public string FiscalEnd { get; set; }

        [StringLength(CustomerConsts.MaxDunsCodeLength, MinimumLength = CustomerConsts.MinDunsCodeLength)]
        public string DunsCode { get; set; }

        [StringLength(CustomerConsts.MaxSICCodeLength, MinimumLength = CustomerConsts.MinSICCodeLength)]
        public string SICCode { get; set; }

        [StringLength(CustomerConsts.MaxMailingGroupLength, MinimumLength = CustomerConsts.MinMailingGroupLength)]
        public string MailingGroup { get; set; }

        [StringLength(CustomerConsts.MaxMakesLength, MinimumLength = CustomerConsts.MinMakesLength)]
        public string Makes { get; set; }

        public short? POReq { get; set; }

        public short? PrevShip { get; set; }

        public short? Taxable { get; set; }

        [StringLength(CustomerConsts.MaxTaxCodeLength, MinimumLength = CustomerConsts.MinTaxCodeLength)]
        public string TaxCode { get; set; }

        [StringLength(CustomerConsts.MaxLaborRateLength, MinimumLength = CustomerConsts.MinLaborRateLength)]
        public string LaborRate { get; set; }

        [StringLength(CustomerConsts.MaxShopLaborRateLength, MinimumLength = CustomerConsts.MinShopLaborRateLength)]
        public string ShopLaborRate { get; set; }

        public short? ShowLaborRate { get; set; }

        [StringLength(CustomerConsts.MaxRentalRateLength, MinimumLength = CustomerConsts.MinRentalRateLength)]
        public string RentalRate { get; set; }

        public short? ShowPartNoAlias { get; set; }

        [StringLength(CustomerConsts.MaxPartsRateLength, MinimumLength = CustomerConsts.MinPartsRateLength)]
        public string PartsRate { get; set; }

        public double? PartsRateDiscount { get; set; }

        public DateTime? Added { get; set; }

        [StringLength(CustomerConsts.MaxAddedByLength, MinimumLength = CustomerConsts.MinAddedByLength)]
        public string AddedBy { get; set; }

        public DateTime? Changed { get; set; }

        [StringLength(CustomerConsts.MaxChangedByLength, MinimumLength = CustomerConsts.MinChangedByLength)]
        public string ChangedBy { get; set; }

        [StringLength(CustomerConsts.MaxSalesContactLength, MinimumLength = CustomerConsts.MinSalesContactLength)]
        public string SalesContact { get; set; }

        [StringLength(CustomerConsts.MaxCSContactLength, MinimumLength = CustomerConsts.MinCSContactLength)]
        public string CSContact { get; set; }

        [StringLength(CustomerConsts.MaxAccountingContactLength, MinimumLength = CustomerConsts.MinAccountingContactLength)]
        public string AccountingContact { get; set; }

        public short? InternalCustomer { get; set; }

        public short? EquipmentBid { get; set; }

        public string Comments { get; set; }

        public string ARComments { get; set; }

        public string CompanyComments { get; set; }

        public DateTime? CompanyCommentsDate { get; set; }

        [StringLength(CustomerConsts.MaxCompanyCommentsByLength, MinimumLength = CustomerConsts.MinCompanyCommentsByLength)]
        public string CompanyCommentsBy { get; set; }

        [StringLength(CustomerConsts.MaxBusinessCategoryLength, MinimumLength = CustomerConsts.MinBusinessCategoryLength)]
        public string BusinessCategory { get; set; }

        public string BusinessDescription { get; set; }

        [StringLength(CustomerConsts.MaxSICCode2Length, MinimumLength = CustomerConsts.MinSICCode2Length)]
        public string SICCode2 { get; set; }

        [StringLength(CustomerConsts.MaxSICCode3Length, MinimumLength = CustomerConsts.MinSICCode3Length)]
        public string SICCode3 { get; set; }

        [StringLength(CustomerConsts.MaxSICCode4Length, MinimumLength = CustomerConsts.MinSICCode4Length)]
        public string SICCode4 { get; set; }

        public short? Shifts { get; set; }

        [StringLength(CustomerConsts.MaxCategoryLength, MinimumLength = CustomerConsts.MinCategoryLength)]
        public string Category { get; set; }

        public DateTime? HoursOfOpStart { get; set; }

        public DateTime? HoursOfOpEnd { get; set; }

        public string DeliveryInfo { get; set; }

        [StringLength(CustomerConsts.MaxCustomerTerritoryLength, MinimumLength = CustomerConsts.MinCustomerTerritoryLength)]
        public string CustomerTerritory { get; set; }

        public short? CreditHoldFlag { get; set; }

        [StringLength(CustomerConsts.MaxCreditRating1Length, MinimumLength = CustomerConsts.MinCreditRating1Length)]
        public string CreditRating1 { get; set; }

        [StringLength(CustomerConsts.MaxCreditRating2Length, MinimumLength = CustomerConsts.MinCreditRating2Length)]
        public string CreditRating2 { get; set; }

        public short? Statements { get; set; }

        public short? CreditHoldDays { get; set; }

        public short? FinanceCharge { get; set; }

        public DateTime? ResaleExpDate { get; set; }

        [StringLength(CustomerConsts.MaxStateTaxCodeLength, MinimumLength = CustomerConsts.MinStateTaxCodeLength)]
        public string StateTaxCode { get; set; }

        [StringLength(CustomerConsts.MaxCountyTaxCodeLength, MinimumLength = CustomerConsts.MinCountyTaxCodeLength)]
        public string CountyTaxCode { get; set; }

        [StringLength(CustomerConsts.MaxCityTaxCodeLength, MinimumLength = CustomerConsts.MinCityTaxCodeLength)]
        public string CityTaxCode { get; set; }

        public short? AbsoluteTaxCodes { get; set; }

        [StringLength(CustomerConsts.MaxMFGPermitNoLength, MinimumLength = CustomerConsts.MinMFGPermitNoLength)]
        public string MFGPermitNo { get; set; }

        public DateTime? MFGPermitExpDate { get; set; }

        public short? Branch { get; set; }

        public short? ShowLaborHours { get; set; }

        [StringLength(CustomerConsts.MaxVendorNoLength, MinimumLength = CustomerConsts.MinVendorNoLength)]
        public string VendorNo { get; set; }

        [StringLength(CustomerConsts.MaxLocalTaxCodeLength, MinimumLength = CustomerConsts.MinLocalTaxCodeLength)]
        public string LocalTaxCode { get; set; }

        [StringLength(CustomerConsts.MaxCurrencyTypeLength, MinimumLength = CustomerConsts.MinCurrencyTypeLength)]
        public string CurrencyType { get; set; }

        [StringLength(CustomerConsts.MaxCreditCardNoLength, MinimumLength = CustomerConsts.MinCreditCardNoLength)]
        public string CreditCardNo { get; set; }

        [StringLength(CustomerConsts.MaxCreditCardCVVLength, MinimumLength = CustomerConsts.MinCreditCardCVVLength)]
        public string CreditCardCVV { get; set; }

        [StringLength(CustomerConsts.MaxCreditCardExpDateLength, MinimumLength = CustomerConsts.MinCreditCardExpDateLength)]
        public string CreditCardExpDate { get; set; }

        [StringLength(CustomerConsts.MaxCreditCardTypeLength, MinimumLength = CustomerConsts.MinCreditCardTypeLength)]
        public string CreditCardType { get; set; }

        [StringLength(CustomerConsts.MaxNameOnCreditCardLength, MinimumLength = CustomerConsts.MinNameOnCreditCardLength)]
        public string NameOnCreditCard { get; set; }

        [StringLength(CustomerConsts.MaxRFCLength, MinimumLength = CustomerConsts.MinRFCLength)]
        public string RFC { get; set; }

        [StringLength(CustomerConsts.MaxOldNumberLength, MinimumLength = CustomerConsts.MinOldNumberLength)]
        public string OldNumber { get; set; }

        public short? SuppressPartsPricing { get; set; }

        public decimal? ServiceCharge { get; set; }

        [StringLength(CustomerConsts.MaxServiceChargeDescriptionLength, MinimumLength = CustomerConsts.MinServiceChargeDescriptionLength)]
        public string ServiceChargeDescription { get; set; }

        public short? FinalCopies { get; set; }

        public short? POBoxAndAddress { get; set; }

        [StringLength(CustomerConsts.MaxInsuranceNoLength, MinimumLength = CustomerConsts.MinInsuranceNoLength)]
        public string InsuranceNo { get; set; }

        public DateTime? InsuranceNoDate { get; set; }

        public DateTime? InsuranceNoRecvDate { get; set; }

        [StringLength(CustomerConsts.MaxCreditCardAddressLength, MinimumLength = CustomerConsts.MinCreditCardAddressLength)]
        public string CreditCardAddress { get; set; }

        [StringLength(CustomerConsts.MaxCreditCardPOBoxLength, MinimumLength = CustomerConsts.MinCreditCardPOBoxLength)]
        public string CreditCardPOBox { get; set; }

        [StringLength(CustomerConsts.MaxCreditCardCityLength, MinimumLength = CustomerConsts.MinCreditCardCityLength)]
        public string CreditCardCity { get; set; }

        [StringLength(CustomerConsts.MaxCreditCardStateLength, MinimumLength = CustomerConsts.MinCreditCardStateLength)]
        public string CreditCardState { get; set; }

        [StringLength(CustomerConsts.MaxCreditCardZipCodeLength, MinimumLength = CustomerConsts.MinCreditCardZipCodeLength)]
        public string CreditCardZipCode { get; set; }

        [StringLength(CustomerConsts.MaxCreditCardCountryLength, MinimumLength = CustomerConsts.MinCreditCardCountryLength)]
        public string CreditCardCountry { get; set; }

        [StringLength(CustomerConsts.MaxPMLaborRateLength, MinimumLength = CustomerConsts.MinPMLaborRateLength)]
        public string PMLaborRate { get; set; }

        [StringLength(CustomerConsts.MaxReferenceNo1Length, MinimumLength = CustomerConsts.MinReferenceNo1Length)]
        public string ReferenceNo1 { get; set; }

        [StringLength(CustomerConsts.MaxReferenceNo2Length, MinimumLength = CustomerConsts.MinReferenceNo2Length)]
        public string ReferenceNo2 { get; set; }

        public short? GMSummary { get; set; }

        [StringLength(CustomerConsts.MaxOB10NoLength, MinimumLength = CustomerConsts.MinOB10NoLength)]
        public string OB10No { get; set; }

        [StringLength(CustomerConsts.MaxOldNameLength, MinimumLength = CustomerConsts.MinOldNameLength)]
        public string OldName { get; set; }

        public short? CustomerBillTo { get; set; }

        [StringLength(CustomerConsts.MaxShipViaLength, MinimumLength = CustomerConsts.MinShipViaLength)]
        public string ShipVia { get; set; }

        public short? NoAddMisc { get; set; }

        [StringLength(CustomerConsts.MaxLaborDiscountLength, MinimumLength = CustomerConsts.MinLaborDiscountLength)]
        public string LaborDiscount { get; set; }

        [StringLength(CustomerConsts.MaxTaxRateLength, MinimumLength = CustomerConsts.MinTaxRateLength)]
        public string TaxRate { get; set; }

        [StringLength(CustomerConsts.MaxTMHUNoLength, MinimumLength = CustomerConsts.MinTMHUNoLength)]
        public string TMHUNo { get; set; }

        public short? LockTaxCode { get; set; }

        [StringLength(CustomerConsts.MaxTaxCodeImportLength, MinimumLength = CustomerConsts.MinTaxCodeImportLength)]
        public string TaxCodeImport { get; set; }

        public string ShippingComments { get; set; }

        public short? NoShippingCharge { get; set; }

        [StringLength(CustomerConsts.MaxShippingCompanyLength, MinimumLength = CustomerConsts.MinShippingCompanyLength)]
        public string ShippingCompany { get; set; }

        [StringLength(CustomerConsts.MaxShippingAccountLength, MinimumLength = CustomerConsts.MinShippingAccountLength)]
        public string ShippingAccount { get; set; }

        [StringLength(CustomerConsts.MaxEMailInvoiceAddressLength, MinimumLength = CustomerConsts.MinEMailInvoiceAddressLength)]
        public string EMailInvoiceAddress { get; set; }

        [StringLength(CustomerConsts.MaxEMailInvoiceAttentionLength, MinimumLength = CustomerConsts.MinEMailInvoiceAttentionLength)]
        public string EMailInvoiceAttention { get; set; }

        public short? EMailInvoice { get; set; }

        public short? NoPrintInvoice { get; set; }

        public short? BackupRequired { get; set; }

        [StringLength(CustomerConsts.MaxOldSalesman1Length, MinimumLength = CustomerConsts.MinOldSalesman1Length)]
        public string OldSalesman1 { get; set; }

        [StringLength(CustomerConsts.MaxOldSalesman2Length, MinimumLength = CustomerConsts.MinOldSalesman2Length)]
        public string OldSalesman2 { get; set; }

        [StringLength(CustomerConsts.MaxOldSalesman3Length, MinimumLength = CustomerConsts.MinOldSalesman3Length)]
        public string OldSalesman3 { get; set; }

        [StringLength(CustomerConsts.MaxOldSalesman4Length, MinimumLength = CustomerConsts.MinOldSalesman4Length)]
        public string OldSalesman4 { get; set; }

        [StringLength(CustomerConsts.MaxOldSalesman5Length, MinimumLength = CustomerConsts.MinOldSalesman5Length)]
        public string OldSalesman5 { get; set; }

        [StringLength(CustomerConsts.MaxOldSalesman6Length, MinimumLength = CustomerConsts.MinOldSalesman6Length)]
        public string OldSalesman6 { get; set; }

        public DateTime? LastAutoSalesmanUpdate { get; set; }

        public DateTime? LastAutoSalesmanUpdate1 { get; set; }

        public DateTime? LastAutoSalesmanUpdate2 { get; set; }

        public DateTime? LastAutoSalesmanUpdate3 { get; set; }

        public DateTime? LastAutoSalesmanUpdate4 { get; set; }

        public DateTime? LastAutoSalesmanUpdate5 { get; set; }

        public DateTime? LastAutoSalesmanUpdate6 { get; set; }

        [StringLength(CustomerConsts.MaxInvoiceLanguageLength, MinimumLength = CustomerConsts.MinInvoiceLanguageLength)]
        public string InvoiceLanguage { get; set; }

        public bool PeopleSoft { get; set; }

        [StringLength(CustomerConsts.MaxPSCompanyLength, MinimumLength = CustomerConsts.MinPSCompanyLength)]
        public string PSCompany { get; set; }

        [StringLength(CustomerConsts.MaxPSAccountLength, MinimumLength = CustomerConsts.MinPSAccountLength)]
        public string PSAccount { get; set; }

        [StringLength(CustomerConsts.MaxPSLocationLength, MinimumLength = CustomerConsts.MinPSLocationLength)]
        public string PSLocation { get; set; }

        [StringLength(CustomerConsts.MaxPSDeptLength, MinimumLength = CustomerConsts.MinPSDeptLength)]
        public string PSDept { get; set; }

        [StringLength(CustomerConsts.MaxPSProductLength, MinimumLength = CustomerConsts.MinPSProductLength)]
        public string PSProduct { get; set; }

        [StringLength(CustomerConsts.MaxAltCustomerNoLength, MinimumLength = CustomerConsts.MinAltCustomerNoLength)]
        public string AltCustomerNo { get; set; }

        public short? OverRideShipTo { get; set; }

        public short? OnFileResale { get; set; }

        public short? OnFileMFGPermit { get; set; }

        public short? OnFileInsurance { get; set; }

        public int? Inactive { get; set; }

        public int? OverRideShipToRates { get; set; }

        public short? SuppressPartsList { get; set; }

        [StringLength(CustomerConsts.MaxMarketingSourceLength, MinimumLength = CustomerConsts.MinMarketingSourceLength)]
        public string MarketingSource { get; set; }

        public int? CreditCardLastTransID { get; set; }

        [StringLength(CustomerConsts.MaxEmailRoadServiceLength, MinimumLength = CustomerConsts.MinEmailRoadServiceLength)]
        public string EmailRoadService { get; set; }

        [StringLength(CustomerConsts.MaxEmailShopServiceLength, MinimumLength = CustomerConsts.MinEmailShopServiceLength)]
        public string EmailShopService { get; set; }

        [StringLength(CustomerConsts.MaxEmailPMServiceLength, MinimumLength = CustomerConsts.MinEmailPMServiceLength)]
        public string EmailPMService { get; set; }

        [StringLength(CustomerConsts.MaxEmailRentalPMServiceLength, MinimumLength = CustomerConsts.MinEmailRentalPMServiceLength)]
        public string EmailRentalPMService { get; set; }

        [StringLength(CustomerConsts.MaxEmailPartsCounterLength, MinimumLength = CustomerConsts.MinEmailPartsCounterLength)]
        public string EmailPartsCounter { get; set; }

        [StringLength(CustomerConsts.MaxEmailEquipmentSalesLength, MinimumLength = CustomerConsts.MinEmailEquipmentSalesLength)]
        public string EmailEquipmentSales { get; set; }

        [StringLength(CustomerConsts.MaxEmailRentalsLength, MinimumLength = CustomerConsts.MinEmailRentalsLength)]
        public string EmailRentals { get; set; }

        [Required]
        public int ID { get; set; }

        [StringLength(CustomerConsts.MaxARStatementsEmailAddressLength, MinimumLength = CustomerConsts.MinARStatementsEmailAddressLength)]
        public string ARStatementsEmailAddress { get; set; }

        public int AccountTypeId { get; set; }

    }
}