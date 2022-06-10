using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("SpecStatus", Schema = "web")]
    [Index(nameof(TenantId), Name = "SpecStatus_TenantId_index")]
    [Index(nameof(SpecStatus1), nameof(TenantId), Name = "UC_SpecStatus", IsUnique = true)]
    public class SpecStatus : FullAuditedEntity<long>, IMustHaveTenant
    {
        public int TenantId { get; set; }
        [Required]
        [Column("SpecStatus")]
        [StringLength(50)]
        public string SpecStatus1 { get; set; }
        [StringLength(50)]
        public string Description { get; set; }
        public bool IsMigrated { get; set; }
    }
}
