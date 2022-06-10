using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("WOQuote", Schema = "web")]
    [Index(nameof(TenantId), Name = "WOQuote_TenantId_index")]
    public class Woquote : FullAuditedEntity<long>, IMustHaveTenant
    {
        public int TenantId { get; set; }
        [Column("WONo")]
        public int Wono { get; set; }
        public short SaleBranch { get; set; }
        public short SaleDept { get; set; }
        [Required]
        [StringLength(50)]
        public string SaleCode { get; set; }
        [Required]
        [StringLength(50)]
        public string Type { get; set; }
        public short QuoteLine { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? Amount { get; set; }
        [StringLength(50)]
        public string SaleAccount { get; set; }
        public short? Taxable { get; set; }
        public short? Print { get; set; }
        [StringLength(200)]
        public string Description { get; set; }
        public short? StateTax { get; set; }
        public short? CountyTax { get; set; }
        public short? CityTax { get; set; }
        public short? LocalTax { get; set; }
        [StringLength(100)]
        public string QuoteText { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? HoursAllowed { get; set; }
        [StringLength(50)]
        public string RepairCode { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? EstimatedCost { get; set; }
        [StringLength(50)]
        public string Section { get; set; }
        public int? LegacyId { get; set; }
        public bool IsMigrated { get; set; }
    }
}
