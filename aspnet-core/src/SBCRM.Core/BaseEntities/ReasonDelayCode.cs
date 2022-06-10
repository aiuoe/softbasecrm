using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("ReasonDelayCodes", Schema = "web")]
    [Index(nameof(TenantId), Name = "ReasonDelayCodes_TenantId_index")]
    [Index(nameof(Code), nameof(TenantId), Name = "UC_ReasonDelayCodes", IsUnique = true)]
    public class ReasonDelayCode : FullAuditedEntity<long>, IMustHaveTenant
    {
        public int TenantId { get; set; }
        [Required]
        [StringLength(50)]
        public string Code { get; set; }
        [Column("ATACodes")]
        [StringLength(50)]
        public string Atacodes { get; set; }
        [StringLength(200)]
        public string Description { get; set; }
        public bool IsMigrated { get; set; }
    }
}
