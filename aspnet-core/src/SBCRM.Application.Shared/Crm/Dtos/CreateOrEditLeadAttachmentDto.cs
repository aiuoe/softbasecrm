using System;
using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace SBCRM.Crm.Dtos
{
    public class CreateOrEditLeadAttachmentDto : EntityDto<int?>
    {

        [Required]
        public string Name { get; set; }

        [Required]
        public string FilePath { get; set; }

        public int? LeadId { get; set; }

    }
}