using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("PartNoAlias", Schema = "web")]
    [Index(nameof(TenantId), Name = "PartNoAlias_TenantId_index")]
    [Index(nameof(PartNo), nameof(PartNoAlias1), nameof(TenantId), Name = "UC_PartNoAlias", IsUnique = true)]
    public class PartNoAlias : FullAuditedEntity<long>, IMustHaveTenant
    {
        public int TenantId { get; set; }
        [Required]
        [StringLength(100)]
        public string PartNo { get; set; }
        [Required]
        [Column("PartNoAlias")]
        [StringLength(100)]
        public string PartNoAlias1 { get; set; }
        [StringLength(100)]
        public string CreatedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? Created { get; set; }
        public bool IsMigrated { get; set; }
    }
}
