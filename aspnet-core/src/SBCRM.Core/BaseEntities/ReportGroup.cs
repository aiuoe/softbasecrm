using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("ReportGroups", Schema = "web")]
    [Index(nameof(TenantId), Name = "ReportGroups_TenantId_index")]
    public class ReportGroup : FullAuditedEntity<long>, IMustHaveTenant
    {
        public int TenantId { get; set; }
        public int? LegacyId { get; set; }
        [Column("ReportGroupGUID")]
        public Guid? ReportGroupGuid { get; set; }
        [StringLength(120)]
        public string ReportGroupName { get; set; }
        [Required]
        public bool? UserDefinedGroup { get; set; }
        [StringLength(100)]
        public string SecureName { get; set; }
        public bool IsMigrated { get; set; }
    }
}
