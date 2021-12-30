using Abp.Application.Services.Dto;

namespace SBCRM.Crm.Dtos
{
    /// <summary>
    /// Class that handles the request for get a lead source list
    /// </summary>
    public class GetAllLeadStatusesInput : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }

        public string DescriptionFilter { get; set; }

        public string ColorFilter { get; set; }

        public int? IsLeadConversionValidFilter { get; set; }

        public int? IsDefaultFilter { get; set; }
    }
}