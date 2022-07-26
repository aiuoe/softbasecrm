using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("ARImages", Schema = "web")]
    [Index(nameof(TenantId), Name = "ARImages_TenantId_index")]
    public class Arimage : FullAuditedEntity<long>, IMustHaveTenant
    {
        [Required]
        [StringLength(50)]
        public string CustomerNo { get; set; }
        public long InvoiceNo { get; set; }
        [Required]
        [StringLength(200)]
        public string FileName { get; set; }
        [StringLength(200)]
        public string FilePath { get; set; }
        [Column(TypeName = "image")]
        public byte[] Image { get; set; }
        public bool? ProcessedParts { get; set; }
        public bool? ProcessedLabor { get; set; }
        public bool? ProcessedComments { get; set; }
        [Column("ProcessedCSS")]
        public bool? ProcessedCss { get; set; }
        [StringLength(50)]
        public string ProcessedPartsBy { get; set; }
        [StringLength(50)]
        public string ProcessedLaborBy { get; set; }
        [StringLength(50)]
        public string ProcessedCommentsBy { get; set; }
        [Column("ProcessedCSSBy")]
        [StringLength(50)]
        public string ProcessedCssby { get; set; }
        public bool? IncludeWithInvoice { get; set; }
        [StringLength(100)]
        public string AddedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DateAdded { get; set; }
        [StringLength(100)]
        public string ChangedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DateChanged { get; set; }
        public int TenantId { get; set; }
        public bool IsMigrated { get; set; }
    }
}
