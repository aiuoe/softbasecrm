using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("JournalDetail", Schema = "web")]
    [Index(nameof(TenantId), Name = "JournalDetail_TenantId_index")]
    public class JournalDetail : FullAuditedEntity<long>, IMustHaveTenant
    {
        public int TenantId { get; set; }
        public int LegacyId { get; set; }
        [Required]
        [StringLength(50)]
        public string Journal { get; set; }
        [Required]
        [StringLength(50)]
        public string AccountNo { get; set; }
        [Required]
        [StringLength(50)]
        public string ControlNo { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime EntryDate { get; set; }
        [StringLength(255)]
        public string Description { get; set; }
        public int? InvoiceNo { get; set; }
        [Column("APInvoiceNo")]
        [StringLength(50)]
        public string ApinvoiceNo { get; set; }
        [StringLength(50)]
        public string CustomerNo { get; set; }
        [StringLength(50)]
        public string VendorNo { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? Amount { get; set; }
        public short? Payment { get; set; }
        [Column("APCheck")]
        public short? Apcheck { get; set; }
        public bool IsMigrated { get; set; }
    }
}
