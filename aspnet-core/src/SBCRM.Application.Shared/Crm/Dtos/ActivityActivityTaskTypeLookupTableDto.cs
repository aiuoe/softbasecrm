using Abp.Application.Services.Dto;

namespace SBCRM.Crm.Dtos
{
    /// <summary>
    /// Dto for the activity task type lookup table of the Activity
    /// </summary>
    public class ActivityActivityTaskTypeLookupTableDto
    {
        public int Id { get; set; }

        public string DisplayName { get; set; }
    }
}