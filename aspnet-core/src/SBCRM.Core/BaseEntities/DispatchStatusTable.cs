using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("DispatchStatusTable", Schema = "web")]
    [Index(nameof(TenantId), Name = "DispatchStatusTable_TenantId_index")]
    [Index(nameof(DispatchStatus), nameof(TenantId), Name = "UC_DispatchStatusTable", IsUnique = true)]
    public class DispatchStatusTable : FullAuditedEntity<long>, IMustHaveTenant
    {
        [Required]
        [StringLength(100)]
        public string DispatchStatus { get; set; }
        public int TenantId { get; set; }
        public bool IsMigrated { get; set; }
    }
}
