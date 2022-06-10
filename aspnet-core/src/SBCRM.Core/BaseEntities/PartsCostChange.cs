using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("PartsCostChange", Schema = "web")]
    [Index(nameof(TenantId), Name = "PartsCostChange_TenantId_index")]
    [Index(nameof(PartNo), nameof(Warehouse), nameof(CreationTime), nameof(TenantId), Name = "UC_PartsCostChange", IsUnique = true)]
    public class PartsCostChange : FullAuditedEntity<long>, IMustHaveTenant
    {
        public int TenantId { get; set; }
        [Required]
        [StringLength(100)]
        public string PartNo { get; set; }
        [Required]
        [StringLength(100)]
        public string Warehouse { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime EntryDate { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? PreviousCost { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? CurrentCost { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? OnHand { get; set; }
        [StringLength(50)]
        public string ChangedBy { get; set; }
        public bool IsMigrated { get; set; }
    }
}
