using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Authorization;
using SBCRM.Authorization;
using SBCRM.Crm.Dtos;

namespace SBCRM.Modules.Administration
{
    /// <summary>
    /// App service to handle Department information
    /// </summary>
    [RemoteService(false)]
    [AbpAuthorize(AppPermissions.Pages_Administration_Department)]
    public class DepartmentAppService : SBCRMAppServiceBase, IDepartmentAppService
    {
        /// <summary>
        /// Create or edit department
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task CreateOrEdit(CreateOrEditDepartmentDto input)
        {
            throw new NotImplementedException();
        }
    }
}
