using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("WOPrintFormat", Schema = "web")]
    [Index(nameof(TenantId), Name = "WOPrintFormat_TenantId_index")]
    [Index(nameof(Branch), nameof(Dept), nameof(Item), nameof(TenantId), Name = "UC_WOPrintFormat", IsUnique = true)]
    public class WoprintFormat : FullAuditedEntity<long>, IMustHaveTenant
    {
        public int TenantId { get; set; }
        [Required]
        [StringLength(100)]
        public string Branch { get; set; }
        [Required]
        [StringLength(100)]
        public string Dept { get; set; }
        [Required]
        [StringLength(100)]
        public string Item { get; set; }
        public int? PositionX { get; set; }
        public int? PositionY { get; set; }
        public short? CustomerFormat { get; set; }
        public short? InternalFormat { get; set; }
        [StringLength(100)]
        public string SetupLabel { get; set; }
        public short? FontSize { get; set; }
        [StringLength(100)]
        public string FontName { get; set; }
        public short? FontBold { get; set; }
        public short? FontItalic { get; set; }
        public bool IsMigrated { get; set; }
    }
}
