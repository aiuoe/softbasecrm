using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("APRepeatDetail", Schema = "web")]
    [Index(nameof(TenantId), Name = "APRepeatDetail_TenantId_index")]
    public class ApRepeatDetail : FullAuditedEntity<long>, IMustHaveTenant
    {
        [Required]
        [StringLength(100)]
        public string VendorNo { get; set; }
        [Required]
        [Column("APInvoiceNo")]
        [StringLength(100)]
        public string ApinvoiceNo { get; set; }
        [Required]
        [StringLength(100)]
        public string AccountNo { get; set; }
        [Required]
        [StringLength(100)]
        public string ControlNo { get; set; }
        [StringLength(100)]
        public string CustomerNo { get; set; }
        public int? InvoiceNo { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? Amount { get; set; }
        [StringLength(100)]
        public string Description { get; set; }
        [StringLength(100)]
        public string AddedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? Added { get; set; }
        public int TenantId { get; set; }
        public bool IsMigrated { get; set; }
    }
}
