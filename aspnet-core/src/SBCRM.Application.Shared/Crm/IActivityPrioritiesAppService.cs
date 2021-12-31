using System;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using SBCRM.Crm.Dtos;
using SBCRM.Dto;

namespace SBCRM.Crm
{
    /// <summary>
    /// App service interface for handling CRUD operations of Activity Priorities
    /// </summary>
    public interface IActivityPrioritiesAppService : IApplicationService
    {
        /// <summary>
        /// Get all activitiy priorities used for list/grid
        /// </summary>
        /// <param name="input">The query of the http header</param>
        /// <returns></returns>
        Task<PagedResultDto<GetActivityPriorityForViewDto>> GetAll(GetAllActivityPrioritiesInput input);

        /// <summary>
        /// View details of an activity priority based on the provided id
        /// </summary>
        /// <param name="id">The id of the activity</param>
        /// <returns></returns>
        Task<GetActivityPriorityForViewDto> GetActivityPriorityForView(int id);

        /// <summary>
        /// Get activity priority for edit
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<GetActivityPriorityForEditOutput> GetActivityPriorityForEdit(EntityDto input);

        /// <summary>
        /// Get activity priority for create or edit
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task CreateOrEdit(CreateOrEditActivityPriorityDto input);

        /// <summary>
        /// Delete the Activity Priority
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task Delete(EntityDto input);

    }
}