using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("Briggs", Schema = "web")]
    [Index(nameof(TenantId), Name = "Briggs_TenantId_index")]
    [Index(nameof(PartNo), nameof(TenantId), Name = "UC_Briggs", IsUnique = true)]
    public class Brigg : FullAuditedEntity<long>, IMustHaveTenant
    {
        [Required]
        [StringLength(100)]
        public string PartNo { get; set; }
        [StringLength(100)]
        public string Description { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? List { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? Cost { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? Weight { get; set; }
        [StringLength(50)]
        public string Status { get; set; }
        [StringLength(100)]
        public string ReplacedBy { get; set; }
        [StringLength(100)]
        public string Type { get; set; }
        [StringLength(50)]
        public string DiscountCode { get; set; }
        [StringLength(50)]
        public string StockingCode { get; set; }
        public short? MinOrderQty { get; set; }
        [StringLength(50)]
        public string Disposition { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? Created { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LastUpdated { get; set; }
        public int TenantId { get; set; }
        public bool IsMigrated { get; set; }
    }
}
