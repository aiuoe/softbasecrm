using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("PrintInfoBar", Schema = "web")]
    [Index(nameof(TenantId), Name = "PrintInfoBar_TenantId_index")]
    [Index(nameof(Branch), nameof(Dept), nameof(FieldName), nameof(TenantId), Name = "UC_PrintInfoBar", IsUnique = true)]
    public class PrintInfoBar : FullAuditedEntity<long>, IMustHaveTenant
    {
        public int TenantId { get; set; }
        public int Branch { get; set; }
        public int Dept { get; set; }
        [Required]
        [StringLength(50)]
        public string FieldName { get; set; }
        [StringLength(50)]
        public string FieldLabel { get; set; }
        [StringLength(50)]
        public string PrintField { get; set; }
        public int? PrintTop { get; set; }
        public int? PrintLeft { get; set; }
        public int? PrintWidth { get; set; }
        [StringLength(50)]
        public string FontName { get; set; }
        public int? FontSize { get; set; }
        public int? FontBold { get; set; }
        public int? FontItalic { get; set; }
        public int? NumericField { get; set; }
        public int? DateField { get; set; }
        [StringLength(100)]
        public string FieldLabelFrench { get; set; }
        public bool IsMigrated { get; set; }
    }
}
