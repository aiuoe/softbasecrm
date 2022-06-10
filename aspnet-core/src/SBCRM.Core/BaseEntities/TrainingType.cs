using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("TrainingType", Schema = "web")]
    [Index(nameof(TenantId), Name = "TrainingType_TenantId_index")]
    [Index(nameof(TrainingType1), nameof(TenantId), Name = "UC_TrainingType", IsUnique = true)]
    public class TrainingType : FullAuditedEntity<long>, IMustHaveTenant
    {
        public int TenantId { get; set; }
        [Required]
        [Column("TrainingType")]
        [StringLength(50)]
        public string TrainingType1 { get; set; }
        public bool IsMigrated { get; set; }
    }
}
