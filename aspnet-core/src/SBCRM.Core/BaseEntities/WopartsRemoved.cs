using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("WOPartsRemoved", Schema = "web")]
    [Index(nameof(TenantId), Name = "WOPartsRemoved_TenantId_index")]
    public class WopartsRemoved : FullAuditedEntity<long>, IMustHaveTenant
    {
        public int TenantId { get; set; }
        [Column("WONo")]
        public int? Wono { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? EntryDate { get; set; }
        [StringLength(50)]
        public string AddedBy { get; set; }
        [StringLength(50)]
        public string RemovedBy { get; set; }
        [StringLength(50)]
        public string PartNo { get; set; }
        [StringLength(50)]
        public string Warehouse { get; set; }
        [StringLength(200)]
        public string Description { get; set; }
        [StringLength(50)]
        public string PartsGroup { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? Qty { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? ShipQty { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? InitQty { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? CostRate { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? SellRate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? RemovedDate { get; set; }
        public int? LegacyId { get; set; }
        public bool IsMigrated { get; set; }
    }
}
