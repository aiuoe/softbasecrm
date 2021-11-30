using Abp.AspNetCore.Mvc.Authorization;
using SBCRM.Authorization;
using SBCRM.Storage;
using Abp.BackgroundJobs;

namespace SBCRM.Web.Controllers
{
    [AbpMvcAuthorize(AppPermissions.Pages_Administration_Users)]
    public class UsersController : UsersControllerBase
    {
        public UsersController(IBinaryObjectManager binaryObjectManager, IBackgroundJobManager backgroundJobManager)
            : base(binaryObjectManager, backgroundJobManager)
        {
        }
    }
}