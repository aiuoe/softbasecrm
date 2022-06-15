using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("eRentEquipmentDetail", Schema = "web")]
    [Index(nameof(TenantId), Name = "eRentEquipmentDetail_TenantId_index")]
    public class ERentEquipmentDetail : FullAuditedEntity<long>, IMustHaveTenant
    {
        [Column("LegacyID")]
        public int? LegacyId { get; set; }
        public long? DocumentNumber { get; set; }
        [Required]
        [StringLength(50)]
        public string ModelGroup { get; set; }
        [Required]
        [StringLength(50)]
        public string EquipmentGroup { get; set; }
        public int? Quantity { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? DailyRate { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? WeeklyRate { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? MonthlyRate { get; set; }
        [StringLength(50)]
        public string Transportation { get; set; }
        public int TenantId { get; set; }
        public bool IsMigrated { get; set; }
    }
}
