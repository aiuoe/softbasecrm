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
    [Table("PartsCost", Schema = "web")]
    [Index(nameof(TenantId), Name = "PartsCost_TenantId_index")]
    [Index(nameof(PartNo), nameof(Warehouse), nameof(CreationTime), nameof(TenantId), Name = "UC_PartsCost", IsUnique = true)]
    public class PartsCost : FullAuditedEntity<long>, IMustHaveTenant
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
        public decimal? Qty { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? Cost { get; set; }
        [StringLength(100)]
        public string ChangedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DateChanged { get; set; }
        [StringLength(50)]
        public string BrokerNo { get; set; }
        [StringLength(50)]
        public string ImportNo { get; set; }
        [StringLength(50)]
        public string CustomsNo { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ImportDate { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? CurrencyRate { get; set; }
        public int? LegacyId { get; set; }
        public bool IsMigrated { get; set; }
    }
}
