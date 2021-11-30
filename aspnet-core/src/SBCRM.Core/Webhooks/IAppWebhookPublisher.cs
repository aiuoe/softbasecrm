using System.Threading.Tasks;
using SBCRM.Authorization.Users;

namespace SBCRM.WebHooks
{
    public interface IAppWebhookPublisher
    {
        Task PublishTestWebhook();
    }
}
