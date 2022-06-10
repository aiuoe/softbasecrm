using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("MarketingSources", Schema = "web")]
    [Index(nameof(TenantId), Name = "MarketingSources_TenantId_index")]
    public class MarketingSource : FullAuditedEntity<long>, IMustHaveTenant
    {
        public int TenantId { get; set; }
        [Column("MarketingSource")]
        [StringLength(50)]
        public string MarketingSource1 { get; set; }
        [StringLength(50)]
        public string AddedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? AddedDate { get; set; }
        public bool IsMigrated { get; set; }
    }
}
