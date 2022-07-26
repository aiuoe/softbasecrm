using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("Warehouse", Schema = "web")]
    [Index(nameof(TenantId), Name = "Warehouse_TenantId_index")]
    public class Warehouse : FullAuditedEntity<long>, IMustHaveTenant
    {
        public int TenantId { get; set; }
        [Required]
        [Column("Warehouse")]
        [StringLength(50)]
        public string WarehouseName { get; set; }
        [StringLength(50)]
        public string Description { get; set; }
        [StringLength(50)]
        public string InventoryAccount { get; set; }
        [Column("FIFOInventory")]
        public short? Fifoinventory { get; set; }
        public short? ServiceVan { get; set; }
        public short? PickTickets { get; set; }
        [StringLength(50)]
        public string Supply1 { get; set; }
        [StringLength(50)]
        public string Supply2 { get; set; }
        [StringLength(50)]
        public string Supply3 { get; set; }
        [StringLength(50)]
        public string Supply4 { get; set; }
        [StringLength(50)]
        public string Supply5 { get; set; }
        public short? Branch { get; set; }
        [StringLength(50)]
        public string Prefix { get; set; }
        public short? Reprice { get; set; }
        public short? Consignment { get; set; }
        public short? AverageCost { get; set; }
        [StringLength(50)]
        public string LandedAccount { get; set; }
        [StringLength(50)]
        public string AddedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DateAdded { get; set; }
        [StringLength(50)]
        public string ChangedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DateChanged { get; set; }
        [StringLength(50)]
        public string CustomerNo { get; set; }
        public bool IsMigrated { get; set; }
    }
}
