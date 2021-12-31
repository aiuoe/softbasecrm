using Abp.Application.Services.Dto;

namespace SBCRM.Crm.Dtos
{
    /// <summary>
    /// Class that handles Dto for Lead Status module
    /// </summary>
    public class LeadStatusDto : EntityDto
    {
        public string Description { get; set; }

        public string Color { get; set; }

        public bool IsLeadConversionValid { get; set; }

        public bool IsDefault { get; set; }
    }
}