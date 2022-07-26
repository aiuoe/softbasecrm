using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("PartsBinHistory", Schema = "web")]
    [Index(nameof(TenantId), Name = "PartsBinHistory_TenantId_index")]
    [Index(nameof(PartNo), nameof(Warehouse), nameof(CreationTime), nameof(TenantId), Name = "UC_PartsBinHistory", IsUnique = true)]
    public class PartsBinHistory : FullAuditedEntity<long>, IMustHaveTenant
    {
        public int TenantId { get; set; }
        [Required]
        [StringLength(50)]
        public string PartNo { get; set; }
        [Required]
        [StringLength(50)]
        public string Warehouse { get; set; }
        [StringLength(50)]
        public string OldBin { get; set; }
        [StringLength(100)]
        public string ChangedBy { get; set; }
        public bool IsMigrated { get; set; }
    }
}
