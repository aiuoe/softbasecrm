using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("LaborRate", Schema = "web")]
    [Index(nameof(TenantId), Name = "LaborRate_TenantId_index")]
    [Index(nameof(Code), nameof(TenantId), Name = "UC_LaborRate", IsUnique = true)]
    public class LaborRate : FullAuditedEntity<long>, IMustHaveTenant
    {
        public int TenantId { get; set; }
        [Required]
        [StringLength(50)]
        public string Code { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? Rate { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? OverTime { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? Premium { get; set; }
        [StringLength(50)]
        public string Description { get; set; }
        [StringLength(50)]
        public string AddedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DateAdded { get; set; }
        [StringLength(50)]
        public string ChangedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DateChanged { get; set; }
        public bool IsMigrated { get; set; }
    }
}
