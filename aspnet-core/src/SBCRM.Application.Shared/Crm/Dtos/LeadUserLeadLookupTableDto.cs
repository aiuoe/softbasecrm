using Abp.Application.Services.Dto;

namespace SBCRM.Crm.Dtos
{
    /// <summary>
    /// DTO to manage the object lead user lead for lookup purposes
    /// </summary>
    public class LeadUserLeadLookupTableDto
    {
        public int Id { get; set; }

        public string DisplayName { get; set; }
    }
}