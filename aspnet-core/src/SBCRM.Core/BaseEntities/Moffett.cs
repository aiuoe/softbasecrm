using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("Moffett", Schema = "web")]
    [Index(nameof(TenantId), Name = "Moffett_TenantId_index")]
    [Index(nameof(PartNo), nameof(TenantId), Name = "UC_Moffett", IsUnique = true)]
    public class Moffett : FullAuditedEntity<long>, IMustHaveTenant
    {
        public int TenantId { get; set; }
        [Required]
        [StringLength(50)]
        public string PartNo { get; set; }
        [StringLength(100)]
        public string Description { get; set; }
        [StringLength(100)]
        public string ReplacedBy { get; set; }
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
        [Column(TypeName = "datetime")]
        public DateTime? Created { get; set; }
        [StringLength(100)]
        public string CreatedBy { get; set; }
        [StringLength(100)]
        public string LastUpdateBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LastUpdate { get; set; }
        public bool IsMigrated { get; set; }
    }
}
