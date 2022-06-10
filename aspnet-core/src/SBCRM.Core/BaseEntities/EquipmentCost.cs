using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("EquipmentCost", Schema = "web")]
    [Index(nameof(TenantId), Name = "EquipmentCost_TenantId_index")]
    [Index(nameof(SerialNo), nameof(Pono), nameof(TenantId), Name = "UC_EquipmentCost", IsUnique = true)]
    public class EquipmentCost : FullAuditedEntity<long>, IMustHaveTenant
    {
        public int TenantId { get; set; }
        [Required]
        [StringLength(100)]
        public string SerialNo { get; set; }
        [Column("PONo")]
        public long Pono { get; set; }
        [Column("PODescription")]
        [StringLength(50)]
        public string Podescription { get; set; }
        [StringLength(50)]
        public string VendorNo { get; set; }
        [StringLength(50)]
        public string VendorName { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? Amount { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? RecvDate { get; set; }
        [StringLength(50)]
        public string RecvBy { get; set; }
        public bool IsMigrated { get; set; }
    }
}
