using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("Barrett", Schema = "web")]
    [Index(nameof(TenantId), Name = "Barrett_TenantId_index")]
    [Index(nameof(PartNo), nameof(TenantId), Name = "UC_Barrett", IsUnique = true)]
    public class Barrett : FullAuditedEntity<long>, IMustHaveTenant
    {
        [Required]
        [StringLength(50)]
        public string PartNo { get; set; }
        [StringLength(50)]
        public string Description { get; set; }
        [StringLength(50)]
        public string UnitsOfMeasure { get; set; }
        [StringLength(50)]
        public string PriceCode { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? List { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? Cost { get; set; }
        public int? QtyBreak1 { get; set; }
        public int? QtyBreak2 { get; set; }
        public int? QtyBreak3 { get; set; }
        public int? QtyBreak4 { get; set; }
        public int? QtyBreak5 { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? PriceBreak1 { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? PriceBreak2 { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? PriceBreak3 { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? PriceBreak4 { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? PriceBreak5 { get; set; }
        [StringLength(50)]
        public string PartNoReplaces { get; set; }
        [StringLength(50)]
        public string PartNoReplacedBy { get; set; }
        [StringLength(50)]
        public string ReturnFlag { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LastUpdate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? Created { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? PreCurrencyCost { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? PreCurrencyList { get; set; }
        [StringLength(50)]
        public string CurrencyType { get; set; }
        public int TenantId { get; set; }
        public bool IsMigrated { get; set; }
    }
}
