using Abp.Application.Services.Dto;

namespace SBCRM.Crm.Dtos
{
    /// <summary>
    /// Dto for the activity status lookup table of the Activity
    /// </summary>
    public class ActivityActivityStatusLookupTableDto
    {
        public int Id { get; set; }

        public string DisplayName { get; set; }

        public bool IsDefault { get; set; }
    }
}