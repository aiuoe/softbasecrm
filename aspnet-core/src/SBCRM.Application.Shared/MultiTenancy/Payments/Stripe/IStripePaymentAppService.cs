using System.Threading.Tasks;
using Abp.Application.Services;
using SBCRM.MultiTenancy.Payments.Dto;
using SBCRM.MultiTenancy.Payments.Stripe.Dto;

namespace SBCRM.MultiTenancy.Payments.Stripe
{
    public interface IStripePaymentAppService : IApplicationService
    {
        Task ConfirmPayment(StripeConfirmPaymentInput input);

        StripeConfigurationDto GetConfiguration();

        Task<SubscriptionPaymentDto> GetPaymentAsync(StripeGetPaymentInput input);

        Task<string> CreatePaymentSession(StripeCreatePaymentSessionInput input);
    }
}