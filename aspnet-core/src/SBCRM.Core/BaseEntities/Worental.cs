using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("WORental", Schema = "web")]
    [Index(nameof(TenantId), Name = "WORental_TenantId_index")]
    public class Worental : FullAuditedEntity<long>, IMustHaveTenant
    {
        public int TenantId { get; set; }
        [Column("WONo")]
        public int Wono { get; set; }
        [StringLength(50)]
        public string AddedBy { get; set; }
        [StringLength(50)]
        public string SerialNo { get; set; }
        [StringLength(50)]
        public string UnitNo { get; set; }
        [StringLength(50)]
        public string Make { get; set; }
        [StringLength(50)]
        public string Model { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? Sell { get; set; }
        public short? Disposition { get; set; }
        public short? SaleBranch { get; set; }
        public short? SaleDept { get; set; }
        [StringLength(50)]
        public string SaleCode { get; set; }
        [StringLength(50)]
        public string SaleAccount { get; set; }
        public bool? Taxable { get; set; }
        public bool? Transfer { get; set; }
        [Column("TransferWONoFrom")]
        public int? TransferWonoFrom { get; set; }
        [Column("TransferWONoTo")]
        public int? TransferWonoTo { get; set; }
        [StringLength(50)]
        public string TransferBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? TransferDate { get; set; }
        public string Comments { get; set; }
        [StringLength(50)]
        public string ModelGroup { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? Cost { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? HourMeter { get; set; }
        public bool? StateTax { get; set; }
        public bool? CountyTax { get; set; }
        public bool? CityTax { get; set; }
        public bool? LocalTax { get; set; }
        public bool? NoPrint { get; set; }
        [Column("CustomerPOLineNo")]
        public short? CustomerPolineNo { get; set; }
        public short? PeriodsBilled { get; set; }
        public bool? ShowPeriodsBilled { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? DayRent { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? WeekRent { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? FourWeekRent { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? MonthRent { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? QuarterRent { get; set; }
        public short? SwapOutStatus { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? SwapStartDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? SwapEndDate { get; set; }
        [StringLength(50)]
        public string Section { get; set; }
        public int? LegacyId { get; set; }
        public bool IsMigrated { get; set; }
    }
}
