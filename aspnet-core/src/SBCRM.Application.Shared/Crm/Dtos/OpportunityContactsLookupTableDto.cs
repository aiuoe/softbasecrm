using Abp.Application.Services.Dto;

namespace SBCRM.Crm.Dtos
{
    /// <summary>
    /// DTO to manage the customer - contacts source lookup object
    /// </summary>
    public class OpportunityContactsLookupTableDto
    {
        public int Id { get; set; }

        public string ContactName { get; set; }

    }
}
