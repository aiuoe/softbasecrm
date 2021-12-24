using Abp.Application.Services.Dto;

namespace SBCRM.Crm.Dtos
{
    /// <summary>
    /// Dto for the User lookup table of the Activity
    /// </summary>
    public class ActivityUserLookupTableDto
    {
        public long Id { get; set; }

        public string DisplayName { get; set; }
    }
}