using Abp.Application.Services.Dto;

namespace SBCRM.Crm.Dtos
{
    /// <summary>
    /// A lookup table dto for lead status
    /// </summary>
    public class LeadLeadStatusLookupTableDto
    {
        public bool isLeadConversionValid;

        public int Id { get; set; }

        public string DisplayName { get; set; }

        public bool IsDefault { get; set; }
    }
}