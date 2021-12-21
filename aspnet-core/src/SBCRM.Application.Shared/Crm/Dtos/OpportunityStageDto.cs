using Abp.Application.Services.Dto;

namespace SBCRM.Crm.Dtos
{
    /// <summary>
    /// Class Dto for OpportunityStage entity
    /// </summary>
    public class OpportunityStageDto : EntityDto
    {
        /// <summary>
        /// Opportunity description
        /// </summary>
        public string Description { get; set; }
    }
}