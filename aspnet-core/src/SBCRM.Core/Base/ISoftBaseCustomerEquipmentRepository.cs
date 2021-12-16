using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using SBCRM.Legacy;

namespace SBCRM.Base
{
    /// <summary>
    /// Repository to manage the customer equipment information
    /// </summary>
    public interface ISoftBaseCustomerEquipmentRepository
    {
        /// <summary>
        /// Get customer invoices
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<PagedResultDto<CustomerEquipmentViewDto>> GetPagedCustomerEquipment(GetAllCustomerEquipmentInput input);
    }
}
