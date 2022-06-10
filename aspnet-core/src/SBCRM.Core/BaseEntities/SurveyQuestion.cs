using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("SurveyQuestion", Schema = "web")]
    [Index(nameof(TenantId), Name = "SurveyQuestion_TenantId_index")]
    [Index(nameof(Survey), nameof(QuestionNo), nameof(TenantId), Name = "UC_SurveyQuestion", IsUnique = true)]
    public class SurveyQuestion : FullAuditedEntity<long>, IMustHaveTenant
    {
        public int TenantId { get; set; }
        [Required]
        [StringLength(50)]
        public string Survey { get; set; }
        public short QuestionNo { get; set; }
        [StringLength(255)]
        public string Question { get; set; }
        public short? Response { get; set; }
        public short? CheckResponses { get; set; }
        public short? Multiple { get; set; }
        public short? NextIfYes { get; set; }
        public short? NextIfNo { get; set; }
        [StringLength(50)]
        public string Check1 { get; set; }
        [StringLength(50)]
        public string Check2 { get; set; }
        [StringLength(50)]
        public string Check3 { get; set; }
        [StringLength(50)]
        public string Check4 { get; set; }
        [StringLength(50)]
        public string Check5 { get; set; }
        [StringLength(50)]
        public string Check6 { get; set; }
        [StringLength(50)]
        public string Check7 { get; set; }
        [StringLength(50)]
        public string Check8 { get; set; }
        [StringLength(50)]
        public string Check9 { get; set; }
        [StringLength(50)]
        public string Check10 { get; set; }
        [StringLength(50)]
        public string CreatedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DateCreated { get; set; }
        public bool IsMigrated { get; set; }
    }
}
