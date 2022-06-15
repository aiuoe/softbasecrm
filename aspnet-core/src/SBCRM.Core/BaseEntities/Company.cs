using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("Company", Schema = "web")]
    [Index(nameof(TenantId), Name = "Company_TenantId_index")]
    [Index(nameof(Number), nameof(TenantId), Name = "UC_Company", IsUnique = true)]
    public class Company : FullAuditedEntity<long>, IMustHaveTenant
    {
        public short Number { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        [StringLength(50)]
        public string SubName { get; set; }
        [StringLength(50)]
        public string Address { get; set; }
        [StringLength(50)]
        public string City { get; set; }
        [StringLength(50)]
        public string State { get; set; }
        [StringLength(50)]
        public string ZipCode { get; set; }
        [StringLength(50)]
        public string Phone { get; set; }
        [StringLength(50)]
        public string Fax { get; set; }
        [StringLength(50)]
        public string Group1 { get; set; }
        [StringLength(50)]
        public string Group2 { get; set; }
        [StringLength(50)]
        public string Group3 { get; set; }
        [StringLength(50)]
        public string Group4 { get; set; }
        [StringLength(50)]
        public string Group5 { get; set; }
        [StringLength(50)]
        public string Group6 { get; set; }
        public short? InvoiceCopies { get; set; }
        public bool LastInvoiceCopy { get; set; }
        public bool AutomaticInvoiceDate { get; set; }
        [StringLength(50)]
        public string PartsCurrencyFormat { get; set; }
        [StringLength(50)]
        public string AccountingPackage { get; set; }
        [StringLength(50)]
        public string AccountingPath { get; set; }
        [Column("APCheckFormat")]
        [StringLength(50)]
        public string ApcheckFormat { get; set; }
        [Column("NextPO")]
        public int? NextPo { get; set; }
        [Column("EqNextPO")]
        public int? EqNextPo { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CurrentFiscalStart { get; set; }
        [StringLength(50)]
        public string RetainedEarnings { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? AccountingCutoffDate { get; set; }
        public bool PrintLaborSummary { get; set; }
        public bool PrintSerialNo { get; set; }
        public bool PrintMake { get; set; }
        public bool PrintModel { get; set; }
        public bool PrintUnitNo { get; set; }
        public bool PrintModelGroup { get; set; }
        public bool PrintModelYear { get; set; }
        public bool PrintStage { get; set; }
        public bool PrintUpright { get; set; }
        public bool PrintDownHeight { get; set; }
        public bool PrintForks { get; set; }
        public bool PrintAttachments { get; set; }
        public bool PrintPower { get; set; }
        public bool PrintTransmission { get; set; }
        public bool PrintCapacity { get; set; }
        public bool PrintTireType { get; set; }
        [Column("PrintLBR")]
        public bool PrintLbr { get; set; }
        public bool PrintEquipmentComments { get; set; }
        public string DefaultEquipmentComments { get; set; }
        [StringLength(50)]
        public string LogoFile { get; set; }
        public bool AutoSalesGroup { get; set; }
        public bool DisableMilesCalculation { get; set; }
        public string InvoiceComments { get; set; }
        public int? NextCustomerNo { get; set; }
        [StringLength(50)]
        public string DefaultCustomerTerms { get; set; }
        [Column("LTGuruUserName")]
        [StringLength(50)]
        public string LtguruUserName { get; set; }
        [Column("LTGuruPassword")]
        [StringLength(50)]
        public string LtguruPassword { get; set; }
        [StringLength(50)]
        public string DealerNo { get; set; }
        [StringLength(100)]
        public string IntrupaDealerNo { get; set; }
        [Column("LPMDealerNo")]
        [StringLength(100)]
        public string LpmdealerNo { get; set; }
        public short? ContactFollowupDays { get; set; }
        [StringLength(50)]
        public string DefaultWholeVerbage { get; set; }
        [StringLength(50)]
        public string DefaultDecimalVerbage { get; set; }
        public short? InvoiceCutOffDay { get; set; }
        [Column("WIPAccrual")]
        public bool Wipaccrual { get; set; }
        [Column("IncludeWIPBalance", TypeName = "decimal(19, 4)")]
        public decimal? IncludeWipbalance { get; set; }
        [StringLength(50)]
        public string CheckDateFormat { get; set; }
        [Column("SMTPServer")]
        [StringLength(100)]
        public string Smtpserver { get; set; }
        [Column("SMTPUserName")]
        [StringLength(100)]
        public string SmtpuserName { get; set; }
        [Column("SMTPPassword")]
        [StringLength(100)]
        public string Smtppassword { get; set; }
        [Column("EMailAddress")]
        [StringLength(100)]
        public string EmailAddress { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? FutureCutOffDate { get; set; }
        [StringLength(50)]
        public string CustomerNo { get; set; }
        [StringLength(50)]
        public string ChangedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DateChanged { get; set; }
        [Column(TypeName = "image")]
        public byte[] Image { get; set; }
        public bool UseImage { get; set; }
        public int? NextControlNo { get; set; }
        public short? LaborRounding { get; set; }
        [Column(TypeName = "text")]
        public string EmailComments { get; set; }
        [Column("SMTPPort")]
        public int? Smtpport { get; set; }
        [Column("UseUserID")]
        public bool? UseUserId { get; set; }
        [Column("eLiftUserName")]
        [StringLength(50)]
        public string ELiftUserName { get; set; }
        [Column("eLiftPassword")]
        [StringLength(50)]
        public string ELiftPassword { get; set; }
        [Column("eliftTest")]
        public short? EliftTest { get; set; }
        public int? MobileIncludeMisc { get; set; }
        public int? MobileIncludeTimes { get; set; }
        public int? MobileAutoDocCenter { get; set; }
        [StringLength(50)]
        public string MobileEmailAddress { get; set; }
        [Column("SMTPSecure")]
        public bool? Smtpsecure { get; set; }
        [Column("SMTPSecureType")]
        public int? SmtpsecureType { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? StartTimeDefault { get; set; }
        public int? NoClearSignature { get; set; }
        public int? DispatchManualRefresh { get; set; }
        [Column("QuotePartsNA")]
        [StringLength(50)]
        public string QuotePartsNa { get; set; }
        public int? MobileSuppressPartNo { get; set; }
        public int? MobileAddHours { get; set; }
        public int? Office365 { get; set; }
        [Column("MSExchange")]
        public int? Msexchange { get; set; }
        [Column("QtoOAllowPartialBO")]
        public int? QtoOallowPartialBo { get; set; }
        public int? HourMeterChangeAllowed { get; set; }
        public int? EmailOption { get; set; }
        public bool UsePayByCreditCard { get; set; }
        [StringLength(50)]
        public string CreditCardVendor { get; set; }
        [StringLength(128)]
        public string AuthLogin { get; set; }
        [StringLength(128)]
        public string AuthPwd { get; set; }
        [Column("LCount")]
        [StringLength(400)]
        public string Lcount { get; set; }
        [Column("TVHAccountNo")]
        [StringLength(50)]
        public string TvhaccountNo { get; set; }
        [Column("TVHKey")]
        [StringLength(100)]
        public string Tvhkey { get; set; }
        [Column("TVHCountry")]
        [StringLength(50)]
        public string Tvhcountry { get; set; }
        [Column("TVHWarehouse")]
        [StringLength(50)]
        public string Tvhwarehouse { get; set; }
        [Column("IncludeRAWHours")]
        public bool IncludeRawhours { get; set; }
        public int? QuoteHoldParts { get; set; }
        public int? EquipmentDeleteTest { get; set; }
        [Column("QtoOPromptEachBO")]
        public int? QtoOpromptEachBo { get; set; }
        [Column("eRentKey")]
        [StringLength(200)]
        public string ERentKey { get; set; }
        [Column("PJTest")]
        public bool? Pjtest { get; set; }
        public bool? TrailerFlag { get; set; }
        [Column("DisallowAutoPostCC")]
        public bool? DisallowAutoPostCc { get; set; }
        [StringLength(200)]
        public string BillTrustHost { get; set; }
        [StringLength(200)]
        public string BillTrustUserName { get; set; }
        [StringLength(200)]
        public string BillTrustPassword { get; set; }
        [StringLength(50)]
        public string BillTrustPort { get; set; }
        public int? BillTrustAgingDay { get; set; }
        public int TenantId { get; set; }
        public bool IsMigrated { get; set; }
    }
}
