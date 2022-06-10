using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("Depreciation", Schema = "web")]
    [Index(nameof(TenantId), Name = "Depreciation_TenantId_index")]
    [Index(nameof(SerialNo), nameof(TenantId), Name = "UC_Depreciation", IsUnique = true)]
    public class Depreciation : FullAuditedEntity<long>, IMustHaveTenant
    {
        [Required]
        [StringLength(100)]
        public string SerialNo { get; set; }
        [StringLength(50)]
        public string DepreciationGroup { get; set; }
        [StringLength(50)]
        public string Method { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? StartingValue { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? ResidualValue { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? NetBookValue { get; set; }
        public short? TotalMonths { get; set; }
        public short? RemainingMonths { get; set; }
        [StringLength(50)]
        public string CreditAccount { get; set; }
        [StringLength(50)]
        public string DebitAccount { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? Created { get; set; }
        [StringLength(50)]
        public string CreatedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? Changed { get; set; }
        [StringLength(50)]
        public string ChangedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LastUpdated { get; set; }
        [StringLength(50)]
        public string LastUpdatedBy { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? LastUpdatedAmount { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? ManualAmount { get; set; }
        public bool Inactive { get; set; }
        public int TenantId { get; set; }
        public bool IsMigrated { get; set; }
    }
}
