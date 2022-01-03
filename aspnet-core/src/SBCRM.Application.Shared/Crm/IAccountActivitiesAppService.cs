using Abp.Application.Services;
using Abp.Application.Services.Dto;
using SBCRM.Crm.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SBCRM.Crm
{
    /// <summary>
    /// App service for handling CRUD operations of Activities in Accounts module
    /// </summary>
    public interface IAccountActivitiesAppService: IApplicationService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<PagedResultDto<GetActivityForViewDto>> GetAll(GetAllActivitiesForWidget input);

        /// <summary>
        /// Updates an activity if the id of the input has a value, otherwise creates it.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task CreateOrEdit(CreateOrEditActivityDto input);

        /// <summary>
        /// Deletes an activity
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task Delete(EntityDto<long> input);
    }
}
