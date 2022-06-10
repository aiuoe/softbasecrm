using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("EventLog", Schema = "web")]
    [Index(nameof(TenantId), Name = "EventLog_TenantId_index")]
    public class EventLog : FullAuditedEntity<long>, IMustHaveTenant
    {
        [Column("LegacyID")]
        public int? LegacyId { get; set; }
        [Required]
        [StringLength(50)]
        public string EventName { get; set; }
        [Required]
        [StringLength(50)]
        public string EventType { get; set; }
        public DateTime EventDate { get; set; }
        [Required]
        [StringLength(50)]
        public string EventUsername { get; set; }
        [Required]
        [Column(TypeName = "text")]
        public string EventData { get; set; }
        public int TenantId { get; set; }
        public bool IsMigrated { get; set; }
    }
}
