using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("Ariens", Schema = "web")]
    [Index(nameof(TenantId), Name = "Ariens_TenantId_index")]
    [Index(nameof(PartNo), nameof(TenantId), Name = "UC_Ariens", IsUnique = true)]
    public class Arien : FullAuditedEntity<long>, IMustHaveTenant
    {
        [Required]
        [StringLength(100)]
        public string PartNo { get; set; }
        [StringLength(100)]
        public string Description { get; set; }
        [StringLength(50)]
        public string ObsoleteCode { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? List { get; set; }
        [StringLength(50)]
        public string DiscountCode { get; set; }
        public short? PackageQty { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? Created { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LastUpdated { get; set; }
        public int TenantId { get; set; }
        public bool IsMigrated { get; set; }
    }
}
