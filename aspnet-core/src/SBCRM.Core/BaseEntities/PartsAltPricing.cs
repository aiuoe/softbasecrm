using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("PartsAltPricing", Schema = "web")]
    [Index(nameof(TenantId), Name = "PartsAltPricing_TenantId_index")]
    [Index(nameof(CustomerNo), nameof(PartsGroup), nameof(TenantId), Name = "UC_PartsAltPricing", IsUnique = true)]
    public class PartsAltPricing : FullAuditedEntity<long>, IMustHaveTenant
    {
        public int TenantId { get; set; }
        [Required]
        [StringLength(50)]
        public string CustomerNo { get; set; }
        [Required]
        [StringLength(50)]
        public string PartsGroup { get; set; }
        [StringLength(50)]
        public string PartsRate { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? PartsDiscount { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DateAdded { get; set; }
        [StringLength(50)]
        public string AddedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DateChanged { get; set; }
        [StringLength(50)]
        public string ChangedBy { get; set; }
        public short? NationalList { get; set; }
        public short? QtyBreak { get; set; }
        public short? WalmartPricing { get; set; }
        public short? TargetPricing { get; set; }
        public bool IsMigrated { get; set; }
    }
}
