using System;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using SBCRM.Crm.Dtos;
using SBCRM.Dto;

namespace SBCRM.Crm
{
    /// <summary>
    /// App Service interface for handling CRUD operations of Activity Statuses
    /// </summary>
    public interface IActivityStatusesAppService : IApplicationService
    {
        /// <summary>
        /// Get all activity statuses
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<PagedResultDto<GetActivityStatusForViewDto>> GetAll(GetAllActivityStatusesInput input);

        /// <summary>
        /// Get the activity status for viewing
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<GetActivityStatusForViewDto> GetActivityStatusForView(int id);

        /// <summary>
        /// Get the activity status for editing
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<GetActivityStatusForEditOutput> GetActivityStatusForEdit(EntityDto input);

        /// <summary>
        /// Create or edit an activity status
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task CreateOrEdit(CreateOrEditActivityStatusDto input);

        /// <summary>
        /// Delete an activity status
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task Delete(EntityDto input);

    }
}