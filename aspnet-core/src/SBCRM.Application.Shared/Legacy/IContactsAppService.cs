using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using SBCRM.Legacy.Dtos;
using SBCRM.Dto;

namespace SBCRM.Legacy
{
    /// <summary>
    /// App service to handle Customer-Contacts information
    /// </summary>
    public interface IContactsAppService : IApplicationService
    {
        /// <summary>
        /// Method to get permission to DELETE Contact in Accounts
        /// The user can see the widget if meet these 2 conditions:
        /// 1. The current user has <see cref="AppPermissions.Pages_Contacts_Delete"/>  permission, oriented for Managers
        /// 2. The current user has <see cref="AppPermissions.Pages_Contacts_Delete__Dynamic"/> permission and is assigned in the Account/Customer
        /// </summary>
        /// <param name="customerNumber"></param>
        /// <returns></returns>
        Task<bool> GetCanDeleteContact(string customerNumber);

        /// <summary>
        /// Get all contacts types without paging
        /// </summary>
        /// <returns></returns>
        Task<List<GetContactForViewDto>> GetAllWithoutPaging(GetAllNoPagedContactsInput input);

        /// <summary>
        /// Get all contacts
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<PagedResultDto<GetContactForViewDto>> GetAll(GetAllContactsInput input);

        /// <summary>
        /// Get contact for edition mode
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<GetContactForEditOutput> GetContactForEdit(EntityDto input);

        /// <summary>
        /// Create or edit contact
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task CreateOrEdit(CreateOrEditContactDto input);

        /// <summary>
        /// Delete contact
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task Delete(EntityDto input);

    }
}