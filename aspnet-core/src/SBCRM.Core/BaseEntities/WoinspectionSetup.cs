using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("WOInspectionSetup", Schema = "web")]
    [Index(nameof(TenantId), Name = "WOInspectionSetup_TenantId_index")]
    public class WoinspectionSetup : FullAuditedEntity<long>, IMustHaveTenant
    {
        public int TenantId { get; set; }
        [StringLength(50)]
        public string InspectionName { get; set; }
        public int? Page { get; set; }
        [StringLength(50)]
        public string Question01 { get; set; }
        [StringLength(50)]
        public string Question02 { get; set; }
        [StringLength(50)]
        public string Question03 { get; set; }
        [StringLength(50)]
        public string Question04 { get; set; }
        [StringLength(50)]
        public string Question05 { get; set; }
        [StringLength(50)]
        public string Question06 { get; set; }
        [StringLength(50)]
        public string Question07 { get; set; }
        [StringLength(50)]
        public string Question08 { get; set; }
        [StringLength(50)]
        public string Question09 { get; set; }
        [StringLength(50)]
        public string Question10 { get; set; }
        [StringLength(50)]
        public string Question11 { get; set; }
        [StringLength(50)]
        public string Question12 { get; set; }
        [StringLength(50)]
        public string Question13 { get; set; }
        [StringLength(50)]
        public string Question14 { get; set; }
        [StringLength(50)]
        public string Question15 { get; set; }
        [StringLength(50)]
        public string Question16 { get; set; }
        [StringLength(50)]
        public string Question17 { get; set; }
        [StringLength(50)]
        public string Question18 { get; set; }
        [StringLength(50)]
        public string Question19 { get; set; }
        [StringLength(50)]
        public string Question20 { get; set; }
        [StringLength(50)]
        public string Question21 { get; set; }
        [StringLength(50)]
        public string Question22 { get; set; }
        [StringLength(50)]
        public string Question23 { get; set; }
        [StringLength(50)]
        public string Question24 { get; set; }
        [StringLength(50)]
        public string Question25 { get; set; }
        [StringLength(50)]
        public string Question26 { get; set; }
        [StringLength(50)]
        public string Question27 { get; set; }
        [StringLength(50)]
        public string Question28 { get; set; }
        [StringLength(50)]
        public string Question29 { get; set; }
        [StringLength(50)]
        public string Question30 { get; set; }
        [StringLength(50)]
        public string Question31 { get; set; }
        [StringLength(50)]
        public string Question32 { get; set; }
        public bool? Indent01 { get; set; }
        public bool? Indent02 { get; set; }
        public bool? Indent03 { get; set; }
        public bool? Indent04 { get; set; }
        public bool? Indent05 { get; set; }
        public bool? Indent06 { get; set; }
        public bool? Indent07 { get; set; }
        public bool? Indent08 { get; set; }
        public bool? Indent09 { get; set; }
        public bool? Indent10 { get; set; }
        public bool? Indent11 { get; set; }
        public bool? Indent12 { get; set; }
        public bool? Indent13 { get; set; }
        public bool? Indent14 { get; set; }
        public bool? Indent15 { get; set; }
        public bool? Indent16 { get; set; }
        public bool? Indent17 { get; set; }
        public bool? Indent18 { get; set; }
        public bool? Indent19 { get; set; }
        public bool? Indent20 { get; set; }
        public bool? Indent21 { get; set; }
        public bool? Indent22 { get; set; }
        public bool? Indent23 { get; set; }
        public bool? Indent24 { get; set; }
        public bool? Indent25 { get; set; }
        public bool? Indent26 { get; set; }
        public bool? Indent27 { get; set; }
        public bool? Indent28 { get; set; }
        public bool? Indent29 { get; set; }
        public bool? Indent30 { get; set; }
        public bool? Indent31 { get; set; }
        public bool? Indent32 { get; set; }
        public int? LegacyId { get; set; }
        [StringLength(50)]
        public string AddedBy { get; set; }
        [StringLength(50)]
        public string ChangedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DateAdded { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DateChanged { get; set; }
        public bool IsMigrated { get; set; }
    }
}
