using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("PMStatus", Schema = "web")]
    [Index(nameof(TenantId), Name = "PMStatus_TenantId_index")]
    [Index(nameof(Status), nameof(TenantId), Name = "UC_PMStatus", IsUnique = true)]
    public class Pmstatus : FullAuditedEntity<long>, IMustHaveTenant
    {
        public int TenantId { get; set; }
        [Required]
        [StringLength(50)]
        public string Status { get; set; }
        public string Description { get; set; }
        public bool IsMigrated { get; set; }
    }
}
