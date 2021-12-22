using System;
using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace SBCRM.Crm.Dtos
{
    /// <summary>
    /// DTO to manage the object opportunity for create or edit purposes
    /// </summary>
    public class CreateOrEditOpportunityDto : EntityDto<int?>
    {

        [Required(ErrorMessage = "A Name is required")]
        [StringLength(OpportunityConsts.MaxNameLength, MinimumLength = OpportunityConsts.MinNameLength)]
        public string Name { get; set; }

        [Range(OpportunityConsts.MinAmountValue, OpportunityConsts.MaxAmountValue)]
        public decimal? Amount { get; set; }

        [Range(OpportunityConsts.MinProbabilityValue, OpportunityConsts.MaxProbabilityValue)]
        public decimal? Probability { get; set; }

        public DateTime? CloseDate { get; set; }

        public string Description { get; set; }

        [StringLength(OpportunityConsts.MaxBranchLength, MinimumLength = OpportunityConsts.MinBranchLength)]
        public string Branch { get; set; }

        [StringLength(OpportunityConsts.MaxDepartmentLength, MinimumLength = OpportunityConsts.MinDepartmentLength)]
        public string Department { get; set; }

        [Required(ErrorMessage = "A Stage is required")]
        [Range(1, int.MaxValue, ErrorMessage = "A Stage is required")]
        public int OpportunityStageId { get; set; }

        public int? LeadSourceId { get; set; }

        public int? OpportunityTypeId { get; set; }

        [Required(ErrorMessage = "An Account is required")]
        public string CustomerNumber { get; set; }

        [Required(ErrorMessage = "A Contact is required")]
        [Range(1, int.MaxValue, ErrorMessage = "A Contact is required")]
        public int ContactId { get; set; }
    }
}