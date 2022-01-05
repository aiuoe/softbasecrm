using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using SBCRM.Crm.Dtos;
using SBCRM.Dto;
using System.Collections.Generic;

namespace SBCRM.Crm
{
    /// <summary>
    /// App service for handling CRUD operations of Activities
    /// </summary>
    public interface IActivitiesAppService : IApplicationService
    {
        /// <summary>
        /// Get all activities used for list/grid
        /// </summary>
        /// <param name="input">The query of the http header</param>
        /// <returns></returns>
        Task<PagedResultDto<GetActivityForViewDto>> GetAll(GetAllActivitiesInput input);

        /// <summary>
        /// View details of an activity based on the provided id
        /// </summary>
        /// <param name="id">The id of the activity</param>
        /// <returns></returns>
        Task<GetActivityForViewDto> GetActivityForView(long id);

        /// <summary>
        /// View details of an activity used for editing/updating based on the provided input which includes the id of the activity
        /// </summary>
        /// <param name="input">Input from http header query which includes the id of the activity</param>
        /// <returns></returns>
        Task<GetActivityForEditOutput> GetActivityForEdit(EntityDto<long> input);

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
        /// Generates an excel file that contains the list of activities based on the input.
        /// </summary>
        /// <param name="input">The http query header used for filtering, pagination, and sorting. This should exactly match the query of the GetAll method.</param>
        /// <returns></returns>
        Task<FileDto> GetActivitiesToExcel(GetAllActivitiesForExcelInput input);

        /// <summary>
        /// Get all accounts for table dropdown
        /// </summary>
        /// <returns></returns>
        Task<List<ActivityCustomerLookupTableDto>> GetAllAccountsForTableDropdown();

        /// <summary>
        /// Get all accounts related to opportunity for table dropdown
        /// </summary>
        /// <returns></returns>
        Task<List<ActivityCustomerLookupTableDto>> GetAllAccountRelatedToOpportunityForTableDropdown();

        /// <summary>
        /// Get all opportunities for table dropdown
        /// </summary>
        /// <returns></returns>
        Task<List<ActivityOpportunityLookupTableDto>> GetAllOpportunityForTableDropdown();

        /// <summary>
        /// Get all leads for table dropdown
        /// </summary>
        /// <returns></returns>
        Task<List<ActivityLeadLookupTableDto>> GetAllLeadForTableDropdown();

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

    }
}