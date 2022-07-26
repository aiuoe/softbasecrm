using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("DispatchSecondary", Schema = "web")]
    [Index(nameof(TenantId), Name = "DispatchSecondary_TenantId_index")]
    public class DispatchSecondary : FullAuditedEntity<long>, IMustHaveTenant
    {
        [Column("WONo")]
        public long? Wono { get; set; }
        [StringLength(100)]
        public string DispatchName { get; set; }
        [StringLength(100)]
        public string AddedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DateAdded { get; set; }
        public int TenantId { get; set; }
        public bool IsMigrated { get; set; }
    }
}
