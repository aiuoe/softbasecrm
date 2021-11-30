using Microsoft.AspNetCore.Mvc;
using SBCRM.Web.Controllers;

namespace SBCRM.Web.Public.Controllers
{
    public class AboutController : SBCRMControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}