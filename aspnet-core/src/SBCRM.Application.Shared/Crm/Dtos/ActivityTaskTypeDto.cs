using System;
using Abp.Application.Services.Dto;

namespace SBCRM.Crm.Dtos
{
    /// <summary>
    /// Dto for the Activity Task Type entity
    /// </summary>
    public class ActivityTaskTypeDto : EntityDto
    {
        public string Description { get; set; }

        public int Order { get; set; }

        public string Color { get; set; }
        
        public bool IsDefault { get; set; }

        public string Code { get; set; }

    }
}