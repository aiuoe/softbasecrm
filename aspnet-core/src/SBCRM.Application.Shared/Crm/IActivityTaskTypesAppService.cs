using System;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using SBCRM.Crm.Dtos;
using SBCRM.Dto;

namespace SBCRM.Crm
{
    /// <summary>
    /// App service interface for handling CRUD operations of Activity Types
    /// </summary>
    public interface IActivityTaskTypesAppService : IApplicationService
    {
        /// <summary>
        /// Get all activity types
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<PagedResultDto<GetActivityTaskTypeForViewDto>> GetAll(GetAllActivityTaskTypesInput input);

        /// <summary>
        /// Get activity type for viewing
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<GetActivityTaskTypeForViewDto> GetActivityTaskTypeForView(int id);

        /// <summary>
        /// Get activity type for editing
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<GetActivityTaskTypeForEditOutput> GetActivityTaskTypeForEdit(EntityDto input);

        /// <summary>
        /// Create or edit an activity type
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task CreateOrEdit(CreateOrEditActivityTaskTypeDto input);

        /// <summary>
        /// Deletes an activity type
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task Delete(EntityDto input);

    }
}