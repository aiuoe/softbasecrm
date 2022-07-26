using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("SaleCodes", Schema = "web")]
    [Index(nameof(TenantId), Name = "SaleCodes_TenantId_index")]
    [Index(nameof(Branch), nameof(Dept), nameof(Code), nameof(TenantId), Name = "UC_SaleCodes", IsUnique = true)]
    public class SaleCode : FullAuditedEntity<long>, IMustHaveTenant
    {
        public int TenantId { get; set; }
        public short Branch { get; set; }
        public short Dept { get; set; }
        [Required]
        [StringLength(50)]
        public string Code { get; set; }
        [StringLength(50)]
        public string PartsCost { get; set; }
        [StringLength(50)]
        public string PartsDiscount { get; set; }
        [StringLength(50)]
        public string PartsList { get; set; }
        [StringLength(50)]
        public string PartsWholesale { get; set; }
        [StringLength(50)]
        public string PartsWarranty { get; set; }
        [StringLength(50)]
        public string PartsInternal { get; set; }
        [StringLength(50)]
        public string Labor { get; set; }
        [StringLength(50)]
        public string Misc { get; set; }
        [StringLength(50)]
        public string Rental { get; set; }
        [StringLength(50)]
        public string Equipment { get; set; }
        [Column("PartsCostCOG")]
        [StringLength(50)]
        public string PartsCostCog { get; set; }
        [Column("PartsDiscountCOG")]
        [StringLength(50)]
        public string PartsDiscountCog { get; set; }
        [Column("PartsListCOG")]
        [StringLength(50)]
        public string PartsListCog { get; set; }
        [Column("PartsWholesaleCOG")]
        [StringLength(50)]
        public string PartsWholesaleCog { get; set; }
        [Column("PartsWarrantyCOG")]
        [StringLength(50)]
        public string PartsWarrantyCog { get; set; }
        [Column("PartsInternalCOG")]
        [StringLength(50)]
        public string PartsInternalCog { get; set; }
        [Column("LaborCOG")]
        [StringLength(50)]
        public string LaborCog { get; set; }
        [Column("MiscCOG")]
        [StringLength(50)]
        public string MiscCog { get; set; }
        [Column("RentalCOG")]
        [StringLength(50)]
        public string RentalCog { get; set; }
        [Column("EquipmentCOG")]
        [StringLength(50)]
        public string EquipmentCog { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? RentalPercent { get; set; }
        [Column("MiscINV")]
        [StringLength(50)]
        public string MiscInv { get; set; }
        public bool PartsTax { get; set; }
        public bool LaborTax { get; set; }
        public bool MiscTax { get; set; }
        public bool RentalTax { get; set; }
        public bool EquipmentTax { get; set; }
        public short? PartsSale { get; set; }
        public short? LaborSale { get; set; }
        public short? MiscSale { get; set; }
        public short? RentalSale { get; set; }
        public short? EquipmentSale { get; set; }
        [StringLength(50)]
        public string GeneralDescription { get; set; }
        [StringLength(50)]
        public string PartsDescription { get; set; }
        [StringLength(50)]
        public string LaborDescription { get; set; }
        [StringLength(50)]
        public string MiscDescription { get; set; }
        [StringLength(50)]
        public string RentalDescription { get; set; }
        [StringLength(50)]
        public string EquipmentDescription { get; set; }
        public bool Customer { get; set; }
        public bool ReWork { get; set; }
        public bool GuaranteedMaintenance { get; set; }
        [StringLength(50)]
        public string CustomerNo { get; set; }
        [StringLength(50)]
        public string LaborRate { get; set; }
        public string Comments { get; set; }
        public bool RentalCostPrompt { get; set; }
        public bool AutoExp { get; set; }
        public short? AutoExpBranch { get; set; }
        public short? AutoExpDept { get; set; }
        [StringLength(50)]
        public string AutoExpCode { get; set; }
        public bool RequireSerialNo { get; set; }
        [StringLength(50)]
        public string LandedAccount { get; set; }
        public bool PartsStateTax { get; set; }
        public bool PartsCountyTax { get; set; }
        public bool PartsCityTax { get; set; }
        public bool PartsLocalTax { get; set; }
        public bool LaborStateTax { get; set; }
        public bool LaborCountyTax { get; set; }
        public bool LaborCityTax { get; set; }
        public bool LaborLocalTax { get; set; }
        public bool MiscStateTax { get; set; }
        public bool MiscCountyTax { get; set; }
        public bool MiscCityTax { get; set; }
        public bool MiscLocalTax { get; set; }
        public bool RentalStateTax { get; set; }
        public bool RentalCountyTax { get; set; }
        public bool RentalCityTax { get; set; }
        public bool RentalLocalTax { get; set; }
        public bool EqStateTax { get; set; }
        public bool EqCountyTax { get; set; }
        public bool EqCityTax { get; set; }
        public bool EqLocalTax { get; set; }
        [StringLength(100)]
        public string AddedBy { get; set; }
        [StringLength(100)]
        public string ChangedBy { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? MiscMarkup { get; set; }
        public bool ExcludeCredit { get; set; }
        [StringLength(50)]
        public string SubTotalType { get; set; }
        public bool TravelTime { get; set; }
        public bool LostTime { get; set; }
        [StringLength(50)]
        public string DefaultTaxCodesParts { get; set; }
        [StringLength(300)]
        public string DefaultTaxCodesPartsDesc { get; set; }
        [StringLength(50)]
        public string DefaultTaxCodesLabor { get; set; }
        [StringLength(300)]
        public string DefaultTaxCodesLaborDesc { get; set; }
        [StringLength(50)]
        public string DefaultTaxCodesMisc { get; set; }
        [StringLength(300)]
        public string DefaultTaxCodesMiscDesc { get; set; }
        [StringLength(50)]
        public string DefaultTaxCodesRental { get; set; }
        [StringLength(300)]
        public string DefaultTaxCodesRentalDesc { get; set; }
        [StringLength(50)]
        public string DefaultTaxCodesEquip { get; set; }
        [StringLength(300)]
        public string DefaultTaxCodesEquipDesc { get; set; }
        public bool IsMigrated { get; set; }
    }
}
