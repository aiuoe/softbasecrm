﻿using SBCRM.Authorization.Users;
using System.Linq;
using System.Linq.Dynamic.Core;
using Abp.Linq.Extensions;
using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using SBCRM.Crm.Dtos;
using Abp.Application.Services.Dto;
using SBCRM.Authorization;
using Abp.Authorization;
using Microsoft.EntityFrameworkCore;
using Abp.Domain.Uow;
using Abp.EntityHistory;

namespace SBCRM.Crm
{
    /// <summary>
    /// App Service that manages the AccountUser transactions
    /// </summary>
    [AbpAuthorize(AppPermissions.Pages_AccountUsers)]
    public class AccountUsersAppService : SBCRMAppServiceBase, IAccountUsersAppService
    {
        private readonly IRepository<AccountUser> _accountUserRepository;
        private readonly IRepository<User, long> _lookupUserRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;
        private readonly IEntityChangeSetReasonProvider _reasonProvider;

        /// <summary>
        /// Constructor method
        /// </summary>
        /// <param name="accountUserRepository"></param>
        /// <param name="lookupUserRepository"></param>
        /// <param name="unitOfWorkManager"></param>
        /// <param name="reasonProvider"></param>
        public AccountUsersAppService(IRepository<AccountUser> accountUserRepository,
            IRepository<User, long> lookupUserRepository,
            IUnitOfWorkManager unitOfWorkManager,
            IEntityChangeSetReasonProvider reasonProvider)
        {
            _accountUserRepository = accountUserRepository;
            _lookupUserRepository = lookupUserRepository;
            _unitOfWorkManager = unitOfWorkManager;
            _reasonProvider = reasonProvider;
        }

        /// <summary>
        /// Gets all the account users give a Customer number
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<PagedResultDto<GetAccountUserForViewDto>> GetAll(GetAllAccountUsersInput input)
        {
            var filteredAccountUsers = _accountUserRepository.GetAll()
                .Include(e => e.UserFk)
                .Include(e => e.CustomerFk)
                .WhereIf(!string.IsNullOrWhiteSpace(input.Filter), e => false)
                .WhereIf(!string.IsNullOrWhiteSpace(input.UserNameFilter),
                    e => e.UserFk != null && e.UserFk.Name == input.UserNameFilter)
                .WhereIf(!string.IsNullOrWhiteSpace(input.CustomerNumber),
                    e => e.CustomerFk != null && e.CustomerFk.Number == input.CustomerNumber)
                .Where(p => !p.IsDeleted);

            var pagedAndFilteredAccountUsers = filteredAccountUsers
                .OrderBy(input.Sorting ?? "id asc")
                .PageBy(input);

            var totalCount = await filteredAccountUsers.CountAsync();

            var dbList = await filteredAccountUsers.ToListAsync();
            var results = new List<GetAccountUserForViewDto>();

            foreach (var o in dbList)
            {
                var res = new GetAccountUserForViewDto()
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
        public async Task<GetAccountUserForViewDto> GetAccountUserForView(int id)
        {
            var accountUser = await _accountUserRepository.GetAsync(id);

            var output = new GetAccountUserForViewDto {AccountUser = ObjectMapper.Map<AccountUserDto>(accountUser)};

            if (output.AccountUser.UserId != null)
            {
                var _lookupUser = await _lookupUserRepository.FirstOrDefaultAsync((long) output.AccountUser.UserId);
                output.UserName = _lookupUser?.Name?.ToString();
            }

            return output;
        }

        /// <summary>
        /// Get an specific account user for edit purposes
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [AbpAuthorize(AppPermissions.Pages_AccountUsers_Edit)]
        public async Task<GetAccountUserForEditOutput> GetAccountUserForEdit(EntityDto input)
        {
            var accountUser = await _accountUserRepository.FirstOrDefaultAsync(input.Id);

            var output = new GetAccountUserForEditOutput
            { AccountUser = ObjectMapper.Map<CreateOrEditAccountUserDto>(accountUser) };

            if (output.AccountUser.UserId != null)
            {
                var _lookupUser = await _lookupUserRepository.FirstOrDefaultAsync((long)output.AccountUser.UserId);
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
        public async Task<List<AccountUserUserLookupTableDto>> GetAllUserForTableDropdown()
        {
            return await _lookupUserRepository.GetAll()
                .Select(user => new AccountUserUserLookupTableDto
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
            using (_reasonProvider.Use("User wa assigned to Account"))
            {
                foreach (var item in input)
                {
                    var accountUserExists = _accountUserRepository.FirstOrDefault(p => p.UserId == item.UserId
                        && p.CustomerNumber == item.CustomerNumber
                        && p.IsDeleted);

                    if (accountUserExists == null)
                    {
                        var accountUser = ObjectMapper.Map<AccountUser>(item);

                        await _accountUserRepository.InsertAsync(accountUser);
                    }
                    else
                    {
                        accountUserExists.IsDeleted = false;
                        var accountUserInDatabase = ObjectMapper.Map<CreateOrEditAccountUserDto>(accountUserExists);
                        var accountUser = await _accountUserRepository.FirstOrDefaultAsync(accountUserInDatabase.Id.Value);
                        ObjectMapper.Map(input, accountUser);
                    }
                }

                await _unitOfWorkManager.Current.SaveChangesAsync();
            }
        }
    }
}