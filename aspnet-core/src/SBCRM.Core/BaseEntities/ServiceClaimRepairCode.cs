using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("ServiceClaimRepairCode", Schema = "web")]
    [Index(nameof(TenantId), Name = "ServiceClaimRepairCode_TenantId_index")]
    [Index(nameof(RepairCode), nameof(TenantId), Name = "UC_ServiceClaimRepairCode", IsUnique = true)]
    public class ServiceClaimRepairCode : FullAuditedEntity<long>, IMustHaveTenant
    {
        public int TenantId { get; set; }
        [Required]
        [StringLength(100)]
        public string RepairCode { get; set; }
        public bool IsMigrated { get; set; }
    }
}
