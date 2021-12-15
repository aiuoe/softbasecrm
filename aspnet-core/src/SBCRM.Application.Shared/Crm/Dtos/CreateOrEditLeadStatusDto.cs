using System;
using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace SBCRM.Crm.Dtos
{
    /// <summary>
    /// Lead status dto used by the ui to create or edit a lead status
    /// </summary>
    public class CreateOrEditLeadStatusDto : EntityDto<int?>
    {

        [Required]
        [StringLength(LeadStatusConsts.MaxDescriptionLength, MinimumLength = LeadStatusConsts.MinDescriptionLength)]
        public string Description { get; set; }

        public bool IsLeadConversionValid { get; set; }

        public bool IsDefault { get; set; }

    }
}