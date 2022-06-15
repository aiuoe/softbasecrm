using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("ARDetail", Schema = "web")]
    [Index(nameof(TenantId), Name = "ARDetail_TenantId_index")]
    public class ArDetail : FullAuditedEntity<long>, IMustHaveTenant
    {
        public bool? HistoryFlag { get; set; }
        [Required]
        [StringLength(50)]
        public string AccountNo { get; set; }
        [Required]
        [StringLength(50)]
        public string CustomerNo { get; set; }
        public int ApplyToInvoiceNo { get; set; }
        [Required]
        [StringLength(50)]
        public string EntryType { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime EntryDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? EffectiveDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? Due { get; set; }
        public int? InvoiceNo { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? Amount { get; set; }
        [StringLength(50)]
        public string CheckNo { get; set; }
        public string Comments { get; set; }
        public bool? Dispute { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DisputeDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? InvoiceRecvDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? PaymentPromiseDate { get; set; }
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
        [StringLength(50)]
        public string SalesTaxAccount { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? SalesTaxAmount { get; set; }
        public bool? CustomerSelected { get; set; }
        public bool? ExcludeCredit { get; set; }
        [StringLength(50)]
        public string Journal { get; set; }
        [StringLength(100)]
        public string AddedBy { get; set; }
        public int TenantId { get; set; }
        public bool IsMigrated { get; set; }
    }
}
