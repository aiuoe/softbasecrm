using System;
using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace SBCRM.Crm.Dtos
{
    public class CreateOrEditOpportunityDto : EntityDto<int?>
    {

        [Required]
        [StringLength(OpportunityConsts.MaxNameLength, MinimumLength = OpportunityConsts.MinNameLength)]
        public string Name { get; set; }

        [Range(OpportunityConsts.MinAmountValue, OpportunityConsts.MaxAmountValue)]
        public decimal Amount { get; set; }

        [Range(OpportunityConsts.MinProbabilityValue, OpportunityConsts.MaxProbabilityValue)]
        public decimal Probability { get; set; }

        public DateTime CloseDate { get; set; }

        public string Description { get; set; }

        [StringLength(OpportunityConsts.MaxBranchLength, MinimumLength = OpportunityConsts.MinBranchLength)]
        public string Branch { get; set; }

        [StringLength(OpportunityConsts.MaxDepartmentLength, MinimumLength = OpportunityConsts.MinDepartmentLength)]
        public string Department { get; set; }

        public int? OpportunityStageId { get; set; }

        public int? LeadSourceId { get; set; }

        public int? OpportunityTypeId { get; set; }

    }
}