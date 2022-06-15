using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("EquipmentRemoved", Schema = "web")]
    [Index(nameof(TenantId), Name = "EquipmentRemoved_TenantId_index")]
    public class EquipmentRemoved : FullAuditedEntity<long>, IMustHaveTenant
    {
        [StringLength(50)]
        public string SerialNo { get; set; }
        [StringLength(50)]
        public string Make { get; set; }
        [StringLength(50)]
        public string Model { get; set; }
        [StringLength(50)]
        public string UnitNo { get; set; }
        [StringLength(50)]
        public string ControlNo { get; set; }
        public int? InventoryBranch { get; set; }
        public int? InventoryDept { get; set; }
        public int? Customer { get; set; }
        [StringLength(50)]
        public string CustomerNo { get; set; }
        [StringLength(100)]
        public string RemovedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? RemovedDate { get; set; }
        [Column("LegacyID")]
        public int LegacyId { get; set; }
        public int TenantId { get; set; }
        public bool IsMigrated { get; set; }
    }
}
