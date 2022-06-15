using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("SaleCodesParts", Schema = "web")]
    [Index(nameof(TenantId), Name = "SaleCodesParts_TenantId_index")]
    [Index(nameof(Branch), nameof(Dept), nameof(Code), nameof(PartsGroup), nameof(TenantId), Name = "UC_SaleCodesParts", IsUnique = true)]
    public class SaleCodesPart : FullAuditedEntity<long>, IMustHaveTenant
    {
        public int TenantId { get; set; }
        public short Branch { get; set; }
        public short Dept { get; set; }
        [Required]
        [StringLength(50)]
        public string Code { get; set; }
        [Required]
        [StringLength(50)]
        public string PartsGroup { get; set; }
        [StringLength(50)]
        public string PartsCost { get; set; }
        [StringLength(50)]
        public string PartsDiscount { get; set; }
        [StringLength(50)]
        public string PartsList { get; set; }
        [StringLength(50)]
        public string PartsWholesale { get; set; }
        [StringLength(50)]
        public string PartsWarranty { get; set; }
        [StringLength(50)]
        public string PartsInternal { get; set; }
        [Column("PartsCostCOG")]
        [StringLength(50)]
        public string PartsCostCog { get; set; }
        [Column("PartsDiscountCOG")]
        [StringLength(50)]
        public string PartsDiscountCog { get; set; }
        [Column("PartsListCOG")]
        [StringLength(50)]
        public string PartsListCog { get; set; }
        [Column("PartsWholesaleCOG")]
        [StringLength(50)]
        public string PartsWholesaleCog { get; set; }
        [Column("PartsWarrantyCOG")]
        [StringLength(50)]
        public string PartsWarrantyCog { get; set; }
        [Column("PartsInternalCOG")]
        [StringLength(50)]
        public string PartsInternalCog { get; set; }
        public bool IsMigrated { get; set; }
    }
}
