using SBCRM.Crm;
using SBCRM.Crm;
using SBCRM.Crm;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities.Auditing;
using Abp.Domain.Entities;

namespace SBCRM.Crm
{
    [Table("Opportunities")]
    public class Opportunity : FullAuditedEntity
    {

        [Required]
        [StringLength(OpportunityConsts.MaxNameLength, MinimumLength = OpportunityConsts.MinNameLength)]
        public virtual string Name { get; set; }

        [Range(OpportunityConsts.MinAmountValue, OpportunityConsts.MaxAmountValue)]
        public virtual decimal Amount { get; set; }

        [Range(OpportunityConsts.MinProbabilityValue, OpportunityConsts.MaxProbabilityValue)]
        public virtual decimal Probability { get; set; }

        public virtual DateTime CloseDate { get; set; }

        public virtual string Description { get; set; }

        [StringLength(OpportunityConsts.MaxBranchLength, MinimumLength = OpportunityConsts.MinBranchLength)]
        public virtual string Branch { get; set; }

        [StringLength(OpportunityConsts.MaxDepartmentLength, MinimumLength = OpportunityConsts.MinDepartmentLength)]
        public virtual string Department { get; set; }

        public virtual int? OpportunityStageId { get; set; }

        [ForeignKey("OpportunityStageId")]
        public OpportunityStage OpportunityStageFk { get; set; }

        public virtual int? LeadSourceId { get; set; }

        [ForeignKey("LeadSourceId")]
        public LeadSource LeadSourceFk { get; set; }

        public virtual int? OpportunityTypeId { get; set; }

        [ForeignKey("OpportunityTypeId")]
        public OpportunityType OpportunityTypeFk { get; set; }

    }
}