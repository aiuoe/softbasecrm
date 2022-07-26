using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("PersonGroup", Schema = "web")]
    [Index(nameof(TenantId), Name = "PersonGroup_TenantId_index")]
    public class PersonGroup : FullAuditedEntity<long>, IMustHaveTenant
    {
        [Column("PersonGroup")]
        [StringLength(50)]
        public string PersonGroup1 { get; set; }
        public short? SortOrder { get; set; }
        public int TenantId { get; set; }
        public bool IsMigrated { get; set; }
    }
}
