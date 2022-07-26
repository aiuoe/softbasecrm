using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("MiscPODetail", Schema = "web")]
    [Index(nameof(TenantId), Name = "MiscPODetail_TenantId_index")]
    public class MiscPodetail : FullAuditedEntity<long>, IMustHaveTenant
    {
        public int TenantId { get; set; }
        [Column("PONo")]
        public int Pono { get; set; }
        public short? Received { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime Date { get; set; }
        [StringLength(50)]
        public string Description { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? Amount { get; set; }
        [StringLength(50)]
        public string InventoryAccount { get; set; }
        [StringLength(50)]
        public string ControlNo { get; set; }
        [StringLength(50)]
        public string Journal { get; set; }
        [Column("APInvoiceNo")]
        [StringLength(50)]
        public string ApinvoiceNo { get; set; }
        [StringLength(50)]
        public string VendorNo { get; set; }
        [StringLength(50)]
        public string ReceivedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ReceivedDate { get; set; }
        [Column("WONo")]
        public int? Wono { get; set; }
        [Column("AccruedPOAccount")]
        [StringLength(50)]
        public string AccruedPoaccount { get; set; }
        public int? LegacyId { get; set; }
        [StringLength(50)]
        public string AddedBy { get; set; }
        [StringLength(50)]
        public string ChangedBy { get; set; }
        [Column("WOMiscID")]
        public int? WomiscId { get; set; }
        public bool IsMigrated { get; set; }
    }
}
