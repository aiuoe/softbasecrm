using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;

namespace SBCRM.Administration
{
    /// <summary>
    /// App service for handling CRUD operations of Departments in Administration module
    /// </summary>
    public interface IDepartmentAppService: IApplicationService
    {

        /// <summary>
        /// Create or edit department
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task CreateOrEdit(CreateOrEditDepartmentDto input);
    }
}
