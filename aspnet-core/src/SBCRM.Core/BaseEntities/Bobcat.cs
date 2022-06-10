using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("Bobcat", Schema = "web")]
    [Index(nameof(TenantId), Name = "Bobcat_TenantId_index")]
    [Index(nameof(PartNo), nameof(TenantId), Name = "UC_Bobcat", IsUnique = true)]
    public class Bobcat : FullAuditedEntity<long>, IMustHaveTenant
    {
        [Required]
        [StringLength(100)]
        public string PartNo { get; set; }
        [StringLength(100)]
        public string Description { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? Weight { get; set; }
        public short? Markup { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? Cost { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? List { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? PreCurrencyCost { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? PreCurrencyList { get; set; }
        [StringLength(50)]
        public string CurrencyType { get; set; }
        [StringLength(50)]
        public string NonReturn { get; set; }
        [StringLength(50)]
        public string IncDec { get; set; }
        public int? SellMultiple { get; set; }
        [StringLength(50)]
        public string QtyBreak { get; set; }
        [Column("HCPCode")]
        [StringLength(50)]
        public string Hcpcode { get; set; }
        [StringLength(50)]
        public string OwnershipCode { get; set; }
        [StringLength(50)]
        public string ShipDirectOnly { get; set; }
        [StringLength(50)]
        public string InactivePart { get; set; }
        [StringLength(200)]
        public string Notes { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? Created { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LastUpdate { get; set; }
        public int TenantId { get; set; }
        public bool IsMigrated { get; set; }
    }
}
