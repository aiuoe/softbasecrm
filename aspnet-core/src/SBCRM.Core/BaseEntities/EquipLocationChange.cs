using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("EquipLocationChange", Schema = "web")]
    [Index(nameof(TenantId), Name = "EquipLocationChange_TenantId_index")]
    [Index(nameof(SerialNo), nameof(TenantId), Name = "UC_EquipLocationChange", IsUnique = true)]
    public class EquipLocationChange : FullAuditedEntity<long>, IMustHaveTenant
    {
        [Required]
        [StringLength(50)]
        public string SerialNo { get; set; }
        public bool FromBranch { get; set; }
        public bool FromDept { get; set; }
        [StringLength(50)]
        public string FromInventoryAccount { get; set; }
        [StringLength(50)]
        public string FromCustomerNo { get; set; }
        public bool FromCustomerFlag { get; set; }
        public bool ToBranch { get; set; }
        public bool ToDept { get; set; }
        [StringLength(50)]
        public string ToInventoryAccount { get; set; }
        [StringLength(50)]
        public string ToCustomerNo { get; set; }
        public bool ToCustomerFlag { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? Changed { get; set; }
        [StringLength(100)]
        public string ChangedBy { get; set; }
        public int TenantId { get; set; }
        public bool IsMigrated { get; set; }
    }
}
