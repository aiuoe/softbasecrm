using Abp.Application.Services.Dto;

namespace SBCRM.Crm.Dtos
{
    /// <summary>
    /// App service to handle opportunity stage information
    /// </summary>
    public class OpportunityStageDto : EntityDto
    {
        public string Description { get; set; }

        public int Order { get; set; }

        public string Color { get; set; }
    }
}