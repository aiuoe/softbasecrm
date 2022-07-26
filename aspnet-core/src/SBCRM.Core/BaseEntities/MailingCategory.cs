using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("MailingCategory", Schema = "web")]
    [Index(nameof(TenantId), Name = "MailingCategory_TenantId_index")]
    [Index(nameof(Category), nameof(TenantId), Name = "UC_MailingCategory", IsUnique = true)]
    public class MailingCategory : FullAuditedEntity<long>, IMustHaveTenant
    {
        public int TenantId { get; set; }
        [Required]
        [StringLength(100)]
        public string Category { get; set; }
        [StringLength(100)]
        public string Description { get; set; }
        public bool IsMigrated { get; set; }
    }
}
