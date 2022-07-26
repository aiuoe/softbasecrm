using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("FedExCodes", Schema = "web")]
    [Index(nameof(TenantId), Name = "FedExCodes_TenantId_index")]
    [Index(nameof(Code), nameof(TenantId), Name = "UC_FedExCodes", IsUnique = true)]
    public class FedExCode : FullAuditedEntity<long>, IMustHaveTenant
    {
        [Required]
        [StringLength(50)]
        public string Code { get; set; }
        public int TenantId { get; set; }
        public bool IsMigrated { get; set; }
    }
}
