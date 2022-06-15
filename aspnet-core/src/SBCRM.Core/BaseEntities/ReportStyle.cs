using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("ReportStyles", Schema = "web")]
    [Index(nameof(TenantId), Name = "ReportStyles_TenantId_index")]
    public class ReportStyle : FullAuditedEntity<long>, IMustHaveTenant
    {
        public int TenantId { get; set; }
        public int? LegacyId { get; set; }
        [StringLength(100)]
        public string Type { get; set; }
        [Column(TypeName = "text")]
        public string Style { get; set; }
        public bool IsMigrated { get; set; }
    }
}
