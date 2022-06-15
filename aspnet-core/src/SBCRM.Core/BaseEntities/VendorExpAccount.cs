using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("VendorExpAccounts", Schema = "web")]
    [Index(nameof(TenantId), Name = "VendorExpAccounts_TenantId_index")]
    [Index(nameof(VendorNo), nameof(ExpAccountNo), nameof(TenantId), Name = "UC_VendorExpAccounts", IsUnique = true)]
    public class VendorExpAccount : FullAuditedEntity<long>, IMustHaveTenant
    {
        public int TenantId { get; set; }
        [Required]
        [StringLength(50)]
        public string VendorNo { get; set; }
        [Required]
        [StringLength(50)]
        public string ExpAccountNo { get; set; }
        [StringLength(50)]
        public string AddedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DateAdded { get; set; }
        public bool IsMigrated { get; set; }
    }
}
