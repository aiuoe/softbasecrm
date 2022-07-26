using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("SaleCodesEQMake", Schema = "web")]
    [Index(nameof(TenantId), Name = "SaleCodesEQMake_TenantId_index")]
    [Index(nameof(Branch), nameof(Dept), nameof(Code), nameof(Make), nameof(TenantId), Name = "UC_SaleCodesEQMake", IsUnique = true)]
    public class SaleCodesEqmake : FullAuditedEntity<long>, IMustHaveTenant
    {
        public int TenantId { get; set; }
        public int Branch { get; set; }
        public int Dept { get; set; }
        [Required]
        [StringLength(50)]
        public string Code { get; set; }
        [Required]
        [StringLength(50)]
        public string Make { get; set; }
        [StringLength(50)]
        public string Equipment { get; set; }
        [Column("EquipmentCOG")]
        [StringLength(50)]
        public string EquipmentCog { get; set; }
        public bool IsMigrated { get; set; }
    }
}
