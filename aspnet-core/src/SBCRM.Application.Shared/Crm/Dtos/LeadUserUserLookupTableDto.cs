using Abp.Application.Services.Dto;

namespace SBCRM.Crm.Dtos
{
    /// <summary>
    /// DTO to manage the object lead user user for input purposes
    /// </summary>
    public class LeadUserUserLookupTableDto
    {
        public long Id { get; set; }

        public string DisplayName { get; set; }
    }
}