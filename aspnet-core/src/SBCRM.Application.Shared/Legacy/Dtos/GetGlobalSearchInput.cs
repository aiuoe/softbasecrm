using Abp.Application.Services.Dto;

namespace SBCRM.Legacy.Dtos
{
    public enum GlobalSearchCategory
    {
        All,
        Account,
        Lead,
        Opportunity,
        Activity
    }

    /// <summary>
    /// Input for global search
    /// </summary>
    public class GetGlobalSearchInput : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }
        public GlobalSearchCategory? CategoryCode { get; set; }
    }
}
