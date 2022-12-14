using System;
using System.Threading.Tasks;
using Abp.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc;
using SBCRM.Crm.Dtos;
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

        [HttpPost]
        public async Task<CreateOrEditDepartmentDto> Create([FromBody] CreateOrEditLeadDto input)
        {
            throw new NotImplementedException();
        }
    }
}
