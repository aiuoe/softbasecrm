using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("Orders", Schema = "web")]
    [Index(nameof(TenantId), Name = "Orders_TenantId_index")]
    public class Order : FullAuditedEntity<long>, IMustHaveTenant
    {
        public int TenantId { get; set; }
        public int OrderNo { get; set; }
        public short? OrderStatus { get; set; }
        [Column("WONo")]
        public int Wono { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime EntryDate { get; set; }
        [Required]
        [StringLength(50)]
        public string PartNo { get; set; }
        [Required]
        [StringLength(50)]
        public string Warehouse { get; set; }
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
        public short? NoCostUpdate { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? RecvQty { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? Recved { get; set; }
        public short? PrintTicket { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? OrderDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? RecvDate { get; set; }
        public short? Priority { get; set; }
        [StringLength(50)]
        public string InvAccount { get; set; }
        [Column("VendorBO")]
        public short? VendorBo { get; set; }
        [StringLength(255)]
        public string ItemComments { get; set; }
        [StringLength(50)]
        public string ReceivedBy { get; set; }
        public short? Approved { get; set; }
        [Column("VendorBODate", TypeName = "datetime")]
        public DateTime? VendorBodate { get; set; }
        public short? PreRecv { get; set; }
        public int? DetailLineNo { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? PreRecvQty { get; set; }
        [StringLength(50)]
        public string OriginalInvAccount { get; set; }
        [Column("AccruedPOAccount")]
        [StringLength(50)]
        public string AccruedPoaccount { get; set; }
        [StringLength(100)]
        public string DescriptionFrench { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DateAdded { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DateChanged { get; set; }
        public int? LegacyId { get; set; }
        [Column("WOPartsID")]
        public int? WopartsId { get; set; }
        [StringLength(50)]
        public string AddedBy { get; set; }
        [StringLength(50)]
        public string ChangedBy { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? TempQty { get; set; }
        public int? Selected { get; set; }
        public bool IsMigrated { get; set; }
    }
}
