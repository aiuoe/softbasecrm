using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("DispatchPriority", Schema = "web")]
    [Index(nameof(TenantId), Name = "DispatchPriority_TenantId_index")]
    [Index(nameof(Priority), nameof(TenantId), Name = "UC_DispatchPriority", IsUnique = true)]
    public class DispatchPriority : FullAuditedEntity<long>, IMustHaveTenant
    {
        public int Priority { get; set; }
        [StringLength(100)]
        public string Description { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DateAdded { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DateUpdated { get; set; }
        public int TenantId { get; set; }
        public bool IsMigrated { get; set; }
    }
}
