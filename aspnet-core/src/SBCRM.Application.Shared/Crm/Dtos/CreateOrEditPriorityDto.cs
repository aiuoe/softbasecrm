using System;
using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace SBCRM.Crm.Dtos
{
    /// <summary>
    /// Priority dto used by the ui to create or edit a priority
    /// </summary>
    public class CreateOrEditPriorityDto : EntityDto<int?>
    {

        [Required]
        [StringLength(PriorityConsts.MaxDescriptionLength, MinimumLength = PriorityConsts.MinDescriptionLength)]
        public string Description { get; set; }

        public bool IsDefault { get; set; }

    }
}