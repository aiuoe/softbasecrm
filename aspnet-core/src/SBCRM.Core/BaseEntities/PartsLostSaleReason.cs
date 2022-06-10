using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("PartsLostSaleReason", Schema = "web")]
    [Index(nameof(TenantId), Name = "PartsLostSaleReason_TenantId_index")]
    [Index(nameof(ReasonCode), nameof(TenantId), Name = "UC_PartsLostSaleReason", IsUnique = true)]
    public class PartsLostSaleReason : FullAuditedEntity<long>, IMustHaveTenant
    {
        public int TenantId { get; set; }
        [Required]
        [StringLength(50)]
        public string ReasonCode { get; set; }
        [StringLength(200)]
        public string ReasonDescription { get; set; }
        [StringLength(100)]
        public string AddedBy { get; set; }
        [StringLength(100)]
        public string UpdatedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? AddedDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedDate { get; set; }
        public bool IsMigrated { get; set; }
    }
}
