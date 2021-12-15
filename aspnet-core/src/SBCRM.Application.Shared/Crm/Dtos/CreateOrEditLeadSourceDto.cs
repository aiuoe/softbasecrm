using System;
using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace SBCRM.Crm.Dtos
{
    /// <summary>
    /// Lead source dto used by the ui to create or edit a lead source
    /// </summary>
    public class CreateOrEditLeadSourceDto : EntityDto<int?>
    {

        [Required]
        [StringLength(LeadSourceConsts.MaxDescriptionLength, MinimumLength = LeadSourceConsts.MinDescriptionLength)]
        public string Description { get; set; }

        public bool IsDefault { get; set; }

    }
}