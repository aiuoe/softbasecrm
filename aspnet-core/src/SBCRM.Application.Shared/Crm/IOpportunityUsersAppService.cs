using System;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using SBCRM.Crm.Dtos;
using SBCRM.Dto;
using System.Collections.Generic;

namespace SBCRM.Crm
{
    /// <summary>
    /// App service to handle opportunity user information
    /// </summary>
    public interface IOpportunityUsersAppService : IApplicationService
    {
        /// <summary>
        /// Get all opportunity users
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<PagedResultDto<GetOpportunityUserForViewDto>> GetAll(GetAllOpportunityUsersInput input);

        /// <summary>
        /// Get opportunity user for view mode
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<GetOpportunityUserForViewDto> GetOpportunityUserForView(int id);

        /// <summary>
        /// Get opportunity user for view mode
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<GetOpportunityUserForEditOutput> GetOpportunityUserForEdit(EntityDto input);

        /// <summary>
        /// Create or edit opportunity user
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task CreateOrEdit(CreateOrEditOpportunityUserDto input);

        /// <summary>
        /// Deletes a opportunity user
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task Delete(EntityDto input);

        /// <summary>
        /// Get Opportunity User Lead for dropdown
        /// </summary>
        /// <returns></returns>
        Task<List<OpportunityUserUserLookupTableDto>> GetAllUserForTableDropdown();

        /// <summary>
        /// Get Opportunity User User for table
        /// </summary>
        /// <returns></returns>
        Task<List<OpportunityUserOpportunityLookupTableDto>> GetAllOpportunityForTableDropdown();

        /// <summary>
        /// This method save a list of users connected with an specific Opportunity
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task CreateMultipleOpportunityUsers(List<CreateOrEditOpportunityUserDto> input);

    }
}