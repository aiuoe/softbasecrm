using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("PartsInquiryHistory", Schema = "web")]
    [Index(nameof(TenantId), Name = "PartsInquiryHistory_TenantId_index")]
    public class PartsInquiryHistory : FullAuditedEntity<long>, IMustHaveTenant
    {
        public int TenantId { get; set; }
        public int? LegacyId { get; set; }
        [StringLength(100)]
        public string SecureName { get; set; }
        [StringLength(100)]
        public string PartNo { get; set; }
        [StringLength(100)]
        public string Warehouse { get; set; }
        [StringLength(100)]
        public string Description { get; set; }
        [StringLength(50)]
        public string Bin { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? OnHand { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? EntryDate { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? Cost { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? Discount { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? List { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? Internal { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? Warranty { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? Wholesale { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? Customer { get; set; }
        [StringLength(50)]
        public string CustomerNo { get; set; }
        [StringLength(100)]
        public string AddedBy { get; set; }
        public bool IsMigrated { get; set; }
    }
}
