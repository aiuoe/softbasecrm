using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using SBCRM.MultiTenancy.Accounting.Dto;

namespace SBCRM.MultiTenancy.Accounting
{
    public interface IInvoiceAppService
    {
        Task<InvoiceDto> GetInvoiceInfo(EntityDto<long> input);

        Task CreateInvoice(CreateInvoiceDto input);
    }
}
