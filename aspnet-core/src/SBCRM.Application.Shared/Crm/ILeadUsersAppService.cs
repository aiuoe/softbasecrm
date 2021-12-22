using System;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using SBCRM.Crm.Dtos;
using SBCRM.Dto;
using System.Collections.Generic;
using System.Collections.Generic;

namespace SBCRM.Crm
{
    /// <summary>
    /// App service to handle lead user information
    /// </summary>
    public interface ILeadUsersAppService : IApplicationService
    {
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