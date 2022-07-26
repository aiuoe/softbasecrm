using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("RentalRate", Schema = "web")]
    [Index(nameof(TenantId), Name = "RentalRate_TenantId_index")]
    [Index(nameof(RentalRateCode), nameof(TenantId), Name = "UC_RentalRate", IsUnique = true)]
    public class RentalRate : FullAuditedEntity<long>, IMustHaveTenant
    {
        public int TenantId { get; set; }
        [Required]
        [StringLength(50)]
        public string RentalRateCode { get; set; }
        [StringLength(50)]
        public string Description { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? MonthlyRate { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? FourWeekRate { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? WeeklyRate { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? DailyRate { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? QuarterlyRate { get; set; }
        [Column("RentalOTRate", TypeName = "decimal(19, 4)")]
        public decimal? RentalOtrate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? Created { get; set; }
        [StringLength(100)]
        public string CreatedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LastUpdated { get; set; }
        [StringLength(100)]
        public string LastUpdatedBy { get; set; }
        public bool IsMigrated { get; set; }
    }
}
