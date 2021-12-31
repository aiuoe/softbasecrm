using System;
using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace SBCRM.Crm.Dtos
{
    /// <summary>
    /// Activity Source Type Dto for Creating or Editing
    /// </summary>
    public class CreateOrEditActivitySourceTypeDto : EntityDto<int?>
    {

        [Required]
        [StringLength(ActivitySourceTypeConsts.MaxDescriptionLength, MinimumLength = ActivitySourceTypeConsts.MinDescriptionLength)]
        public string Description { get; set; }

        public int Order { get; set; }

        [StringLength(ActivitySourceTypeConsts.MaxCodeLength, MinimumLength = ActivitySourceTypeConsts.MinCodeLength)]
        public string Code { get; set; }

    }
}