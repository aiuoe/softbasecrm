using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("Nissan", Schema = "web")]
    [Index(nameof(TenantId), Name = "Nissan_TenantId_index")]
    [Index(nameof(PartNo), nameof(TenantId), Name = "UC_Nissan", IsUnique = true)]
    public class Nissan : FullAuditedEntity<long>, IMustHaveTenant
    {
        public int TenantId { get; set; }
        [Required]
        [StringLength(50)]
        public string PartNo { get; set; }
        [StringLength(50)]
        public string Description { get; set; }
        [StringLength(50)]
        public string UnitOfMeasure { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? List { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? Cost { get; set; }
        [StringLength(50)]
        public string PriceCode { get; set; }
        [StringLength(50)]
        public string ReplacesPartNo { get; set; }
        [StringLength(50)]
        public string ReplacedByPartNo { get; set; }
        public short? ReturnableFlag { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? PreCurrencyCost { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? PreCurrencyList { get; set; }
        [StringLength(50)]
        public string CurrencyType { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LastUpdate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? Created { get; set; }
        public bool IsMigrated { get; set; }
    }
}
