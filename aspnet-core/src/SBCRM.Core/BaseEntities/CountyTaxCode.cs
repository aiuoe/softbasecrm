using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("CountyTaxCodes", Schema = "web")]
    [Index(nameof(TenantId), Name = "CountyTaxCodes_TenantId_index")]
    [Index(nameof(TaxCode), nameof(TenantId), Name = "UC_CountyTaxCodes", IsUnique = true)]
    public class CountyTaxCode : FullAuditedEntity<long>, IMustHaveTenant
    {
        [Required]
        [StringLength(50)]
        public string TaxCode { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? TaxRate { get; set; }
        [StringLength(50)]
        public string Description { get; set; }
        [StringLength(50)]
        public string TaxAccount { get; set; }
        [StringLength(50)]
        public string CountyCode { get; set; }
        public bool CountySpecialFlag { get; set; }
        [StringLength(50)]
        public string StateSpecialAccount { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? StateSpecialRate { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? StateSpecialMin { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? StateSpecialMax { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? MaxAmount { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? TaxRateRental { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? TaxRateEquip { get; set; }
        public bool? Quebec { get; set; }
        public bool? PartsNonTaxable { get; set; }
        public bool? LaborNonTaxable { get; set; }
        public bool? MiscNonTaxable { get; set; }
        public bool? RentalNonTaxable { get; set; }
        public bool? EquipmentNonTaxable { get; set; }
        public int TenantId { get; set; }
        public bool IsMigrated { get; set; }
    }
}
