using Abp.AspNetCore.Mvc.Authorization;
using SBCRM.Authorization.Users.Profile;
using SBCRM.Crm;
using SBCRM.Storage;

namespace SBCRM.Web.Controllers
{
    [AbpMvcAuthorize]
    public class LeadImportController : LeadImportControllerBase
    {
        public LeadImportController(
            ILeadsAppService leadsAppService,
            ITempFileCacheManager tempFileCacheManager,
            IProfileAppService profileAppService)
            : base(leadsAppService, tempFileCacheManager, profileAppService)
        {
        }
    }
}