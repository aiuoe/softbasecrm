using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("APDetail", Schema = "web")]
    [Index(nameof(TenantId), Name = "APDetail_TenantId_index")]
    public class ApDetail : FullAuditedEntity<long>, IMustHaveTenant
    {
        public bool? HistoryFlag { get; set; }
        [Required]
        [StringLength(50)]
        public string AccountNo { get; set; }
        public int? VendorNo { get; set; }
        [Required]
        [Column("APInvoiceNo")]
        [StringLength(50)]
        public string ApinvoiceNo { get; set; }
        [Required]
        [StringLength(50)]
        public string EntryType { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime EntryDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? EffectiveDate { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? Amount { get; set; }
        public int? CheckNo { get; set; }
        [Column(TypeName = "text")]
        public string Comments { get; set; }
        [Column("APInvoiceDate", TypeName = "datetime")]
        public DateTime? ApinvoiceDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DueDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DiscountDate { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? DiscountAmount { get; set; }
        [StringLength(50)]
        public string Status { get; set; }
        [StringLength(100)]
        public string Authorizedby { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? AuthorizedDate { get; set; }
        [StringLength(100)]
        public string Holdby { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? HoldDate { get; set; }
        public bool? DiscountTaken { get; set; }
        [Column("PONo")]
        public int? Pono { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? ApprovedAmount { get; set; }
        [StringLength(50)]
        public string CurrencyType { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? ConversionRate { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? ConvertedAmount { get; set; }
        [Column("MEConversionRate", TypeName = "decimal(19, 4)")]
        public decimal? MeconversionRate { get; set; }
        [Column("MEDate", TypeName = "datetime")]
        public DateTime? Medate { get; set; }
        [Column("PMEConversionRate", TypeName = "decimal(19, 4)")]
        public decimal? PmeconversionRate { get; set; }
        [Column("PMEDate", TypeName = "datetime")]
        public DateTime? Pmedate { get; set; }
        public int? SalesTaxAccount { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? SalesTaxAmount { get; set; }
        [Column("ApplyToAPInvoiceNo")]
        [StringLength(50)]
        public string ApplyToApinvoiceNo { get; set; }
        [StringLength(50)]
        public string Journal { get; set; }
        public int TenantId { get; set; }
        public bool IsMigrated { get; set; }
    }
}
