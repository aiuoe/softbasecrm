using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("EFTDetail", Schema = "web")]
    [Index(nameof(TenantId), Name = "EFTDetail_TenantId_index")]
    public class Eftdetail : FullAuditedEntity<long>, IMustHaveTenant
    {
        [Column("LegacyID")]
        public long? LegacyId { get; set; }
        [Column("EFTNo")]
        public int Eftno { get; set; }
        [StringLength(50)]
        public string AccountNo { get; set; }
        [StringLength(50)]
        public string VendorNo { get; set; }
        [Column("APInvoiceNo")]
        [StringLength(50)]
        public string ApinvoiceNo { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? EntryDate { get; set; }
        [Column("APInvoiceDate", TypeName = "datetime")]
        public DateTime? ApinvoiceDate { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? Amount { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? DiscountAmount { get; set; }
        public bool HistoryFlag { get; set; }
        [StringLength(50)]
        public string DiscountAccount { get; set; }
        [StringLength(50)]
        public string DiscountTaken { get; set; }
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
        [Column("ApplyToAPInvoiceNo")]
        [StringLength(50)]
        public string ApplyToApinvoiceNo { get; set; }
        public int TenantId { get; set; }
        public bool IsMigrated { get; set; }
    }
}
