using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("CurrencyTypes", Schema = "web")]
    [Index(nameof(TenantId), Name = "CurrencyTypes_TenantId_index")]
    [Index(nameof(CurrencyType1), nameof(TenantId), Name = "UC_CurrencyTypes", IsUnique = true)]
    public class CurrencyType : FullAuditedEntity<long>, IMustHaveTenant
    {
        [Required]
        [Column("CurrencyType")]
        [StringLength(50)]
        public string CurrencyType1 { get; set; }
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
