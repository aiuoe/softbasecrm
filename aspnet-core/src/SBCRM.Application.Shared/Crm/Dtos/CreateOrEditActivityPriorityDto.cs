using System;
using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace SBCRM.Crm.Dtos
{
    /// <summary>
    /// Activity Priority Dto for Creating or Editing
    /// </summary>
    public class CreateOrEditActivityPriorityDto : EntityDto<int?>
    {

        [Required]
        [StringLength(ActivityPriorityConsts.MaxDescriptionLength, MinimumLength = ActivityPriorityConsts.MinDescriptionLength)]
        public string Description { get; set; }

        [Required]
        [StringLength(ActivityPriorityConsts.MaxColorLength, MinimumLength = ActivityPriorityConsts.MinColorLength)]
        public string Color { get; set; }

        public int Order { get; set; }

        public bool IsDefault { get; set; }

    }
}