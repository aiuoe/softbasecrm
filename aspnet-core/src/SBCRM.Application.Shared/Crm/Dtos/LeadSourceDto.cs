using System;
using Abp.Application.Services.Dto;

namespace SBCRM.Crm.Dtos
{
    public class LeadSourceDto : EntityDto
    {
        public string Description { get; set; }

        public int Order { get; set; }

        public bool IsDefault { get; set; }

    }
}