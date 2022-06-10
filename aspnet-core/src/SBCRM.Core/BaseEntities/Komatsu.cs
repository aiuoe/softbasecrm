using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("Komatsu", Schema = "web")]
    [Index(nameof(TenantId), Name = "Komatsu_TenantId_index")]
    [Index(nameof(PartNo), nameof(TenantId), Name = "UC_Komatsu", IsUnique = true)]
    public class Komatsu : FullAuditedEntity<long>, IMustHaveTenant
    {
        public int TenantId { get; set; }
        [Required]
        [StringLength(50)]
        public string PartNo { get; set; }
        [StringLength(50)]
        public string Description { get; set; }
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
        [StringLength(50)]
        public string UsePartNo { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? PreCurrencyNetPrice { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? PreCurrencyCustomerPrice { get; set; }
        [StringLength(50)]
        public string CurrencyType { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? Weight { get; set; }
        [StringLength(50)]
        public string UnitOfMeasure { get; set; }
        [StringLength(50)]
        public string ReturnCode { get; set; }
        [StringLength(50)]
        public string ReturnCodeDesc { get; set; }
        [StringLength(50)]
        public string KomatsuUser { get; set; }
        public bool IsMigrated { get; set; }
    }
}
