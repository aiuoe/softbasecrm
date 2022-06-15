using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("Tecumseh", Schema = "web")]
    [Index(nameof(TenantId), Name = "Tecumseh_TenantId_index")]
    [Index(nameof(PartNo), nameof(TenantId), Name = "UC_Tecumseh", IsUnique = true)]
    public class Tecumseh : FullAuditedEntity<long>, IMustHaveTenant
    {
        public int TenantId { get; set; }
        [Required]
        [StringLength(50)]
        public string PartNo { get; set; }
        [StringLength(50)]
        public string Description { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? List { get; set; }
        [StringLength(50)]
        public string DiscountCode { get; set; }
        public short? ChangeCode { get; set; }
        public short? NewPart { get; set; }
        [StringLength(50)]
        public string AvailabilityCode { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LastUpdated { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? Created { get; set; }
        public bool IsMigrated { get; set; }
    }
}
