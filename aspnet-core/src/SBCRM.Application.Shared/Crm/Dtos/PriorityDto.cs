using System;
using Abp.Application.Services.Dto;

namespace SBCRM.Crm.Dtos
{
    /// <summary>
    /// DTO for priority entities
    /// </summary>
    public class PriorityDto : EntityDto
    {
        public string Description { get; set; }

        public bool IsDefault { get; set; }

        public string Color { get; set; }

    }
}