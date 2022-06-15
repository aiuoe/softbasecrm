using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("PartsDemand", Schema = "web")]
    [Index(nameof(TenantId), Name = "PartsDemand_TenantId_index")]
    [Index(nameof(PartNo), nameof(Warehouse), nameof(TenantId), Name = "UC_PartsDemand", IsUnique = true)]
    public class PartsDemand : FullAuditedEntity<long>, IMustHaveTenant
    {
        public int TenantId { get; set; }
        [Required]
        [StringLength(50)]
        public string PartNo { get; set; }
        [Required]
        [StringLength(50)]
        public string Warehouse { get; set; }
        public int? Demand1 { get; set; }
        public int? Demand2 { get; set; }
        public int? Demand3 { get; set; }
        public int? Demand4 { get; set; }
        public int? Demand5 { get; set; }
        public int? Demand6 { get; set; }
        public int? Demand7 { get; set; }
        public int? Demand8 { get; set; }
        public int? Demand9 { get; set; }
        public int? Demand10 { get; set; }
        public int? Demand11 { get; set; }
        public int? Demand12 { get; set; }
        public int? DemandLast1 { get; set; }
        public int? DemandLast2 { get; set; }
        public int? DemandLast3 { get; set; }
        public int? DemandLast4 { get; set; }
        public int? DemandLast5 { get; set; }
        public int? DemandLast6 { get; set; }
        public int? DemandLast7 { get; set; }
        public int? DemandLast8 { get; set; }
        public int? DemandLast9 { get; set; }
        public int? DemandLast10 { get; set; }
        public int? DemandLast11 { get; set; }
        public int? DemandLast12 { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LastRoll { get; set; }
        public bool IsMigrated { get; set; }
    }
}
