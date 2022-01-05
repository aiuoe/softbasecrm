using Abp.Application.Services.Dto;

namespace SBCRM.Crm.Dtos
{
    /// <summary>
    /// DTO to manage the filter object to get customer opportunities
    /// </summary>
    public class GetCustomerOpportunitiesInput : PagedAndSortedResultRequestDto
    {
        public string CustomerNumber { get; set; }
    }
}
