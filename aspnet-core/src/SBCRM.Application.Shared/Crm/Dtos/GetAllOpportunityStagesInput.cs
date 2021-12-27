using Abp.Application.Services.Dto;

namespace SBCRM.Crm.Dtos
{
    /// <summary>
    /// DTO to manage the object opportunity stages for input purposes
    /// </summary>
    public class GetAllOpportunityStagesInput : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }

        public string DescriptionFilter { get; set; }
    }
}