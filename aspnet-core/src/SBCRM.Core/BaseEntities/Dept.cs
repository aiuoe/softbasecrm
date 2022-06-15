using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("Dept", Schema = "web")]
    [Index(nameof(TenantId), Name = "Dept_TenantId_index")]
    [Index(nameof(Branch), nameof(Dept1), nameof(TenantId), Name = "UC_DeptNews", IsUnique = true)]
    public class Dept : FullAuditedEntity<long>, IMustHaveTenant
    {
        public int TenantId { get; set; }
        public short Branch { get; set; }
        [Column("Dept")]
        public short Dept1 { get; set; }
        [StringLength(50)]
        public string Title { get; set; }
        public short? SaleGroup { get; set; }
        public short? MechGroup { get; set; }
        [StringLength(10)]
        public string InvoiceType { get; set; }
        [StringLength(50)]
        public string InvoiceName { get; set; }
        [StringLength(50)]
        public string LaborAccount { get; set; }
        [StringLength(50)]
        public string EquipmentAccount { get; set; }
        [StringLength(50)]
        public string InternalCustomer { get; set; }
        public int? NextInvoice { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        [StringLength(50)]
        public string MiscDescription { get; set; }
        [StringLength(4)]
        public string MiscPercent { get; set; }
        [StringLength(50)]
        public string MiscSaleAccount { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? MiscLimit { get; set; }
        public bool? MiscLaborOnly { get; set; }
        [StringLength(50)]
        public string DeptGroup { get; set; }
        [StringLength(50)]
        public string TermsOverRide { get; set; }
        public bool? PartsPricing { get; set; }
        public bool? InitialComments { get; set; }
        public bool? MiscPartsOnly { get; set; }
        [StringLength(4)]
        public string HoursInDay { get; set; }
        public short? DaysInWeek { get; set; }
        public short? DaysIn4Week { get; set; }
        public short? DaysInMonth { get; set; }
        public short? DaysInQuarter { get; set; }
        [Column("NextPONo")]
        public int? NextPono { get; set; }
        public int? NextQuote { get; set; }
        public string QuoteComments { get; set; }
        [StringLength(50)]
        public string CashAccount { get; set; }
        public int? NextRentalContract { get; set; }
        public bool? SuppressLaborHours { get; set; }
        [StringLength(4)]
        public string AdditionalLaborHours { get; set; }
        public int? AdditionalLaborMech { get; set; }
        [StringLength(50)]
        public string AdditionalLaborAccountNo { get; set; }
        [StringLength(100)]
        public string RentalReturnStatus { get; set; }
        public bool? SuppressPartsPricing { get; set; }
        public short? QuoteExpirationDays { get; set; }
        public string InvoiceComments { get; set; }
        [Column("OpenWOWatermark")]
        [StringLength(50)]
        public string OpenWowatermark { get; set; }
        [Column("BOPriority")]
        public short? Bopriority { get; set; }
        public short? StockPriority { get; set; }
        public short? EmergencyCostPriority { get; set; }
        public bool? TaxAtDealer { get; set; }
        [StringLength(50)]
        public string QuoteVerbiage { get; set; }
        public bool? NoCreditOnQuote { get; set; }
        [StringLength(50)]
        public string InvoiceNameFrench { get; set; }
        [StringLength(50)]
        public string QuoteVerbiageFrench { get; set; }
        public string MobileDisclaimer { get; set; }
        public string MobileSignatureDisclaimer { get; set; }
        [StringLength(200)]
        public string InternalTopText { get; set; }
        [StringLength(50)]
        public string CreditCardAccountNo { get; set; }
        [Column("NoCC")]
        public bool? NoCc { get; set; }
        [StringLength(1024)]
        public string PartsRecvEmail { get; set; }
        [StringLength(50)]
        public string AddedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DateAdded { get; set; }
        [StringLength(50)]
        public string ChangedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DateChanged { get; set; }
        public bool IsMigrated { get; set; }
    }
}
