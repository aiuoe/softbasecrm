using System.Threading.Tasks;
using Abp.Webhooks;

namespace SBCRM.WebHooks
{
    public interface IWebhookEventAppService
    {
        Task<WebhookEvent> Get(string id);
    }
}
