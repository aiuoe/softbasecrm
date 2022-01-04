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
        /// Method to get permission to VIEW Assigned Users widget in Opportunities
        /// The user can see the widget if meet these 2 conditions:
        /// 1. The current user has <see cref="AppPermissions.Pages_OpportunityUsers"/>  permission, oriented for Managers
        /// 2. The current user has <see cref="AppPermissions.Pages_OpportunityUsers_View__Dynamic"/> permission and is assigned in the Opportunity
        /// </summary>
        /// <param name="opportunityId"></param>
        /// <returns></returns>
        Task<bool> GetCanViewAssignedUsersWidget(int opportunityId);


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