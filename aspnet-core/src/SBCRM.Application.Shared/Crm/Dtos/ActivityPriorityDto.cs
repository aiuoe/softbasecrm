using System;
using Abp.Application.Services.Dto;

namespace SBCRM.Crm.Dtos
{
    /// <summary>
    /// Dto for the Activity Priority entity
    /// </summary>
    public class ActivityPriorityDto : EntityDto
    {
        public string Description { get; set; }

        public string Color { get; set; }

        public int Order { get; set; }

        public bool IsDefault { get; set; }

    }
}