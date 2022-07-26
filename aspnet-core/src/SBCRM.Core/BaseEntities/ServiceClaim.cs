using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("ServiceClaim", Schema = "web")]
    [Index(nameof(TenantId), Name = "ServiceClaim_TenantId_index")]
    [Index(nameof(DealerInvoiceNo), nameof(TenantId), Name = "UC_ServiceClaim", IsUnique = true)]
    public class ServiceClaim : FullAuditedEntity<long>, IMustHaveTenant
    {
        public int TenantId { get; set; }
        [Required]
        [StringLength(100)]
        public string DealerInvoiceNo { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ReceivedDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ProcessedDate { get; set; }
        [StringLength(50)]
        public string CustomerNo { get; set; }
        [StringLength(50)]
        public string VendorNo { get; set; }
        [StringLength(100)]
        public string SerialNo { get; set; }
        [Column("CustomerPO")]
        [StringLength(100)]
        public string CustomerPo { get; set; }
        [StringLength(50)]
        public string CustomerInvoiceNo { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? HourMeter { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? RepairDate { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? DealerParts { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? DealerLabor { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? DealerSublet { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? DealerFreight { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? DealerMisc { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? DealerSalesTax { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? DealerTotal { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? SubmittedParts { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? SubmittedLabor { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? SubmittedSublet { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? SubmittedFreight { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? SubmittedMisc { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? SubmittedSalesTax { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? SubmittedTotal { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? SubmittedDate { get; set; }
        [StringLength(100)]
        public string BatchNo { get; set; }
        public string RepairReason { get; set; }
        [StringLength(50)]
        public string RepairType { get; set; }
        [StringLength(50)]
        public string RepairCode1 { get; set; }
        [StringLength(50)]
        public string RepairCode2 { get; set; }
        [StringLength(50)]
        public string RepairCode3 { get; set; }
        [StringLength(50)]
        public string RepairCode4 { get; set; }
        [StringLength(50)]
        public string RepairCode5 { get; set; }
        [StringLength(50)]
        public string RepairCode6 { get; set; }
        public string AdjustmentReason { get; set; }
        public short? PendingInfo { get; set; }
        public short? AdjustmentsMade { get; set; }
        public string ReturnReason { get; set; }
        [StringLength(50)]
        public string ReturnCode1 { get; set; }
        [StringLength(50)]
        public string ReturnCode2 { get; set; }
        [StringLength(50)]
        public string ReturnCode3 { get; set; }
        [StringLength(50)]
        public string ReturnCode4 { get; set; }
        [StringLength(50)]
        public string ReturnCode5 { get; set; }
        [StringLength(50)]
        public string ReturnCode6 { get; set; }
        [StringLength(50)]
        public string ReturnCode7 { get; set; }
        [StringLength(50)]
        public string ReturnCode8 { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ReturnedDate { get; set; }
        [StringLength(50)]
        public string ResubmittedDate { get; set; }
        [StringLength(50)]
        public string ResbComments { get; set; }
        public short? Exported { get; set; }
        public short? CustomerExported { get; set; }
        public bool IsMigrated { get; set; }
    }
}
