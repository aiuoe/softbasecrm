using System.Threading.Tasks;
using SBCRM.Security.Recaptcha;

namespace SBCRM.Test.Base.Web
{
    public class FakeRecaptchaValidator : IRecaptchaValidator
    {
        public Task ValidateAsync(string captchaResponse)
        {
            return Task.CompletedTask;
        }
    }
}
