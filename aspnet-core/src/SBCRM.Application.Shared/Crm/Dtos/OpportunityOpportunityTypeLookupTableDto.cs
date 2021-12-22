using Abp.Application.Services.Dto;

namespace SBCRM.Crm.Dtos
{
    /// <summary>
    /// DTO to manage the opportunity - opportunity type type lookup object
    /// </summary>
    public class OpportunityOpportunityTypeLookupTableDto
    {
        public int Id { get; set; }

        public string DisplayName { get; set; }
    }
}