using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("WOParts", Schema = "web")]
    [Index(nameof(TenantId), Name = "WOParts_TenantId_index")]
    public class Wopart : FullAuditedEntity<long>, IMustHaveTenant
    {
        public int TenantId { get; set; }
        [Column("WONo")]
        public int Wono { get; set; }
        [StringLength(50)]
        public string AddedBy { get; set; }
        [StringLength(50)]
        public string BillTo { get; set; }
        [StringLength(50)]
        public string PartNo { get; set; }
        [StringLength(50)]
        public string Warehouse { get; set; }
        [StringLength(200)]
        public string Description { get; set; }
        [StringLength(50)]
        public string Intructions { get; set; }
        [StringLength(50)]
        public string PartNoAlias { get; set; }
        [StringLength(50)]
        public string Bin { get; set; }
        [StringLength(50)]
        public string PartsGroup { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? Qty { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? ShipQty { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? PickQty { get; set; }
        [Column("BOQty", TypeName = "decimal(19, 4)")]
        public decimal? Boqty { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? OrderQty { get; set; }
        public long? OrderNo { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? InitQty { get; set; }
        public bool? NoDemand { get; set; }
        public short? Priority { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? CostRate { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? SellRate { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? ListRate { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? Cost { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? Sell { get; set; }
        [Column("BOStatus")]
        public short? Bostatus { get; set; }
        public short? SaleBranch { get; set; }
        public short? SaleDept { get; set; }
        [StringLength(50)]
        public string SaleCode { get; set; }
        [StringLength(50)]
        public string SaleAccount { get; set; }
        [StringLength(50)]
        public string CostAccount { get; set; }
        [StringLength(50)]
        public string InvAccount { get; set; }
        public bool? Taxable { get; set; }
        [StringLength(50)]
        public string Section { get; set; }
        [StringLength(50)]
        public string RepairGroup { get; set; }
        [StringLength(50)]
        public string RepairCode { get; set; }
        public bool? Transfer { get; set; }
        [Column("TransferWONoFrom")]
        public int? TransferWonoFrom { get; set; }
        [Column("TransferWONoTo")]
        public int? TransferWonoTo { get; set; }
        [StringLength(50)]
        public string TransferBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? TransferDate { get; set; }
        [StringLength(255)]
        public string Instructions { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? LandedCost { get; set; }
        [StringLength(50)]
        public string LandedAccount { get; set; }
        public bool? NoPrint { get; set; }
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
        [StringLength(100)]
        public string ReferenceNo { get; set; }
        [StringLength(100)]
        public string Model { get; set; }
        public bool? StateTax { get; set; }
        public bool? CountyTax { get; set; }
        public bool? CityTax { get; set; }
        public bool? LocalTax { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? QuoteDeliveryDate { get; set; }
        [Column("CustomerPOLineNo")]
        public short? CustomerPolineNo { get; set; }
        [Column("WIPAccount")]
        [StringLength(50)]
        public string Wipaccount { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? BackorderCost { get; set; }
        public bool? BackorderCostNoUpdate { get; set; }
        [StringLength(50)]
        public string PreferredVendor { get; set; }
        [StringLength(50)]
        public string VendorAliasNo { get; set; }
        public short? SectionNo { get; set; }
        [StringLength(200)]
        public string DescriptionFrench { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime EntryDate { get; set; }
        public int? LegacyId { get; set; }
        public bool IsMigrated { get; set; }
    }
}
