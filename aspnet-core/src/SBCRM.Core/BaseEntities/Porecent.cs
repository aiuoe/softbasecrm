using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("PORecent", Schema = "web")]
    [Index(nameof(TenantId), Name = "PORecent_TenantId_index")]
    public partial class Porecent
    {
        [Key]
        public long Id { get; set; }
        public int TenantId { get; set; }
        [Column("LegacyID")]
        public int? LegacyId { get; set; }
        [StringLength(100)]
        public string SecureName { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? EntryDate { get; set; }
        [Column("PONo")]
        public long? Pono { get; set; }
        public bool IsMigrated { get; set; }
        public DateTime CreationTime { get; set; }
        public long? CreatorUserId { get; set; }
        public DateTime? LastModificationTime { get; set; }
        public long? LastModifierUserId { get; set; }
        public bool IsDeleted { get; set; }
        public long? DeleterUserId { get; set; }
        public DateTime? DeletionTime { get; set; }
    }
}
