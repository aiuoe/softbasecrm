using Abp.Application.Services.Dto;

namespace SBCRM.Crm.Dtos
{
    /// <summary>
    /// Activity Status Dto for Viewing Input
    /// </summary>
    public class GetAllActivityStatusesInput : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }

        public string DescriptionFilter { get; set; }
    }
}