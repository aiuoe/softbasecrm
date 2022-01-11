using System;
using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace SBCRM.Crm.Dtos
{
    /// <summary>
    /// Lead attachment data transfer model for creating and editing attachment.
    /// </summary>
    public class CreateOrEditLeadAttachmentDto : EntityDto<int?>
    {

        [Required]
        public string Name { get; set; }

        [Required]
        public string FilePath { get; set; }

        public int? LeadId { get; set; }

    }
}