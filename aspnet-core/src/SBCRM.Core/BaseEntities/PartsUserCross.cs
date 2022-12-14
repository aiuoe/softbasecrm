using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("PartsUserCross", Schema = "web")]
    [Index(nameof(TenantId), Name = "PartsUserCross_TenantId_index")]
    [Index(nameof(PartNo), nameof(MasterNo), nameof(TenantId), Name = "UC_PartsUserCross", IsUnique = true)]
    public class PartsUserCross : FullAuditedEntity<long>, IMustHaveTenant
    {
        public int TenantId { get; set; }
        [Required]
        [StringLength(100)]
        public string PartNo { get; set; }
        [Required]
        [StringLength(100)]
        public string MasterNo { get; set; }
        [StringLength(100)]
        public string Description { get; set; }
        [StringLength(100)]
        public string CreatedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? Created { get; set; }
        public bool IsMigrated { get; set; }
    }
}
