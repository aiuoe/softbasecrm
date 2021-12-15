using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using SBCRM.Legacy;

namespace SBCRM.Base
{
    /// <summary>
    /// Repository to manage the customer WIP information
    /// </summary>
    public interface ISoftBaseCustomerWipRepository
    {
        /// <summary>
        /// Get customer invoices
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<PagedResultDto<CustomerInvoiceWipViewDto>> GetPagedCustomerInvoices(GetAllCustomerInvoicesInput input);
    }
}
