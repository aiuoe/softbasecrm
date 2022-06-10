using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SBCRM.Core.BaseEntities
{
    [Table("WOInspection", Schema = "web")]
    [Index(nameof(TenantId), Name = "WOInspection_TenantId_index")]
    public class Woinspection : FullAuditedEntity<long>, IMustHaveTenant
    {
        public int TenantId { get; set; }
        [Column("WONo")]
        public int? Wono { get; set; }
        [StringLength(50)]
        public string InspectionName { get; set; }
        public int? Page { get; set; }
        public bool? Question01 { get; set; }
        public bool? Question02 { get; set; }
        public bool? Question03 { get; set; }
        public bool? Question04 { get; set; }
        public bool? Question05 { get; set; }
        public bool? Question06 { get; set; }
        public bool? Question07 { get; set; }
        public bool? Question08 { get; set; }
        public bool? Question09 { get; set; }
        public bool? Question10 { get; set; }
        public bool? Question11 { get; set; }
        public bool? Question12 { get; set; }
        public bool? Question13 { get; set; }
        public bool? Question14 { get; set; }
        public bool? Question15 { get; set; }
        public bool? Question16 { get; set; }
        public bool? Question17 { get; set; }
        public bool? Question18 { get; set; }
        public bool? Question19 { get; set; }
        public bool? Question20 { get; set; }
        public bool? Question21 { get; set; }
        public bool? Question22 { get; set; }
        public bool? Question23 { get; set; }
        public bool? Question24 { get; set; }
        public bool? Question25 { get; set; }
        public bool? Question26 { get; set; }
        public bool? Question27 { get; set; }
        public bool? Question28 { get; set; }
        public bool? Question29 { get; set; }
        public bool? Question30 { get; set; }
        public bool? Question31 { get; set; }
        public bool? Question32 { get; set; }
        public int? LegacyId { get; set; }
        public bool? QuestionFail01 { get; set; }
        public bool? QuestionFail02 { get; set; }
        public bool? QuestionFail03 { get; set; }
        public bool? QuestionFail04 { get; set; }
        public bool? QuestionFail05 { get; set; }
        public bool? QuestionFail06 { get; set; }
        public bool? QuestionFail07 { get; set; }
        public bool? QuestionFail08 { get; set; }
        public bool? QuestionFail09 { get; set; }
        public bool? QuestionFail10 { get; set; }
        public bool? QuestionFail11 { get; set; }
        public bool? QuestionFail12 { get; set; }
        public bool? QuestionFail13 { get; set; }
        public bool? QuestionFail14 { get; set; }
        public bool? QuestionFail15 { get; set; }
        public bool? QuestionFail16 { get; set; }
        public bool? QuestionFail17 { get; set; }
        public bool? QuestionFail18 { get; set; }
        public bool? QuestionFail19 { get; set; }
        public bool? QuestionFail20 { get; set; }
        public bool? QuestionFail21 { get; set; }
        public bool? QuestionFail22 { get; set; }
        public bool? QuestionFail23 { get; set; }
        public bool? QuestionFail24 { get; set; }
        public bool? QuestionFail25 { get; set; }
        public bool? QuestionFail26 { get; set; }
        public bool? QuestionFail27 { get; set; }
        public bool? QuestionFail28 { get; set; }
        public bool? QuestionFail29 { get; set; }
        public bool? QuestionFail30 { get; set; }
        public bool? QuestionFail31 { get; set; }
        public bool? QuestionFail32 { get; set; }
        public bool IsMigrated { get; set; }
    }
}
