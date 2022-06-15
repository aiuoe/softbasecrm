using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("PartsPriceFiles", Schema = "web")]
    [Index(nameof(TenantId), Name = "PartsPriceFiles_TenantId_index")]
    [Index(nameof(PartNo), nameof(Supplier), nameof(TenantId), Name = "UC_PartsPriceFiles", IsUnique = true)]
    public class PartsPriceFile : FullAuditedEntity<long>, IMustHaveTenant
    {
        public int TenantId { get; set; }
        [Required]
        [StringLength(50)]
        public string Supplier { get; set; }
        [Required]
        [StringLength(50)]
        public string PartNo { get; set; }
        [Column("PartNoWODash")]
        [StringLength(50)]
        public string PartNoWodash { get; set; }
        [StringLength(50)]
        public string PartNoOriginal { get; set; }
        [Column("PartNoWOPrefix")]
        [StringLength(50)]
        public string PartNoWoprefix { get; set; }
        [StringLength(100)]
        public string Description { get; set; }
        [StringLength(100)]
        public string DescriptionFrench { get; set; }
        [Column("MFGCode")]
        [StringLength(50)]
        public string Mfgcode { get; set; }
        [StringLength(50)]
        public string ReplacedBy { get; set; }
        [StringLength(50)]
        public string ReplacesPartNo { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? Cost { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? List { get; set; }
        [Column("ECost", TypeName = "decimal(19, 4)")]
        public decimal? Ecost { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? WholesalePrice { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? PreCurrencyCost { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? PreCurrencyList { get; set; }
        [Column("PreCurrencyECost", TypeName = "decimal(19, 4)")]
        public decimal? PreCurrencyEcost { get; set; }
        [StringLength(50)]
        public string CurrencyType { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? NationalList { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? WalMartList { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? TargetList { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? PreCurrencyNationalList { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? PreCurrencyWalMartList { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? PreCurrencyTargetList { get; set; }
        [Column("QUP")]
        [StringLength(50)]
        public string Qup { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? EffectiveDate { get; set; }
        [StringLength(50)]
        public string DiscountCode { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? Discount { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? Markup { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? Weight { get; set; }
        [StringLength(50)]
        public string UnitOfMeasure { get; set; }
        public int? PackageQty { get; set; }
        public int? BlockQty { get; set; }
        [StringLength(50)]
        public string ObsoleteCode { get; set; }
        [StringLength(50)]
        public string ReturnFlag { get; set; }
        public int? NonReturn { get; set; }
        public int? ReturnCode { get; set; }
        [StringLength(50)]
        public string ReturnCodeDescription { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ProductionStart { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ProductionEnd { get; set; }
        [StringLength(256)]
        public string Comments { get; set; }
        [StringLength(100)]
        public string AddedBy { get; set; }
        [StringLength(100)]
        public string ChangedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DateAdded { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DateChanged { get; set; }
        [Column("LegacyID")]
        public int? LegacyId { get; set; }
        public bool IsMigrated { get; set; }
    }
}
