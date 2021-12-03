using Abp.Application.Services.Dto;

namespace SBCRM.Crm.Dtos
{
    public class GetAllForLookupTableInput : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }
    }
}