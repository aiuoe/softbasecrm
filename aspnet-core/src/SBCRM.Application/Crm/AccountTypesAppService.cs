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

namespace SBCRM.Crm
{
    [AbpAuthorize(AppPermissions.Pages_AccountTypes)]
    public class AccountTypesAppService : SBCRMAppServiceBase, IAccountTypesAppService
    {
        private readonly IRepository<AccountType> _accountTypeRepository;

        public AccountTypesAppService(IRepository<AccountType> accountTypeRepository)
        {
            _accountTypeRepository = accountTypeRepository;

        }

        //public async Task<PagedResultDto<GetAccountTypeForViewDto>> GetAll()
        //{
        //    var defaultInput = new GetAllAccountTypesInput
        //    {
        //        SkipCount = 0,
        //        MaxResultCount = int.MaxValue
        //    };
        //    return await GetAll(defaultInput);
        //}

        public async Task<PagedResultDto<GetAccountTypeForViewDto>> GetAll(GetAllAccountTypesInput input)
        {

            var filteredAccountTypes = _accountTypeRepository.GetAll()
                        .WhereIf(!string.IsNullOrWhiteSpace(input?.Filter), e => false || e.Description.Contains(input.Filter));

            var pagedAndFilteredAccountTypes = filteredAccountTypes
                .OrderBy(input.Sorting ?? "id asc")
                .PageBy(input);

            var accountTypes = from o in pagedAndFilteredAccountTypes
                               select new
                               {
                                   Id = o.Id,
                                   o.Description
                               };

            var totalCount = await filteredAccountTypes.CountAsync();

            var dbList = await accountTypes.ToListAsync();
            var results = new List<GetAccountTypeForViewDto>();

            foreach (var o in dbList)
            {
                var res = new GetAccountTypeForViewDto()
                {
                    AccountType = new AccountTypeDto
                    {
                        Id = o.Id,
                        Description = o.Description
                    }
                };

                results.Add(res);
            }

            return new PagedResultDto<GetAccountTypeForViewDto>(
                totalCount,
                results
            );

        }

        [AbpAuthorize(AppPermissions.Pages_AccountTypes_Edit)]
        public async Task<GetAccountTypeForEditOutput> GetAccountTypeForEdit(EntityDto input)
        {
            var accountType = await _accountTypeRepository.FirstOrDefaultAsync(input.Id);

            var output = new GetAccountTypeForEditOutput { AccountType = ObjectMapper.Map<CreateOrEditAccountTypeDto>(accountType) };

            return output;
        }

        public async Task CreateOrEdit(CreateOrEditAccountTypeDto input)
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

        [AbpAuthorize(AppPermissions.Pages_AccountTypes_Create)]
        protected virtual async Task Create(CreateOrEditAccountTypeDto input)
        {
            var accountType = ObjectMapper.Map<AccountType>(input);

            await _accountTypeRepository.InsertAsync(accountType);

        }

        [AbpAuthorize(AppPermissions.Pages_AccountTypes_Edit)]
        protected virtual async Task Update(CreateOrEditAccountTypeDto input)
        {
            var accountType = await _accountTypeRepository.FirstOrDefaultAsync((int)input.Id);
            ObjectMapper.Map(input, accountType);

        }

        [AbpAuthorize(AppPermissions.Pages_AccountTypes_Delete)]
        public async Task Delete(EntityDto input)
        {
            await _accountTypeRepository.DeleteAsync(input.Id);
        }

    }
}