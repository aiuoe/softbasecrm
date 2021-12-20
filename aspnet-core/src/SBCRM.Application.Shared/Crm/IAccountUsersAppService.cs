using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using SBCRM.Crm.Dtos;
using System.Collections.Generic;

namespace SBCRM.Crm
{
    /// <summary>
    /// App Service that manages the AccountUser transactions
    /// </summary>
    public interface IAccountUsersAppService : IApplicationService
    {
        /// <summary>
        /// Gets all the account users give a Customer number
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<PagedResultDto<GetAccountUserForViewDto>> GetAll(GetAllAccountUsersInput input);

        /// <summary>
        /// Gets an specific AccountUser given its id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<GetAccountUserForViewDto> GetAccountUserForView(int id);

        /// <summary>
        /// Get an specific account user for edit purposes
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<GetAccountUserForEditOutput> GetAccountUserForEdit(EntityDto input);

        /// <summary>
        /// Deletes an account user
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task Delete(EntityDto input);

        /// <summary>
        /// Get all users for table dropdown
        /// </summary>
        /// <returns></returns>
        Task<List<AccountUserUserLookupTableDto>> GetAllUserForTableDropdown();

        /// <summary>
        /// This method save a list of users connected with an specific Account
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task CreateMultipleAccountUsers(List<CreateOrEditAccountUserDto> input);

    }
}