using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("SaleCodesEquipment", Schema = "web")]
    [Index(nameof(TenantId), Name = "SaleCodesEquipment_TenantId_index")]
    [Index(nameof(Branch), nameof(Dept), nameof(Code), nameof(ModelGroup), nameof(TenantId), Name = "UC_SaleCodesEquipment", IsUnique = true)]
    public class SaleCodesEquipment : FullAuditedEntity<long>, IMustHaveTenant
    {
        [Key]
        public long Id { get; set; }
        public int TenantId { get; set; }
        public short Branch { get; set; }
        public short Dept { get; set; }
        [Required]
        [StringLength(50)]
        public string Code { get; set; }
        [Required]
        [StringLength(50)]
        public string ModelGroup { get; set; }
        [StringLength(50)]
        public string Equipment { get; set; }
        [Column("EquipmentCOG")]
        [StringLength(50)]
        public string EquipmentCog { get; set; }
        public bool IsMigrated { get; set; }
    }
}
