using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("EQControlNoChange", Schema = "web")]
    [Index(nameof(TenantId), Name = "EQControlNoChange_TenantId_index")]
    [Index(nameof(SerialNo), nameof(ControlNo), nameof(TenantId), Name = "UC_EQControlNoChange", IsUnique = true)]
    public class EqcontrolNoChange : FullAuditedEntity<long>, IMustHaveTenant
    {
        public int LegacyId { get; set; }
        [Required]
        [StringLength(100)]
        public string SerialNo { get; set; }
        [Required]
        [StringLength(50)]
        public string ControlNo { get; set; }
        [Column("LastWOOpen")]
        public int? LastWoopen { get; set; }
        [Column("LastWOClosed")]
        public int? LastWoclosed { get; set; }
        public int? LastRentalClosed { get; set; }
        public int? LastEquipmentClosed { get; set; }
        [StringLength(50)]
        public string LastEquipmentCostAccount { get; set; }
        public int? LastServiceClosed { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DealerOrderDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DealerAquisitionDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DealerRecvDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DealerSaleDate { get; set; }
        public bool CommissionPaid { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DealerWarrantyDate { get; set; }
        [StringLength(50)]
        public string DealerWarrantyCode { get; set; }
        [Column("DealerETA", TypeName = "datetime")]
        public DateTime? DealerEta { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DealerPaidDate { get; set; }
        public bool DealerPaid { get; set; }
        [Column("ITAState")]
        [StringLength(50)]
        public string Itastate { get; set; }
        [Column("ITACounty")]
        [StringLength(50)]
        public string Itacounty { get; set; }
        [Column("ITASIC")]
        [StringLength(50)]
        public string Itasic { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CustomerOrderDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CustomerAquisitionDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CustomerRecvDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CustomerWarrantyDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CustomerMajorWarrantyDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CustomerExtendedWarrantyDate { get; set; }
        [StringLength(50)]
        public string ExtendedWarrantyApplicationNo { get; set; }
        [StringLength(50)]
        public string CustomerWarrantyCode { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CustomerRequiredDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CustomerEnrollmentDate { get; set; }
        [Column("PPSA")]
        public short? Ppsa { get; set; }
        [Column("PPSANo")]
        [StringLength(50)]
        public string Ppsano { get; set; }
        [Column("PPSACustomerNo")]
        [StringLength(50)]
        public string PpsacustomerNo { get; set; }
        [Column("PPSAExpDate", TypeName = "datetime")]
        public DateTime? PpsaexpDate { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? Cost { get; set; }
        public bool TradeIn { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? Sell { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? AsIsWholesale { get; set; }
        [Column("DRWholesale", TypeName = "decimal(19, 4)")]
        public decimal? Drwholesale { get; set; }
        public bool SpecDealerReady { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? Retail { get; set; }
        public bool PublishedPrice { get; set; }
        public bool WholesaleList { get; set; }
        public bool RetailList { get; set; }
        [StringLength(50)]
        public string CustomerLaborRate { get; set; }
        [StringLength(50)]
        public string CustomerShopLaborRate { get; set; }
        public bool NonTaxable { get; set; }
        public bool UnitInOperation { get; set; }
        public bool WebRentalFlag { get; set; }
        public bool WebUsedFlag { get; set; }
        [Column("SRNo")]
        [StringLength(50)]
        public string Srno { get; set; }
        [Column("PONo")]
        [StringLength(50)]
        public string Pono { get; set; }
        public bool FloorPlan { get; set; }
        [StringLength(50)]
        public string FloorPlanNo { get; set; }
        [StringLength(100)]
        public string FloorPlanBank { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? FloorPlanAmount { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? FloorPlanStartDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? FloorPlanPaid { get; set; }
        [Column("RENo")]
        [StringLength(50)]
        public string Reno { get; set; }
        [StringLength(50)]
        public string FinancingNo { get; set; }
        [StringLength(50)]
        public string ImportNo { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ImportDate { get; set; }
        [StringLength(100)]
        public string LeaseCompany { get; set; }
        public bool LeaseFlag { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? LeasePayment { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LeaseStartDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LeaseExpirationDate { get; set; }
        public bool LeaseTerm { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? LeaseResidual { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? LeaseAmount { get; set; }
        [StringLength(100)]
        public string LeaseNo { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? HoursPerWorkday { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? DaysPerWeek { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? WeeksPerYear { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? MaintPayment { get; set; }
        [Column("LeasePONo")]
        [StringLength(50)]
        public string LeasePono { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DateAdded { get; set; }
        [StringLength(100)]
        public string AddedBy { get; set; }
        public int TenantId { get; set; }
        public bool IsMigrated { get; set; }
    }
}
