using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("SurveyResponse", Schema = "web")]
    [Index(nameof(TenantId), Name = "SurveyResponse_TenantId_index")]
    [Index(nameof(CustomerNo), nameof(Survey), nameof(SurveyDate), nameof(QuestionNo), nameof(TenantId), Name = "UC_SurveyResponse", IsUnique = true)]
    public class SurveyResponse : FullAuditedEntity<long>, IMustHaveTenant
    {
        public int TenantId { get; set; }
        [Required]
        [StringLength(50)]
        public string CustomerNo { get; set; }
        [Required]
        [StringLength(50)]
        public string Survey { get; set; }
        public int QuestionNo { get; set; }
        [StringLength(255)]
        public string Response { get; set; }
        public short? Check1 { get; set; }
        public short? Check2 { get; set; }
        public short? Check3 { get; set; }
        public short? Check4 { get; set; }
        public short? Check5 { get; set; }
        public short? Check6 { get; set; }
        public short? Check7 { get; set; }
        public short? Check8 { get; set; }
        public short? Check9 { get; set; }
        public short? Check10 { get; set; }
        [StringLength(50)]
        public string CreatedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DateAnswered { get; set; }
        [StringLength(50)]
        public string AnsweredBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime SurveyDate { get; set; }
        public bool IsMigrated { get; set; }
    }
}
