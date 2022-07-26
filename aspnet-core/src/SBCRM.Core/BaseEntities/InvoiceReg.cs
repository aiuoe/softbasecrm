using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("InvoiceReg", Schema = "web")]
    [Index(nameof(TenantId), Name = "InvoiceReg_TenantId_index")]
    [Index(nameof(InvoiceNo), nameof(TenantId), Name = "UC_InvoiceReg", IsUnique = true)]
    public class InvoiceReg : FullAuditedEntity<long>, IMustHaveTenant
    {
        public int TenantId { get; set; }
        public int InvoiceNo { get; set; }
        public short? SaleBranch { get; set; }
        public short? SaleDept { get; set; }
        [StringLength(50)]
        public string SaleCode { get; set; }
        public short? ExpBranch { get; set; }
        public short? ExpDept { get; set; }
        [StringLength(50)]
        public string ExpCode { get; set; }
        public short? Customer { get; set; }
        public short? GuaranteedMaintenance { get; set; }
        [StringLength(50)]
        public string BillTo { get; set; }
        [StringLength(50)]
        public string BillToName { get; set; }
        [StringLength(50)]
        public string BillToZipCode { get; set; }
        [StringLength(50)]
        public string ShipTo { get; set; }
        [StringLength(50)]
        public string ShipToName { get; set; }
        [StringLength(50)]
        public string ControlNo { get; set; }
        [Column("PONo")]
        [StringLength(50)]
        public string Pono { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? TaxRate { get; set; }
        [StringLength(50)]
        public string PartsRate { get; set; }
        [StringLength(50)]
        public string LaborRate { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? RentalRate { get; set; }
        [StringLength(50)]
        public string SerialNo { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? HourMeter { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? OpenDate { get; set; }
        [StringLength(50)]
        public string OpenBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ClosedDate { get; set; }
        [StringLength(50)]
        public string ClosedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? InvoiceDate { get; set; }
        [StringLength(50)]
        public string RecvAccount { get; set; }
        public short? CopiesPrinted { get; set; }
        public bool? DemandCopyPrinted { get; set; }
        public bool? CopiesComplete { get; set; }
        public bool? DetailCopiesPrinted { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? PartsCost { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? LaborCost { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? MiscCost { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? RentalCost { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? EquipmentCost { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? PartsTaxable { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? LaborTaxable { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? MiscTaxable { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? RentalTaxable { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? EquipmentTaxable { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? PartsNonTax { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? LaborNonTax { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? MiscNonTax { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? RentalNonTax { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? EquipmentNonTax { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? TotalTax { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? GrandTotal { get; set; }
        public string Comments { get; set; }
        [StringLength(50)]
        public string AdTitle { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DateFinalPrinted { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? StateTax { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? CountyTax { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? CityTax { get; set; }
        [StringLength(50)]
        public string PrintSkippedBy { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? OdometerReading { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? LocalTax { get; set; }
        [StringLength(50)]
        public string CurrencyType { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? ConversionRate { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? ConvertedGrandTotal { get; set; }
        public int? NumeroDeFactura { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? StateSpecialTax { get; set; }
        [Column("OB10No")]
        [StringLength(50)]
        public string Ob10no { get; set; }
        [Column("OB10Export")]
        public short? Ob10export { get; set; }
        [Column("TMHUExport")]
        public short? Tmhuexport { get; set; }
        [Column("TMHUNo")]
        [StringLength(50)]
        public string Tmhuno { get; set; }
        public short? PrintSelect { get; set; }
        [Column("TMTExport")]
        public short? Tmtexport { get; set; }
        [Column("TSPull")]
        public int? Tspull { get; set; }
        public bool? BillTrustExclude { get; set; }
        public bool? BillTrustFlag { get; set; }
        public bool IsMigrated { get; set; }
    }
}
