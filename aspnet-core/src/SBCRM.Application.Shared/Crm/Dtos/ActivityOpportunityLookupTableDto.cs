using Abp.Application.Services.Dto;

namespace SBCRM.Crm.Dtos
{
    /// <summary>
    /// Dto for the Opportunity lookup table of the Activity
    /// </summary>
    public class ActivityOpportunityLookupTableDto
    {
        public int Id { get; set; }

        public string DisplayName { get; set; }

        public string CustomerNumber { get; set; }
    }
}