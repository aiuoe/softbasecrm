using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("ShipVia", Schema = "web")]
    [Index(nameof(TenantId), Name = "ShipVia_TenantId_index")]
    [Index(nameof(ShipVia), nameof(TenantId), Name = "UC_ShipVia", IsUnique = true)]
    public class ShipVium : FullAuditedEntity<long>, IMustHaveTenant
    {
        public int TenantId { get; set; }
        [Required]
        [StringLength(50)]
        public string ShipVia { get; set; }
        public short? SortOrder { get; set; }
        public bool IsMigrated { get; set; }
    }
}
