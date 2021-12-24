using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace SBCRM.Crm.Dtos
{
    /// <summary>
    /// DTO to manage the object opportunity stage for create or edit purposes
    /// </summary>
    public class CreateOrEditOpportunityStageDto : EntityDto<int?>
    {
        [Required]
        [StringLength(OpportunityStageConsts.MaxDescriptionLength, MinimumLength = OpportunityStageConsts.MinDescriptionLength)]
        public string Description { get; set; }

        public virtual int Order { get; set; }

        public virtual string Color { get; set; }
    }
}