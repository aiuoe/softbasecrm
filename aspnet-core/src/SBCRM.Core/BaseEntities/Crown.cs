using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("Crown", Schema = "web")]
    [Index(nameof(TenantId), Name = "Crown_TenantId_index")]
    [Index(nameof(PartNo), nameof(SpecialQty), nameof(TenantId), Name = "UC_Crown", IsUnique = true)]
    public class Crown : FullAuditedEntity<long>, IMustHaveTenant
    {
        public int TenantId { get; set; }
        [Required]
        [StringLength(50)]
        public string PartNo { get; set; }
        [StringLength(50)]
        public string Description { get; set; }
        public bool SpecialQty { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? List { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? Cost { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? NationalList { get; set; }
        [StringLength(50)]
        public string PriceKey { get; set; }
        [StringLength(50)]
        public string ReplacedbyPartNo { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? Weight { get; set; }
        [StringLength(50)]
        public string LevelCode { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LastUpdated { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? Created { get; set; }
        [StringLength(50)]
        public string QtyBreakCode { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? BestQtyList { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? WalMartList { get; set; }
        [StringLength(50)]
        public string NewChanged { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? PreCurrencyCost { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? PreCurrencyList { get; set; }
        [StringLength(50)]
        public string CurrencyType { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? TargetList { get; set; }
        public bool IsMigrated { get; set; }
    }
}
