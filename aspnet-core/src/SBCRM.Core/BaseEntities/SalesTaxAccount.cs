using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("SalesTaxAccounts", Schema = "web")]
    [Index(nameof(TenantId), Name = "SalesTaxAccounts_TenantId_index")]
    public class SalesTaxAccount : FullAuditedEntity<long>, IMustHaveTenant
    {
        public int TenantId { get; set; }
        [StringLength(50)]
        public string AccountNo { get; set; }
        [StringLength(50)]
        public string Type { get; set; }
        public bool IsMigrated { get; set; }
    }
}
