using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("CheckFormat", Schema = "web")]
    [Index(nameof(TenantId), Name = "CheckFormat_TenantId_index")]
    [Index(nameof(FormatName), nameof(ElementName), nameof(TenantId), Name = "UC_CheckFormat", IsUnique = true)]
    public class CheckFormat : FullAuditedEntity<long>, IMustHaveTenant
    {
        [Required]
        [StringLength(50)]
        public string FormatName { get; set; }
        [Required]
        [StringLength(50)]
        public string ElementName { get; set; }
        public int? TopPosition { get; set; }
        public int? LeftPosition { get; set; }
        [StringLength(50)]
        public string Font { get; set; }
        public int? FontSize { get; set; }
        public bool FontBold { get; set; }
        public bool FontItalic { get; set; }
        public bool PrintElement { get; set; }
        [StringLength(50)]
        public string ElementFormat { get; set; }
        public int TenantId { get; set; }
        public bool IsMigrated { get; set; }
    }
}
