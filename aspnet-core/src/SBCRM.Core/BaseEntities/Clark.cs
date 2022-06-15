using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("Clark", Schema = "web")]
    [Index(nameof(TenantId), Name = "Clark_TenantId_index")]
    [Index(nameof(PartNo), nameof(TenantId), Name = "UC_Clark", IsUnique = true)]
    public class Clark : FullAuditedEntity<long>, IMustHaveTenant
    {
        [Required]
        [StringLength(50)]
        public string PartNo { get; set; }
        [StringLength(50)]
        public string Description { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? Weight { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? CustomerPrice { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? NetPrice { get; set; }
        [Column("CHCode")]
        [StringLength(50)]
        public string Chcode { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LastUpdate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? Created { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? PreCurrencyNetPrice { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? PreCurrencyCustomerPrice { get; set; }
        [StringLength(50)]
        public string CurrencyType { get; set; }
        public int TenantId { get; set; }
        public bool IsMigrated { get; set; }
    }
}
