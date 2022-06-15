using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("SurveyHeader", Schema = "web")]
    [Index(nameof(TenantId), Name = "SurveyHeader_TenantId_index")]
    [Index(nameof(Survey), nameof(TenantId), Name = "UC_SurveyHeader", IsUnique = true)]
    public class SurveyHeader : FullAuditedEntity<long>, IMustHaveTenant
    {
        public int TenantId { get; set; }
        [Required]
        [StringLength(50)]
        public string Survey { get; set; }
        public string Description { get; set; }
        public short? Valid { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? StartDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? EndDate { get; set; }
        [StringLength(50)]
        public string CreatedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DateCreated { get; set; }
        public bool IsMigrated { get; set; }
    }
}
