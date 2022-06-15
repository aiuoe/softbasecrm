using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("ShopStatusTable", Schema = "web")]
    [Index(nameof(TenantId), Name = "ShopStatusTable_TenantId_index")]
    [Index(nameof(ShopStatus), nameof(TenantId), Name = "UC_ShopStatusTable", IsUnique = true)]
    public class ShopStatusTable : FullAuditedEntity<long>, IMustHaveTenant
    {
        public int TenantId { get; set; }
        [Required]
        [StringLength(50)]
        public string ShopStatus { get; set; }
        public int? SortOrder { get; set; }
        [StringLength(100)]
        public string AddedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DateAdded { get; set; }
        [StringLength(100)]
        public string ChangedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DateChanged { get; set; }
        public bool IsMigrated { get; set; }
    }
}
