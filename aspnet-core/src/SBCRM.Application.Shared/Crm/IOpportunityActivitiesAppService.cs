using Abp.Application.Services;
using Abp.Application.Services.Dto;
using SBCRM.Crm.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SBCRM.Crm
{
    public interface IOpportunityActivitiesAppService: IApplicationService
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

        /// <summary>
        /// Get all users for table dropdown
        /// </summary>
        /// <returns></returns>
        Task<List<ActivityUserLookupTableDto>> GetAllUserForTableDropdown();

        /// <summary>
        /// Get all activity source type for table dropdown
        /// </summary>
        /// <returns></returns>
        Task<List<ActivityActivitySourceTypeLookupTableDto>> GetAllActivitySourceTypeForTableDropdown();

        /// <summary>
        /// Get all activity task type for table dropdown
        /// </summary>
        /// <returns></returns>
        Task<List<ActivityActivityTaskTypeLookupTableDto>> GetAllActivityTaskTypeForTableDropdown();

        /// <summary>
        /// Get all activity status for table dropdown
        /// </summary>
        /// <returns></returns>
        Task<List<ActivityActivityStatusLookupTableDto>> GetAllActivityStatusForTableDropdown();


        /// <summary>
        /// Get all activity priority for table dropdown
        /// </summary>
        /// <returns></returns>
        Task<List<ActivityActivityPriorityLookupTableDto>> GetAllActivityPriorityForTableDropdown();


        /// <summary>
        /// View details of an activity used for editing/updating based on the provided input which includes the id of the activity
        /// </summary>
        /// <param name="input">Input from http header query which includes the id of the activity</param>
        /// <returns></returns>
        Task<GetActivityForEditOutput> GetActivityForEdit(EntityDto<long> input);

    }
}
