using System;
using Abp.Application.Services.Dto;

namespace SBCRM.Crm.Dtos
{
    public class CustomerAttachmentDto : EntityDto
    {
        public string Name { get; set; }

        public string FilePath { get; set; }

    }
}