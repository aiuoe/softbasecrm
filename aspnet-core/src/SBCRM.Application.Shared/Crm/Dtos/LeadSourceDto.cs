using Abp.Application.Services.Dto;

namespace SBCRM.Crm.Dtos
{
    /// <summary>
    /// DTO to manage the object lead source
    /// </summary>
    public class LeadSourceDto : EntityDto
    {
        public string Description { get; set; }

        public int Order { get; set; }

        public virtual bool IsDefault { get; set; }
    }
}