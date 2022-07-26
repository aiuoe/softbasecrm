using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("TrinDocsDetail", Schema = "web")]
    [Index(nameof(TenantId), Name = "TrinDocsDetail_TenantId_index")]
    public class TrinDocsDetail : FullAuditedEntity<long>, IMustHaveTenant
    {
        public int TenantId { get; set; }
        [Column("TrinDocsID")]
        public int? TrinDocsId { get; set; }
        [StringLength(50)]
        public string AccountNo { get; set; }
        public int? DepartmentNo { get; set; }
        public int? BranchNo { get; set; }
        [StringLength(50)]
        public string ControlNo { get; set; }
        [StringLength(50)]
        public string Description { get; set; }
        public int? ItemNo { get; set; }
        [Column("WONo")]
        public int? Wono { get; set; }
        [Column("QTY", TypeName = "decimal(19, 4)")]
        public decimal? Qty { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? ExtendedAmount { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? AmountEach { get; set; }
        [StringLength(50)]
        public string TemplateType { get; set; }
        [StringLength(50)]
        public string FullAccount { get; set; }
        [StringLength(50)]
        public string SerialNumber { get; set; }
        public int? LegacyId { get; set; }
        public bool IsMigrated { get; set; }
    }
}
