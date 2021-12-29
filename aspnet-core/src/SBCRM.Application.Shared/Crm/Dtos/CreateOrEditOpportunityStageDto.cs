using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace SBCRM.Crm.Dtos
{
    /// <summary>
    /// DTO to manage the object opportunity stages for input purposes
    /// </summary>
    public class CreateOrEditOpportunityStageDto : EntityDto<int?>
    {
        [Required]
        [StringLength(OpportunityStageConsts.MaxDescriptionLength, MinimumLength = OpportunityStageConsts.MinDescriptionLength)]
        public string Description { get; set; }

        public virtual int Order { get; set; }

        [Required]
        [StringLength(OpportunityStageConsts.MaxColorLength, MinimumLength = OpportunityStageConsts.MinColorLength)]
        public string Color { get; set; }
    }
}