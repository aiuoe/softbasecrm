using Abp.Application.Services.Dto;

namespace SBCRM.Crm.Dtos
{
    /// <summary>
    /// Dto for the activity priority lookup table of the Activity
    /// </summary>
    public class ActivityActivityPriorityLookupTableDto
    {
        public int Id { get; set; }

        public string DisplayName { get; set; }
    }
}