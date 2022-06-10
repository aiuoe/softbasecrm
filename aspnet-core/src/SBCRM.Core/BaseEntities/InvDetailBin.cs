using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("InvDetailBin", Schema = "web")]
    [Index(nameof(TenantId), Name = "InvDetailBin_TenantId_index")]
    [Index(nameof(InventoryId), nameof(Warehouse), nameof(PartNo), nameof(Bin), nameof(TenantId), Name = "UC_InvDetailBin", IsUnique = true)]
    public class InvDetailBin : FullAuditedEntity<long>, IMustHaveTenant
    {
        public int TenantId { get; set; }
        [Required]
        [Column("InventoryID")]
        [StringLength(50)]
        public string InventoryId { get; set; }
        [Required]
        [StringLength(50)]
        public string Warehouse { get; set; }
        [Required]
        [StringLength(50)]
        public string PartNo { get; set; }
        [Required]
        [StringLength(50)]
        public string Bin { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? OnHand { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? Count { get; set; }
        public short? CountFlag { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CountDateTime { get; set; }
        public short? PostFlag { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? PostDateTime { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CaptureDateTime { get; set; }
        public bool IsMigrated { get; set; }
    }
}
