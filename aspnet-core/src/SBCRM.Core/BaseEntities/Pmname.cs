using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("PMName", Schema = "web")]
    [Index(nameof(TenantId), Name = "PMName_TenantId_index")]
    [Index(nameof(Pmname1), nameof(TenantId), Name = "UC_PMName", IsUnique = true)]
    public class Pmname : FullAuditedEntity<long>, IMustHaveTenant
    {
        public int TenantId { get; set; }
        [Required]
        [Column("PMName")]
        [StringLength(50)]
        public string Pmname1 { get; set; }
        [StringLength(50)]
        public string Description { get; set; }
        public bool IsMigrated { get; set; }
    }
}
