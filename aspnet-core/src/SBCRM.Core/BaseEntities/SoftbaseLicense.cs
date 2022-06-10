using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("SoftbaseLicense", Schema = "web")]
    [Index(nameof(TenantId), Name = "SoftbaseLicense_TenantId_index")]
    public class SoftbaseLicense : FullAuditedEntity<long>, IMustHaveTenant
    {
        public int TenantId { get; set; }
        public int? LegacyId { get; set; }
        [StringLength(100)]
        public string ComputerName { get; set; }
        [Column("MachineID")]
        [StringLength(100)]
        public string MachineId { get; set; }
        [Column("HDSerialNo")]
        [StringLength(100)]
        public string HdserialNo { get; set; }
        public int? WhiteListed { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ExpirationDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DateAdded { get; set; }
        public bool IsMigrated { get; set; }
    }
}
