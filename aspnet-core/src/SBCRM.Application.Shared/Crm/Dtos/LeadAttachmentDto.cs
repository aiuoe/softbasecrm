using System;
using Abp.Application.Services.Dto;

namespace SBCRM.Crm.Dtos
{
    public class LeadAttachmentDto : EntityDto
    {
        public string Name { get; set; }

        public string FilePath { get; set; }

        public int? LeadId { get; set; }

    }
}