using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("FOB", Schema = "web")]
    [Index(nameof(TenantId), Name = "FOB_TenantId_index")]
    public class Fob : FullAuditedEntity<long>, IMustHaveTenant
    {
        [Column("FOB")]
        [StringLength(100)]
        public string Fob1 { get; set; }
        public short? SortOrder { get; set; }
        public int TenantId { get; set; }
        public bool IsMigrated { get; set; }
    }
}
