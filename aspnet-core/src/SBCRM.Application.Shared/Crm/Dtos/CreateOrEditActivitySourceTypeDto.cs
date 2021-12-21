using System;
using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace SBCRM.Crm.Dtos
{
    public class CreateOrEditActivitySourceTypeDto : EntityDto<int?>
    {

        [Required]
        [StringLength(ActivitySourceTypeConsts.MaxDescriptionLength, MinimumLength = ActivitySourceTypeConsts.MinDescriptionLength)]
        public string Description { get; set; }

    }
}