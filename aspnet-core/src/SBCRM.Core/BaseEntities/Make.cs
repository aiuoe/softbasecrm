using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("Make", Schema = "web")]
    [Index(nameof(TenantId), Name = "Make_TenantId_index")]
    [Index(nameof(Make1), nameof(TenantId), Name = "UC_Make", IsUnique = true)]
    public class Make : FullAuditedEntity<long>, IMustHaveTenant
    {
        public int TenantId { get; set; }
        [Required]
        [Column("Make")]
        [StringLength(50)]
        public string Make1 { get; set; }
        [StringLength(50)]
        public string Description { get; set; }
        public bool IsMigrated { get; set; }
    }
}
