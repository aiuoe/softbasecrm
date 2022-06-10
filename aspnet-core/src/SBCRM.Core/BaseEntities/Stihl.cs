using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("Stihl", Schema = "web")]
    [Index(nameof(TenantId), Name = "Stihl_TenantId_index")]
    [Index(nameof(PartNo), nameof(TenantId), Name = "UC_Stihl", IsUnique = true)]
    public class Stihl : FullAuditedEntity<long>, IMustHaveTenant
    {
        public int TenantId { get; set; }
        [Required]
        [StringLength(50)]
        public string PartNo { get; set; }
        [StringLength(100)]
        public string Description { get; set; }
        [StringLength(100)]
        public string DescriptionFrench { get; set; }
        [StringLength(50)]
        public string NewPartNo { get; set; }
        [StringLength(50)]
        public string UnitofMeasure { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? List { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? Markup { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? Cost { get; set; }
        public short? PackageQty { get; set; }
        [StringLength(50)]
        public string ReturnCode { get; set; }
        [Column("UPCCodePackage")]
        [StringLength(50)]
        public string UpccodePackage { get; set; }
        [Column("UPCCodeSingle")]
        [StringLength(50)]
        public string UpccodeSingle { get; set; }
        [StringLength(100)]
        public string CreatedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? Created { get; set; }
        [StringLength(100)]
        public string ChangedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? Changed { get; set; }
        public bool IsMigrated { get; set; }
    }
}
