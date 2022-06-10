using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("Training", Schema = "web")]
    [Index(nameof(TenantId), Name = "Training_TenantId_index")]
    [Index(nameof(CustomerNo), nameof(Operator), nameof(TrainingDate), nameof(TenantId), Name = "UC_Training", IsUnique = true)]
    public class Training : FullAuditedEntity<long>, IMustHaveTenant
    {
        public int TenantId { get; set; }
        [Required]
        [StringLength(50)]
        public string CustomerNo { get; set; }
        [Required]
        [StringLength(50)]
        public string Operator { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime TrainingDate { get; set; }
        [StringLength(50)]
        public string TrainingType { get; set; }
        [StringLength(50)]
        public string Location { get; set; }
        [StringLength(50)]
        public string Trainer { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? TrainingExpirationDate { get; set; }
        public bool IsMigrated { get; set; }
    }
}
