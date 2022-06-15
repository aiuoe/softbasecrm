using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("InventoryCount", Schema = "web")]
    [Index(nameof(TenantId), Name = "InventoryCount_TenantId_index")]
    [Index(nameof(InventoryId), nameof(PartNo), nameof(Warehouse), nameof(TenantId), Name = "UC_InventoryCount", IsUnique = true)]
    public class InventoryCount : FullAuditedEntity<long>, IMustHaveTenant
    {
        public int TenantId { get; set; }
        [Required]
        [Column("InventoryID")]
        [StringLength(50)]
        public string InventoryId { get; set; }
        [Required]
        [StringLength(50)]
        public string PartNo { get; set; }
        [Required]
        [StringLength(50)]
        public string Warehouse { get; set; }
        [StringLength(50)]
        public string Description { get; set; }
        [StringLength(50)]
        public string BinLocation { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? OnHand { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? Count { get; set; }
        public short? Posted { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DateGenerated { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DatePosted { get; set; }
        public bool IsMigrated { get; set; }
    }
}
