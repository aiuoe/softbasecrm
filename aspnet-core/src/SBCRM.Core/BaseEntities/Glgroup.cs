using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("GLGroup", Schema = "web")]
    [Index(nameof(TenantId), Name = "GLGroup_TenantId_index")]
    [Index(nameof(AccountField), nameof(TenantId), Name = "UC_GLGroup", IsUnique = true)]
    public class Glgroup : FullAuditedEntity<long>, IMustHaveTenant
    {
        [Required]
        [StringLength(50)]
        public string AccountField { get; set; }
        [Required]
        [StringLength(50)]
        public string Section { get; set; }
        [Required]
        [StringLength(50)]
        public string SectionGroup { get; set; }
        [StringLength(50)]
        public string GroupTitle { get; set; }
        public int TenantId { get; set; }
        public bool IsMigrated { get; set; }
    }
}
