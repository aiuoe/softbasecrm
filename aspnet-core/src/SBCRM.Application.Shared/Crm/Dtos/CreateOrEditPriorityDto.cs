using System;
using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace SBCRM.Crm.Dtos
{
    public class CreateOrEditPriorityDto : EntityDto<int?>
    {

        [Required]
        [StringLength(PriorityConsts.MaxDescriptionLength, MinimumLength = PriorityConsts.MinDescriptionLength)]
        public string Description { get; set; }

    }
}