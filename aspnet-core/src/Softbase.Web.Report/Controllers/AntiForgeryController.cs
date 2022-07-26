using Microsoft.AspNetCore.Antiforgery;

namespace SBCRM.Web.Controllers
{
    public class AntiForgeryController : SBCRMControllerBase
    {
        private readonly IAntiforgery _antiforgery;

        public AntiForgeryController(IAntiforgery antiforgery)
        {
            _antiforgery = antiforgery;
        }

        public void GetToken()
        {
            _antiforgery.SetCookieTokenAndHeader(HttpContext);
        }
    }
}
