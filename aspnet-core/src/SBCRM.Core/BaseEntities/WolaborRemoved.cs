using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("WOLaborRemoved", Schema = "web")]
    [Index(nameof(TenantId), Name = "WOLaborRemoved_TenantId_index")]
    public class WolaborRemoved : FullAuditedEntity<long>, IMustHaveTenant
    {
        public int TenantId { get; set; }
        [Column("WONo")]
        public int? Wono { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? EntryDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? RemovedDate { get; set; }
        [StringLength(100)]
        public string AddedBy { get; set; }
        [StringLength(100)]
        public string RemovedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DateOfLabor { get; set; }
        public int? MechanicNo { get; set; }
        [StringLength(100)]
        public string MechanicName { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? Hours { get; set; }
        [StringLength(50)]
        public string LaborRateType { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? CostRate { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? SellRate { get; set; }
        public int? LegacyId { get; set; }
        public bool IsMigrated { get; set; }
    }
}
