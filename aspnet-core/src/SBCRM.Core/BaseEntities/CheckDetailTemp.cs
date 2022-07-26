using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("CheckDetailTemp", Schema = "web")]
    [Index(nameof(TenantId), Name = "CheckDetailTemp_TenantId_index")]
    public class CheckDetailTemp : FullAuditedEntity<long>, IMustHaveTenant
    {
        public int CheckNo { get; set; }
        [Required]
        [StringLength(50)]
        public string AccountNo { get; set; }
        [Required]
        [StringLength(50)]
        public string VendorNo { get; set; }
        [Required]
        [Column("APInvoiceNo")]
        [StringLength(50)]
        public string ApinvoiceNo { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime EntryDate { get; set; }
        [Column("APInvoiceDate", TypeName = "datetime")]
        public DateTime? ApinvoiceDate { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? Amount { get; set; }
        public bool Printed { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? DiscountAmount { get; set; }
        public bool HistoryFlag { get; set; }
        [StringLength(50)]
        public string DiscountAccount { get; set; }
        public bool DiscountTaken { get; set; }
        [StringLength(50)]
        public string CurrencyType { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? ConversionRate { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? ConvertedAmount { get; set; }
        [StringLength(50)]
        public string SalesTaxAccount { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? SalesTaxAmount { get; set; }
        [Column("APDetailID")]
        public int? ApdetailId { get; set; }
        public int? LegacyId { get; set; }
        public int TenantId { get; set; }
        public bool IsMigrated { get; set; }
    }
}
