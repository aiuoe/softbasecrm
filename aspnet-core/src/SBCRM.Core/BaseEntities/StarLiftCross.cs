using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("StarLiftCross", Schema = "web")]
    [Index(nameof(TenantId), Name = "StarLiftCross_TenantId_index")]
    [Index(nameof(Oemcode), nameof(NonToyotaPartNo), nameof(ToyotaPartNo), nameof(TenantId), Name = "UC_StarLiftCross", IsUnique = true)]
    public class StarLiftCross : FullAuditedEntity<long>, IMustHaveTenant
    {
        public int TenantId { get; set; }
        [Required]
        [Column("OEMCode")]
        [StringLength(50)]
        public string Oemcode { get; set; }
        [Required]
        [StringLength(50)]
        public string NonToyotaPartNo { get; set; }
        [StringLength(50)]
        public string Description { get; set; }
        [Required]
        [StringLength(50)]
        public string ToyotaPartNo { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? Cost { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? List { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LastUpdated { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? Created { get; set; }
        public bool IsMigrated { get; set; }
    }
}
