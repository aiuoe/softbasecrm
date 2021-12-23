using System;
using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace SBCRM.Crm.Dtos
{
    /// <summary>
    /// DTO to manage the object opportunity type for create or edit purposes
    /// </summary>
    public class CreateOrEditOpportunityTypeDto : EntityDto<int?>
    {

        [Required]
        [StringLength(OpportunityTypeConsts.MaxDescriptionLength, MinimumLength = OpportunityTypeConsts.MinDescriptionLength)]
        public string Description { get; set; }

    }
}