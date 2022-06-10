using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("WOLock", Schema = "web")]
    [Index(nameof(TenantId), Name = "WOLock_TenantId_index")]
    public class Wolock : FullAuditedEntity<long>, IMustHaveTenant
    {
        public int TenantId { get; set; }
        [Column("WONo")]
        public int? Wono { get; set; }
        [StringLength(50)]
        public string EmployeeNo { get; set; }
        [StringLength(50)]
        public string SecureName { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LockDate { get; set; }
        public bool IsMigrated { get; set; }
    }
}
