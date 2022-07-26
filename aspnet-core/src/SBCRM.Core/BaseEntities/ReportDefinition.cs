using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("ReportDefinitions", Schema = "web")]
    [Index(nameof(TenantId), Name = "ReportDefinitions_TenantId_index")]
    public class ReportDefinition : FullAuditedEntity<long>, IMustHaveTenant
    {
        public int TenantId { get; set; }
        public long? LegacyId { get; set; }
        [Column("ReportGUID")]
        public Guid ReportGuid { get; set; }
        [Column("ReportGroupGUID")]
        public Guid ReportGroupGuid { get; set; }
        [StringLength(80)]
        public string ReportName { get; set; }
        [StringLength(160)]
        public string ReportTitle { get; set; }
        [StringLength(8000)]
        public string ReportDescription { get; set; }
        [StringLength(2000)]
        public string ReportPath { get; set; }
        [Column(TypeName = "text")]
        public string ReportSchema { get; set; }
        public bool BaseReport { get; set; }
        [StringLength(30)]
        public string ReportCreatedBy { get; set; }
        [StringLength(50)]
        public string ReportLastUpdatedBy { get; set; }
        public int? ReportVersion { get; set; }
        public bool IsMigrated { get; set; }
    }
}
