using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("ServiceClaimReturnCode", Schema = "web")]
    [Index(nameof(TenantId), Name = "ServiceClaimReturnCode_TenantId_index")]
    [Index(nameof(ReturnCode), nameof(TenantId), Name = "UC_ServiceClaimReturnCode", IsUnique = true)]
    public class ServiceClaimReturnCode : FullAuditedEntity<long>, IMustHaveTenant
    {
        public int TenantId { get; set; }
        [Required]
        [StringLength(100)]
        public string ReturnCode { get; set; }
        [StringLength(100)]
        public string Description { get; set; }
        public bool IsMigrated { get; set; }
    }
}
