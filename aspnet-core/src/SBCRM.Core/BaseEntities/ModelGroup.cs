using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("ModelGroup", Schema = "web")]
    [Index(nameof(TenantId), Name = "ModelGroup_TenantId_index")]
    [Index(nameof(ModelGroup1), nameof(TenantId), Name = "UC_ModelGroup", IsUnique = true)]
    public class ModelGroup : FullAuditedEntity<long>, IMustHaveTenant
    {
        public int TenantId { get; set; }
        [Required]
        [Column("ModelGroup")]
        [StringLength(50)]
        public string ModelGroup1 { get; set; }
        [StringLength(50)]
        public string Description { get; set; }
        public bool IsMigrated { get; set; }
    }
}
