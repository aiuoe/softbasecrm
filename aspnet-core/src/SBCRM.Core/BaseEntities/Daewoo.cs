using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("Daewoo", Schema = "web")]
    [Index(nameof(TenantId), Name = "Daewoo_TenantId_index")]
    [Index(nameof(PartNo), nameof(TenantId), Name = "UC_Daewoo", IsUnique = true)]
    public class Daewoo : FullAuditedEntity<long>, IMustHaveTenant
    {
        [StringLength(1)]
        public string Flag { get; set; }
        [Required]
        [StringLength(50)]
        public string PartNo { get; set; }
        [StringLength(40)]
        public string Description { get; set; }
        public int? IncrementalSellQty { get; set; }
        [StringLength(50)]
        public string SellUnitOfMeasure { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? DealerNet { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? RetailPrice { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? EffectiveDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LastUpdate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? Created { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? PreCurrencyDealerNet { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? PreCurrencyRetailPrice { get; set; }
        [StringLength(50)]
        public string CurrencyType { get; set; }
        public int TenantId { get; set; }
        public bool IsMigrated { get; set; }
    }
}
