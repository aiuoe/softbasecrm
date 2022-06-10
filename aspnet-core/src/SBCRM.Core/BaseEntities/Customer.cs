using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("Customer", Schema = "web")]
    [Index(nameof(TenantId), Name = "Customer_TenantId_index")]
    [Index(nameof(Number), nameof(TenantId), Name = "UC_Customer", IsUnique = true)]
    public class Customer : FullAuditedEntity<long>, IMustHaveTenant
    {
        [Required]
        [StringLength(100)]
        public string Number { get; set; }
        [StringLength(50)]
        public string BillTo { get; set; }
        [StringLength(255)]
        public string Name { get; set; }
        [StringLength(50)]
        public string SearchName { get; set; }
        [StringLength(50)]
        public string SubName { get; set; }
        [Column("POBox")]
        [StringLength(50)]
        public string Pobox { get; set; }
        [StringLength(255)]
        public string Address { get; set; }
        [StringLength(255)]
        public string City { get; set; }
        [StringLength(255)]
        public string State { get; set; }
        [StringLength(255)]
        public string ZipCode { get; set; }
        [StringLength(50)]
        public string Country { get; set; }
        [StringLength(50)]
        public string Salutation { get; set; }
        [StringLength(255)]
        public string Phone { get; set; }
        [StringLength(50)]
        public string Extention { get; set; }
        [StringLength(50)]
        public string Phone2 { get; set; }
        [StringLength(50)]
        public string Cellular { get; set; }
        [StringLength(50)]
        public string Beeper { get; set; }
        [StringLength(50)]
        public string HomePhone { get; set; }
        [StringLength(50)]
        public string Fax { get; set; }
        [StringLength(50)]
        public string ResaleNo { get; set; }
        [Column("EMail")]
        [StringLength(1000)]
        public string Email { get; set; }
        [Column("WWWAddress")]
        [StringLength(50)]
        public string Wwwaddress { get; set; }
        [StringLength(50)]
        public string ParentCompany { get; set; }
        [StringLength(50)]
        public string MapLocation { get; set; }
        [StringLength(255)]
        public string Salesman1 { get; set; }
        [StringLength(50)]
        public string Salesman2 { get; set; }
        [StringLength(50)]
        public string Salesman3 { get; set; }
        [StringLength(50)]
        public string Salesman4 { get; set; }
        [StringLength(50)]
        public string Salesman5 { get; set; }
        [StringLength(50)]
        public string Salesman6 { get; set; }
        [Column("LockAPR1")]
        public bool LockApr1 { get; set; }
        [Column("LockAPR2")]
        public bool LockApr2 { get; set; }
        [Column("LockAPR3")]
        public bool LockApr3 { get; set; }
        [Column("LockAPR4")]
        public bool LockApr4 { get; set; }
        [Column("LockAPR5")]
        public bool LockApr5 { get; set; }
        [Column("LockAPR6")]
        public bool LockApr6 { get; set; }
        public bool SalesGroup1 { get; set; }
        public bool SalesGroup2 { get; set; }
        public bool SalesGroup3 { get; set; }
        public bool SalesGroup4 { get; set; }
        public bool SalesGroup5 { get; set; }
        public bool SalesGroup6 { get; set; }
        [StringLength(255)]
        public string Terms { get; set; }
        [StringLength(50)]
        public string FiscalEnd { get; set; }
        [StringLength(50)]
        public string DunsCode { get; set; }
        [Column("SICCode")]
        [StringLength(50)]
        public string Siccode { get; set; }
        [StringLength(50)]
        public string MailingGroup { get; set; }
        [StringLength(50)]
        public string Makes { get; set; }
        [Column("POReq")]
        public bool Poreq { get; set; }
        public bool PrevShip { get; set; }
        public bool Taxable { get; set; }
        [StringLength(255)]
        public string TaxCode { get; set; }
        [StringLength(255)]
        public string LaborRate { get; set; }
        [StringLength(50)]
        public string ShopLaborRate { get; set; }
        public short? ShowLaborRate { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? RentalRate { get; set; }
        public short? ShowPartNoAlias { get; set; }
        [StringLength(255)]
        public string PartsRate { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? PartsRateDiscount { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? Added { get; set; }
        [StringLength(50)]
        public string AddedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? Changed { get; set; }
        [StringLength(50)]
        public string ChangedBy { get; set; }
        [StringLength(50)]
        public string SalesContact { get; set; }
        [Column("CSContact")]
        [StringLength(50)]
        public string Cscontact { get; set; }
        [StringLength(255)]
        public string AccountingContact { get; set; }
        public bool InternalCustomer { get; set; }
        public bool EquipmentBid { get; set; }
        public string Comments { get; set; }
        [Column("ARComments")]
        public string Arcomments { get; set; }
        public string CompanyComments { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CompanyCommentsDate { get; set; }
        [StringLength(50)]
        public string CompanyCommentsBy { get; set; }
        [StringLength(50)]
        public string BusinessCategory { get; set; }
        public string BusinessDescription { get; set; }
        [Column("SICCode2")]
        [StringLength(50)]
        public string Siccode2 { get; set; }
        [Column("SICCode3")]
        [StringLength(50)]
        public string Siccode3 { get; set; }
        [Column("SICCode4")]
        [StringLength(50)]
        public string Siccode4 { get; set; }
        public short? Shifts { get; set; }
        [StringLength(50)]
        public string Category { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? HoursOfOpStart { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? HoursOfOpEnd { get; set; }
        public string DeliveryInfo { get; set; }
        [StringLength(50)]
        public string CustomerTerritory { get; set; }
        public bool CreditHoldFlag { get; set; }
        [StringLength(50)]
        public string CreditRating1 { get; set; }
        [StringLength(50)]
        public string CreditRating2 { get; set; }
        public bool Statements { get; set; }
        public bool CreditHoldDays { get; set; }
        public bool FinanceCharge { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ResaleExpDate { get; set; }
        [StringLength(50)]
        public string StateTaxCode { get; set; }
        [StringLength(50)]
        public string CountyTaxCode { get; set; }
        [StringLength(50)]
        public string CityTaxCode { get; set; }
        public bool AbsoluteTaxCodes { get; set; }
        [Column("MFGPermitNo")]
        [StringLength(50)]
        public string MfgpermitNo { get; set; }
        [Column("MFGPermitExpDate", TypeName = "datetime")]
        public DateTime? MfgpermitExpDate { get; set; }
        public short? Branch { get; set; }
        public bool ShowLaborHours { get; set; }
        [StringLength(50)]
        public string VendorNo { get; set; }
        [StringLength(50)]
        public string LocalTaxCode { get; set; }
        [StringLength(50)]
        public string CurrencyType { get; set; }
        [StringLength(50)]
        public string CreditCardNo { get; set; }
        [Column("CreditCardCVV")]
        [StringLength(50)]
        public string CreditCardCvv { get; set; }
        [StringLength(50)]
        public string CreditCardExpDate { get; set; }
        [StringLength(50)]
        public string CreditCardType { get; set; }
        [StringLength(50)]
        public string NameOnCreditCard { get; set; }
        [Column("RFC")]
        [StringLength(50)]
        public string Rfc { get; set; }
        [StringLength(50)]
        public string OldNumber { get; set; }
        public bool SuppressPartsPricing { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? ServiceCharge { get; set; }
        [StringLength(100)]
        public string ServiceChargeDescription { get; set; }
        public bool FinalCopies { get; set; }
        [Column("POBoxAndAddress")]
        public bool PoboxAndAddress { get; set; }
        [StringLength(50)]
        public string InsuranceNo { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? InsuranceNoDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? InsuranceNoRecvDate { get; set; }
        [StringLength(50)]
        public string CreditCardAddress { get; set; }
        [Column("CreditCardPOBox")]
        [StringLength(50)]
        public string CreditCardPobox { get; set; }
        [StringLength(50)]
        public string CreditCardCity { get; set; }
        [StringLength(50)]
        public string CreditCardState { get; set; }
        [StringLength(50)]
        public string CreditCardZipCode { get; set; }
        [StringLength(50)]
        public string CreditCardCountry { get; set; }
        [Column("PMLaborRate")]
        [StringLength(50)]
        public string PmlaborRate { get; set; }
        [StringLength(50)]
        public string ReferenceNo1 { get; set; }
        [StringLength(50)]
        public string ReferenceNo2 { get; set; }
        [Column("GMSummary")]
        public bool Gmsummary { get; set; }
        [Column("OB10No")]
        [StringLength(50)]
        public string Ob10no { get; set; }
        [StringLength(100)]
        public string OldName { get; set; }
        public bool CustomerBillTo { get; set; }
        [StringLength(100)]
        public string ShipVia { get; set; }
        public bool NoAddMisc { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? LaborDiscount { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? TaxRate { get; set; }
        [Column("TMHUNo")]
        [StringLength(50)]
        public string Tmhuno { get; set; }
        public bool LockTaxCode { get; set; }
        [StringLength(50)]
        public string TaxCodeImport { get; set; }
        public string ShippingComments { get; set; }
        public bool NoShippingCharge { get; set; }
        [StringLength(50)]
        public string ShippingCompany { get; set; }
        [StringLength(50)]
        public string ShippingAccount { get; set; }
        [Column("EMailInvoiceAddress")]
        [StringLength(1000)]
        public string EmailInvoiceAddress { get; set; }
        [Column("EMailInvoiceAttention")]
        [StringLength(100)]
        public string EmailInvoiceAttention { get; set; }
        [Column("EMailInvoice")]
        public bool EmailInvoice { get; set; }
        public bool NoPrintInvoice { get; set; }
        public bool BackupRequired { get; set; }
        [StringLength(50)]
        public string OldSalesman1 { get; set; }
        [StringLength(50)]
        public string OldSalesman2 { get; set; }
        [StringLength(50)]
        public string OldSalesman3 { get; set; }
        [StringLength(50)]
        public string OldSalesman4 { get; set; }
        [StringLength(50)]
        public string OldSalesman5 { get; set; }
        [StringLength(50)]
        public string OldSalesman6 { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LastAutoSalesmanUpdate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LastAutoSalesmanUpdate1 { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LastAutoSalesmanUpdate2 { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LastAutoSalesmanUpdate3 { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LastAutoSalesmanUpdate4 { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LastAutoSalesmanUpdate5 { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LastAutoSalesmanUpdate6 { get; set; }
        [StringLength(50)]
        public string InvoiceLanguage { get; set; }
        public bool? PeopleSoft { get; set; }
        [Column("PSCompany")]
        [StringLength(50)]
        public string Pscompany { get; set; }
        [Column("PSAccount")]
        [StringLength(50)]
        public string Psaccount { get; set; }
        [Column("PSLocation")]
        [StringLength(50)]
        public string Pslocation { get; set; }
        [Column("PSDept")]
        [StringLength(50)]
        public string Psdept { get; set; }
        [Column("PSProduct")]
        [StringLength(50)]
        public string Psproduct { get; set; }
        [StringLength(50)]
        public string AltCustomerNo { get; set; }
        public bool OverRideShipTo { get; set; }
        public bool OnFileResale { get; set; }
        [Column("OnFileMFGPermit")]
        public bool OnFileMfgpermit { get; set; }
        public bool OnFileInsurance { get; set; }
        public int? Inactive { get; set; }
        public int? OverRideShipToRates { get; set; }
        public short? SuppressPartsList { get; set; }
        [StringLength(100)]
        public string MarketingSource { get; set; }
        [Column("CreditCardLastTransID")]
        public int? CreditCardLastTransId { get; set; }
        [StringLength(400)]
        public string EmailRoadService { get; set; }
        [StringLength(400)]
        public string EmailShopService { get; set; }
        [Column("EmailPMService")]
        [StringLength(400)]
        public string EmailPmservice { get; set; }
        [Column("EmailRentalPMService")]
        [StringLength(400)]
        public string EmailRentalPmservice { get; set; }
        [StringLength(400)]
        public string EmailPartsCounter { get; set; }
        [StringLength(400)]
        public string EmailEquipmentSales { get; set; }
        [StringLength(400)]
        public string EmailRentals { get; set; }
        [Column("LegacyID")]
        public int? LegacyId { get; set; }
        [Column("ARStatementsEmailAddress")]
        [StringLength(1000)]
        public string ArstatementsEmailAddress { get; set; }
        public int TenantId { get; set; }
        public bool IsMigrated { get; set; }
    }
}
