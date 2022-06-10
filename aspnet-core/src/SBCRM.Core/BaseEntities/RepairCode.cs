using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("RepairCode", Schema = "web")]
    [Index(nameof(TenantId), Name = "RepairCode_TenantId_index")]
    [Index(nameof(RepairCode1), nameof(TenantId), Name = "UC_RepairCode", IsUnique = true)]
    public class RepairCode : FullAuditedEntity<long>, IMustHaveTenant
    {
        public int TenantId { get; set; }
        [Required]
        [Column("RepairCode")]
        [StringLength(50)]
        public string RepairCode1 { get; set; }
        [StringLength(50)]
        public string Description { get; set; }
        [StringLength(50)]
        public string RepairGroup { get; set; }
        public string RepairCodeMemo { get; set; }
        [Column(TypeName = "decimal(16, 4)")]
        public decimal? HoursAllowed { get; set; }
        [Column(TypeName = "decimal(16, 4)")]
        public decimal? Amount { get; set; }
        [Column(TypeName = "decimal(16, 4)")]
        public decimal? EstimatedCost { get; set; }
        [StringLength(50)]
        public string AddedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DateAdded { get; set; }
        [StringLength(50)]
        public string ChangedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DateChanged { get; set; }
        public bool IsMigrated { get; set; }
    }
}
