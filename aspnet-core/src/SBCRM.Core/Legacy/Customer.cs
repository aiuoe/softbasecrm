using SBCRM.Crm;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities.Auditing;
using Abp.Domain.Entities;

namespace SBCRM.Legacy
{
    [Table("Customer", Schema = "dbo")]
    public class Customer
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual int Id { get; set; }

        [Key]
        [Required]
        [StringLength(CustomerConsts.MaxNumberLength, MinimumLength = CustomerConsts.MinNumberLength)]
        public virtual string Number { get; set; }

        [StringLength(CustomerConsts.MaxBillToLength, MinimumLength = CustomerConsts.MinBillToLength)]
        public virtual string BillTo { get; set; }

        [StringLength(CustomerConsts.MaxNameLength, MinimumLength = CustomerConsts.MinNameLength)]
        public virtual string Name { get; set; }

        [StringLength(CustomerConsts.MaxSearchNameLength, MinimumLength = CustomerConsts.MinSearchNameLength)]
        public virtual string SearchName { get; set; }

        [StringLength(CustomerConsts.MaxSubNameLength, MinimumLength = CustomerConsts.MinSubNameLength)]
        public virtual string SubName { get; set; }

        [StringLength(CustomerConsts.MaxPOBoxLength, MinimumLength = CustomerConsts.MinPOBoxLength)]
        public virtual string POBox { get; set; }

        [StringLength(CustomerConsts.MaxAddressLength, MinimumLength = CustomerConsts.MinAddressLength)]
        public virtual string Address { get; set; }

        [StringLength(CustomerConsts.MaxCityLength, MinimumLength = CustomerConsts.MinCityLength)]
        public virtual string City { get; set; }

        [StringLength(CustomerConsts.MaxStateLength, MinimumLength = CustomerConsts.MinStateLength)]
        public virtual string State { get; set; }

        [StringLength(CustomerConsts.MaxZipCodeLength, MinimumLength = CustomerConsts.MinZipCodeLength)]
        public virtual string ZipCode { get; set; }

        [StringLength(CustomerConsts.MaxCountryLength, MinimumLength = CustomerConsts.MinCountryLength)]
        public virtual string Country { get; set; }

        [StringLength(CustomerConsts.MaxSalutationLength, MinimumLength = CustomerConsts.MinSalutationLength)]
        public virtual string Salutation { get; set; }

        [StringLength(CustomerConsts.MaxPhoneLength, MinimumLength = CustomerConsts.MinPhoneLength)]
        public virtual string Phone { get; set; }

        [StringLength(CustomerConsts.MaxExtentionLength, MinimumLength = CustomerConsts.MinExtentionLength)]
        public virtual string Extention { get; set; }

        [StringLength(CustomerConsts.MaxPhone2Length, MinimumLength = CustomerConsts.MinPhone2Length)]
        public virtual string Phone2 { get; set; }

        [StringLength(CustomerConsts.MaxCellularLength, MinimumLength = CustomerConsts.MinCellularLength)]
        public virtual string Cellular { get; set; }

        [StringLength(CustomerConsts.MaxBeeperLength, MinimumLength = CustomerConsts.MinBeeperLength)]
        public virtual string Beeper { get; set; }

        [StringLength(CustomerConsts.MaxHomePhoneLength, MinimumLength = CustomerConsts.MinHomePhoneLength)]
        public virtual string HomePhone { get; set; }

        [StringLength(CustomerConsts.MaxFaxLength, MinimumLength = CustomerConsts.MinFaxLength)]
        public virtual string Fax { get; set; }

        [StringLength(CustomerConsts.MaxResaleNoLength, MinimumLength = CustomerConsts.MinResaleNoLength)]
        public virtual string ResaleNo { get; set; }

        [StringLength(CustomerConsts.MaxEMailLength, MinimumLength = CustomerConsts.MinEMailLength)]
        public virtual string EMail { get; set; }

        [StringLength(CustomerConsts.MaxWWWAddressLength, MinimumLength = CustomerConsts.MinWWWAddressLength)]
        public virtual string WWWAddress { get; set; }

        [StringLength(CustomerConsts.MaxParentCompanyLength, MinimumLength = CustomerConsts.MinParentCompanyLength)]
        public virtual string ParentCompany { get; set; }

        [StringLength(CustomerConsts.MaxMapLocationLength, MinimumLength = CustomerConsts.MinMapLocationLength)]
        public virtual string MapLocation { get; set; }

        [StringLength(CustomerConsts.MaxSalesman1Length, MinimumLength = CustomerConsts.MinSalesman1Length)]
        public virtual string Salesman1 { get; set; }

        [StringLength(CustomerConsts.MaxSalesman2Length, MinimumLength = CustomerConsts.MinSalesman2Length)]
        public virtual string Salesman2 { get; set; }

        [StringLength(CustomerConsts.MaxSalesman3Length, MinimumLength = CustomerConsts.MinSalesman3Length)]
        public virtual string Salesman3 { get; set; }

        [StringLength(CustomerConsts.MaxSalesman4Length, MinimumLength = CustomerConsts.MinSalesman4Length)]
        public virtual string Salesman4 { get; set; }

        [StringLength(CustomerConsts.MaxSalesman5Length, MinimumLength = CustomerConsts.MinSalesman5Length)]
        public virtual string Salesman5 { get; set; }

        [StringLength(CustomerConsts.MaxSalesman6Length, MinimumLength = CustomerConsts.MinSalesman6Length)]
        public virtual string Salesman6 { get; set; }

        public virtual short? LockAPR1 { get; set; }

        public virtual short? LockAPR2 { get; set; }

        public virtual short? LockAPR3 { get; set; }

        public virtual short? LockAPR4 { get; set; }

        public virtual short? LockAPR5 { get; set; }

        public virtual short? LockAPR6 { get; set; }

        public virtual short? SalesGroup1 { get; set; }

        public virtual short? SalesGroup2 { get; set; }

        public virtual short? SalesGroup3 { get; set; }

        public virtual short? SalesGroup4 { get; set; }

        public virtual short? SalesGroup5 { get; set; }

        public virtual short? SalesGroup6 { get; set; }

        [StringLength(CustomerConsts.MaxTermsLength, MinimumLength = CustomerConsts.MinTermsLength)]
        public virtual string Terms { get; set; }

        [StringLength(CustomerConsts.MaxFiscalEndLength, MinimumLength = CustomerConsts.MinFiscalEndLength)]
        public virtual string FiscalEnd { get; set; }

        [StringLength(CustomerConsts.MaxDunsCodeLength, MinimumLength = CustomerConsts.MinDunsCodeLength)]
        public virtual string DunsCode { get; set; }

        [StringLength(CustomerConsts.MaxSICCodeLength, MinimumLength = CustomerConsts.MinSICCodeLength)]
        public virtual string SICCode { get; set; }

        [StringLength(CustomerConsts.MaxMailingGroupLength, MinimumLength = CustomerConsts.MinMailingGroupLength)]
        public virtual string MailingGroup { get; set; }

        [StringLength(CustomerConsts.MaxMakesLength, MinimumLength = CustomerConsts.MinMakesLength)]
        public virtual string Makes { get; set; }

        public virtual short? POReq { get; set; }

        public virtual short? PrevShip { get; set; }

        public virtual short? Taxable { get; set; }

        [StringLength(CustomerConsts.MaxTaxCodeLength, MinimumLength = CustomerConsts.MinTaxCodeLength)]
        public virtual string TaxCode { get; set; }

        [StringLength(CustomerConsts.MaxLaborRateLength, MinimumLength = CustomerConsts.MinLaborRateLength)]
        public virtual string LaborRate { get; set; }

        [StringLength(CustomerConsts.MaxShopLaborRateLength, MinimumLength = CustomerConsts.MinShopLaborRateLength)]
        public virtual string ShopLaborRate { get; set; }

        public virtual short? ShowLaborRate { get; set; }

        [StringLength(CustomerConsts.MaxRentalRateLength, MinimumLength = CustomerConsts.MinRentalRateLength)]
        public virtual string RentalRate { get; set; }

        public virtual short? ShowPartNoAlias { get; set; }

        [StringLength(CustomerConsts.MaxPartsRateLength, MinimumLength = CustomerConsts.MinPartsRateLength)]
        public virtual string PartsRate { get; set; }

        public virtual double? PartsRateDiscount { get; set; }

        public virtual DateTime? Added { get; set; }

        [StringLength(CustomerConsts.MaxAddedByLength, MinimumLength = CustomerConsts.MinAddedByLength)]
        public virtual string AddedBy { get; set; }

        public virtual DateTime? Changed { get; set; }

        [StringLength(CustomerConsts.MaxChangedByLength, MinimumLength = CustomerConsts.MinChangedByLength)]
        public virtual string ChangedBy { get; set; }

        [StringLength(CustomerConsts.MaxSalesContactLength, MinimumLength = CustomerConsts.MinSalesContactLength)]
        public virtual string SalesContact { get; set; }

        [StringLength(CustomerConsts.MaxCSContactLength, MinimumLength = CustomerConsts.MinCSContactLength)]
        public virtual string CSContact { get; set; }

        [StringLength(CustomerConsts.MaxAccountingContactLength, MinimumLength = CustomerConsts.MinAccountingContactLength)]
        public virtual string AccountingContact { get; set; }

        public virtual short? InternalCustomer { get; set; }

        public virtual short? EquipmentBid { get; set; }

        public virtual string Comments { get; set; }

        public virtual string ARComments { get; set; }

        public virtual string CompanyComments { get; set; }

        public virtual DateTime? CompanyCommentsDate { get; set; }

        [StringLength(CustomerConsts.MaxCompanyCommentsByLength, MinimumLength = CustomerConsts.MinCompanyCommentsByLength)]
        public virtual string CompanyCommentsBy { get; set; }

        [StringLength(CustomerConsts.MaxBusinessCategoryLength, MinimumLength = CustomerConsts.MinBusinessCategoryLength)]
        public virtual string BusinessCategory { get; set; }

        public virtual string BusinessDescription { get; set; }

        [StringLength(CustomerConsts.MaxSICCode2Length, MinimumLength = CustomerConsts.MinSICCode2Length)]
        public virtual string SICCode2 { get; set; }

        [StringLength(CustomerConsts.MaxSICCode3Length, MinimumLength = CustomerConsts.MinSICCode3Length)]
        public virtual string SICCode3 { get; set; }

        [StringLength(CustomerConsts.MaxSICCode4Length, MinimumLength = CustomerConsts.MinSICCode4Length)]
        public virtual string SICCode4 { get; set; }

        public virtual short? Shifts { get; set; }

        [StringLength(CustomerConsts.MaxCategoryLength, MinimumLength = CustomerConsts.MinCategoryLength)]
        public virtual string Category { get; set; }

        public virtual DateTime? HoursOfOpStart { get; set; }

        public virtual DateTime? HoursOfOpEnd { get; set; }

        public virtual string DeliveryInfo { get; set; }

        [StringLength(CustomerConsts.MaxCustomerTerritoryLength, MinimumLength = CustomerConsts.MinCustomerTerritoryLength)]
        public virtual string CustomerTerritory { get; set; }

        public virtual short? CreditHoldFlag { get; set; }

        [StringLength(CustomerConsts.MaxCreditRating1Length, MinimumLength = CustomerConsts.MinCreditRating1Length)]
        public virtual string CreditRating1 { get; set; }

        [StringLength(CustomerConsts.MaxCreditRating2Length, MinimumLength = CustomerConsts.MinCreditRating2Length)]
        public virtual string CreditRating2 { get; set; }

        public virtual short? Statements { get; set; }

        public virtual short? CreditHoldDays { get; set; }

        public virtual short? FinanceCharge { get; set; }

        public virtual DateTime? ResaleExpDate { get; set; }

        [StringLength(CustomerConsts.MaxStateTaxCodeLength, MinimumLength = CustomerConsts.MinStateTaxCodeLength)]
        public virtual string StateTaxCode { get; set; }

        [StringLength(CustomerConsts.MaxCountyTaxCodeLength, MinimumLength = CustomerConsts.MinCountyTaxCodeLength)]
        public virtual string CountyTaxCode { get; set; }

        [StringLength(CustomerConsts.MaxCityTaxCodeLength, MinimumLength = CustomerConsts.MinCityTaxCodeLength)]
        public virtual string CityTaxCode { get; set; }

        public virtual short? AbsoluteTaxCodes { get; set; }

        [StringLength(CustomerConsts.MaxMFGPermitNoLength, MinimumLength = CustomerConsts.MinMFGPermitNoLength)]
        public virtual string MFGPermitNo { get; set; }

        public virtual DateTime? MFGPermitExpDate { get; set; }

        public virtual short? Branch { get; set; }

        public virtual short? ShowLaborHours { get; set; }

        [StringLength(CustomerConsts.MaxVendorNoLength, MinimumLength = CustomerConsts.MinVendorNoLength)]
        public virtual string VendorNo { get; set; }

        [StringLength(CustomerConsts.MaxLocalTaxCodeLength, MinimumLength = CustomerConsts.MinLocalTaxCodeLength)]
        public virtual string LocalTaxCode { get; set; }

        [StringLength(CustomerConsts.MaxCurrencyTypeLength, MinimumLength = CustomerConsts.MinCurrencyTypeLength)]
        public virtual string CurrencyType { get; set; }

        [StringLength(CustomerConsts.MaxCreditCardNoLength, MinimumLength = CustomerConsts.MinCreditCardNoLength)]
        public virtual string CreditCardNo { get; set; }

        [StringLength(CustomerConsts.MaxCreditCardCVVLength, MinimumLength = CustomerConsts.MinCreditCardCVVLength)]
        public virtual string CreditCardCVV { get; set; }

        [StringLength(CustomerConsts.MaxCreditCardExpDateLength, MinimumLength = CustomerConsts.MinCreditCardExpDateLength)]
        public virtual string CreditCardExpDate { get; set; }

        [StringLength(CustomerConsts.MaxCreditCardTypeLength, MinimumLength = CustomerConsts.MinCreditCardTypeLength)]
        public virtual string CreditCardType { get; set; }

        [StringLength(CustomerConsts.MaxNameOnCreditCardLength, MinimumLength = CustomerConsts.MinNameOnCreditCardLength)]
        public virtual string NameOnCreditCard { get; set; }

        [StringLength(CustomerConsts.MaxRFCLength, MinimumLength = CustomerConsts.MinRFCLength)]
        public virtual string RFC { get; set; }

        [StringLength(CustomerConsts.MaxOldNumberLength, MinimumLength = CustomerConsts.MinOldNumberLength)]
        public virtual string OldNumber { get; set; }

        public virtual short? SuppressPartsPricing { get; set; }

        public virtual decimal? ServiceCharge { get; set; }

        [StringLength(CustomerConsts.MaxServiceChargeDescriptionLength, MinimumLength = CustomerConsts.MinServiceChargeDescriptionLength)]
        public virtual string ServiceChargeDescription { get; set; }

        public virtual short? FinalCopies { get; set; }

        public virtual short? POBoxAndAddress { get; set; }

        [StringLength(CustomerConsts.MaxInsuranceNoLength, MinimumLength = CustomerConsts.MinInsuranceNoLength)]
        public virtual string InsuranceNo { get; set; }

        public virtual DateTime? InsuranceNoDate { get; set; }

        public virtual DateTime? InsuranceNoRecvDate { get; set; }

        [StringLength(CustomerConsts.MaxCreditCardAddressLength, MinimumLength = CustomerConsts.MinCreditCardAddressLength)]
        public virtual string CreditCardAddress { get; set; }

        [StringLength(CustomerConsts.MaxCreditCardPOBoxLength, MinimumLength = CustomerConsts.MinCreditCardPOBoxLength)]
        public virtual string CreditCardPOBox { get; set; }

        [StringLength(CustomerConsts.MaxCreditCardCityLength, MinimumLength = CustomerConsts.MinCreditCardCityLength)]
        public virtual string CreditCardCity { get; set; }

        [StringLength(CustomerConsts.MaxCreditCardStateLength, MinimumLength = CustomerConsts.MinCreditCardStateLength)]
        public virtual string CreditCardState { get; set; }

        [StringLength(CustomerConsts.MaxCreditCardZipCodeLength, MinimumLength = CustomerConsts.MinCreditCardZipCodeLength)]
        public virtual string CreditCardZipCode { get; set; }

        [StringLength(CustomerConsts.MaxCreditCardCountryLength, MinimumLength = CustomerConsts.MinCreditCardCountryLength)]
        public virtual string CreditCardCountry { get; set; }

        [StringLength(CustomerConsts.MaxPMLaborRateLength, MinimumLength = CustomerConsts.MinPMLaborRateLength)]
        public virtual string PMLaborRate { get; set; }

        [StringLength(CustomerConsts.MaxReferenceNo1Length, MinimumLength = CustomerConsts.MinReferenceNo1Length)]
        public virtual string ReferenceNo1 { get; set; }

        [StringLength(CustomerConsts.MaxReferenceNo2Length, MinimumLength = CustomerConsts.MinReferenceNo2Length)]
        public virtual string ReferenceNo2 { get; set; }

        public virtual short? GMSummary { get; set; }

        [StringLength(CustomerConsts.MaxOB10NoLength, MinimumLength = CustomerConsts.MinOB10NoLength)]
        public virtual string OB10No { get; set; }

        [StringLength(CustomerConsts.MaxOldNameLength, MinimumLength = CustomerConsts.MinOldNameLength)]
        public virtual string OldName { get; set; }

        public virtual short? CustomerBillTo { get; set; }

        [StringLength(CustomerConsts.MaxShipViaLength, MinimumLength = CustomerConsts.MinShipViaLength)]
        public virtual string ShipVia { get; set; }

        public virtual short? NoAddMisc { get; set; }

        [StringLength(CustomerConsts.MaxLaborDiscountLength, MinimumLength = CustomerConsts.MinLaborDiscountLength)]
        public virtual string LaborDiscount { get; set; }

        [StringLength(CustomerConsts.MaxTaxRateLength, MinimumLength = CustomerConsts.MinTaxRateLength)]
        public virtual string TaxRate { get; set; }

        [StringLength(CustomerConsts.MaxTMHUNoLength, MinimumLength = CustomerConsts.MinTMHUNoLength)]
        public virtual string TMHUNo { get; set; }

        public virtual short? LockTaxCode { get; set; }

        [StringLength(CustomerConsts.MaxTaxCodeImportLength, MinimumLength = CustomerConsts.MinTaxCodeImportLength)]
        public virtual string TaxCodeImport { get; set; }

        public virtual string ShippingComments { get; set; }

        public virtual short? NoShippingCharge { get; set; }

        [StringLength(CustomerConsts.MaxShippingCompanyLength, MinimumLength = CustomerConsts.MinShippingCompanyLength)]
        public virtual string ShippingCompany { get; set; }

        [StringLength(CustomerConsts.MaxShippingAccountLength, MinimumLength = CustomerConsts.MinShippingAccountLength)]
        public virtual string ShippingAccount { get; set; }

        [StringLength(CustomerConsts.MaxEMailInvoiceAddressLength, MinimumLength = CustomerConsts.MinEMailInvoiceAddressLength)]
        public virtual string EMailInvoiceAddress { get; set; }

        [StringLength(CustomerConsts.MaxEMailInvoiceAttentionLength, MinimumLength = CustomerConsts.MinEMailInvoiceAttentionLength)]
        public virtual string EMailInvoiceAttention { get; set; }

        public virtual short? EMailInvoice { get; set; }

        public virtual short? NoPrintInvoice { get; set; }

        public virtual short? BackupRequired { get; set; }

        [StringLength(CustomerConsts.MaxOldSalesman1Length, MinimumLength = CustomerConsts.MinOldSalesman1Length)]
        public virtual string OldSalesman1 { get; set; }

        [StringLength(CustomerConsts.MaxOldSalesman2Length, MinimumLength = CustomerConsts.MinOldSalesman2Length)]
        public virtual string OldSalesman2 { get; set; }

        [StringLength(CustomerConsts.MaxOldSalesman3Length, MinimumLength = CustomerConsts.MinOldSalesman3Length)]
        public virtual string OldSalesman3 { get; set; }

        [StringLength(CustomerConsts.MaxOldSalesman4Length, MinimumLength = CustomerConsts.MinOldSalesman4Length)]
        public virtual string OldSalesman4 { get; set; }

        [StringLength(CustomerConsts.MaxOldSalesman5Length, MinimumLength = CustomerConsts.MinOldSalesman5Length)]
        public virtual string OldSalesman5 { get; set; }

        [StringLength(CustomerConsts.MaxOldSalesman6Length, MinimumLength = CustomerConsts.MinOldSalesman6Length)]
        public virtual string OldSalesman6 { get; set; }

        public virtual DateTime? LastAutoSalesmanUpdate { get; set; }

        public virtual DateTime? LastAutoSalesmanUpdate1 { get; set; }

        public virtual DateTime? LastAutoSalesmanUpdate2 { get; set; }

        public virtual DateTime? LastAutoSalesmanUpdate3 { get; set; }

        public virtual DateTime? LastAutoSalesmanUpdate4 { get; set; }

        public virtual DateTime? LastAutoSalesmanUpdate5 { get; set; }

        public virtual DateTime? LastAutoSalesmanUpdate6 { get; set; }

        [StringLength(CustomerConsts.MaxInvoiceLanguageLength, MinimumLength = CustomerConsts.MinInvoiceLanguageLength)]
        public virtual string InvoiceLanguage { get; set; }

        public virtual bool PeopleSoft { get; set; }

        [StringLength(CustomerConsts.MaxPSCompanyLength, MinimumLength = CustomerConsts.MinPSCompanyLength)]
        public virtual string PSCompany { get; set; }

        [StringLength(CustomerConsts.MaxPSAccountLength, MinimumLength = CustomerConsts.MinPSAccountLength)]
        public virtual string PSAccount { get; set; }

        [StringLength(CustomerConsts.MaxPSLocationLength, MinimumLength = CustomerConsts.MinPSLocationLength)]
        public virtual string PSLocation { get; set; }

        [StringLength(CustomerConsts.MaxPSDeptLength, MinimumLength = CustomerConsts.MinPSDeptLength)]
        public virtual string PSDept { get; set; }

        [StringLength(CustomerConsts.MaxPSProductLength, MinimumLength = CustomerConsts.MinPSProductLength)]
        public virtual string PSProduct { get; set; }

        [StringLength(CustomerConsts.MaxAltCustomerNoLength, MinimumLength = CustomerConsts.MinAltCustomerNoLength)]
        public virtual string AltCustomerNo { get; set; }

        public virtual short? OverRideShipTo { get; set; }

        public virtual short? OnFileResale { get; set; }

        public virtual short? OnFileMFGPermit { get; set; }

        public virtual short? OnFileInsurance { get; set; }

        public virtual int? Inactive { get; set; }

        public virtual int? OverRideShipToRates { get; set; }

        public virtual short? SuppressPartsList { get; set; }

        [StringLength(CustomerConsts.MaxMarketingSourceLength, MinimumLength = CustomerConsts.MinMarketingSourceLength)]
        public virtual string MarketingSource { get; set; }

        public virtual int? CreditCardLastTransID { get; set; }

        [StringLength(CustomerConsts.MaxEmailRoadServiceLength, MinimumLength = CustomerConsts.MinEmailRoadServiceLength)]
        public virtual string EmailRoadService { get; set; }

        [StringLength(CustomerConsts.MaxEmailShopServiceLength, MinimumLength = CustomerConsts.MinEmailShopServiceLength)]
        public virtual string EmailShopService { get; set; }

        [StringLength(CustomerConsts.MaxEmailPMServiceLength, MinimumLength = CustomerConsts.MinEmailPMServiceLength)]
        public virtual string EmailPMService { get; set; }

        [StringLength(CustomerConsts.MaxEmailRentalPMServiceLength, MinimumLength = CustomerConsts.MinEmailRentalPMServiceLength)]
        public virtual string EmailRentalPMService { get; set; }

        [StringLength(CustomerConsts.MaxEmailPartsCounterLength, MinimumLength = CustomerConsts.MinEmailPartsCounterLength)]
        public virtual string EmailPartsCounter { get; set; }

        [StringLength(CustomerConsts.MaxEmailEquipmentSalesLength, MinimumLength = CustomerConsts.MinEmailEquipmentSalesLength)]
        public virtual string EmailEquipmentSales { get; set; }

        [StringLength(CustomerConsts.MaxEmailRentalsLength, MinimumLength = CustomerConsts.MinEmailRentalsLength)]
        public virtual string EmailRentals { get; set; }

        

        [StringLength(CustomerConsts.MaxARStatementsEmailAddressLength, MinimumLength = CustomerConsts.MinARStatementsEmailAddressLength)]
        public virtual string ARStatementsEmailAddress { get; set; }

        public virtual int AccountTypeId { get; set; }

        [ForeignKey("AccountTypeId")]
        public AccountType AccountTypeFk { get; set; }

    }
}