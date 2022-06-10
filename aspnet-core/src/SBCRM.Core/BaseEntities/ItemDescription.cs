using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("ItemDescription", Schema = "web")]
    [Index(nameof(TenantId), Name = "ItemDescription_TenantId_index")]
    public partial class ItemDescription : FullAuditedEntity<long>, IMustHaveTenant
    {
        public int TenantId { get; set; }
        [StringLength(50)]
        public string Item { get; set; }
        [StringLength(50)]
        public string Description { get; set; }
        public bool IsMigrated { get; set; }
    }
}
