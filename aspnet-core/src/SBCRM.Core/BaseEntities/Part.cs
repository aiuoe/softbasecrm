using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("Parts", Schema = "web")]
    [Index(nameof(TenantId), Name = "Parts_TenantId_index")]
    public class Part : FullAuditedEntity<long>, IMustHaveTenant
    {
        public int TenantId { get; set; }
        [Required]
        [StringLength(50)]
        public string PartNo { get; set; }
        [Required]
        [StringLength(50)]
        public string Warehouse { get; set; }
        [Column("MFGCode")]
        [StringLength(50)]
        public string Mfgcode { get; set; }
        [StringLength(50)]
        public string Sort1 { get; set; }
        [StringLength(50)]
        public string Sort2 { get; set; }
        [StringLength(50)]
        public string Sort3 { get; set; }
        [StringLength(50)]
        public string Sort4 { get; set; }
        [StringLength(50)]
        public string Sort5 { get; set; }
        [StringLength(50)]
        public string Sort6 { get; set; }
        [StringLength(50)]
        public string Sort7 { get; set; }
        [StringLength(50)]
        public string Sort8 { get; set; }
        [StringLength(50)]
        public string MasterPartNo { get; set; }
        [StringLength(50)]
        public string UsePartNo { get; set; }
        [StringLength(50)]
        public string UseWarehouse { get; set; }
        [StringLength(50)]
        public string CorePartNo { get; set; }
        [StringLength(50)]
        public string CoreWarehouse { get; set; }
        [StringLength(50)]
        public string Description { get; set; }
        [StringLength(50)]
        public string Status { get; set; }
        [StringLength(50)]
        public string PriorStatus { get; set; }
        [StringLength(50)]
        public string PartNoAlias { get; set; }
        [StringLength(50)]
        public string Bin { get; set; }
        [StringLength(50)]
        public string Bin1 { get; set; }
        [StringLength(50)]
        public string Bin2 { get; set; }
        [StringLength(50)]
        public string Bin3 { get; set; }
        [StringLength(50)]
        public string Bin4 { get; set; }
        public short? ReturnCode { get; set; }
        public short? Published { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? Weight { get; set; }
        [StringLength(50)]
        public string PartsGroup { get; set; }
        [StringLength(50)]
        public string Rating { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? RatingDate { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? Cost { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? Discount { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? List { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? Internal { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? Warranty { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? Wholesale { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? OldCost { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? OldDiscount { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? OldList { get; set; }
        public short? NoReprice { get; set; }
        public short? NonTaxable { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? FullBin { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? OnHand { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? StartingOnHand { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? Allocated { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? OnOrder { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? BackOrder { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? AbsoluteMin { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? MinStock { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? MaxStock { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? PackageQty { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? BlockQty { get; set; }
        public short? AutoOrder { get; set; }
        public short? CoreFlag { get; set; }
        [StringLength(50)]
        public string CreatedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }
        [StringLength(50)]
        public string ChangedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ChangedDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? StatusDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LastOrder { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LastDemand { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LastSale { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LastPick { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LastRecv { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LastAdjustment { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LastInventory { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LastTransfer { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LastReplenishment { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LastReprice { get; set; }
        public string Comments { get; set; }
        [StringLength(50)]
        public string MonthEndStatus { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? MonthEndQty { get; set; }
        public short? SellAsAlias { get; set; }
        [StringLength(50)]
        public string PreferredVendorNo { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? PreCurrencyCost { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? PreCurrencyDiscount { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? PreCurrencyList { get; set; }
        [StringLength(100)]
        public string ReferenceNo { get; set; }
        [StringLength(100)]
        public string Model { get; set; }
        [StringLength(50)]
        public string CurrencyType { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? PreFreightCustomsCost { get; set; }
        [Column("OldNUmber")]
        [StringLength(50)]
        public string OldNumber { get; set; }
        public short? KitFlag { get; set; }
        public short? NonReturnable { get; set; }
        [StringLength(50)]
        public string PartNoOriginal { get; set; }
        public short? LeadTime { get; set; }
        [StringLength(255)]
        public string UnitDescription { get; set; }
        public short? SerialNoRequired { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? StatusReviewDate { get; set; }
        [StringLength(100)]
        public string DescriptionFrench { get; set; }
        [StringLength(50)]
        public string InvCategory { get; set; }
        public int? LegacyId { get; set; }
        [StringLength(50)]
        public string DefaultTaxCodesParts { get; set; }
        [StringLength(300)]
        public string DefaultTaxCodesPartsDesc { get; set; }
        [Column("SKU")]
        [StringLength(50)]
        public string Sku { get; set; }
        public bool IsMigrated { get; set; }
    }
}
