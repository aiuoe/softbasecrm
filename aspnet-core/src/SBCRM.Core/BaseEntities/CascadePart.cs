using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("CascadeParts", Schema = "web")]
    [Index(nameof(TenantId), Name = "CascadeParts_TenantId_index")]
    [Index(nameof(PartNo), nameof(TenantId), Name = "UC_CascadeParts", IsUnique = true)]
    public class CascadePart : FullAuditedEntity<long>, IMustHaveTenant
    {
        [Required]
        [StringLength(100)]
        public string PartNo { get; set; }
        [StringLength(100)]
        public string Description { get; set; }
        [StringLength(100)]
        public string UsePartNo { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? Cost { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? List { get; set; }
        [StringLength(50)]
        public string PartType { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? PreCurrencyCost { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? PreCurrencyList { get; set; }
        [StringLength(50)]
        public string CurrencyType { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? Created { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LastUpdate { get; set; }
        public int TenantId { get; set; }
        public bool IsMigrated { get; set; }
    }
}
