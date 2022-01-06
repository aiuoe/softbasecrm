using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Auditing;
using Abp.Domain.Entities.Auditing;
using SBCRM.Crm.Support;
using SBCRM.Legacy;

namespace SBCRM.Crm
{
    /// <summary>
    /// Opportunity entity
    /// </summary>
    [Table("Opportunities")]
    [Audited]
    public class Opportunity : FullAuditedEntity, ISilentTenant
    {
        public int? TenantId { get; set; }

        [Required(ErrorMessage = "A Name is required")]
        [StringLength(OpportunityConsts.MaxNameLength, MinimumLength = OpportunityConsts.MinNameLength)]
        public virtual string Name { get; set; }

        [Range(OpportunityConsts.MinAmountValue, OpportunityConsts.MaxAmountValue)]
        public virtual decimal? Amount { get; set; }

        [Range(OpportunityConsts.MinProbabilityValue, OpportunityConsts.MaxProbabilityValue)]
        public virtual decimal? Probability { get; set; }

        public virtual DateTime? CloseDate { get; set; }

        public virtual string Description { get; set; }

        [Required(ErrorMessage = "An Stage is required")]
        public virtual int? OpportunityStageId { get; set; }

        [ForeignKey("OpportunityStageId")]
        public OpportunityStage OpportunityStageFk { get; set; }
        
        public virtual int? LeadSourceId { get; set; }

        [ForeignKey("LeadSourceId")]
        public LeadSource LeadSourceFk { get; set; }

        public virtual int? OpportunityTypeId { get; set; }

        [ForeignKey("OpportunityTypeId")]
        public OpportunityType OpportunityTypeFk { get; set; }

        [Required(ErrorMessage = "A Contact is required")]
        public virtual int? ContactId { get; set; }

        [ForeignKey("ContactId")]
        public Contact ContactFk { get; set; }

        [Required(ErrorMessage = "An Account is required")]
        public virtual string CustomerNumber { get; set; }

        [ForeignKey("CustomerNumber")]
        public Customer CustomerFk { get; set; }

        public virtual short Branch { get; set; }
        public virtual short Dept { get; set; }

        [ForeignKey("Branch, Dept")]
        public Department DepartmentFk { get; set; }

        public List<OpportunityUser> Users { get; set; }
    }
}