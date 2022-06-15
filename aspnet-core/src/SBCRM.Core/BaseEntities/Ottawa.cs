using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("Ottawa", Schema = "web")]
    [Index(nameof(TenantId), Name = "Ottawa_TenantId_index")]
    [Index(nameof(PartNo), nameof(TenantId), Name = "UC_Ottawa", IsUnique = true)]
    public class Ottawa : FullAuditedEntity<long>, IMustHaveTenant
    {
        public int TenantId { get; set; }
        [Required]
        [StringLength(100)]
        public string PartNo { get; set; }
        [StringLength(100)]
        public string Description { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? Cost { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? PreCurrencyCost { get; set; }
        [StringLength(50)]
        public string CurrencyType { get; set; }
        [StringLength(100)]
        public string CreatedBy { get; set; }
        [StringLength(100)]
        public string UpdatedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? Created { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? Updated { get; set; }
        public bool IsMigrated { get; set; }
    }
}
