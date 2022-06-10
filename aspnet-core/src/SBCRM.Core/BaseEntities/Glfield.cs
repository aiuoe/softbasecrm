using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("GLField", Schema = "web")]
    [Index(nameof(TenantId), Name = "GLField_TenantId_index")]
    [Index(nameof(AccountField), nameof(TenantId), Name = "UC_GLField", IsUnique = true)]
    public class Glfield : FullAuditedEntity<long>, IMustHaveTenant
    {
        [Required]
        [StringLength(50)]
        public string AccountField { get; set; }
        public bool Balance { get; set; }
        public bool Calculated { get; set; }
        public int TenantId { get; set; }
        public bool IsMigrated { get; set; }
    }
}
