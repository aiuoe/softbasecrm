using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("VendorImages", Schema = "web")]
    [Index(nameof(TenantId), Name = "VendorImages_TenantId_index")]
    public class VendorImage : FullAuditedEntity<long>, IMustHaveTenant
    {
        public int TenantId { get; set; }
        [Required]
        [StringLength(50)]
        public string VendorNo { get; set; }
        [Required]
        [StringLength(200)]
        public string FileName { get; set; }
        [StringLength(200)]
        public string FilePath { get; set; }
        [Column(TypeName = "image")]
        public byte[] Image { get; set; }
        public int? LegacyId { get; set; }
        [StringLength(100)]
        public string AddedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DateAdded { get; set; }
        [StringLength(100)]
        public string ChangedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DateChanged { get; set; }
        public bool IsMigrated { get; set; }
    }
}
