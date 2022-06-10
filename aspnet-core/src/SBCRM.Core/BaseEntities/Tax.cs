using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("Tax", Schema = "web")]
    [Index(nameof(TenantId), Name = "Tax_TenantId_index")]
    [Index(nameof(Code), nameof(TenantId), Name = "UC_Tax", IsUnique = true)]
    public class Tax : FullAuditedEntity<long>, IMustHaveTenant
    {
        public int TenantId { get; set; }
        [Required]
        [StringLength(50)]
        public string Code { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? Rate { get; set; }
        [StringLength(50)]
        public string Account { get; set; }
        [StringLength(50)]
        public string RentalAccount { get; set; }
        [StringLength(50)]
        public string Description { get; set; }
        public string Comments { get; set; }
        public bool PartsNonTaxable { get; set; }
        public bool LaborNonTaxable { get; set; }
        public bool MiscNonTaxable { get; set; }
        public bool RentalNonTaxable { get; set; }
        public bool EquipmentNonTaxable { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? CountyRate { get; set; }
        [StringLength(50)]
        public string CountyAccount { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? MaxAmount { get; set; }
        public bool CustomerOverride { get; set; }
        [StringLength(50)]
        public string AccountPaid { get; set; }
        [StringLength(100)]
        public string County { get; set; }
        public bool IsMigrated { get; set; }
    }
}
