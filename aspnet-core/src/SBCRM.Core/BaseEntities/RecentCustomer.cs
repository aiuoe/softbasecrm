using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("RecentCustomer", Schema = "web")]
    [Index(nameof(TenantId), Name = "RecentCustomer_TenantId_index")]
    public class RecentCustomer : FullAuditedEntity<long>, IMustHaveTenant
    {
        public int TenantId { get; set; }
        [StringLength(100)]
        public string SecureName { get; set; }
        [StringLength(50)]
        public string CustomerNo { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? EntryDate { get; set; }
        public int? LegacyId { get; set; }
        public bool IsMigrated { get; set; }
    }
}
