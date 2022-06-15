using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("JohnDeere", Schema = "web")]
    [Index(nameof(TenantId), Name = "JohnDeere_TenantId_index")]
    [Index(nameof(PartNo), nameof(TenantId), Name = "UC_JohnDeere", IsUnique = true)]
    public class JohnDeere : FullAuditedEntity<long>, IMustHaveTenant
    {
        public int TenantId { get; set; }
        [Required]
        [StringLength(50)]
        public string PartNo { get; set; }
        public short? CorePart { get; set; }
        [StringLength(100)]
        public string Description { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? PackageQty { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? Cost { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? List { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? ExchangeCost { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? ExchangeList { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? ReturnCreditCost { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? ReturnCreditList { get; set; }
        public short? Returnable { get; set; }
        [StringLength(50)]
        public string PricedPerEachOrPer100 { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? Weight { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? PriceEffectiveDate { get; set; }
        public short? StockOrderDiscount { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? PreCurrencyCost { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? PreCurrencyList { get; set; }
        [StringLength(50)]
        public string CurrencyType { get; set; }
        [StringLength(100)]
        public string CreatedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? Created { get; set; }
        [StringLength(100)]
        public string LastUpdateBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LastUpdate { get; set; }
        public bool IsMigrated { get; set; }
    }
}
