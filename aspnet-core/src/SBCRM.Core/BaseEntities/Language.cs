using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("Language", Schema = "web")]
    [Index(nameof(TenantId), Name = "Language_TenantId_index")]
    [Index(nameof(ProgramName), nameof(FormName), nameof(FieldName), nameof(FieldNo), nameof(Language1), nameof(TenantId), Name = "UC_Language", IsUnique = true)]
    public class Language : FullAuditedEntity<long>, IMustHaveTenant
    {
        public int TenantId { get; set; }
        [Required]
        [StringLength(100)]
        public string ProgramName { get; set; }
        public short? Tabbed { get; set; }
        [Required]
        [StringLength(100)]
        public string FormName { get; set; }
        [Required]
        [StringLength(100)]
        public string FieldName { get; set; }
        public int FieldNo { get; set; }
        [Required]
        [Column("Language")]
        [StringLength(100)]
        public string Language1 { get; set; }
        public short? Indexed { get; set; }
        [StringLength(100)]
        public string LabelCaption { get; set; }
        public bool IsMigrated { get; set; }
    }
}
