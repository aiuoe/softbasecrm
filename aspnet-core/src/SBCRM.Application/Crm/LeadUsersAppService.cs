using SBCRM.Crm;
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

namespace SBCRM.Crm
{
    [AbpAuthorize(AppPermissions.Pages_LeadUsers)]
    public class LeadUsersAppService : SBCRMAppServiceBase, ILeadUsersAppService
    {
        private readonly IRepository<LeadUser> _leadUserRepository;
        private readonly IRepository<Lead, int> _lookup_leadRepository;
        private readonly IRepository<User, long> _lookup_userRepository;

        public LeadUsersAppService(IRepository<LeadUser> leadUserRepository, IRepository<Lead, int> lookup_leadRepository, IRepository<User, long> lookup_userRepository)
        {
            _leadUserRepository = leadUserRepository;
            _lookup_leadRepository = lookup_leadRepository;
            _lookup_userRepository = lookup_userRepository;

        }

        public async Task<PagedResultDto<GetLeadUserForViewDto>> GetAll(GetAllLeadUsersInput input)
        {

            var filteredLeadUsers = _leadUserRepository.GetAll()
                        .Include(e => e.LeadFk)
                        .Include(e => e.UserFk)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.Filter), e => false)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.LeadCompanyNameFilter), e => e.LeadFk != null && e.LeadFk.CompanyName == input.LeadCompanyNameFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.UserNameFilter), e => e.UserFk != null && e.UserFk.Name == input.UserNameFilter);

            var pagedAndFilteredLeadUsers = filteredLeadUsers
                .OrderBy(input.Sorting ?? "id asc")
                .PageBy(input);

            var leadUsers = from o in pagedAndFilteredLeadUsers
                            join o1 in _lookup_leadRepository.GetAll() on o.LeadId equals o1.Id into j1
                            from s1 in j1.DefaultIfEmpty()

                            join o2 in _lookup_userRepository.GetAll() on o.UserId equals o2.Id into j2
                            from s2 in j2.DefaultIfEmpty()

                            select new
                            {

                                Id = o.Id,
                                LeadCompanyName = s1 == null || s1.CompanyName == null ? "" : s1.CompanyName.ToString(),
                                UserName = s2 == null || s2.Name == null ? "" : s2.Name.ToString()
                            };

            var totalCount = await filteredLeadUsers.CountAsync();

            var dbList = await leadUsers.ToListAsync();
            var results = new List<GetLeadUserForViewDto>();

            foreach (var o in dbList)
            {
                var res = new GetLeadUserForViewDto()
                {
                    LeadUser = new LeadUserDto
                    {

                        Id = o.Id,
                    },
                    LeadCompanyName = o.LeadCompanyName,
                    UserName = o.UserName
                };

                results.Add(res);
            }

            return new PagedResultDto<GetLeadUserForViewDto>(
                totalCount,
                results
            );

        }

        [AbpAuthorize(AppPermissions.Pages_LeadUsers_Edit)]
        public async Task<GetLeadUserForEditOutput> GetLeadUserForEdit(EntityDto input)
        {
            var leadUser = await _leadUserRepository.FirstOrDefaultAsync(input.Id);

            var output = new GetLeadUserForEditOutput { LeadUser = ObjectMapper.Map<CreateOrEditLeadUserDto>(leadUser) };

            if (output.LeadUser.LeadId != null)
            {
                var _lookupLead = await _lookup_leadRepository.FirstOrDefaultAsync((int)output.LeadUser.LeadId);
                output.LeadCompanyName = _lookupLead?.CompanyName?.ToString();
            }

            if (output.LeadUser.UserId != null)
            {
                var _lookupUser = await _lookup_userRepository.FirstOrDefaultAsync((long)output.LeadUser.UserId);
                output.UserName = _lookupUser?.Name?.ToString();
            }

            return output;
        }

        public async Task CreateOrEdit(CreateOrEditLeadUserDto input)
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

        [AbpAuthorize(AppPermissions.Pages_LeadUsers_Create)]
        protected virtual async Task Create(CreateOrEditLeadUserDto input)
        {
            var leadUser = ObjectMapper.Map<LeadUser>(input);

            await _leadUserRepository.InsertAsync(leadUser);

        }

        [AbpAuthorize(AppPermissions.Pages_LeadUsers_Edit)]
        protected virtual async Task Update(CreateOrEditLeadUserDto input)
        {
            var leadUser = await _leadUserRepository.FirstOrDefaultAsync((int)input.Id);
            ObjectMapper.Map(input, leadUser);

        }

        [AbpAuthorize(AppPermissions.Pages_LeadUsers_Delete)]
        public async Task Delete(EntityDto input)
        {
            await _leadUserRepository.DeleteAsync(input.Id);
        }
        [AbpAuthorize(AppPermissions.Pages_LeadUsers)]
        public async Task<List<LeadUserLeadLookupTableDto>> GetAllLeadForTableDropdown()
        {
            return await _lookup_leadRepository.GetAll()
                .Select(lead => new LeadUserLeadLookupTableDto
                {
                    Id = lead.Id,
                    DisplayName = lead == null || lead.CompanyName == null ? "" : lead.CompanyName.ToString()
                }).ToListAsync();
        }

        [AbpAuthorize(AppPermissions.Pages_LeadUsers)]
        public async Task<List<LeadUserUserLookupTableDto>> GetAllUserForTableDropdown()
        {
            return await _lookup_userRepository.GetAll()
                .Select(user => new LeadUserUserLookupTableDto
                {
                    Id = user.Id,
                    DisplayName = user == null || user.Name == null ? "" : user.Name.ToString()
                }).ToListAsync();
        }

    }
}