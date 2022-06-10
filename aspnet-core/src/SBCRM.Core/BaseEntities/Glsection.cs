using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("GLSection", Schema = "web")]
    [Index(nameof(TenantId), Name = "GLSection_TenantId_index")]
    [Index(nameof(Section), nameof(TenantId), Name = "UC_GLSection", IsUnique = true)]
    public class Glsection : FullAuditedEntity<long>, IMustHaveTenant
    {
        public int TenantId { get; set; }
        [Required]
        [StringLength(50)]
        public string Section { get; set; }
        [StringLength(50)]
        public string SectionTitle { get; set; }
        public bool IsMigrated { get; set; }
    }
}
