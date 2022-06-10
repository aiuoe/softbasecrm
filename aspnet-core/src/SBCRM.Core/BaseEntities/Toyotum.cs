using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("Toyota", Schema = "web")]
    [Index(nameof(TenantId), Name = "Toyota_TenantId_index")]
    [Index(nameof(PartNo), nameof(TenantId), Name = "UC_Toyota", IsUnique = true)]
    public class Toyotum : FullAuditedEntity<long>, IMustHaveTenant
    {
        public int TenantId { get; set; }
        [StringLength(1)]
        public string RecordType { get; set; }
        [Required]
        [StringLength(50)]
        public string PartNo { get; set; }
        [StringLength(1)]
        public string StatusCode { get; set; }
        [StringLength(40)]
        public string Description { get; set; }
        [StringLength(2)]
        public string Class { get; set; }
        [StringLength(1)]
        public string AccessoryCode { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? DealerPrice { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? WholesalePrice { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? RetailPrice { get; set; }
        [Column("QUP")]
        [StringLength(5)]
        public string Qup { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? CoreCharge { get; set; }
        [StringLength(2)]
        public string DiscountCode { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? PreCurrencyDealerPrice { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? PreCurrencyWholesalePrice { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? PreCurrencyRetailPrice { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ProductionStart { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ProductionEnd { get; set; }
        [StringLength(50)]
        public string CurrencyType { get; set; }
        public bool ReturnCode { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LastUpdate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? Created { get; set; }
        public bool IsMigrated { get; set; }
    }
}
