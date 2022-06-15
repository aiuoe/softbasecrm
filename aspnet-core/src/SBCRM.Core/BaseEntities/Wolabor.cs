using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("WOLabor", Schema = "web")]
    [Index(nameof(TenantId), Name = "WOLabor_TenantId_index")]
    public partial class Wolabor : FullAuditedEntity<long>, IMustHaveTenant
    {
        public int TenantId { get; set; }
        [Column("WONo")]
        public int Wono { get; set; }
        [StringLength(50)]
        public string AddedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DateOfLabor { get; set; }
        public int? MechanicNo { get; set; }
        [StringLength(50)]
        public string MechanicName { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? Hours { get; set; }
        [StringLength(50)]
        public string LaborRateType { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? CostRate { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? SellRate { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? Cost { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? Sell { get; set; }
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
        public bool? StateTax { get; set; }
        public bool? CountyTax { get; set; }
        public bool? CityTax { get; set; }
        public bool? LocalTax { get; set; }
        [Column("CustomerPOLineNo")]
        public short? CustomerPolineNo { get; set; }
        [Column("WIPAccount")]
        [StringLength(50)]
        public string Wipaccount { get; set; }
        public short? SectionNo { get; set; }
        [StringLength(50)]
        public string FedExCode { get; set; }
        [Column(TypeName = "text")]
        public string AdditionalDescription { get; set; }
        public int? LegacyId { get; set; }
        public bool IsMigrated { get; set; }
    }
}
