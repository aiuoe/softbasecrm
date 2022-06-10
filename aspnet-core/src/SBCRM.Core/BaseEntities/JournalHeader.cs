using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("JournalHeader", Schema = "web")]
    [Index(nameof(TenantId), Name = "JournalHeader_TenantId_index")]
    [Index(nameof(Journal), nameof(TenantId), Name = "UC_JournalHeader", IsUnique = true)]
    public class JournalHeader : FullAuditedEntity<long>, IMustHaveTenant
    {
        public int TenantId { get; set; }
        [Required]
        [StringLength(50)]
        public string Journal { get; set; }
        public bool Posted { get; set; }
        [StringLength(50)]
        public string AccountField { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? EffectiveDate { get; set; }
        [StringLength(50)]
        public string Source { get; set; }
        public string Comments { get; set; }
        [StringLength(50)]
        public string CopyOfJournal { get; set; }
        [StringLength(50)]
        public string CreatedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? PostedDate { get; set; }
        [StringLength(50)]
        public string PostedBy { get; set; }
        [StringLength(50)]
        public string Type { get; set; }
        public bool Cleared { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }
        public bool IsMigrated { get; set; }
    }
}
