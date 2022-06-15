using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("eRentFeesDetail", Schema = "web")]
    [Index(nameof(TenantId), Name = "eRentFeesDetail_TenantId_index")]
    public class ERentFeesDetail : FullAuditedEntity<long>, IMustHaveTenant
    {
        [Column("LegacyID")]
        public int? LegacyId { get; set; }
        public long? DocumentNumber { get; set; }
        [Required]
        [StringLength(50)]
        public string ModelGroup { get; set; }
        [Required]
        [StringLength(50)]
        public string EquipmentGroup { get; set; }
        [Required]
        [StringLength(50)]
        public string Charge { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal Amount { get; set; }
        [Column("EquipmentDetailID")]
        public long? EquipmentDetailId { get; set; }
        public int TenantId { get; set; }
        public bool IsMigrated { get; set; }
    }
}
