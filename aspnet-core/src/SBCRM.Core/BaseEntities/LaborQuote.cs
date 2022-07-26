using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("LaborQuote", Schema = "web")]
    [Index(nameof(TenantId), Name = "LaborQuote_TenantId_index")]
    [Index(nameof(Make), nameof(ModelGroup), nameof(RepairGroup), nameof(RepairCode), nameof(TenantId), Name = "UC_LaborQuote", IsUnique = true)]
    public class LaborQuote : FullAuditedEntity<long>, IMustHaveTenant
    {
        public int TenantId { get; set; }
        [Required]
        [StringLength(50)]
        public string Make { get; set; }
        [Required]
        [StringLength(50)]
        public string ModelGroup { get; set; }
        [Required]
        [StringLength(50)]
        public string RepairGroup { get; set; }
        [Required]
        [StringLength(50)]
        public string RepairCode { get; set; }
        [StringLength(50)]
        public string Description { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? MinHours { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? AvgHours { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? MaxHours { get; set; }
        public bool IsMigrated { get; set; }
    }
}
