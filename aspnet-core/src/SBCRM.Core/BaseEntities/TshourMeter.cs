using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("TSHourMeter", Schema = "web")]
    [Index(nameof(TenantId), Name = "TSHourMeter_TenantId_index")]
    public class TshourMeter : FullAuditedEntity<long>, IMustHaveTenant
    {
        public int TenantId { get; set; }
        public int? LegacyId { get; set; }
        [Column("hardware_id")]
        [StringLength(50)]
        public string HardwareId { get; set; }
        [Column("serial_number")]
        [StringLength(50)]
        public string SerialNumber { get; set; }
        [Column("gmt_datetime", TypeName = "datetime")]
        public DateTime? GmtDatetime { get; set; }
        [Column("hour_meter", TypeName = "decimal(19, 4)")]
        public decimal? HourMeter { get; set; }
        public bool IsMigrated { get; set; }
    }
}
