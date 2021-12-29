using Abp.Application.Services.Dto;

namespace SBCRM.Crm.Dtos
{
    /// <summary>
    /// OpportunityUser dto used populate the lookup table
    /// </summary>
    public class OpportunityUserOpportunityLookupTableDto
    {
        public int Id { get; set; }

        public string DisplayName { get; set; }
    }
}