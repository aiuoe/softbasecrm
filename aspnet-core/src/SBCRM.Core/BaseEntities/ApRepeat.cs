using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("APRepeat", Schema = "web")]
    [Index(nameof(TenantId), Name = "APRepeat_TenantId_index")]
    [Index(nameof(VendorNo), nameof(ApinvoiceNo), nameof(TenantId), Name = "UC_APRepeat", IsUnique = true)]
    public class ApRepeat : FullAuditedEntity<long>, IMustHaveTenant
    {
        [Required]
        [StringLength(100)]
        public string VendorNo { get; set; }
        [Required]
        [Column("APInvoiceNo")]
        [StringLength(100)]
        public string ApinvoiceNo { get; set; }
        [Column("OriginalAPInvoiceNo")]
        [StringLength(100)]
        public string OriginalApinvoiceNo { get; set; }
        public short? TotalRepeats { get; set; }
        public short? CurrentCount { get; set; }
        public short? FrequencyMethod { get; set; }
        public short? Frequency { get; set; }
        [StringLength(100)]
        public string AccountNo { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? Amount { get; set; }
        [StringLength(100)]
        public string AddedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? Added { get; set; }
        public int TenantId { get; set; }
        public bool IsMigrated { get; set; }
    }
}
