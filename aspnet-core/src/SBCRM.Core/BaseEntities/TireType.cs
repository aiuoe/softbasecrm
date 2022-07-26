using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("TireTypes", Schema = "web")]
    [Index(nameof(TenantId), Name = "TireTypes_TenantId_index")]
    [Index(nameof(TireType1), nameof(TenantId), Name = "UC_TireTypes", IsUnique = true)]
    public class TireType : FullAuditedEntity<long>, IMustHaveTenant
    {
        public int TenantId { get; set; }
        [Required]
        [Column("TireType")]
        [StringLength(50)]
        public string TireType1 { get; set; }
        [StringLength(200)]
        public string Description { get; set; }
        public int? SortOrder { get; set; }
        [StringLength(100)]
        public string AddedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? AddedDate { get; set; }
        public bool IsMigrated { get; set; }
    }
}
