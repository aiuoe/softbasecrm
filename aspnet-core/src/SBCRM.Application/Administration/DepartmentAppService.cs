using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Authorization;
using SBCRM.Authorization;

namespace SBCRM.Administration
{
    /// <summary>
    /// App service to handle Department information
    /// </summary>
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
