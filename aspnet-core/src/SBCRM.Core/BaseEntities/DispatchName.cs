using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("DispatchNames", Schema = "web")]
    [Index(nameof(TenantId), Name = "DispatchNames_TenantId_index")]
    [Index(nameof(SecureName), nameof(DispatchName1), nameof(TenantId), Name = "UC_DispatchNames", IsUnique = true)]
    public class DispatchName : FullAuditedEntity<long>, IMustHaveTenant
    {
        [Required]
        [StringLength(100)]
        public string SecureName { get; set; }
        [Required]
        [Column("DispatchName")]
        [StringLength(100)]
        public string DispatchName1 { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? AddedDate { get; set; }
        public int TenantId { get; set; }
        public bool IsMigrated { get; set; }
    }
}
