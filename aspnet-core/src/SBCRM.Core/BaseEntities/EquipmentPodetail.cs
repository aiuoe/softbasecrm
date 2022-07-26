using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("EquipmentPODetail", Schema = "web")]
    [Index(nameof(TenantId), Name = "EquipmentPODetail_TenantId_index")]
    public class EquipmentPodetail : FullAuditedEntity<long>, IMustHaveTenant
    {
        [Column("PONo")]
        public int Pono { get; set; }
        public bool Received { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime Date { get; set; }
        [StringLength(50)]
        public string Description { get; set; }
        [StringLength(50)]
        public string SerialNo { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? Amount { get; set; }
        [StringLength(50)]
        public string InventoryAccount { get; set; }
        [StringLength(50)]
        public string VendorNo { get; set; }
        [StringLength(50)]
        public string VendorName { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? RecvDate { get; set; }
        [StringLength(50)]
        public string RecvBy { get; set; }
        [StringLength(50)]
        public string Journal { get; set; }
        [Column("APInvoiceNo")]
        [StringLength(50)]
        public string ApinvoiceNo { get; set; }
        [Column("AccruedPOAccount")]
        [StringLength(50)]
        public string AccruedPoaccount { get; set; }
        [Column("LegacyID")]
        public int? LegacyId { get; set; }
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
