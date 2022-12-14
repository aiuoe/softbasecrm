using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using SBCRM.Crm.Dtos;
using System.Collections.Generic;

namespace SBCRM.Crm
{
    /// <summary>
    /// App service to handle lead user information
    /// </summary>
    public interface ILeadUsersAppService : IApplicationService
    {
        /// <summary>
        /// Method to get permission to VIEW Assigned Users widget in Leads
        /// The user can see the widget if meet these 2 conditions:
        /// 1. The current user has <see cref="AppPermissions.Pages_LeadUsers"/>  permission, oriented for Managers
        /// 2. The current user has <see cref="AppPermissions.Pages_LeadUsers_View__Dynamic"/> permission and is assigned in the Lead
        /// </summary>
        /// <param name="leadId"></param>
        /// <returns></returns>
        Task<bool> GetCanViewAssignedUsersWidget(int leadId);

        /// <summary>
        /// Get all lead users
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<PagedResultDto<GetLeadUserForViewDto>> GetAll(GetAllLeadUsersInput input);

        /// <summary>
        /// Get lead source user for edit mode
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<GetLeadUserForEditOutput> GetLeadUserForEdit(EntityDto input);

        /// <summary>
        /// Create or edit lead user
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task CreateOrEdit(CreateOrEditLeadUserDto input);

        /// <summary>
        /// Delete lead user
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task Delete(EntityDto input);

        /// <summary>
        /// Get Lead User Lead type dropdown
        /// </summary>
        /// <returns></returns>
        Task<List<LeadUserLeadLookupTableDto>> GetAllLeadForTableDropdown();

        /// <summary>
        /// Get Lead User User type dropdown
        /// </summary>
        /// <returns></returns>
        Task<List<LeadUserUserLookupTableDto>> GetAllUserForTableDropdown();

        /// <summary>
        /// This method save a list of users connected with an specific Account
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task CreateMultipleLeadUsers(List<CreateOrEditLeadUserDto> input);

    }
}