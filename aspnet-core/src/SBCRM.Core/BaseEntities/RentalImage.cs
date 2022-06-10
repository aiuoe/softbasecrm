using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("RentalImages", Schema = "web")]
    [Index(nameof(TenantId), Name = "RentalImages_TenantId_index")]
    public class RentalImage : FullAuditedEntity<long>, IMustHaveTenant
    {
        public int TenantId { get; set; }
        public int? RentalContractNo { get; set; }
        [StringLength(100)]
        public string FileName { get; set; }
        [StringLength(200)]
        public string FilePath { get; set; }
        [Column(TypeName = "image")]
        public byte[] Image { get; set; }
        [StringLength(100)]
        public string AddedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DateAdded { get; set; }
        [StringLength(100)]
        public string ChangedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DateChanged { get; set; }
        public int? LegacyId { get; set; }
        public bool IsMigrated { get; set; }
    }
}
