using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using SBCRM.Legacy;

namespace SBCRM.Base
{
    /// <summary>
    /// Repository to manage the customer invoices information
    /// </summary>
    public interface ISoftBaseCustomerInvoiceRepository
    {
        /// <summary>
        /// Get customer invoices
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<PagedResultDto<CustomerInvoiceViewDto>> GetPagedCustomerInvoices(GetAllCustomerInvoicesInput input);
    }
}
