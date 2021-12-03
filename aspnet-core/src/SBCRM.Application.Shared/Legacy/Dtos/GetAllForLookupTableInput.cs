using Abp.Application.Services.Dto;

namespace SBCRM.Legacy.Dtos
{
    public class GetAllForLookupTableInput : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }
    }
}