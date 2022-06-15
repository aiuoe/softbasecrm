using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("AdTrack", Schema = "web")]
    [Index(nameof(TenantId), Name = "AdTrack_TenantId_index")]
    [Index(nameof(AdTitle), nameof(EntryDate), nameof(TenantId), Name = "UC_AdTrack", IsUnique = true)]
    public class AdTrack : FullAuditedEntity<long>, IMustHaveTenant
    {
        [Required]
        [StringLength(50)]
        public string AdTitle { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime EntryDate { get; set; }
        public int TenantId { get; set; }
        public bool IsMigrated { get; set; }
    }
}
