using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("WOSignatures", Schema = "web")]
    [Index(nameof(TenantId), Name = "WOSignatures_TenantId_index")]
    public class Wosignature : FullAuditedEntity<long>, IMustHaveTenant
    {
        public int TenantId { get; set; }
        [Column("WONo")]
        public int? Wono { get; set; }
        [StringLength(50)]
        public string SignatureType { get; set; }
        [StringLength(100)]
        public string SignedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DateSigned { get; set; }
        [Column(TypeName = "image")]
        public byte[] Signature { get; set; }
        public int? LegacyId { get; set; }
        public bool IsMigrated { get; set; }
    }
}
