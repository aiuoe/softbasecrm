using System;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("MechanicLaborSignature", Schema = "web")]
    [Index(nameof(TenantId), Name = "MechanicLaborSignature_TenantId_index")]
    public class MechanicLaborSignature : FullAuditedEntity<long>, IMustHaveTenant
    {
        public int TenantId { get; set; }
        public int? LegacyId { get; set; }
        public int? MechanicNo { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LaborDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DateSigned { get; set; }
        [Column(TypeName = "image")]
        public byte[] Signature { get; set; }
        [Column(TypeName = "text")]
        public string Comments { get; set; }
        public bool IsMigrated { get; set; }
    }
}
