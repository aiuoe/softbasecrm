using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("WO", Schema = "web")]
    [Index(nameof(TenantId), Name = "WO_TenantId_index")]
    public class Wo : FullAuditedEntity<long>, IMustHaveTenant
    {
        public int TenantId { get; set; }
        [Column("WONo")]
        public int Wono { get; set; }
        public short? Disposition { get; set; }
        public short? SaleBranch { get; set; }
        public short? SaleDept { get; set; }
        [StringLength(50)]
        public string SaleCode { get; set; }
        public short? ExpBranch { get; set; }
        public short? ExpDept { get; set; }
        [StringLength(50)]
        public string ExpCode { get; set; }
        [StringLength(50)]
        public string ExpAccount { get; set; }
        public bool? CustomerSale { get; set; }
        public bool? GuaranteedMaintenance { get; set; }
        [StringLength(50)]
        public string Type { get; set; }
        [Column("ContinueWO")]
        public bool? ContinueWo { get; set; }
        [StringLength(50)]
        public string BillTo { get; set; }
        [StringLength(50)]
        public string BillContact { get; set; }
        [StringLength(50)]
        public string Terms { get; set; }
        [StringLength(50)]
        public string ShipTo { get; set; }
        [StringLength(50)]
        public string ShipName { get; set; }
        [StringLength(50)]
        public string ShipSubName { get; set; }
        [StringLength(50)]
        public string ShipAddress { get; set; }
        [StringLength(50)]
        public string ShipCity { get; set; }
        [StringLength(50)]
        public string ShipState { get; set; }
        [StringLength(50)]
        public string ShipZipCode { get; set; }
        [StringLength(50)]
        public string ShipPhone { get; set; }
        [StringLength(50)]
        public string ShipContact { get; set; }
        [StringLength(50)]
        public string Salesman { get; set; }
        [StringLength(50)]
        public string Technician { get; set; }
        [StringLength(75)]
        public string Writer { get; set; }
        public int? ReWorkTechnician { get; set; }
        [Column("AssociatedWONo")]
        public int? AssociatedWono { get; set; }
        [StringLength(50)]
        public string ControlNo { get; set; }
        [Column("PONo")]
        [StringLength(50)]
        public string Pono { get; set; }
        public bool? Taxable { get; set; }
        [StringLength(50)]
        public string TaxCode { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? TaxRate { get; set; }
        [StringLength(50)]
        public string TaxAccount { get; set; }
        [StringLength(50)]
        public string PartsRate { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? PartsRateDiscount { get; set; }
        [StringLength(50)]
        public string LaborRate { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? RentalRate { get; set; }
        [StringLength(50)]
        public string SerialNo { get; set; }
        [StringLength(50)]
        public string Make { get; set; }
        [StringLength(50)]
        public string Model { get; set; }
        [StringLength(50)]
        public string ModelGroup { get; set; }
        [StringLength(50)]
        public string UnitNo { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? Capacity { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? HourMeter { get; set; }
        [Column("PMDueDate", TypeName = "datetime")]
        public DateTime? PmdueDate { get; set; }
        [StringLength(50)]
        public string WarrantyCode { get; set; }
        [StringLength(50)]
        public string ServiceVan { get; set; }
        [StringLength(50)]
        public string ServiceZone { get; set; }
        [StringLength(50)]
        public string RepairGroup { get; set; }
        [StringLength(50)]
        public string RepairCode { get; set; }
        public bool? Authorized { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ShopRecvDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ShopSoldDate { get; set; }
        [StringLength(50)]
        public string ShopStatus { get; set; }
        [StringLength(255)]
        public string ShopComments { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ShopAdditionalQuoteDate { get; set; }
        public string ShopDelayComments { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ShopEstimatedCompletionDate { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? ShopEstimatedLaborHours { get; set; }
        public string ShopMiscComments { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? ShopQuoteAmount { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ShopQuoteDate { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? ShopQuoteHours { get; set; }
        public bool? ShopRentalGiven { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ShopRevisedCompletionDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ShopSignedDate { get; set; }
        [StringLength(50)]
        public string MapLocation { get; set; }
        [StringLength(50)]
        public string RentalPeriod { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? RentalStart { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? RentalEnd { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? OpenDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ChangedDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ClosedDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? InvoiceDate { get; set; }
        [StringLength(50)]
        public string OpenBy { get; set; }
        [StringLength(50)]
        public string ChangedBy { get; set; }
        [StringLength(50)]
        public string ClosedBy { get; set; }
        public short? PrintCount { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LastPrint { get; set; }
        [StringLength(50)]
        public string LastPrintedBy { get; set; }
        [StringLength(50)]
        public string ShipVia { get; set; }
        [Column("FOB")]
        [StringLength(50)]
        public string Fob { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DeliveryDate { get; set; }
        [StringLength(50)]
        public string LastMechanic { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LastPartsDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LastLaborDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LastMiscDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LastRentalDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LastEquipmentDate { get; set; }
        public short? CreditFlag { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? CreditAmount { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreditDate { get; set; }
        [StringLength(50)]
        public string CreditBy { get; set; }
        public string Comments { get; set; }
        [StringLength(50)]
        public string AdTitle { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? CreditRequested { get; set; }
        [StringLength(50)]
        public string StateTaxCode { get; set; }
        [StringLength(50)]
        public string CountyTaxCode { get; set; }
        [StringLength(50)]
        public string CityTaxCode { get; set; }
        public bool? AbsoluteTaxCodes { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? StateTaxRate { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? CountyTaxRate { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? CityTaxRate { get; set; }
        [StringLength(50)]
        public string StateTaxAccount { get; set; }
        [StringLength(50)]
        public string CountyTaxAccount { get; set; }
        [StringLength(50)]
        public string CityTaxAccount { get; set; }
        [Column("PMName")]
        [StringLength(50)]
        public string Pmname { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? HourMeterDate { get; set; }
        public bool? Dispatched { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DispatchedDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CompletedDate { get; set; }
        [StringLength(50)]
        public string DispatchedBy { get; set; }
        public bool? PaperWorkComplete { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? PaperWorkDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ArrivalDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CallDate { get; set; }
        [Column("InvToCOG")]
        public bool? InvToCog { get; set; }
        [Column("InvToCOGInvoiceNo")]
        public int? InvToCoginvoiceNo { get; set; }
        public int? RentalContractNo { get; set; }
        [StringLength(50)]
        public string FormOfPayment { get; set; }
        [Column("FOPNumber")]
        [StringLength(50)]
        public string Fopnumber { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? OdometerReading { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? OdometerReadingDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ScheduleDate { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? ScheduleHours { get; set; }
        [Column("FOPExpiration")]
        [StringLength(50)]
        public string Fopexpiration { get; set; }
        [StringLength(50)]
        public string LocalTaxCode { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? LocalTaxRate { get; set; }
        [StringLength(50)]
        public string LocalTaxAccount { get; set; }
        public string PrivateComments { get; set; }
        [StringLength(50)]
        public string CurrencyType { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? ConversionRate { get; set; }
        [StringLength(100)]
        public string BuildPartNo { get; set; }
        [StringLength(100)]
        public string BuildWarehouse { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? BuildQuantity { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? UtilizationDays { get; set; }
        public bool? FirstTimeCompletion { get; set; }
        [StringLength(50)]
        public string DispatchStatus { get; set; }
        [StringLength(50)]
        public string DispatchCheckin { get; set; }
        [StringLength(100)]
        public string FinancedBy { get; set; }
        public bool? ReDispatched { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ReDispatchedDate { get; set; }
        [StringLength(100)]
        public string ReDispatchedBy { get; set; }
        public bool? OnSite { get; set; }
        public int? NumeroDeFactura { get; set; }
        [Column("RONo")]
        [StringLength(50)]
        public string Rono { get; set; }
        [StringLength(50)]
        public string QuoteType { get; set; }
        public bool? Reversed { get; set; }
        public string ReplaceInvoiceComments { get; set; }
        public short? SequenceNo { get; set; }
        [Column("OriginalWONo")]
        public int? OriginalWono { get; set; }
        public bool? Abuse { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? LaborDiscount { get; set; }
        [StringLength(50)]
        public string TrackingNo { get; set; }
        [StringLength(100)]
        public string AuthorizedBy { get; set; }
        [StringLength(50)]
        public string ModelYear { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ShopQuoteDeclinedDate { get; set; }
        public bool? ShopInboundDroppedOff { get; set; }
        public bool? ShopInboundPickedUp { get; set; }
        public bool? ShopOutboundDroppedOff { get; set; }
        public bool? ShopOutboundPickedUp { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ShopDateIn { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ShopWorkStarted { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? ShopApprovedAmount { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? StateTaxRateRental { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? CountyTaxRateRental { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? CityTaxRateRental { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? LocalTaxRateRental { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? StateTaxRateEquip { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? CountyTaxRateEquip { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? CityTaxRateEquip { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? LocalTaxRateEquip { get; set; }
        [StringLength(50)]
        public string RepSite { get; set; }
        [StringLength(50)]
        public string RepClass { get; set; }
        public short? FedExExport { get; set; }
        public short? FedExExported { get; set; }
        public bool? DispatchTag { get; set; }
        [Column(TypeName = "text")]
        public string MobileRecommended { get; set; }
        public int? EmailCount { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LastEmail { get; set; }
        [StringLength(100)]
        public string LastEmailedBy { get; set; }
        [Column("FOPCVV")]
        [StringLength(50)]
        public string Fopcvv { get; set; }
        [StringLength(50)]
        public string AltCustomerNo { get; set; }
        [StringLength(50)]
        public string ServicePriority { get; set; }
        [StringLength(100)]
        public string AccountingNote { get; set; }
        public int? DispatchPriority { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? StateTaxRateLabor { get; set; }
        [StringLength(400)]
        public string ShipEmailAddress { get; set; }
        [Column("NoCC")]
        public bool? NoCc { get; set; }
        public int? QuoteHoldParts { get; set; }
        [Column("eRentNo")]
        public long? ERentNo { get; set; }
        [Column("zShopPartsOrderDate", TypeName = "datetime")]
        public DateTime? ZShopPartsOrderDate { get; set; }
        [Column("zShopPartsRecvDate", TypeName = "datetime")]
        public DateTime? ZShopPartsRecvDate { get; set; }
        [Column("zShopPartsHoldDate", TypeName = "datetime")]
        public DateTime? ZShopPartsHoldDate { get; set; }
        [Column("zSpotDate", TypeName = "datetime")]
        public DateTime? ZSpotDate { get; set; }
        [Column("zShopEqptHoldDate", TypeName = "datetime")]
        public DateTime? ZShopEqptHoldDate { get; set; }
        [Column("zShopUnitHoldDate", TypeName = "datetime")]
        public DateTime? ZShopUnitHoldDate { get; set; }
        [Column("zShopWorkSuspended", TypeName = "datetime")]
        public DateTime? ZShopWorkSuspended { get; set; }
        public bool IsMigrated { get; set; }
    }
}
