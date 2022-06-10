using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("WOReplicate", Schema = "web")]
    [Index(nameof(TenantId), Name = "WOReplicate_TenantId_index")]
    public class Woreplicate : FullAuditedEntity<long>, IMustHaveTenant
    {
        public int TenantId { get; set; }
        [Column("WONoSource")]
        public int? WonoSource { get; set; }
        public int? DispositionSource { get; set; }
        [Column("WONoDestination")]
        public int? WonoDestination { get; set; }
        [StringLength(50)]
        public string ReplicatedBy { get; set; }
        public int? LegacyId { get; set; }
        public bool IsMigrated { get; set; }
    }
}
