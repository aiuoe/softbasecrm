using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace SBCRM.Crm.Dtos
{
    /// <summary>
    /// Class that handles the request for create or edit a lead source
    /// </summary>
    public class CreateOrEditLeadStatusDto : EntityDto<int?>
    {
        [Required]
        [StringLength(LeadStatusConsts.MaxDescriptionLength, MinimumLength = LeadStatusConsts.MinDescriptionLength)]
        public string Description { get; set; }

        [Required]
        [StringLength(LeadStatusConsts.MaxColorLength, MinimumLength = LeadStatusConsts.MinColorLength)]
        public string Color { get; set; }

        public bool IsLeadConversionValid { get; set; }

        public bool IsDefault { get; set; }

        public virtual int Order { get; set; }
    }
}