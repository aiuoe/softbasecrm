using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("InvCategory", Schema = "web")]
    [Index(nameof(TenantId), Name = "InvCategory_TenantId_index")]
    public class InvCategory : FullAuditedEntity<long>, IMustHaveTenant
    {
        public int TenantId { get; set; }
        public int? LegacyId { get; set; }
        [StringLength(50)]
        public string Category { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DateAdded { get; set; }
        public bool IsMigrated { get; set; }
    }
}
