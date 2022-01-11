using System;
using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace SBCRM.Crm.Dtos
{
    /// <summary>
    /// A lead attachment model for creating purposes.
    /// </summary>
    public class CreateOrEditOpportunityAttachmentDto : EntityDto<int?>
    {

        [Required]
        [StringLength(OpportunityAttachmentConsts.MaxNameLength, MinimumLength = OpportunityAttachmentConsts.MinNameLength)]
        public string Name { get; set; }

        [Required]
        [StringLength(OpportunityAttachmentConsts.MaxFilePathLength, MinimumLength = OpportunityAttachmentConsts.MinFilePathLength)]
        public string FilePath { get; set; }

        public int? OpportunityId { get; set; }

    }
}