using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("Hamech", Schema = "web")]
    [Index(nameof(TenantId), Name = "Hamech_TenantId_index")]
    [Index(nameof(PartNo), nameof(SpecialQty), nameof(TenantId), Name = "UC_Hamech", IsUnique = true)]
    public class Hamech : FullAuditedEntity<long>, IMustHaveTenant
    {
        public int TenantId { get; set; }
        [Required]
        [StringLength(50)]
        public string PartNo { get; set; }
        [StringLength(100)]
        public string Description { get; set; }
        public short SpecialQty { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? List { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? Cost { get; set; }
        [StringLength(50)]
        public string PriceKey { get; set; }
        [StringLength(50)]
        public string ReplacedbyPartNo { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? Weight { get; set; }
        [StringLength(50)]
        public string LevelCode { get; set; }
        [StringLength(50)]
        public string QtyBreakCode { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? NationalList { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? BestQtyList { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? WalMartList { get; set; }
        [StringLength(50)]
        public string NewChanged { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? TargetList { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? PreCurrencyCost { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? PreCurrencyList { get; set; }
        [StringLength(50)]
        public string CurrencyType { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LastUpdated { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? Created { get; set; }
        public bool IsMigrated { get; set; }
    }
}
