using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("ReportSecurity", Schema = "web")]
    [Index(nameof(TenantId), Name = "ReportSecurity_TenantId_index")]
    public class ReportSecurity : FullAuditedEntity<long>, IMustHaveTenant
    {
        public int TenantId { get; set; }
        public long? LegacyId { get; set; }
        [Required]
        [StringLength(100)]
        public string SecureName { get; set; }
        [Column("OrigReportGroupGUID")]
        public Guid OrigReportGroupGuid { get; set; }
        [Column("ReportGroupGUID")]
        public Guid ReportGroupGuid { get; set; }
        [Column("ReportGUID")]
        public Guid ReportGuid { get; set; }
        public bool IsMigrated { get; set; }
    }
}
