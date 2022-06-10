using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("TransSignature", Schema = "web")]
    [Index(nameof(TenantId), Name = "TransSignature_TenantId_index")]
    public class TransSignature : FullAuditedEntity<long>, IMustHaveTenant
    {
        public int TenantId { get; set; }
        public int? LegacyId { get; set; }
        public int? TrackingNo { get; set; }
        [StringLength(50)]
        public string SignatureType { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DateSigned { get; set; }
        [Column(TypeName = "image")]
        public byte[] Signature { get; set; }
        public bool IsMigrated { get; set; }
    }
}
