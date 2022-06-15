using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("GLDetail", Schema = "web")]
    [Index(nameof(TenantId), Name = "GLDetail_TenantId_index")]
    public class Gldetail : FullAuditedEntity<long>, IMustHaveTenant
    {
        [StringLength(50)]
        public string Journal { get; set; }
        [StringLength(50)]
        public string AccountNo { get; set; }
        [StringLength(50)]
        public string ControlNo { get; set; }
        [StringLength(255)]
        public string Description { get; set; }
        [StringLength(50)]
        public string AccountField { get; set; }
        [StringLength(50)]
        public string Source { get; set; }
        public int? InvoiceNo { get; set; }
        [Column("APInvoiceNo")]
        [StringLength(50)]
        public string ApinvoiceNo { get; set; }
        [StringLength(50)]
        public string CustomerNo { get; set; }
        [StringLength(50)]
        public string VendorNo { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? EffectiveDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? PostedDate { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? Amount { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? HistoryDate { get; set; }
        public bool? HistoryFlag { get; set; }
        [StringLength(100)]
        public string AddedBy { get; set; }
        [StringLength(100)]
        public string ProgramVersion { get; set; }
        [Column("ARCheckNo")]
        [StringLength(100)]
        public string ArcheckNo { get; set; }
        [Column("ARPONo")]
        [StringLength(100)]
        public string Arpono { get; set; }
        [Column("APCheckNo")]
        public int? ApcheckNo { get; set; }
        [Column("APPONo")]
        public int? Appono { get; set; }
        public int? UniqueFieldLegacy { get; set; }
        public int TenantId { get; set; }
        public bool IsMigrated { get; set; }
    }
}
