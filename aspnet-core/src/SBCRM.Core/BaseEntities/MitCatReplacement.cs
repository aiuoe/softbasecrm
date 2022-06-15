using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("MitCatReplacement", Schema = "web")]
    [Index(nameof(TenantId), Name = "MitCatReplacement_TenantId_index")]
    [Index(nameof(PartNo), nameof(TenantId), Name = "UC_MitCatReplacement", IsUnique = true)]
    public class MitCatReplacement : FullAuditedEntity<long>, IMustHaveTenant
    {
        public int TenantId { get; set; }
        [Required]
        [StringLength(50)]
        public string PartNo { get; set; }
        [StringLength(50)]
        public string ReplacementType { get; set; }
        [StringLength(50)]
        public string PartNo1 { get; set; }
        public short? Qty1 { get; set; }
        [StringLength(50)]
        public string PartNo2 { get; set; }
        public short? Qty2 { get; set; }
        [StringLength(50)]
        public string PartNo3 { get; set; }
        public short? Qty3 { get; set; }
        [StringLength(50)]
        public string PartNo4 { get; set; }
        public short? Qty4 { get; set; }
        [StringLength(50)]
        public string PartNo5 { get; set; }
        public short? Qty5 { get; set; }
        [StringLength(50)]
        public string PartNo6 { get; set; }
        public short? Qty6 { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? Created { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LastUpdate { get; set; }
        public bool IsMigrated { get; set; }
    }
}
