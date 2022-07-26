using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("WOPartsHold", Schema = "web")]
    [Index(nameof(TenantId), Name = "WOPartsHold_TenantId_index")]
    public class WopartsHold : FullAuditedEntity<long>, IMustHaveTenant
    {
        public int TenantId { get; set; }
        public int? LegacyId { get; set; }
        [Column("WONo")]
        public int? Wono { get; set; }
        [Column("QuoteWONo")]
        public int? QuoteWono { get; set; }
        [StringLength(100)]
        public string AddedBy { get; set; }
        [StringLength(50)]
        public string PartNo { get; set; }
        [StringLength(100)]
        public string Warehouse { get; set; }
        [StringLength(200)]
        public string Description { get; set; }
        [StringLength(200)]
        public string FrenchDescription { get; set; }
        [StringLength(100)]
        public string PartNoAlias { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? Qty { get; set; }
        public int? NoDemand { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? SellRate { get; set; }
        [StringLength(100)]
        public string Section { get; set; }
        [StringLength(255)]
        public string Instructions { get; set; }
        public int? NoPrint { get; set; }
        [Column("CustomerPOLineNo")]
        public int? CustomerPolineNo { get; set; }
        [StringLength(50)]
        public string PreferredVendor { get; set; }
        public int? Selected { get; set; }
        public int? Imported { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? EntryDate { get; set; }
        public bool IsMigrated { get; set; }
    }
}
