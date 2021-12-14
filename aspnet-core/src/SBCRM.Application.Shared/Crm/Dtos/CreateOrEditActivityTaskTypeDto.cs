using System;
using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace SBCRM.Crm.Dtos
{
    public class CreateOrEditActivityTaskTypeDto : EntityDto<int?>
    {

        [StringLength(ActivityTaskTypeConsts.MaxDescriptionLength, MinimumLength = ActivityTaskTypeConsts.MinDescriptionLength)]
        public string Description { get; set; }

    }
}