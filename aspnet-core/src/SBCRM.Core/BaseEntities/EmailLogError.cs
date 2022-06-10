using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("EMailLogError", Schema = "web")]
    [Index(nameof(TenantId), Name = "EMailLogError_TenantId_index")]
    public class EmailLogError : FullAuditedEntity<long>, IMustHaveTenant
    {
        [Column("ErrorID")]
        public int? ErrorId { get; set; }
        [StringLength(4096)]
        public string ErrorMessage { get; set; }
        [StringLength(100)]
        public string Subject { get; set; }
        [StringLength(100)]
        public string ToAddress { get; set; }
        [StringLength(4096)]
        public string HeadersSource { get; set; }
        [StringLength(100)]
        public string ApplicationSource { get; set; }
        [StringLength(100)]
        public string EntryBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? EntryDate { get; set; }
        [Column("LegacyID")]
        public int? LegacyId { get; set; }
        public int TenantId { get; set; }
        public bool IsMigrated { get; set; }
    }
}
