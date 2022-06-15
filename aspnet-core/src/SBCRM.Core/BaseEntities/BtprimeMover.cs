using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("BTPrimeMover", Schema = "web")]
    [Index(nameof(TenantId), Name = "BTPrimeMover_TenantId_index")]
    [Index(nameof(PartNo), nameof(TenantId), Name = "UC_BTPrimeMover", IsUnique = true)]
    public partial class BtprimeMover : FullAuditedEntity<long>, IMustHaveTenant
    {
        [Required]
        [StringLength(50)]
        public string PartNo { get; set; }
        [StringLength(255)]
        public string Description { get; set; }
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
        [Column(TypeName = "datetime")]
        public DateTime? LastUpdate { get; set; }
        public int TenantId { get; set; }
        public bool IsMigrated { get; set; }
    }
}
