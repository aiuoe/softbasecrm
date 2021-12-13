using System;
using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace SBCRM.Crm.Dtos
{
    public class CreateOrEditOpportunityStageDto : EntityDto<int?>
    {

        [Required]
        [StringLength(OpportunityStageConsts.MaxDescriptionLength, MinimumLength = OpportunityStageConsts.MinDescriptionLength)]
        public string Description { get; set; }

    }
}