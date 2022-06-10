using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("GL", Schema = "web")]
    [Index(nameof(TenantId), Name = "GL_TenantId_index")]
    [Index(nameof(AccountNo), nameof(AccountField), nameof(Year), nameof(Month), nameof(TenantId), Name = "UC_GL", IsUnique = true)]
    public class Gl : FullAuditedEntity<long>, IMustHaveTenant
    {
        [Required]
        [StringLength(50)]
        public string AccountNo { get; set; }
        [Required]
        [StringLength(50)]
        public string AccountField { get; set; }
        public short Year { get; set; }
        public short Month { get; set; }
        [Column("YTD", TypeName = "decimal(19, 4)")]
        public decimal? Ytd { get; set; }
        [Column("MTD", TypeName = "decimal(19, 4)")]
        public decimal? Mtd { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? LastTransAmount { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LastTransDate { get; set; }
        [StringLength(50)]
        public string LastTransBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LastEffectiveDate { get; set; }
        public int? NumberOfTrans { get; set; }
        [StringLength(100)]
        public string LastTransJournal { get; set; }
        public int TenantId { get; set; }
        public bool IsMigrated { get; set; }
    }
}
