using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace SBCRM.Crm.Dtos
{
    /// <summary>
    /// Class that handles Dto for lead sources
    /// </summary>
    public class CreateOrEditLeadSourceDto : EntityDto<int?>
    {
        /// <summary>
        /// Lead source description
        /// </summary>
        [Required]
        [StringLength(LeadSourceConsts.MaxDescriptionLength, MinimumLength = LeadSourceConsts.MinDescriptionLength)]
        public string Description { get; set; }

        /// <summary>
        /// lead source order
        /// </summary>
        public virtual int Order { get; set; }
    }
}