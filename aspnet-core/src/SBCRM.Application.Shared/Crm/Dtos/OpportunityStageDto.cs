using Abp.Application.Services.Dto;

namespace SBCRM.Crm.Dtos
{
    /// <summary>
    /// DTO to manage the oportunity stage object
    /// </summary>
    public class OpportunityStageDto : EntityDto
    {
        /// <summary>
        /// Opportunity description
        /// </summary>
        public string Description { get; set; }
    }
}