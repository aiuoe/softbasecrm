using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("APPaymentType", Schema = "web")]
    [Index(nameof(TenantId), Name = "APPaymentType_TenantId_index")]
    [Index(nameof(PaymentType), nameof(TenantId), Name = "UC_APPaymentType", IsUnique = true)]
    public class ApPaymentType : FullAuditedEntity<long>, IMustHaveTenant
    {
        [StringLength(100)]
        public string PaymentTypeDescription { get; set; }
        [Required]
        [StringLength(50)]
        public string PaymentType { get; set; }
        public int TenantId { get; set; }
        public bool IsMigrated { get; set; }
    }
}
