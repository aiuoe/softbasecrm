using System;
using Abp.Application.Services.Dto;

namespace SBCRM.Crm.Dtos
{
    public class CustomerAttachmentDto : EntityDto<int?>
    {
        public string Name { get; set; }

        public string FilePath { get; set; }

        public string CustomerNumber { get; set; }
    }
}