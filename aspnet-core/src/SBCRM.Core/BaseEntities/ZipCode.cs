using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("ZipCode", Schema = "web")]
    [Index(nameof(TenantId), Name = "ZipCode_TenantId_index")]
    [Index(nameof(ZipCode1), nameof(TenantId), Name = "UC_ZipCode", IsUnique = true)]
    public class ZipCode : FullAuditedEntity<long>, IMustHaveTenant
    {
        public int TenantId { get; set; }
        [Required]
        [Column("ZipCode")]
        [StringLength(50)]
        public string ZipCode1 { get; set; }
        [StringLength(255)]
        public string City { get; set; }
        [StringLength(255)]
        public string State { get; set; }
        [StringLength(255)]
        public string County { get; set; }
        public int? Branch { get; set; }
        [StringLength(255)]
        public string TaxCode { get; set; }
        public int? Group1 { get; set; }
        public int? Group2 { get; set; }
        public int? Group3 { get; set; }
        public int? Group4 { get; set; }
        public int? Group5 { get; set; }
        public int? Group6 { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? Latitude { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? Longitude { get; set; }
        [StringLength(50)]
        public string AreaCode { get; set; }
        public int? TimeZone { get; set; }
        public int? Elevation { get; set; }
        [StringLength(50)]
        public string AddedBy { get; set; }
        [StringLength(50)]
        public string ChangedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DateAdded { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DateChanged { get; set; }
        public bool IsMigrated { get; set; }
    }
}
