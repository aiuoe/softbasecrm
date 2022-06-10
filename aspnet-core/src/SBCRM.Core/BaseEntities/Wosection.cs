using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("WOSection", Schema = "web")]
    [Index(nameof(TenantId), Name = "WOSection_TenantId_index")]
    [Index(nameof(Wono), nameof(SectionNo), nameof(TenantId), Name = "UC_WOSection", IsUnique = true)]
    public class Wosection : FullAuditedEntity<long>, IMustHaveTenant
    {
        public int TenantId { get; set; }
        [Column("WONo")]
        public int Wono { get; set; }
        public short SectionNo { get; set; }
        [StringLength(50)]
        public string AddedBy { get; set; }
        [StringLength(50)]
        public string SectionDescription { get; set; }
        public bool IsMigrated { get; set; }
    }
}
