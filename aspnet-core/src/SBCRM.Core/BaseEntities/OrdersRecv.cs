using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("OrdersRecv", Schema = "web")]
    [Index(nameof(TenantId), Name = "OrdersRecv_TenantId_index")]
    public class OrdersRecv : FullAuditedEntity<long>, IMustHaveTenant
    {
        public int TenantId { get; set; }
        [Required]
        [StringLength(50)]
        public string PartNo { get; set; }
        [Required]
        [StringLength(50)]
        public string Warehouse { get; set; }
        public int OrderNo { get; set; }
        [Column("WONo")]
        public int Wono { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime OrdersEntryDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime EntryDate { get; set; }
        [StringLength(50)]
        public string Description { get; set; }
        [StringLength(50)]
        public string PartNoAlias { get; set; }
        [StringLength(50)]
        public string Bin { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? Qty { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? CostEach { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? RecvQty { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? OrderDate { get; set; }
        public short? Priority { get; set; }
        [StringLength(50)]
        public string Journal { get; set; }
        [Column("APInvoiceNo")]
        [StringLength(50)]
        public string ApinvoiceNo { get; set; }
        [StringLength(50)]
        public string VendorNo { get; set; }
        [StringLength(50)]
        public string InvAccount { get; set; }
        [StringLength(50)]
        public string BrokerNo { get; set; }
        [StringLength(50)]
        public string ImportNo { get; set; }
        [StringLength(50)]
        public string CustomsNo { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ImportDate { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? CurrencyRate { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? FreightAmount { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? CustomsAmount { get; set; }
        [Column("AccruedPOAccount")]
        [StringLength(50)]
        public string AccruedPoaccount { get; set; }
        public short? BoxNo { get; set; }
        [StringLength(100)]
        public string RecvBy { get; set; }
        public int? LegacyId { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? PreviousImportQty { get; set; }
        public bool IsMigrated { get; set; }
    }
}
