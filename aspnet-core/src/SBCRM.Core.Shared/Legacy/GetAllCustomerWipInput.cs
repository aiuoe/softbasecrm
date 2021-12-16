using Abp.Application.Services.Dto;

namespace SBCRM.Legacy
{
    /// <summary>
    /// DTO to manage the filter object to get customer WIP
    /// </summary>
    public class GetAllCustomerWipInput : PagedAndSortedResultRequestDto
    {
        public string CustomerNumber { get; set; }
        public bool Quotes { get; set; }
        public bool AcceptedQuotes { get; set; }
        public bool CanceledQuotes { get; set; }
    }
}
