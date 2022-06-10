using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("PartsSales", Schema = "web")]
    [Index(nameof(TenantId), Name = "PartsSales_TenantId_index")]
    [Index(nameof(PartNo), nameof(Warehouse), nameof(TenantId), Name = "UC_PartsSales", IsUnique = true)]
    public class PartsSale : FullAuditedEntity<long>, IMustHaveTenant
    {
        public int TenantId { get; set; }
        [Required]
        [StringLength(50)]
        public string PartNo { get; set; }
        [Required]
        [StringLength(50)]
        public string Warehouse { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? Sales1 { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? Sales2 { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? Sales3 { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? Sales4 { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? Sales5 { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? Sales6 { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? Sales7 { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? Sales8 { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? Sales9 { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? Sales10 { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? Sales11 { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? Sales12 { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? SalesLast1 { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? SalesLast2 { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? SalesLast3 { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? SalesLast4 { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? SalesLast5 { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? SalesLast6 { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? SalesLast7 { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? SalesLast8 { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? SalesLast9 { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? SalesLast10 { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? SalesLast11 { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? SalesLast12 { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LastRoll { get; set; }
        public bool IsMigrated { get; set; }
    }
}
