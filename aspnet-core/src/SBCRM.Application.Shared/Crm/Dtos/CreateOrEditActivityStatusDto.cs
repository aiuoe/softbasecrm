using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace SBCRM.Crm.Dtos
{
    /// <summary>
    /// Activity Status Dto for Creating or Editing
    /// </summary>
    public class CreateOrEditActivityStatusDto : EntityDto<int?>
    {
        [Required]
        [StringLength(ActivityStatusConsts.MaxDescriptionLength, MinimumLength = ActivityStatusConsts.MinDescriptionLength)]
        public string Description { get; set; }

        public int Order { get; set; }

        [Required]
        [StringLength(ActivityStatusConsts.MaxColorLength, MinimumLength = ActivityStatusConsts.MinColorLength)]
        public string Color { get; set; }

        public bool IsCompletedStatus { get; set; }
    }
}