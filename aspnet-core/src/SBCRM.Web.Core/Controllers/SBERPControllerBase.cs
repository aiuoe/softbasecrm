using Microsoft.AspNetCore.Mvc;

namespace SBCRM.Web.Controllers
{
    /// <summary>
    /// ERP Controller base
    /// </summary>
    [ApiVersion("1.0")]
    [Route("/api/v1.0/services/[controller]/[action]")]
    public abstract class SBERPControllerBase : SBCRMControllerBase
    {

    }
}