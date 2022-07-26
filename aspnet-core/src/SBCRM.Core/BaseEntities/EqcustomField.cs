using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("EQCustomFields", Schema = "web")]
    [Index(nameof(TenantId), Name = "EQCustomFields_TenantId_index")]
    [Index(nameof(SerialNo), nameof(TenantId), Name = "UC_EQCustomFields", IsUnique = true)]
    public class EqcustomField : FullAuditedEntity<long>, IMustHaveTenant
    {
        [Required]
        [StringLength(100)]
        public string SerialNo { get; set; }
        [StringLength(100)]
        public string Custom01 { get; set; }
        [StringLength(100)]
        public string Custom02 { get; set; }
        [StringLength(100)]
        public string Custom03 { get; set; }
        [StringLength(100)]
        public string Custom04 { get; set; }
        [StringLength(100)]
        public string Custom05 { get; set; }
        [StringLength(100)]
        public string Custom06 { get; set; }
        [StringLength(100)]
        public string Custom07 { get; set; }
        [StringLength(100)]
        public string Custom08 { get; set; }
        [StringLength(100)]
        public string Custom09 { get; set; }
        [StringLength(100)]
        public string Custom10 { get; set; }
        [StringLength(100)]
        public string Custom11 { get; set; }
        [StringLength(100)]
        public string Custom12 { get; set; }
        [StringLength(100)]
        public string Custom13 { get; set; }
        [StringLength(100)]
        public string Custom14 { get; set; }
        [StringLength(100)]
        public string Custom15 { get; set; }
        [StringLength(100)]
        public string Custom16 { get; set; }
        [StringLength(100)]
        public string Custom17 { get; set; }
        [StringLength(100)]
        public string Custom18 { get; set; }
        [StringLength(100)]
        public string Custom19 { get; set; }
        [StringLength(100)]
        public string Custom20 { get; set; }
        public int TenantId { get; set; }
        public bool IsMigrated { get; set; }
    }
}
