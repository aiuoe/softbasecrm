using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("AdTrackDef", Schema = "web")]
    [Index(nameof(TenantId), Name = "AdTrackDef_TenantId_index")]
    [Index(nameof(AdTitle), nameof(TenantId), Name = "UC_AdTrackDef", IsUnique = true)]
    public class AdTrackDef : FullAuditedEntity<long>, IMustHaveTenant
    {
        [Required]
        [StringLength(50)]
        public string AdTitle { get; set; }
        [StringLength(255)]
        public string Description { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? StartDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? EndDate { get; set; }
        [StringLength(255)]
        public string TargetMarket { get; set; }
        public int? TargetMarketSize { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? Cost { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? EstimatedSales { get; set; }
        public int? EstimatedHits { get; set; }
        public int TenantId { get; set; }
        public bool IsMigrated { get; set; }
    }
}
