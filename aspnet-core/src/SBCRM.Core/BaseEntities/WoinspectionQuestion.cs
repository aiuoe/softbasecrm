using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("WOInspectionQuestion", Schema = "web")]
    [Index(nameof(TenantId), Name = "WOInspectionQuestion_TenantId_index")]
    [Index(nameof(Wono), nameof(Name), nameof(Section), nameof(Question), nameof(TenantId), Name = "UC_WOInspectionQuestion", IsUnique = true)]
    public partial class WoinspectionQuestion : FullAuditedEntity<long>, IMustHaveTenant
    {
        public int TenantId { get; set; }
        [Column("WONo")]
        public int Wono { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [Required]
        [StringLength(100)]
        public string Section { get; set; }
        [Required]
        [StringLength(100)]
        public string Question { get; set; }
        [Column("OK")]
        public int? Ok { get; set; }
        [StringLength(50)]
        public string Potential { get; set; }
        [StringLength(100)]
        public string Urgent { get; set; }
        [StringLength(100)]
        public string AddedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DateAdded { get; set; }
        [StringLength(100)]
        public string ChangedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DateChanged { get; set; }
        public bool IsMigrated { get; set; }
    }
}
