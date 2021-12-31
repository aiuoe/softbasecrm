using System;
using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace SBCRM.Crm.Dtos
{
    /// <summary>
    /// Activity Task Type Dto for Creating or Editing
    /// </summary>
    public class CreateOrEditActivityTaskTypeDto : EntityDto<int?>
    {

        [StringLength(ActivityTaskTypeConsts.MaxDescriptionLength, MinimumLength = ActivityTaskTypeConsts.MinDescriptionLength)]
        public string Description { get; set; }

        public bool IsDefault { get; set; }

        [StringLength(ActivityTaskTypeConsts.MaxCodeLength, MinimumLength = ActivityTaskTypeConsts.MinCodeLength)]
        public string Code { get; set; }

    }
}