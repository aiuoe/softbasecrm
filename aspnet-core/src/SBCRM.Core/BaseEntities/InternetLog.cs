using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("InternetLog", Schema = "web")]
    [Index(nameof(TenantId), Name = "InternetLog_TenantId_index")]
    [Index(nameof(Ipaddress), nameof(EntryDate), nameof(TenantId), Name = "UC_InternetLog", IsUnique = true)]
    public class InternetLog : FullAuditedEntity<long>, IMustHaveTenant
    {
        public int TenantId { get; set; }
        [Required]
        [Column("IPAddress")]
        [StringLength(200)]
        public string Ipaddress { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime EntryDate { get; set; }
        public string Browser { get; set; }
        [StringLength(200)]
        public string Selection { get; set; }
        [StringLength(200)]
        public string SecureName { get; set; }
        public bool IsMigrated { get; set; }
    }
}
