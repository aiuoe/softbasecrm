using System.Threading.Tasks;
using Abp.Dependency;

namespace SBCRM.MultiTenancy.Accounting
{
    public interface IInvoiceNumberGenerator : ITransientDependency
    {
        Task<string> GetNewInvoiceNumber();
    }
}