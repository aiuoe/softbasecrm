using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("AdditionalCharges", Schema = "web")]
    [Index(nameof(TenantId), Name = "AdditionalCharges_TenantId_index")]
    [Index(nameof(Branch), nameof(Dept), nameof(MiscDescription), nameof(TenantId), Name = "UC_AdditionalCharges", IsUnique = true)]
    public class AdditionalCharge : FullAuditedEntity<long>, IMustHaveTenant
    {
        public int TenantId { get; set; }
        public int Branch { get; set; }
        public int Dept { get; set; }
        [Required]
        [StringLength(200)]
        public string MiscDescription { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? MiscPercentage { get; set; }
        [StringLength(50)]
        public string MiscSaleAccount { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? AmountLimit { get; set; }
        public bool? LaborOnly { get; set; }
        public bool? PartsOnly { get; set; }
        public bool? Taxable { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? AmountMin { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? Created { get; set; }
        [StringLength(100)]
        public string CreatedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? Updated { get; set; }
        [StringLength(100)]
        public string UpdatedBy { get; set; }
        public bool IsMigrated { get; set; }
    }
}
