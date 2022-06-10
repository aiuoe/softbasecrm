using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("BusinessCategory", Schema = "web")]
    [Index(nameof(TenantId), Name = "BusinessCategory_TenantId_index")]
    [Index(nameof(Category), nameof(TenantId), Name = "UC_BusinessCategory", IsUnique = true)]
    public class BusinessCategory : FullAuditedEntity<long>, IMustHaveTenant
    {
        [Required]
        [StringLength(50)]
        public string Category { get; set; }
        public int TenantId { get; set; }
        public bool IsMigrated { get; set; }
    }
}
