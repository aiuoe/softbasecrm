using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("RentalContractLayout", Schema = "web")]
    [Index(nameof(TenantId), Name = "RentalContractLayout_TenantId_index")]
    [Index(nameof(TableName), nameof(FieldName), nameof(TenantId), Name = "UC_RentalContractLayout", IsUnique = true)]
    public class RentalContractLayout : FullAuditedEntity<long>, IMustHaveTenant
    {
        public int TenantId { get; set; }
        [Required]
        [StringLength(50)]
        public string TableName { get; set; }
        [Required]
        [StringLength(50)]
        public string FieldName { get; set; }
        [StringLength(100)]
        public string ToolTipText { get; set; }
        [StringLength(100)]
        public string ExampleContent { get; set; }
        public int? LeftPosition { get; set; }
        public int? TopPosition { get; set; }
        [StringLength(100)]
        public string FontName { get; set; }
        public short? FontSize { get; set; }
        public bool IsMigrated { get; set; }
    }
}
