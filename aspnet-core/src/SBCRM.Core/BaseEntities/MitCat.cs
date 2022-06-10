using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("MitCat", Schema = "web")]
    [Index(nameof(TenantId), Name = "MitCat_TenantId_index")]
    [Index(nameof(PartNo), nameof(TenantId), Name = "UC_MitCat", IsUnique = true)]
    public class MitCat : FullAuditedEntity<long>, IMustHaveTenant
    {
        public int TenantId { get; set; }
        [Required]
        [StringLength(50)]
        public string PartNo { get; set; }
        [Column("ECostCode")]
        [StringLength(50)]
        public string EcostCode { get; set; }
        [StringLength(50)]
        public string CurrencyType { get; set; }
        [StringLength(50)]
        public string Description { get; set; }
        [StringLength(50)]
        public string NonReturnable { get; set; }
        [StringLength(50)]
        public string ReplacementCode { get; set; }
        public short? MinQty { get; set; }
        [StringLength(50)]
        public string HazMatCode { get; set; }
        [StringLength(50)]
        public string UnitOfMeasure { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? NetWeight { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? GrossWeight { get; set; }
        [StringLength(50)]
        public string FreeTrade { get; set; }
        [StringLength(50)]
        public string Rebuilt { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? Cost { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? List { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? PreCurrencyCost { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? PreCurrencyList { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? DealerCoreCharge { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? CustomerCoreCharge { get; set; }
        [StringLength(50)]
        public string CompanyCode { get; set; }
        [StringLength(50)]
        public string VelocityIndicator { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? EffectiveDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? Created { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LastUpdated { get; set; }
        public bool IsMigrated { get; set; }
    }
}
