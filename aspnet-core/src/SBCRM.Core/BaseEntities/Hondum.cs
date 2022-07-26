using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("Honda", Schema = "web")]
    [Index(nameof(TenantId), Name = "Honda_TenantId_index")]
    [Index(nameof(PartNo), nameof(TenantId), Name = "UC_Honda", IsUnique = true)]
    public class Hondum : FullAuditedEntity<long>, IMustHaveTenant
    {
        public int TenantId { get; set; }
        [Required]
        [StringLength(50)]
        public string PartNo { get; set; }
        [StringLength(100)]
        public string Description { get; set; }
        [StringLength(50)]
        public string NewPartNo { get; set; }
        [Column("NewPart_PRNT_MK")]
        [StringLength(50)]
        public string NewPartPrntMk { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? Cost { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? List { get; set; }
        [StringLength(50)]
        public string NonReturnable { get; set; }
        [StringLength(100)]
        public string DescriptionFrench { get; set; }
        [StringLength(50)]
        public string Category { get; set; }
        [Column("Part_Status")]
        [StringLength(50)]
        public string PartStatus { get; set; }
        [StringLength(100)]
        public string CreatedBy { get; set; }
        [StringLength(100)]
        public string ChangedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? Created { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? Changed { get; set; }
        public bool IsMigrated { get; set; }
    }
}
