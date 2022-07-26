using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("Kohler", Schema = "web")]
    [Index(nameof(TenantId), Name = "Kohler_TenantId_index")]
    [Index(nameof(PartNo), nameof(TenantId), Name = "UC_Kohler", IsUnique = true)]
    public class Kohler : FullAuditedEntity<long>, IMustHaveTenant
    {
        public int TenantId { get; set; }
        [Required]
        [StringLength(100)]
        public string PartNo { get; set; }
        [StringLength(100)]
        public string Description { get; set; }
        [StringLength(50)]
        public string PartNoPrefix { get; set; }
        [StringLength(50)]
        public string PartNoNumber { get; set; }
        [StringLength(50)]
        public string PartNoSuffix { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? List { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? Cost { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? Created { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LastUpdated { get; set; }
        public bool IsMigrated { get; set; }
    }
}
