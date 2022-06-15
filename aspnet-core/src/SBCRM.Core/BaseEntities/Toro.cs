using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("Toro", Schema = "web")]
    [Index(nameof(TenantId), Name = "Toro_TenantId_index")]
    [Index(nameof(PartNo), nameof(TenantId), Name = "UC_Toro", IsUnique = true)]
    public class Toro : FullAuditedEntity<long>, IMustHaveTenant
    {
        public int TenantId { get; set; }
        [Required]
        [StringLength(50)]
        public string PartNo { get; set; }
        [StringLength(50)]
        public string RecordType { get; set; }
        [StringLength(50)]
        public string NewPartNo { get; set; }
        [StringLength(50)]
        public string Description { get; set; }
        [StringLength(50)]
        public string ProductCode { get; set; }
        [StringLength(50)]
        public string UsageCode { get; set; }
        [Column("TRPP")]
        [StringLength(50)]
        public string Trpp { get; set; }
        [StringLength(50)]
        public string StockCode { get; set; }
        [StringLength(50)]
        public string PackageQty { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? Weight { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ValidDate { get; set; }
        [StringLength(50)]
        public string DiscountCode { get; set; }
        [Column("USRetail", TypeName = "decimal(19, 4)")]
        public decimal? Usretail { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LastUpdated { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? Created { get; set; }
        public bool IsMigrated { get; set; }
    }
}
