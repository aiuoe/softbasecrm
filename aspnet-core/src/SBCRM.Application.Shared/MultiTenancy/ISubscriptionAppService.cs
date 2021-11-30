using System.Threading.Tasks;
using Abp.Application.Services;

namespace SBCRM.MultiTenancy
{
    public interface ISubscriptionAppService : IApplicationService
    {
        Task DisableRecurringPayments();

        Task EnableRecurringPayments();
    }
}
