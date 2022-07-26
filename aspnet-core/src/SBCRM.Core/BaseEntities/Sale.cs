using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("Sales", Schema = "web")]
    [Index(nameof(TenantId), Name = "Sales_TenantId_index")]
    [Index(nameof(CustomerNo), nameof(TenantId), Name = "UC_Sales", IsUnique = true)]
    public class Sale : FullAuditedEntity<long>, IMustHaveTenant
    {
        public int TenantId { get; set; }
        [Required]
        [StringLength(50)]
        public string CustomerNo { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? CreditLimit { get; set; }
        [Column("WIP", TypeName = "decimal(19, 4)")]
        public decimal? Wip { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? Balance { get; set; }
        [Column("ITD", TypeName = "decimal(19, 4)")]
        public decimal? Itd { get; set; }
        [Column("TaxITD", TypeName = "decimal(19, 4)")]
        public decimal? TaxItd { get; set; }
        [Column("PartsITD", TypeName = "decimal(19, 4)")]
        public decimal? PartsItd { get; set; }
        [Column("LaborITD", TypeName = "decimal(19, 4)")]
        public decimal? LaborItd { get; set; }
        [Column("MiscITD", TypeName = "decimal(19, 4)")]
        public decimal? MiscItd { get; set; }
        [Column("RentalITD", TypeName = "decimal(19, 4)")]
        public decimal? RentalItd { get; set; }
        [Column("EquipmentITD", TypeName = "decimal(19, 4)")]
        public decimal? EquipmentItd { get; set; }
        [Column("ITDCost", TypeName = "decimal(19, 4)")]
        public decimal? Itdcost { get; set; }
        [Column("PartsITDCost", TypeName = "decimal(19, 4)")]
        public decimal? PartsItdcost { get; set; }
        [Column("LaborITDCost", TypeName = "decimal(19, 4)")]
        public decimal? LaborItdcost { get; set; }
        [Column("MiscITDCost", TypeName = "decimal(19, 4)")]
        public decimal? MiscItdcost { get; set; }
        [Column("RentalITDCost", TypeName = "decimal(19, 4)")]
        public decimal? RentalItdcost { get; set; }
        [Column("EquipmentITDCost", TypeName = "decimal(19, 4)")]
        public decimal? EquipmentItdcost { get; set; }
        [Column("YTD", TypeName = "decimal(19, 4)")]
        public decimal? Ytd { get; set; }
        [Column("TaxYTD", TypeName = "decimal(19, 4)")]
        public decimal? TaxYtd { get; set; }
        [Column("PartsYTD", TypeName = "decimal(19, 4)")]
        public decimal? PartsYtd { get; set; }
        [Column("LaborYTD", TypeName = "decimal(19, 4)")]
        public decimal? LaborYtd { get; set; }
        [Column("MiscYTD", TypeName = "decimal(19, 4)")]
        public decimal? MiscYtd { get; set; }
        [Column("RentalYTD", TypeName = "decimal(19, 4)")]
        public decimal? RentalYtd { get; set; }
        [Column("EquipmentYTD", TypeName = "decimal(19, 4)")]
        public decimal? EquipmentYtd { get; set; }
        [Column("LastYTD", TypeName = "decimal(19, 4)")]
        public decimal? LastYtd { get; set; }
        [Column("TaxLastYTD", TypeName = "decimal(19, 4)")]
        public decimal? TaxLastYtd { get; set; }
        [Column("PartsLastYTD", TypeName = "decimal(19, 4)")]
        public decimal? PartsLastYtd { get; set; }
        [Column("LaborLastYTD", TypeName = "decimal(19, 4)")]
        public decimal? LaborLastYtd { get; set; }
        [Column("MiscLastYTD", TypeName = "decimal(19, 4)")]
        public decimal? MiscLastYtd { get; set; }
        [Column("RentalLastYTD", TypeName = "decimal(19, 4)")]
        public decimal? RentalLastYtd { get; set; }
        [Column("EquipmentLastYTD", TypeName = "decimal(19, 4)")]
        public decimal? EquipmentLastYtd { get; set; }
        [Column("YTDCost", TypeName = "decimal(19, 4)")]
        public decimal? Ytdcost { get; set; }
        [Column("LastYTDCost", TypeName = "decimal(19, 4)")]
        public decimal? LastYtdcost { get; set; }
        [Column("PartsYTDCost", TypeName = "decimal(19, 4)")]
        public decimal? PartsYtdcost { get; set; }
        [Column("LaborYTDCost", TypeName = "decimal(19, 4)")]
        public decimal? LaborYtdcost { get; set; }
        [Column("MiscYTDCost", TypeName = "decimal(19, 4)")]
        public decimal? MiscYtdcost { get; set; }
        [Column("RentalYTDCost", TypeName = "decimal(19, 4)")]
        public decimal? RentalYtdcost { get; set; }
        [Column("EquipmentYTDCost", TypeName = "decimal(19, 4)")]
        public decimal? EquipmentYtdcost { get; set; }
        [Column("PartsLastYTDCost", TypeName = "decimal(19, 4)")]
        public decimal? PartsLastYtdcost { get; set; }
        [Column("LaborLastYTDCost", TypeName = "decimal(19, 4)")]
        public decimal? LaborLastYtdcost { get; set; }
        [Column("MiscLastYTDCost", TypeName = "decimal(19, 4)")]
        public decimal? MiscLastYtdcost { get; set; }
        [Column("RentalLastYTDCost", TypeName = "decimal(19, 4)")]
        public decimal? RentalLastYtdcost { get; set; }
        [Column("EquipmentLastYTDCost", TypeName = "decimal(19, 4)")]
        public decimal? EquipmentLastYtdcost { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? LastSale { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LastSaleDate { get; set; }
        public int? LastInvoice { get; set; }
        [Column("LastYTDRoll", TypeName = "datetime")]
        public DateTime? LastYtdroll { get; set; }
        [Column("LastYTDRollBy")]
        [StringLength(50)]
        public string LastYtdrollBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LastPaymentDate { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? LastPaymentAmount { get; set; }
        public bool IsMigrated { get; set; }
    }
}
