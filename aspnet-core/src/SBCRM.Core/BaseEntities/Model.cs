using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("Model", Schema = "web")]
    [Index(nameof(TenantId), Name = "Model_TenantId_index")]
    [Index(nameof(Model1), nameof(TenantId), Name = "UC_Model", IsUnique = true)]
    public class Model : FullAuditedEntity<long>, IMustHaveTenant
    {
        public int TenantId { get; set; }
        [Required]
        [Column("Model")]
        [StringLength(50)]
        public string Model1 { get; set; }
        [StringLength(50)]
        public string Description { get; set; }
        [StringLength(50)]
        public string ModelGroup { get; set; }
        public bool IsMigrated { get; set; }
    }
}
