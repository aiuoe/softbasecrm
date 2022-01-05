using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Abp.EntityHistory;
using Abp.Linq.Extensions;
using Microsoft.EntityFrameworkCore;
using SBCRM.Authorization;
using SBCRM.Authorization.Users;
using SBCRM.Crm.Dtos;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;

namespace SBCRM.Crm
{
    /// <summary>
    /// App Service that manages the AccountUser transactions
    /// </summary>
    public class AccountUsersAppService : SBCRMAppServiceBase, IAccountUsersAppService
    {
        private readonly IRepository<AccountUser> _accountUserRepository;
        private readonly IRepository<User, long> _lookupUserRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;
        private readonly IEntityChangeSetReasonProvider _reasonProvider;
        private readonly IAccountAutomateAssignmentService _accountAutomateAssignment;

        /// <summary>
        /// Constructor method
        /// </summary>
        /// <param name="accountUserRepository"></param>
        /// <param name="lookupUserRepository"></param>
        /// <param name="unitOfWorkManager"></param>
        /// <param name="reasonProvider"></param>
        /// <param name="accountAutomateAssignment"></param>
        public AccountUsersAppService(IRepository<AccountUser> accountUserRepository,
            IRepository<User, long> lookupUserRepository,
            IUnitOfWorkManager unitOfWorkManager,
            IEntityChangeSetReasonProvider reasonProvider,
            IAccountAutomateAssignmentService accountAutomateAssignment)
        {
            _accountUserRepository = accountUserRepository;
            _accountAutomateAssignment = accountAutomateAssignment;
            _lookupUserRepository = lookupUserRepository;
            _unitOfWorkManager = unitOfWorkManager;
            _reasonProvider = reasonProvider;
        }

        /// <summary>
        /// Method to get permission to VIEW Assigned Users widget in Accounts
        /// The user can see the widget if meet these 2 conditions:
        /// 1. The current user has <see cref="AppPermissions.Pages_AccountUsers"/>  permission, oriented for Managers
        /// 2. The current user has <see cref="AppPermissions.Pages_AccountUsers_View__Dynamic"/> permission and is assigned in the Account/Customer
        /// </summary>
        /// <param name="customerNumber"></param>
        /// <returns></returns>
        [AbpAllowAnonymous]
        public async Task<bool> GetCanViewAssignedUsersWidget(string customerNumber)
        {
            User currentUser = await GetCurrentUserAsync();
            bool hasDynamicPermission =
                await UserManager.IsGrantedAsync(currentUser.Id, AppPermissions.Pages_AccountUsers_View__Dynamic);
            bool hasStaticPermission = await UserManager.IsGrantedAsync(currentUser.Id, AppPermissions.Pages_AccountUsers);

            bool currentUserIsAssignedInCustomer = _accountUserRepository
                .GetAll()
                .Where(x => x.CustomerNumber == customerNumber)
                .Any(x => x.UserId == currentUser.Id);

            bool canViewAssignedUsersDynamic = hasDynamicPermission && currentUserIsAssignedInCustomer;
            return canViewAssignedUsersDynamic || hasStaticPermission;
        }

        /// <summary>
        /// Gets all the account users give a Customer number
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [AbpAuthorize(permissions: new[]
            {
                AppPermissions.Pages_AccountUsers,
                AppPermissions.Pages_AccountUsers_View__Dynamic
            }, RequireAllPermissions = false)]
        public async Task<PagedResultDto<GetAccountUserForViewDto>> GetAll(GetAllAccountUsersInput input)
        {
            IQueryable<AccountUser> filteredAccountUsers = _accountUserRepository.GetAll()
                .Include(e => e.UserFk)
                .Include(e => e.CustomerFk)
                .WhereIf(!string.IsNullOrWhiteSpace(input.Filter), e => false)
                .WhereIf(!string.IsNullOrWhiteSpace(input.UserNameFilter),
                    e => e.UserFk != null && e.UserFk.Name == input.UserNameFilter)
                .WhereIf(!string.IsNullOrWhiteSpace(input.CustomerNumber),
                    e => e.CustomerFk != null && e.CustomerFk.Number == input.CustomerNumber)
                .Where(p => !p.IsDeleted);

            IQueryable<AccountUser> pagedAndFilteredAccountUsers = filteredAccountUsers
                .OrderBy(input.Sorting ?? "id asc")
                .PageBy(input);

            int totalCount = await filteredAccountUsers.CountAsync();

            List<AccountUser> dbList = await filteredAccountUsers.ToListAsync();
            List<GetAccountUserForViewDto> results = new List<GetAccountUserForViewDto>();

            foreach (AccountUser o in dbList)
            {
                GetAccountUserForViewDto res = new GetAccountUserForViewDto()
                {
                    AccountUser = new AccountUserDto
                    {
                        Id = o.Id,
                        UserId = o.UserId
                    },
                    UserName = o.UserFk.UserName,
                    SurName = o.UserFk.Surname,
                    FirstName = o.UserFk.Name,
                    FullName = o.UserFk.FullName
                };

                results.Add(res);
            }

            return new PagedResultDto<GetAccountUserForViewDto>(
                totalCount,
                results
            );
        }

        /// <summary>
        /// Gets an specific AccountUser given its id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [AbpAuthorize(AppPermissions.Pages_AccountUsers)]
        public async Task<GetAccountUserForViewDto> GetAccountUserForView(int id)
        {
            AccountUser accountUser = await _accountUserRepository.GetAsync(id);

            GetAccountUserForViewDto output = new GetAccountUserForViewDto { AccountUser = ObjectMapper.Map<AccountUserDto>(accountUser) };

            if (output.AccountUser.UserId != null)
            {
                User _lookupUser = await _lookupUserRepository.FirstOrDefaultAsync((long)output.AccountUser.UserId);
                output.UserName = _lookupUser?.Name?.ToString();
            }

            return output;
        }

        /// <summary>
        /// Get an specific account user for edit purposes
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [AbpAuthorize(AppPermissions.Pages_AccountUsers)]
        public async Task<GetAccountUserForEditOutput> GetAccountUserForEdit(EntityDto input)
        {
            AccountUser accountUser = await _accountUserRepository.FirstOrDefaultAsync(input.Id);

            GetAccountUserForEditOutput output = new GetAccountUserForEditOutput
            { AccountUser = ObjectMapper.Map<CreateOrEditAccountUserDto>(accountUser) };

            if (output.AccountUser.UserId != null)
            {
                User _lookupUser = await _lookupUserRepository.FirstOrDefaultAsync((long)output.AccountUser.UserId);
                output.UserName = _lookupUser?.Name?.ToString();
            }

            return output;
        }

        /// <summary>
        /// Deletes an account user
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [AbpAuthorize(AppPermissions.Pages_AccountUsers_Delete)]
        public async Task Delete(EntityDto input)
        {
            using (_reasonProvider.Use("User was removed from Account"))
            {
                await _accountUserRepository.DeleteAsync(input.Id);
                await _unitOfWorkManager.Current.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Get all users for table dropdown
        /// </summary>
        /// <returns></returns>
        [AbpAuthorize(AppPermissions.Pages_AccountUsers)]
        public async Task<List<AccountUserLookupTableDto>> GetAllUserForTableDropdown()
        {
            return await _lookupUserRepository.GetAll()
                .Select(user => new AccountUserLookupTableDto
                {
                    Id = user.Id,
                    DisplayName = user == null || user.FullName == null ? string.Empty : user.FullName
                }).ToListAsync();
        }

        /// <summary>
        /// This method save a list of users connected with an specific Account
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [AbpAuthorize(AppPermissions.Pages_AccountUsers_Create)]
        public async Task CreateMultipleAccountUsers(List<CreateOrEditAccountUserDto> input)
        {
            await _accountAutomateAssignment.AssignAccountUsersAsync(input);
        }
    }
}