using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("LaborQuoteGroup", Schema = "web")]
    [Index(nameof(TenantId), Name = "LaborQuoteGroup_TenantId_index")]
    [Index(nameof(RepairGroup), nameof(TenantId), Name = "UC_LaborQuoteGroup", IsUnique = true)]
    public class LaborQuoteGroup : FullAuditedEntity<long>, IMustHaveTenant
    {
        public int TenantId { get; set; }
        [Required]
        [StringLength(50)]
        public string RepairGroup { get; set; }
        [StringLength(50)]
        public string Description { get; set; }
        public bool IsMigrated { get; set; }
    }
}
