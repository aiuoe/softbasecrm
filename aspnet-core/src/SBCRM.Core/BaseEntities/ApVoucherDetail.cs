using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("APVoucherDetail", Schema = "web")]
    [Index(nameof(TenantId), Name = "APVoucherDetail_TenantId_index")]
    public class ApVoucherDetail : FullAuditedEntity<long>, IMustHaveTenant
    {
        [Required]
        [StringLength(50)]
        public string Journal { get; set; }
        [Required]
        [Column("APInvoiceNo")]
        [StringLength(50)]
        public string ApinvoiceNo { get; set; }
        [Required]
        [StringLength(50)]
        public string VendorNo { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime VoucherEntryDate { get; set; }
        [Required]
        [StringLength(50)]
        public string AccountNo { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime EntryDate { get; set; }
        [Required]
        [StringLength(50)]
        public string ControlNo { get; set; }
        [StringLength(50)]
        public string CustomerNo { get; set; }
        public int? InvoiceNo { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? Amount { get; set; }
        [StringLength(100)]
        public string Description { get; set; }
        public bool? TaxFlag { get; set; }
        [StringLength(50)]
        public string AddedBy { get; set; }
        [StringLength(50)]
        public string ChangedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DateAdded { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DateChanged { get; set; }
        public int TenantId { get; set; }
        public bool IsMigrated { get; set; }
    }
}
