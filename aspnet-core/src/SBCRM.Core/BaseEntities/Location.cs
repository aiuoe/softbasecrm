using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("Location", Schema = "web")]
    [Index(nameof(TenantId), Name = "Location_TenantId_index")]
    [Index(nameof(Location1), nameof(TenantId), Name = "UC_Location", IsUnique = true)]
    public class Location : FullAuditedEntity<long>, IMustHaveTenant
    {
        public int TenantId { get; set; }
        [Required]
        [Column("Location")]
        [StringLength(50)]
        public string Location1 { get; set; }
        [StringLength(50)]
        public string Description { get; set; }
        public bool IsMigrated { get; set; }
    }
}
