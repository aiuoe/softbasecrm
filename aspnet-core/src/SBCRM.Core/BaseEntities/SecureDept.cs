using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("SecureDept", Schema = "web")]
    [Index(nameof(TenantId), Name = "SecureDept_TenantId_index")]
    [Index(nameof(SecureName), nameof(SecureBranchLimit), nameof(SecureDeptLimit), nameof(TenantId), Name = "UC_SecureDept", IsUnique = true)]
    public class SecureDept : FullAuditedEntity<long>, IMustHaveTenant
    {
        public int TenantId { get; set; }
        [Required]
        [StringLength(50)]
        public string SecureName { get; set; }
        public short SecureBranchLimit { get; set; }
        public short SecureDeptLimit { get; set; }
        public bool IsMigrated { get; set; }
    }
}
