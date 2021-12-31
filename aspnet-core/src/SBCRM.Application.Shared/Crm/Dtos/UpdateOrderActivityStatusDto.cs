using Abp.Application.Services.Dto;

namespace SBCRM.Crm.Dtos
{
    /// <summary>
    /// DTO to manage the lead status for update order
    /// </summary>
    public class UpdateOrderActivityStatusDto : EntityDto<int?>
    {
        public virtual int Order { get; set; }
    }
}