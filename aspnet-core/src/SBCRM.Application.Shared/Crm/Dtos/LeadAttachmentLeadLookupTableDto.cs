using Abp.Application.Services.Dto;

namespace SBCRM.Crm.Dtos
{

    /// <summary>
    /// Model to list the leads
    /// </summary>
    public class LeadAttachmentLeadLookupTableDto
    {
        public int Id { get; set; }

        public string DisplayName { get; set; }
    }
}