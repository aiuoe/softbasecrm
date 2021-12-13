using System;
using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace SBCRM.Crm.Dtos
{
    public class CreateOrEditActivityStatusDto : EntityDto<int?>
    {

        [StringLength(ActivityStatusConsts.MaxDescriptionLength, MinimumLength = ActivityStatusConsts.MinDescriptionLength)]
        public string Description { get; set; }

    }
}