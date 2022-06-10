using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("InvHeader", Schema = "web")]
    [Index(nameof(TenantId), Name = "InvHeader_TenantId_index")]
    [Index(nameof(InventoryId), nameof(TenantId), Name = "UC_InvHeader", IsUnique = true)]
    public class InvHeader : FullAuditedEntity<long>, IMustHaveTenant
    {
        public int TenantId { get; set; }
        [Required]
        [Column("InventoryID")]
        [StringLength(50)]
        public string InventoryId { get; set; }
        [StringLength(50)]
        public string Warehouse1 { get; set; }
        [StringLength(50)]
        public string Warehouse2 { get; set; }
        [StringLength(50)]
        public string Warehouse3 { get; set; }
        [StringLength(50)]
        public string Warehouse4 { get; set; }
        [StringLength(50)]
        public string Warehouse5 { get; set; }
        [StringLength(50)]
        public string Warehouse6 { get; set; }
        public bool? ExcludeDelete { get; set; }
        public bool? ExcludeChanged { get; set; }
        public bool? ExcludeNew { get; set; }
        public bool? CycleCount { get; set; }
        [StringLength(50)]
        public string BinFrom { get; set; }
        [StringLength(50)]
        public string BinTo { get; set; }
        [StringLength(100)]
        public string AddedBy { get; set; }
        [StringLength(100)]
        public string RefreshedBy { get; set; }
        public bool? Posted { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? NotCountedSince { get; set; }
        [StringLength(50)]
        public string DemandRating { get; set; }
        public bool? MultipleBinMethod { get; set; }
        [StringLength(50)]
        public string PartsGroup { get; set; }
        [StringLength(50)]
        public string InvCategory { get; set; }
        public short? IncludeNeverCounted { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? AddedDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? RefreshedDate { get; set; }
        public bool IsMigrated { get; set; }
    }
}
