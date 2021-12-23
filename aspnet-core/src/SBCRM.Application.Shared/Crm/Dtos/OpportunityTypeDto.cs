using System;
using Abp.Application.Services.Dto;

namespace SBCRM.Crm.Dtos
{
    /// <summary>
    /// DTO to manage the opportunity type object
    /// </summary>
    public class OpportunityTypeDto : EntityDto
    {
        public string Description { get; set; }

        public int Order { get; set; }

    }
}