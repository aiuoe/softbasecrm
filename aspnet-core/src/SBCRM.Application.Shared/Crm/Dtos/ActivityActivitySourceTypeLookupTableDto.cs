using Abp.Application.Services.Dto;

namespace SBCRM.Crm.Dtos
{
    /// <summary>
    /// Dto for the activity source type lookup table of the Activity
    /// </summary>
    public class ActivityActivitySourceTypeLookupTableDto
    {
        public int Id { get; set; }

        public string DisplayName { get; set; }

        public string Code { get; set; }
    }
}