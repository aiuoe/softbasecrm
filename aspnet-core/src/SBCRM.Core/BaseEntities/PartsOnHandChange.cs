using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("PartsOnHandChange", Schema = "web")]
    [Index(nameof(TenantId), Name = "PartsOnHandChange_TenantId_index")]
    [Index(nameof(PartNo), nameof(Warehouse), nameof(EntryDate), nameof(TenantId), Name = "UC_PartsOnHandChange", IsUnique = true)]
    public class PartsOnHandChange : FullAuditedEntity<long>, IMustHaveTenant
    {
        public int TenantId { get; set; }
        [Required]
        [StringLength(50)]
        public string PartNo { get; set; }
        [Required]
        [StringLength(50)]
        public string Warehouse { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime EntryDate { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? PreviousOnHand { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? CurrentOnHand { get; set; }
        [StringLength(50)]
        public string ChangedBy { get; set; }
        public string Reason { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? Cost { get; set; }
        public bool IsMigrated { get; set; }
    }
}
