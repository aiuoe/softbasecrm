using Abp.Application.Services.Dto;

namespace SBCRM.Legacy.Dtos
{
    /// <summary>
    /// Input for global search
    /// </summary>
    public class GetGlobalSearchInput : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }
        public GlobalSearchCategory? CategoryCode { get; set; }
    }
}
