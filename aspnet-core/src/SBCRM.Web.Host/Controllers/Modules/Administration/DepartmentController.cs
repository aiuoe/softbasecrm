using Abp.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc;
using SBCRM.Modules.Administration;

namespace SBCRM.Web.Controllers.Modules.Administration
{
    /// <summary>
    /// Department controller
    /// </summary>
    [AbpMvcAuthorize]
    public class DepartmentController : SBERPControllerBase
    {
        private readonly IDepartmentAppService _departmentAppService;

        /// <summary>
        /// Base constructor
        /// </summary>
        /// <param name="departmentAppService"></param>
        public DepartmentController(IDepartmentAppService departmentAppService)
        {
            _departmentAppService = departmentAppService;
        }
    }
}
