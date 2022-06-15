using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("Kubota", Schema = "web")]
    [Index(nameof(TenantId), Name = "Kubota_TenantId_index")]
    [Index(nameof(PartNo), nameof(TenantId), Name = "UC_Kubota", IsUnique = true)]
    public class Kubotum : FullAuditedEntity<long>, IMustHaveTenant
    {
        public int TenantId { get; set; }
        [Required]
        [StringLength(50)]
        public string PartNo { get; set; }
        [StringLength(50)]
        public string Description { get; set; }
        [StringLength(50)]
        public string ProductClass { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? List { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? Cost { get; set; }
        [StringLength(50)]
        public string PartStatus { get; set; }
        [StringLength(50)]
        public string MultiPack { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LastUpdated { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? Created { get; set; }
        public bool IsMigrated { get; set; }
    }
}
