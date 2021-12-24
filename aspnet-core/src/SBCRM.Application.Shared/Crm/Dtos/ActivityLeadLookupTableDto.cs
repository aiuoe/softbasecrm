using Abp.Application.Services.Dto;

namespace SBCRM.Crm.Dtos
{
    /// <summary>
    /// Dto for the Lead lookup table of the Activity
    /// </summary>
    public class ActivityLeadLookupTableDto
    {
        public int Id { get; set; }

        public string DisplayName { get; set; }
    }
}