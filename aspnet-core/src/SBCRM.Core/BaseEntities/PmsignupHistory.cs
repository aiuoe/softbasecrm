using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("PMSignupHistory", Schema = "web")]
    [Index(nameof(TenantId), Name = "PMSignupHistory_TenantId_index")]
    [Index(nameof(SerialNo), nameof(SignUpDate), nameof(TenantId), Name = "UC_PMSignupHistory", IsUnique = true)]
    public class PmsignupHistory : FullAuditedEntity<long>, IMustHaveTenant
    {
        public int TenantId { get; set; }
        [Required]
        [StringLength(100)]
        public string SerialNo { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime SignUpDate { get; set; }
        [Column("PMCancelledDate", TypeName = "datetime")]
        public DateTime? PmcancelledDate { get; set; }
        [Column("PMCancelledBy")]
        [StringLength(100)]
        public string PmcancelledBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? EntryDate { get; set; }
        public bool IsMigrated { get; set; }
    }
}
