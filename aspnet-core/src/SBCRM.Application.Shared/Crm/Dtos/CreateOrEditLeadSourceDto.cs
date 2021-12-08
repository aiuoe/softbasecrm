using System;
using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace SBCRM.Crm.Dtos
{
    public class CreateOrEditLeadSourceDto : EntityDto<int?>
    {

        [Required]
        [StringLength(LeadSourceConsts.MaxDescriptionLength, MinimumLength = LeadSourceConsts.MinDescriptionLength)]
        public string Description { get; set; }

    }
}