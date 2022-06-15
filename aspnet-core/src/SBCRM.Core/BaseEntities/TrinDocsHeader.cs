using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("TrinDocsHeader", Schema = "web")]
    [Index(nameof(TenantId), Name = "TrinDocsHeader_TenantId_index")]
    public class TrinDocsHeader : FullAuditedEntity<long>, IMustHaveTenant
    {
        public int TenantId { get; set; }
        [Column("TrinDocsID")]
        public int? TrinDocsId { get; set; }
        [StringLength(100)]
        public string VendorName { get; set; }
        [StringLength(50)]
        public string VendorNo { get; set; }
        [Column("PONo")]
        public int? Pono { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? InvoiceAmount { get; set; }
        [StringLength(50)]
        public string DocumentType { get; set; }
        [StringLength(50)]
        public string Approver { get; set; }
        public int? PaymentNo { get; set; }
        [Column("APInvoiceNo")]
        [StringLength(50)]
        public string ApinvoiceNo { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DueDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? InvoiceDate { get; set; }
        [StringLength(50)]
        public string JournalName { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DiscountDate { get; set; }
        [StringLength(50)]
        public string PaymentType { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? PaymentDate { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? Freight { get; set; }
        [Column("ARInvoiceNo")]
        public int? ArinvoiceNo { get; set; }
        [StringLength(50)]
        public string CustomerNo { get; set; }
        [StringLength(50)]
        public string Error { get; set; }
        public bool IsMigrated { get; set; }
    }
}
