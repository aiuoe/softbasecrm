using System;
using Abp.Application.Services.Dto;

namespace SBCRM.Crm.Dtos
{
    /// <summary>
    /// DTO for lead status entities
    /// </summary>
    public class LeadStatusDto : EntityDto
    {
        public string Description { get; set; }

        public bool IsLeadConversionValid { get; set; }

        public bool IsDefault { get; set; }
    }
}