using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("MobileHourMeter", Schema = "web")]
    [Index(nameof(TenantId), Name = "MobileHourMeter_TenantId_index")]
    public class MobileHourMeter : FullAuditedEntity<long>, IMustHaveTenant
    {
        public int TenantId { get; set; }
        public int? LegacyId { get; set; }
        [Column("WONo")]
        public int? Wono { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? EntryDate { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? HourMeter { get; set; }
        [StringLength(100)]
        public string AddedBy { get; set; }
        public bool IsMigrated { get; set; }
    }
}
