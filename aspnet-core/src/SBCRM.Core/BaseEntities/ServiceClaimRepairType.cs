using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("ServiceClaimRepairType", Schema = "web")]
    [Index(nameof(TenantId), Name = "ServiceClaimRepairType_TenantId_index")]
    [Index(nameof(RepairType), nameof(TenantId), Name = "UC_ServiceClaimRepairType", IsUnique = true)]
    public class ServiceClaimRepairType : FullAuditedEntity<long>, IMustHaveTenant
    {
        public int TenantId { get; set; }
        [Required]
        [StringLength(100)]
        public string RepairType { get; set; }
        [StringLength(100)]
        public string Description { get; set; }
        public bool IsMigrated { get; set; }
    }
}
