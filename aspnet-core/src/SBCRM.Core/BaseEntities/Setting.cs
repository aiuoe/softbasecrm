using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("Settings", Schema = "web")]
    [Index(nameof(TenantId), Name = "Settings_TenantId_index")]
    [Index(nameof(SecureName), nameof(ProgramName), nameof(FormName), nameof(TenantId), Name = "UC_Settings", IsUnique = true)]
    public class Setting : FullAuditedEntity<long>, IMustHaveTenant
    {
        public int TenantId { get; set; }
        [Required]
        [StringLength(50)]
        public string SecureName { get; set; }
        [Required]
        [StringLength(50)]
        public string ProgramName { get; set; }
        [Required]
        [StringLength(50)]
        public string FormName { get; set; }
        [StringLength(255)]
        public string Param1 { get; set; }
        [StringLength(255)]
        public string Param2 { get; set; }
        [StringLength(255)]
        public string Param3 { get; set; }
        [StringLength(255)]
        public string Param4 { get; set; }
        [StringLength(255)]
        public string Param5 { get; set; }
        [StringLength(255)]
        public string Param6 { get; set; }
        [StringLength(255)]
        public string Param7 { get; set; }
        [StringLength(255)]
        public string Param8 { get; set; }
        [StringLength(255)]
        public string Param9 { get; set; }
        [StringLength(255)]
        public string Param10 { get; set; }
        public bool IsMigrated { get; set; }
    }
}
