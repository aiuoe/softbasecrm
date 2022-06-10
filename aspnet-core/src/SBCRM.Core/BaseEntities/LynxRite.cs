using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("LynxRite", Schema = "web")]
    [Index(nameof(TenantId), Name = "LynxRite_TenantId_index")]
    [Index(nameof(PartNo), nameof(TenantId), Name = "UC_LynxRite", IsUnique = true)]
    public class LynxRite : FullAuditedEntity<long>, IMustHaveTenant
    {
        public int TenantId { get; set; }
        [Required]
        [StringLength(100)]
        public string PartNo { get; set; }
        [Column("OEMPartNo")]
        [StringLength(100)]
        public string OempartNo { get; set; }
        [StringLength(100)]
        public string ReplacedBy { get; set; }
        [StringLength(100)]
        public string ProductCategory { get; set; }
        [Column("MFG")]
        [StringLength(50)]
        public string Mfg { get; set; }
        [StringLength(100)]
        public string Description { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? Cost { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? Cost1050 { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? Cost51100 { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? List { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? PreCurrencyCost { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? PreCurrencyCost1050 { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? PreCurrencyCost51100 { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? PreCurrencyList { get; set; }
        [StringLength(50)]
        public string CurrencyType { get; set; }
        [StringLength(100)]
        public string CreatedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? Created { get; set; }
        [StringLength(100)]
        public string UpdatedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? Updated { get; set; }
        public bool IsMigrated { get; set; }
    }
}
