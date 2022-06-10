using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("WarrantyCodes", Schema = "web")]
    [Index(nameof(TenantId), Name = "WarrantyCodes_TenantId_index")]
    public class WarrantyCode : FullAuditedEntity<long>, IMustHaveTenant
    {
        public int TenantId { get; set; }
        [Required]
        [StringLength(50)]
        public string Code { get; set; }
        [StringLength(200)]
        public string Description { get; set; }
        public bool IsMigrated { get; set; }
    }
}
