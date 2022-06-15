using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("GLQuarter", Schema = "web")]
    [Index(nameof(TenantId), Name = "GLQuarter_TenantId_index")]
    [Index(nameof(AccountNo), nameof(AccountField), nameof(Year), nameof(Month), nameof(TenantId), Name = "UC_GLQuarter", IsUnique = true)]
    public class Glquarter : FullAuditedEntity<long>, IMustHaveTenant
    {
        [Required]
        [StringLength(50)]
        public string AccountNo { get; set; }
        [Required]
        [StringLength(50)]
        public string AccountField { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        [Column("MTD", TypeName = "decimal(19, 4)")]
        public decimal? Mtd { get; set; }
        [Column("QTD", TypeName = "decimal(19, 4)")]
        public decimal? Qtd { get; set; }
        [Column("YTD", TypeName = "decimal(19, 4)")]
        public decimal? Ytd { get; set; }
        [Column("LMTD", TypeName = "decimal(19, 4)")]
        public decimal? Lmtd { get; set; }
        [Column("LQTD", TypeName = "decimal(19, 4)")]
        public decimal? Lqtd { get; set; }
        [Column("LYTD", TypeName = "decimal(19, 4)")]
        public decimal? Lytd { get; set; }
        [StringLength(100)]
        public string Description { get; set; }
        [StringLength(100)]
        public string AddedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? AddedDate { get; set; }
        [StringLength(100)]
        public string UpdatedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedDate { get; set; }
        public int TenantId { get; set; }
        public bool IsMigrated { get; set; }
    }
}
