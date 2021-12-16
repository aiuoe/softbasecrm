using Abp.Application.Services.Dto;

namespace SBCRM.Crm.Dtos
{
    /// <summary>
    /// A lookup table dto for priorities
    /// </summary>
    public class LeadPriorityLookupTableDto
    {
        public int Id { get; set; }

        public string DisplayName { get; set; }

        public bool IsDefault { get; set; }
    }
}