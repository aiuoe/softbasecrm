using System;
using Abp.Application.Services.Dto;

namespace SBCRM.Crm.Dtos
{
    public class ActivityPriorityDto : EntityDto
    {
        public string Description { get; set; }

        public string Color { get; set; }

    }
}