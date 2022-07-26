using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("ComponentCodes", Schema = "web")]
    [Index(nameof(TenantId), Name = "ComponentCodes_TenantId_index")]
    [Index(nameof(Code), nameof(TenantId), Name = "UC_ComponentCodes", IsUnique = true)]
    public class ComponentCode : FullAuditedEntity<long>, IMustHaveTenant
    {
        [Required]
        [StringLength(50)]
        public string Code { get; set; }
        [StringLength(200)]
        public string Description { get; set; }
        public int TenantId { get; set; }
        public bool IsMigrated { get; set; }
    }
}
