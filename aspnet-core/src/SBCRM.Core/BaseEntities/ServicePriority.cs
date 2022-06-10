using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("ServicePriorities", Schema = "web")]
    [Index(nameof(TenantId), Name = "ServicePriorities_TenantId_index")]
    [Index(nameof(ServicePriority1), nameof(TenantId), Name = "UC_ServicePriorities", IsUnique = true)]
    public class ServicePriority : FullAuditedEntity<long>, IMustHaveTenant
    {
        public int TenantId { get; set; }
        [Required]
        [Column("ServicePriority")]
        [StringLength(50)]
        public string ServicePriority1 { get; set; }
        [StringLength(100)]
        public string ServicePriorityDescription { get; set; }
        public bool IsMigrated { get; set; }
    }
}
