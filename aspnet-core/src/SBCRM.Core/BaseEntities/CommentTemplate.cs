using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("CommentTemplate", Schema = "web")]
    [Index(nameof(TenantId), Name = "CommentTemplate_TenantId_index")]
    [Index(nameof(Template), nameof(TenantId), Name = "UC_CommentTemplate", IsUnique = true)]
    public class CommentTemplate : FullAuditedEntity<long>, IMustHaveTenant
    {
        [Required]
        [StringLength(100)]
        public string Template { get; set; }
        [Column(TypeName = "text")]
        public string Comments { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? Updated { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedBy { get; set; }
        public int TenantId { get; set; }
        public bool IsMigrated { get; set; }
    }
}
