using SBCRM.Authorization.Users;

using System;
using System.Linq;
using System.Linq.Dynamic.Core;
using Abp.Linq.Extensions;
using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using SBCRM.Crm.Dtos;
using SBCRM.Dto;
using Abp.Application.Services.Dto;
using SBCRM.Authorization;
using Abp.Extensions;
using Abp.Authorization;
using Microsoft.EntityFrameworkCore;
using Abp.UI;
using SBCRM.Storage;
using Abp.Domain.Uow;

namespace SBCRM.Crm
{
    [AbpAuthorize(AppPermissions.Pages_AccountUsers)]
    public class AccountUsersAppService : SBCRMAppServiceBase, IAccountUsersAppService
    {
        private readonly IRepository<AccountUser> _accountUserRepository;
        private readonly IRepository<User, long> _lookup_userRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;

        public AccountUsersAppService(  IRepository<AccountUser> accountUserRepository, 
                                        IRepository<User, long> lookup_userRepository,
                                        IUnitOfWorkManager unitOfWorkManager)
        {
            _accountUserRepository = accountUserRepository;
            _lookup_userRepository = lookup_userRepository;
            _unitOfWorkManager = unitOfWorkManager;

        }

        public async Task<PagedResultDto<GetAccountUserForViewDto>> GetAll(GetAllAccountUsersInput input)
        {

            var filteredAccountUsers = _accountUserRepository.GetAll()
                        .Include(e => e.UserFk)
                        .Include(e => e.CustomerFk)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.Filter), e => false)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.UserNameFilter), e => e.UserFk != null && e.UserFk.Name == input.UserNameFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.CustomerNumber), e => e.CustomerFk != null && e.CustomerFk.Number == input.CustomerNumber)
                        .Where(p => !p.IsDeleted);

            var pagedAndFilteredAccountUsers = filteredAccountUsers
                .OrderBy(input.Sorting ?? "id asc")
                .PageBy(input);

            var accountUsers = from o in pagedAndFilteredAccountUsers
                               join o1 in _lookup_userRepository.GetAll() on o.UserId equals o1.Id into j1
                               from s1 in j1.DefaultIfEmpty()

                               select new
                               {

                                   Id = o.Id,
                                   UserId = o.UserId,
                                   UserName = s1 == null || s1.Name == null ? "" : s1.Name.ToString()
                               };

            var totalCount = await filteredAccountUsers.CountAsync();

            var dbList = await accountUsers.ToListAsync();
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
                    UserName = o.UserName
                };

                results.Add(res);
            }

            return new PagedResultDto<GetAccountUserForViewDto>(
                totalCount,
                results
            );

        }

        public async Task<GetAccountUserForViewDto> GetAccountUserForView(int id)
        {
            var accountUser = await _accountUserRepository.GetAsync(id);

            var output = new GetAccountUserForViewDto { AccountUser = ObjectMapper.Map<AccountUserDto>(accountUser) };

            if (output.AccountUser.UserId != null)
            {
                var _lookupUser = await _lookup_userRepository.FirstOrDefaultAsync((long)output.AccountUser.UserId);
                output.UserName = _lookupUser?.Name?.ToString();
            }

            return output;
        }

        [AbpAuthorize(AppPermissions.Pages_AccountUsers_Edit)]
        public async Task<GetAccountUserForEditOutput> GetAccountUserForEdit(EntityDto input)
        {
            var accountUser = await _accountUserRepository.FirstOrDefaultAsync(input.Id);

            var output = new GetAccountUserForEditOutput { AccountUser = ObjectMapper.Map<CreateOrEditAccountUserDto>(accountUser) };

            if (output.AccountUser.UserId != null)
            {
                var _lookupUser = await _lookup_userRepository.FirstOrDefaultAsync((long)output.AccountUser.UserId);
                output.UserName = _lookupUser?.Name?.ToString();
            }

            return output;
        }

        public async Task CreateOrEdit(CreateOrEditAccountUserDto input)
        {
            if (input.Id == null)
            {
                await Create(input);
            }
            else
            {
                await Update(input);
            }
        }

        [AbpAuthorize(AppPermissions.Pages_AccountUsers_Create)]
        protected virtual async Task Create(CreateOrEditAccountUserDto input)
        {
            var accountUser = ObjectMapper.Map<AccountUser>(input);

            await _accountUserRepository.InsertAsync(accountUser);

        }

        [AbpAuthorize(AppPermissions.Pages_AccountUsers_Edit)]
        protected virtual async Task Update(CreateOrEditAccountUserDto input)
        {
            var accountUser = await _accountUserRepository.FirstOrDefaultAsync((int)input.Id);
            ObjectMapper.Map(input, accountUser);

        }

        [AbpAuthorize(AppPermissions.Pages_AccountUsers_Delete)]
        public async Task Delete(EntityDto input)
        {
            await _accountUserRepository.DeleteAsync(input.Id);
        }
        [AbpAuthorize(AppPermissions.Pages_AccountUsers)]
        public async Task<List<AccountUserUserLookupTableDto>> GetAllUserForTableDropdown()
        {
            return await _lookup_userRepository.GetAll()
                .Select(user => new AccountUserUserLookupTableDto
                {
                    Id = user.Id,
                    DisplayName = user == null || user.Name == null ? "" : user.Name.ToString()
                }).ToListAsync();
        }

        /// <summary>
        /// This method save a list of users connected with an especific Account
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [AbpAuthorize(AppPermissions.Pages_AccountUsers)]
        public async Task CreateMultipleAccountUsers(List<CreateOrEditAccountUserDto> input)
        {
            using (var unitOfWork = _unitOfWorkManager.Begin())
            {
                foreach (var item in input)
                {
                    var accountUserExists = _accountUserRepository.
                                            FirstOrDefault(p => p.UserId == item.UserId 
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
                        await Update(accountUserInDatabase);
                    }
                }
                unitOfWork.Complete();
            }

        }
    }
}