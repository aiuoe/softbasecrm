using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("SecureWarehouse", Schema = "web")]
    [Index(nameof(TenantId), Name = "SecureWarehouse_TenantId_index")]
    [Index(nameof(SecureName), nameof(Warehouse), nameof(TenantId), Name = "UC_SecureWarehouse", IsUnique = true)]
    public class SecureWarehouse : FullAuditedEntity<long>, IMustHaveTenant
    {
        public int TenantId { get; set; }
        [Required]
        [StringLength(50)]
        public string SecureName { get; set; }
        [Required]
        [StringLength(100)]
        public string Warehouse { get; set; }
        public bool IsMigrated { get; set; }
    }
}
