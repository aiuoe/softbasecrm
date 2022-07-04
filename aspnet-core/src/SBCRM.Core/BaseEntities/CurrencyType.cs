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
    [Index(nameof(CurrencyTypeName), nameof(TenantId), Name = "UC_CurrencyTypes", IsUnique = true)]
    public class CurrencyType : FullAuditedEntity<long>, IMustHaveTenant
    {
        [Required]
        [Column("CurrencyType")]
        [StringLength(50)]
        public string CurrencyTypeName { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? ConversionRate { get; set; }
        [StringLength(50)]
        public string ExchangeAccount { get; set; }
        public DateTime Created { get; set; }
        [StringLength(100)]
        public string CreatedBy { get; set; }
        public DateTime Updated { get; set; }
        [StringLength(100)]
        public string UpdatedBy { get; set; }
        [StringLength(50)]
        public string WholeVerbage { get; set; }
        [StringLength(50)]
        public string DecimalVerbage { get; set; }
        [StringLength(int.MaxValue)]
        public string CurrencyMessage { get; set; }
        public int TenantId { get; set; }
        public bool IsMigrated { get; set; }
    }
}
