using Abp.Application.Services.Dto;

namespace SBCRM.Crm.Dtos
{
    /// <summary>
    /// DTO to manage the oportunity stage for update order
    /// </summary>
    public class UpdateOrderOpportunityStageDto : EntityDto<int?>
    {
        public string Description { get; set; }
        public virtual int Order { get; set; }
    }
}