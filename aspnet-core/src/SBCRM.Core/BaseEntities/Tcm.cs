using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("TCM", Schema = "web")]
    [Index(nameof(TenantId), Name = "TCM_TenantId_index")]
    [Index(nameof(PartNo), nameof(TenantId), Name = "UC_TCM", IsUnique = true)]
    public class Tcm : FullAuditedEntity<long>, IMustHaveTenant
    {
        public int TenantId { get; set; }
        [Required]
        [StringLength(50)]
        public string PartNo { get; set; }
        [StringLength(50)]
        public string Description { get; set; }
        public short? GroupCode { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? Weight { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? DealerPriceList { get; set; }
        [StringLength(50)]
        public string BarCode { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? Created { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LastUpdate { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? PreCurrencyDealerPriceList { get; set; }
        [StringLength(50)]
        public string CurrencyType { get; set; }
        [Column("PartNoWODash")]
        [StringLength(50)]
        public string PartNoWodash { get; set; }
        [StringLength(100)]
        public string ReplacedBy { get; set; }
        public bool IsMigrated { get; set; }
    }
}
