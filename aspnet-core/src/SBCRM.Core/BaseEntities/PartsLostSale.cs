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
    [Table("PartsLostSales", Schema = "web")]
    [Index(nameof(TenantId), Name = "PartsLostSales_TenantId_index")]
    [Index(nameof(PartNo), nameof(Warehouse), nameof(TenantId), Name = "UC_PartsLostSales", IsUnique = true)]
    public class PartsLostSale : FullAuditedEntity<long>, IMustHaveTenant
    {
        public int TenantId { get; set; }
        [Required]
        [StringLength(50)]
        public string PartNo { get; set; }
        [Required]
        [StringLength(50)]
        public string Warehouse { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? Lost1 { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? Lost2 { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? Lost3 { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? Lost4 { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? Lost5 { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? Lost6 { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? Lost7 { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? Lost8 { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? Lost9 { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? Lost10 { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? Lost11 { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? Lost12 { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? LostLast1 { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? LostLast2 { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? LostLast3 { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? LostLast4 { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? LostLast5 { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? LostLast6 { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? LostLast7 { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? LostLast8 { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? LostLast9 { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? LostLast10 { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? LostLast11 { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? LostLast12 { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LastRoll { get; set; }
        public bool IsMigrated { get; set; }
    }
}
