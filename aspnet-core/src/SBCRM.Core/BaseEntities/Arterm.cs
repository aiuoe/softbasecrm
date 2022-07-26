using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("ARTerms", Schema = "web")]
    [Index(nameof(TenantId), Name = "ARTerms_TenantId_index")]
    [Index(nameof(Terms), nameof(TenantId), Name = "UC_ARTerms", IsUnique = true)]
    public class Arterm : FullAuditedEntity<long>, IMustHaveTenant
    {
        [Required]
        [StringLength(50)]
        public string Terms { get; set; }
        [Column("COD")]
        public short? Cod { get; set; }
        public short? DaysDue { get; set; }
        public short? Days { get; set; }
        public short? DayOfMonth { get; set; }
        public short? Day { get; set; }
        public short? PrintWaterMark { get; set; }
        public bool? CreditCard { get; set; }
        [StringLength(100)]
        public string AddedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DateAdded { get; set; }
        [StringLength(100)]
        public string ChangedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DateChanged { get; set; }
        public int TenantId { get; set; }
        public bool IsMigrated { get; set; }
    }
}
