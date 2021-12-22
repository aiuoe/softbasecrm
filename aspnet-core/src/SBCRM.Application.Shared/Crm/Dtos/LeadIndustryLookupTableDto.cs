using Abp.Application.Services.Dto;

namespace SBCRM.Crm.Dtos
{
    /// <summary>
    /// DTO to manage the object lead industry for lookup purposes
    /// </summary>
    public class LeadIndustryLookupTableDto
    {
        public int Id { get; set; }

        public string DisplayName { get; set; }
    }
}