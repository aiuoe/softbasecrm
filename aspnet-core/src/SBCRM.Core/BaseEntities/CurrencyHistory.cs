using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("CurrencyHistory", Schema = "web")]
    [Index(nameof(TenantId), Name = "CurrencyHistory_TenantId_index")]
    [Index(nameof(CurrencyType), nameof(CurrencyDate), nameof(TenantId), Name = "UC_CurrencyHistory", IsUnique = true)]
    public class CurrencyHistory : FullAuditedEntity<long>, IMustHaveTenant
    {
        [Required]
        [StringLength(50)]
        public string CurrencyType { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CurrencyDate { get; set; }
        [StringLength(100)]
        public string AddedBy { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? ConversionRate { get; set; }
        [StringLength(100)]
        public string ChangedBy { get; set; }
        public int TenantId { get; set; }
        public bool IsMigrated { get; set; }
    }
}
