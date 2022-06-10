using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("PMParts", Schema = "web")]
    [Index(nameof(TenantId), Name = "PMParts_TenantId_index")]
    [Index(nameof(SerialNo), nameof(PartNo), nameof(TenantId), Name = "UC_PMParts", IsUnique = true)]
    public class Pmpart : FullAuditedEntity<long>, IMustHaveTenant
    {
        public int TenantId { get; set; }
        [Required]
        [StringLength(50)]
        public string SerialNo { get; set; }
        [Required]
        [StringLength(50)]
        public string PartNo { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? Qty { get; set; }
        [StringLength(50)]
        public string Instruction { get; set; }
        public short? Required { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DateAdded { get; set; }
        [StringLength(50)]
        public string AddedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DateUpdated { get; set; }
        [StringLength(50)]
        public string UpdatedBy { get; set; }
        [Required]
        [Column("PMName")]
        [StringLength(50)]
        public string Pmname { get; set; }
        public bool IsMigrated { get; set; }
    }
}
