using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("Equipment", Schema = "web")]
    [Index(nameof(TenantId), Name = "Equipment_TenantId_index")]
    [Index(nameof(SerialNo), nameof(TenantId), Name = "UC_Equipment", IsUnique = true)]
    public class Equipment : FullAuditedEntity<long>, IMustHaveTenant
    {
        [Required]
        [StringLength(100)]
        public string SerialNo { get; set; }
        [StringLength(50)]
        public string Make { get; set; }
        [StringLength(50)]
        public string Model { get; set; }
        [StringLength(50)]
        public string ModelGroup { get; set; }
        [StringLength(50)]
        public string UnitNo { get; set; }
        [StringLength(50)]
        public string AttachedTo { get; set; }
        [StringLength(50)]
        public string Location { get; set; }
        [StringLength(50)]
        public string CustomerNo { get; set; }
        public bool Customer { get; set; }
        [StringLength(50)]
        public string InventoryAccount { get; set; }
        public short? InventoryBranch { get; set; }
        public short? InventoryDept { get; set; }
        public short? AttachmentInventory { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? Cost { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? Sell { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? AsIsWholesale { get; set; }
        [Column("DRWholesale", TypeName = "decimal(19, 4)")]
        public decimal? Drwholesale { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? Retail { get; set; }
        public bool PublishedPrice { get; set; }
        public bool WholesaleList { get; set; }
        public bool RetailList { get; set; }
        [StringLength(50)]
        public string Bid1Name { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? Bid1Amount { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? Bid1Date { get; set; }
        [StringLength(50)]
        public string Bid2Name { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? Bid2Amount { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? Bid2Date { get; set; }
        [StringLength(50)]
        public string Bid3Name { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? Bid3Amount { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? Bid3Date { get; set; }
        [StringLength(50)]
        public string RentalRateCode { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? DayRent { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? WeekRent { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? FourWeekRent { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? MonthRent { get; set; }
        [StringLength(50)]
        public string RentalStatus { get; set; }
        [StringLength(50)]
        public string RentalStatusComment { get; set; }
        [StringLength(50)]
        public string ModelYear { get; set; }
        [StringLength(50)]
        public string ModelAge { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? Capacity { get; set; }
        [StringLength(50)]
        public string Power { get; set; }
        public bool FieldDiversion { get; set; }
        [Column("SRNo")]
        [StringLength(50)]
        public string Srno { get; set; }
        [Column("PONo")]
        [StringLength(50)]
        public string Pono { get; set; }
        public bool FloorPlan { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? FloorPlanPaid { get; set; }
        [StringLength(50)]
        public string UprightSerialNo { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? UprightDownHeight { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? UprightHeight { get; set; }
        [StringLength(50)]
        public string UprightStage { get; set; }
        [StringLength(50)]
        public string TireType { get; set; }
        [StringLength(50)]
        public string SpecForks { get; set; }
        [StringLength(50)]
        public string SpecStatus { get; set; }
        [StringLength(50)]
        public string SpecAttatchments { get; set; }
        [StringLength(50)]
        public string SpecTransmission { get; set; }
        [StringLength(255)]
        public string SpecComments { get; set; }
        [StringLength(255)]
        public string SpecWarranty { get; set; }
        [Column("SpecLBR")]
        public bool SpecLbr { get; set; }
        [StringLength(50)]
        public string SpecTirePercent { get; set; }
        public bool SpecDealerReady { get; set; }
        [StringLength(255)]
        public string SpecSource { get; set; }
        [StringLength(255)]
        public string SpecRetailComments { get; set; }
        [StringLength(50)]
        public string EngineSerialNo { get; set; }
        [StringLength(50)]
        public string TransSerialNo { get; set; }
        [StringLength(50)]
        public string SteerAxilSerialNo { get; set; }
        public string AdditionalSerialNo { get; set; }
        [Column("WOInstructions")]
        public string Woinstructions { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? LastHourMeter { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LastHourMeterDate { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? HourMeterHistory { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? HourMeterStart { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? HourMeterStartDate { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? LastOdometer { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LastOdometerDate { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? OdometerHistory { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? OdometerStart { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? OdometerStartDate { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? TotalFuel { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? TotalFuelDate { get; set; }
        public bool FuelRequireHour { get; set; }
        public bool FuelRequireOdometer { get; set; }
        [Column("LastWOOpen")]
        public long? LastWoopen { get; set; }
        [Column("LastWOOpenDate", TypeName = "datetime")]
        public DateTime? LastWoopenDate { get; set; }
        [Column("LastWOClosed")]
        public int? LastWoclosed { get; set; }
        [Column("LastWOClosedDate", TypeName = "datetime")]
        public DateTime? LastWoclosedDate { get; set; }
        public int? LastRentalClosed { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LastRentalClosedDate { get; set; }
        public long? LastEquipmentClosed { get; set; }
        public int? LastEquipmentClosedTerr { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LastEquipmentClosedDate { get; set; }
        public int? LastEquipmentSalesman { get; set; }
        [StringLength(50)]
        public string LastEquipmentCostAccount { get; set; }
        public int? LastServiceClosed { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LastServiceClosedDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DealerAquisitionDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DealerRecvDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DealerSaleDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DealerWarrantyDate { get; set; }
        [StringLength(50)]
        public string DealerWarrantyCode { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DealerPaidDate { get; set; }
        public short? DealerPaid { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CustomerAquisitionDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CustomerRecvDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CustomerWarrantyDate { get; set; }
        [StringLength(50)]
        public string CustomerWarrantyCode { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LeaseExpirationDate { get; set; }
        [StringLength(50)]
        public string CustomerLaborRate { get; set; }
        [StringLength(50)]
        public string CustomerShopLaborRate { get; set; }
        [Column("ServiceITD", TypeName = "decimal(19, 4)")]
        public decimal? ServiceItd { get; set; }
        [Column("PartsITD", TypeName = "decimal(19, 4)")]
        public decimal? PartsItd { get; set; }
        [Column("LaborITD", TypeName = "decimal(19, 4)")]
        public decimal? LaborItd { get; set; }
        [Column("MiscITD", TypeName = "decimal(19, 4)")]
        public decimal? MiscItd { get; set; }
        [Column("IncomeITD", TypeName = "decimal(19, 4)")]
        public decimal? IncomeItd { get; set; }
        [Column("RentalITD", TypeName = "decimal(19, 4)")]
        public decimal? RentalItd { get; set; }
        [Column("ServiceITDCost", TypeName = "decimal(19, 4)")]
        public decimal? ServiceItdcost { get; set; }
        [Column("PartsITDCost", TypeName = "decimal(19, 4)")]
        public decimal? PartsItdcost { get; set; }
        [Column("LaborITDCost", TypeName = "decimal(19, 4)")]
        public decimal? LaborItdcost { get; set; }
        [Column("MiscITDCost", TypeName = "decimal(19, 4)")]
        public decimal? MiscItdcost { get; set; }
        [Column("IncomeITDCost", TypeName = "decimal(19, 4)")]
        public decimal? IncomeItdcost { get; set; }
        [Column("ServiceYTD", TypeName = "decimal(19, 4)")]
        public decimal? ServiceYtd { get; set; }
        [Column("PartsYTD", TypeName = "decimal(19, 4)")]
        public decimal? PartsYtd { get; set; }
        [Column("LaborYTD", TypeName = "decimal(19, 4)")]
        public decimal? LaborYtd { get; set; }
        [Column("MiscYTD", TypeName = "decimal(19, 4)")]
        public decimal? MiscYtd { get; set; }
        [Column("IncomeYTD", TypeName = "decimal(19, 4)")]
        public decimal? IncomeYtd { get; set; }
        [Column("RentalYTD", TypeName = "decimal(19, 4)")]
        public decimal? RentalYtd { get; set; }
        [Column("ServiceYTDCost", TypeName = "decimal(19, 4)")]
        public decimal? ServiceYtdcost { get; set; }
        [Column("PartsYTDCost", TypeName = "decimal(19, 4)")]
        public decimal? PartsYtdcost { get; set; }
        [Column("LaborYTDCost", TypeName = "decimal(19, 4)")]
        public decimal? LaborYtdcost { get; set; }
        [Column("MiscYTDCost", TypeName = "decimal(19, 4)")]
        public decimal? MiscYtdcost { get; set; }
        [Column("IncomeYTDCost", TypeName = "decimal(19, 4)")]
        public decimal? IncomeYtdcost { get; set; }
        [Column("InternalServiceITD", TypeName = "decimal(19, 4)")]
        public decimal? InternalServiceItd { get; set; }
        [Column("InternalPartsITD", TypeName = "decimal(19, 4)")]
        public decimal? InternalPartsItd { get; set; }
        [Column("InternalLaborITD", TypeName = "decimal(19, 4)")]
        public decimal? InternalLaborItd { get; set; }
        [Column("InternalMiscITD", TypeName = "decimal(19, 4)")]
        public decimal? InternalMiscItd { get; set; }
        [Column("InternalIncomeITD", TypeName = "decimal(19, 4)")]
        public decimal? InternalIncomeItd { get; set; }
        [Column("InternalRentalITD", TypeName = "decimal(19, 4)")]
        public decimal? InternalRentalItd { get; set; }
        [Column("InternalServiceITDCost", TypeName = "decimal(19, 4)")]
        public decimal? InternalServiceItdcost { get; set; }
        [Column("InternalPartsITDCost", TypeName = "decimal(19, 4)")]
        public decimal? InternalPartsItdcost { get; set; }
        [Column("InternalLaborITDCost", TypeName = "decimal(19, 4)")]
        public decimal? InternalLaborItdcost { get; set; }
        [Column("InternalMiscITDCost", TypeName = "decimal(19, 4)")]
        public decimal? InternalMiscItdcost { get; set; }
        [Column("InternalIncomeITDCost", TypeName = "decimal(19, 4)")]
        public decimal? InternalIncomeItdcost { get; set; }
        [Column("InternalServiceYTD", TypeName = "decimal(19, 4)")]
        public decimal? InternalServiceYtd { get; set; }
        [Column("InternalPartsYTD", TypeName = "decimal(19, 4)")]
        public decimal? InternalPartsYtd { get; set; }
        [Column("InternalLaborYTD", TypeName = "decimal(19, 4)")]
        public decimal? InternalLaborYtd { get; set; }
        [Column("InternalMiscYTD", TypeName = "decimal(19, 4)")]
        public decimal? InternalMiscYtd { get; set; }
        [Column("InternalIncomeYTD", TypeName = "decimal(19, 4)")]
        public decimal? InternalIncomeYtd { get; set; }
        [Column("InternalRentalYTD", TypeName = "decimal(19, 4)")]
        public decimal? InternalRentalYtd { get; set; }
        [Column("InternalServiceYTDCost", TypeName = "decimal(19, 4)")]
        public decimal? InternalServiceYtdcost { get; set; }
        [Column("InternalPartsYTDCost", TypeName = "decimal(19, 4)")]
        public decimal? InternalPartsYtdcost { get; set; }
        [Column("InternalLaborYTDCost", TypeName = "decimal(19, 4)")]
        public decimal? InternalLaborYtdcost { get; set; }
        [Column("InternalMiscYTDCost", TypeName = "decimal(19, 4)")]
        public decimal? InternalMiscYtdcost { get; set; }
        [Column("InternalIncomeYTDCost", TypeName = "decimal(19, 4)")]
        public decimal? InternalIncomeYtdcost { get; set; }
        public bool GuaranteedMaintenance { get; set; }
        [Column("GMService", TypeName = "decimal(19, 4)")]
        public decimal? Gmservice { get; set; }
        [Column("GMParts", TypeName = "decimal(19, 4)")]
        public decimal? Gmparts { get; set; }
        [Column("GMLabor", TypeName = "decimal(19, 4)")]
        public decimal? Gmlabor { get; set; }
        [Column("GMMisc", TypeName = "decimal(19, 4)")]
        public decimal? Gmmisc { get; set; }
        [Column("GMIncome", TypeName = "decimal(19, 4)")]
        public decimal? Gmincome { get; set; }
        [Column("GMPeriods")]
        public bool Gmperiods { get; set; }
        [Column("GMPeriodsBilled")]
        public bool GmperiodsBilled { get; set; }
        [Column("GMStartDate", TypeName = "datetime")]
        public DateTime? GmstartDate { get; set; }
        [Column("LastGM", TypeName = "datetime")]
        public DateTime? LastGm { get; set; }
        [Column("LastYTDRoll", TypeName = "datetime")]
        public DateTime? LastYtdroll { get; set; }
        [Column("LastYTDRollBy")]
        [StringLength(50)]
        public string LastYtdrollBy { get; set; }
        public string Comments { get; set; }
        [StringLength(50)]
        public string UprightModel { get; set; }
        [StringLength(50)]
        public string UprightLot { get; set; }
        public bool OrderBooked { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CustomerMajorWarrantyDate { get; set; }
        [StringLength(50)]
        public string PictureFile { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DealerOrderDate { get; set; }
        public bool OnOrder { get; set; }
        [StringLength(50)]
        public string SpecInternalHosing { get; set; }
        [StringLength(50)]
        public string DeprAccount { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CustomerExtendedWarrantyDate { get; set; }
        [StringLength(50)]
        public string FloorPlanNo { get; set; }
        [Column("RENo")]
        [StringLength(50)]
        public string Reno { get; set; }
        [StringLength(50)]
        public string FinancingNo { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? QuarterRent { get; set; }
        [StringLength(50)]
        public string SpecTireSize { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }
        [StringLength(50)]
        public string CreatedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? UpdateDate { get; set; }
        [StringLength(50)]
        public string UpdatedBy { get; set; }
        [StringLength(50)]
        public string SpecValves { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? HoursAllowed { get; set; }
        [Column("GMLastInvoiceNo")]
        public int? GmlastInvoiceNo { get; set; }
        [Column("OTRatePerHour", TypeName = "decimal(19, 4)")]
        public decimal? OtratePerHour { get; set; }
        public bool SpecBattery { get; set; }
        public bool SpecCharger { get; set; }
        public bool WebRentalFlag { get; set; }
        public bool WebUsedFlag { get; set; }
        [StringLength(200)]
        public string AcquiredFrom { get; set; }
        [StringLength(50)]
        public string ControlNo { get; set; }
        [Column("DealerETA", TypeName = "datetime")]
        public DateTime? DealerEta { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CustomerRequiredDate { get; set; }
        [StringLength(100)]
        public string LeaseCompany { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? LeasePayment { get; set; }
        public bool LeaseTerm { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? LeaseResidual { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? LeaseAmount { get; set; }
        [StringLength(100)]
        public string LeaseNo { get; set; }
        [StringLength(50)]
        public string LoadCenter { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? MaintPayment { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? HoursPerWorkday { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? WeeksPerYear { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? DaysPerWeek { get; set; }
        [Column("PPSANo")]
        [StringLength(50)]
        public string Ppsano { get; set; }
        [Column("PPSAExpDate", TypeName = "datetime")]
        public DateTime? PpsaexpDate { get; set; }
        [Column("PPSACustomerNo")]
        [StringLength(50)]
        public string PpsacustomerNo { get; set; }
        [Column("PPSA")]
        public short? Ppsa { get; set; }
        [StringLength(100)]
        public string ExtendedWarrantyApplicationNo { get; set; }
        public bool InsuranceRequired { get; set; }
        public bool InsuranceCoverage { get; set; }
        [StringLength(50)]
        public string TireDriveSize { get; set; }
        [StringLength(50)]
        public string TireSteerSize { get; set; }
        [StringLength(50)]
        public string BatteryVoltage { get; set; }
        [StringLength(50)]
        public string BatteryConnector { get; set; }
        [StringLength(50)]
        public string EngineMake { get; set; }
        [StringLength(50)]
        public string EngineModel { get; set; }
        [StringLength(50)]
        public string InTransitAccountNo { get; set; }
        [StringLength(50)]
        public string SpecFreeLift { get; set; }
        [StringLength(50)]
        public string SpecEngineType { get; set; }
        public int? DeliveryNo { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DeliveryDate { get; set; }
        public int? RentalDays { get; set; }
        public int? TransportationHours { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? DeliveryCharge { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? ReturnCharge { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? DeliveryHourMeter { get; set; }
        [StringLength(50)]
        public string ImportNo { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ImportDate { get; set; }
        [StringLength(50)]
        public string UprightScale { get; set; }
        [Column("WOComments")]
        public string Wocomments { get; set; }
        [Column("ITAState")]
        [StringLength(50)]
        public string Itastate { get; set; }
        [Column("ITACounty")]
        [StringLength(50)]
        public string Itacounty { get; set; }
        [Column("ITASIC")]
        [StringLength(50)]
        public string Itasic { get; set; }
        [StringLength(50)]
        public string StockType { get; set; }
        public bool CommissionPaid { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? SpecWeight { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CustomerEnrollmentDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CustomerOrderDate { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? TargetCostPerHour { get; set; }
        [StringLength(100)]
        public string TireDescription { get; set; }
        public bool RerentFlag { get; set; }
        public bool RerentHere { get; set; }
        [StringLength(100)]
        public string FloorPlanBank { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? FloorPlanAmount { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? FloorPlanStartDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LeaseStartDate { get; set; }
        [StringLength(100)]
        public string LastDeliveryName { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LastDeliveryDate { get; set; }
        public bool NonTaxable { get; set; }
        [StringLength(50)]
        public string PartNo { get; set; }
        [StringLength(50)]
        public string GenHousingType { get; set; }
        [StringLength(50)]
        public string GenRating { get; set; }
        [StringLength(50)]
        public string GenPhase { get; set; }
        [StringLength(50)]
        public string GenFuelType { get; set; }
        [StringLength(50)]
        public string GenCondition { get; set; }
        [StringLength(50)]
        public string GenVoltage { get; set; }
        [StringLength(50)]
        public string GenInventoryStatus { get; set; }
        [StringLength(50)]
        public string GenEndSerialNo { get; set; }
        [StringLength(50)]
        public string GenEndModel { get; set; }
        [StringLength(50)]
        public string GenEndMake { get; set; }
        [StringLength(50)]
        public string GenFrequency { get; set; }
        [Column("GenRPM")]
        [StringLength(50)]
        public string GenRpm { get; set; }
        [Column("GenFuelTankID")]
        [StringLength(50)]
        public string GenFuelTankId { get; set; }
        [Column("GenEPATier")]
        [StringLength(50)]
        public string GenEpatier { get; set; }
        public bool LeaseFlag { get; set; }
        [Column("LeasePONo")]
        [StringLength(50)]
        public string LeasePono { get; set; }
        [StringLength(100)]
        public string ModelShort { get; set; }
        [Column("eLiftTruck")]
        public bool ELiftTruck { get; set; }
        [Column("eMake")]
        [StringLength(50)]
        public string EMake { get; set; }
        [Column("eType")]
        [StringLength(50)]
        public string EType { get; set; }
        [Column("eEngine")]
        [StringLength(50)]
        public string EEngine { get; set; }
        [Column("eMastType")]
        [StringLength(50)]
        public string EMastType { get; set; }
        [Column("eOther")]
        [StringLength(1024)]
        public string EOther { get; set; }
        [Column("eState")]
        [StringLength(50)]
        public string EState { get; set; }
        [Column(TypeName = "text")]
        public string MobileRecommended { get; set; }
        public short? TradeIn { get; set; }
        public int? LoadBankTested { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LoadTestDate { get; set; }
        [StringLength(50)]
        public string LoadTestVoltage { get; set; }
        [Column("RentalOTRate", TypeName = "decimal(19, 4)")]
        public decimal? RentalOtrate { get; set; }
        public bool UnitInOperation { get; set; }
        [Column("TShardware_id")]
        [StringLength(45)]
        public string TshardwareId { get; set; }
        public bool? TrackingSolutions { get; set; }
        [Column("LegacyID")]
        public int? LegacyId { get; set; }
        public int TenantId { get; set; }
        public bool IsMigrated { get; set; }
    }
}
