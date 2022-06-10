using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("eParts", Schema = "web")]
    [Index(nameof(TenantId), Name = "eParts_TenantId_index")]
    [Index(nameof(PartNo), nameof(TenantId), Name = "UC_eParts", IsUnique = true)]
    public partial class EPart : FullAuditedEntity<long>, IMustHaveTenant
    {
        [Required]
        [StringLength(50)]
        public string PartNo { get; set; }
        [Column("OEMLine")]
        [StringLength(50)]
        public string Oemline { get; set; }
        [StringLength(50)]
        public string UniqueKey { get; set; }
        [StringLength(50)]
        public string MasterPartNo { get; set; }
        [StringLength(100)]
        public string Description { get; set; }
        [Column("OEMList", TypeName = "decimal(19, 4)")]
        public decimal? Oemlist { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? Cost { get; set; }
        [StringLength(50)]
        public string UnitOfMeasure { get; set; }
        [Column("PreCurrencyOEMList", TypeName = "decimal(19, 4)")]
        public decimal? PreCurrencyOemlist { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? PreCurrencyCost { get; set; }
        [StringLength(50)]
        public string CurrencyType { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? CatalogPriority { get; set; }
        [StringLength(50)]
        public string CategoryCode { get; set; }
        public int? RecordSerialNo { get; set; }
        [StringLength(50)]
        public string CommodityClass { get; set; }
        [StringLength(50)]
        public string CurrencyCode { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? Created { get; set; }
        [StringLength(100)]
        public string CreatedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LastUpdate { get; set; }
        [StringLength(100)]
        public string LastUpdateBy { get; set; }
        public int TenantId { get; set; }
        public bool IsMigrated { get; set; }
    }
}
