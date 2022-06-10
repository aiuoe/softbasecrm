using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("CityTaxCodes", Schema = "web")]
    [Index(nameof(TenantId), Name = "CityTaxCodes_TenantId_index")]
    [Index(nameof(TaxCode), nameof(TenantId), Name = "UC_CityTaxCodes", IsUnique = true)]
    public class CityTaxCode : FullAuditedEntity<long>, IMustHaveTenant
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
        public string CityCode { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? MaxAmount { get; set; }
        [StringLength(50)]
        public string CountyCode { get; set; }
        [StringLength(50)]
        public string CountyDescription { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? TaxRateRental { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? TaxRateEquip { get; set; }
        public int TenantId { get; set; }
        public bool IsMigrated { get; set; }
    }
}
