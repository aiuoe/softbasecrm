using SBCRM.Authorization.Users;
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
    /// App Service that manages the OpportunityUsers transactions
    /// </summary>
    [AbpAuthorize(AppPermissions.Pages_OpportunityUsers)]
    public class OpportunityUsersAppService : SBCRMAppServiceBase, IOpportunityUsersAppService
    {
        private readonly IRepository<OpportunityUser> _opportunityUserRepository;
        private readonly IRepository<User, long> _lookup_userRepository;
        private readonly IRepository<Opportunity, int> _lookup_opportunityRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;
        private readonly IEntityChangeSetReasonProvider _reasonProvider;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="opportunityUserRepository"></param>
        /// <param name="lookup_userRepository"></param>
        /// <param name="lookup_opportunityRepository"></param>
        /// <param name="unitOfWorkManager"></param>
        /// <param name="reasonProvider"></param>
        public OpportunityUsersAppService(IRepository<OpportunityUser> opportunityUserRepository, 
                                            IRepository<User, long> lookup_userRepository, 
                                            IRepository<Opportunity, int> lookup_opportunityRepository,
                                            IUnitOfWorkManager unitOfWorkManager,
                                            IEntityChangeSetReasonProvider reasonProvider)
        {
            _opportunityUserRepository = opportunityUserRepository;
            _lookup_userRepository = lookup_userRepository;
            _lookup_opportunityRepository = lookup_opportunityRepository;
            _unitOfWorkManager = unitOfWorkManager;
            _reasonProvider = reasonProvider;

        }

        /// <summary>
        /// Get all opportunity users
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<PagedResultDto<GetOpportunityUserForViewDto>> GetAll(GetAllOpportunityUsersInput input)
        {

            var filteredOpportunityUsers = _opportunityUserRepository.GetAll()
                        .Include(e => e.UserFk)
                        .Include(e => e.OpportunityFk)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.Filter), e => false)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.UserNameFilter), e => e.UserFk != null && e.UserFk.Name == input.UserNameFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.OpportunityNameFilter), e => e.OpportunityFk != null && e.OpportunityFk.Name == input.OpportunityNameFilter)
                        .Where(e => e.OpportunityFk != null && e.OpportunityFk.Id == input.OpportunityId)
                        .Where(e => !e.IsDeleted);

            var pagedAndFilteredOpportunityUsers = filteredOpportunityUsers
                .OrderBy(input.Sorting ?? "id asc")
                .PageBy(input);

            var opportunityUsers = from o in pagedAndFilteredOpportunityUsers
                                   join o1 in _lookup_userRepository.GetAll() on o.UserId equals o1.Id into j1
                                   from s1 in j1.DefaultIfEmpty()

                                   join o2 in _lookup_opportunityRepository.GetAll() on o.OpportunityId equals o2.Id into j2
                                   from s2 in j2.DefaultIfEmpty()

                                   select new
                                   {

                                       Id = o.Id,
                                       UserName = s1 == null || s1.Name == null ? "" : s1.Name.ToString(),
                                       OpportunityName = s2 == null || s2.Name == null ? "" : s2.Name.ToString(),
                                       UserId = o.UserId
                                   };

            var totalCount = await filteredOpportunityUsers.CountAsync();

            var dbList = await opportunityUsers.ToListAsync();
            var results = new List<GetOpportunityUserForViewDto>();

            foreach (var o in dbList)
            {
                var res = new GetOpportunityUserForViewDto()
                {
                    OpportunityUser = new OpportunityUserDto
                    {

                        Id = o.Id,
                        UserId = o.UserId
                    },
                    UserName = o.UserName,
                    OpportunityName = o.OpportunityName
                };

                results.Add(res);
            }

            return new PagedResultDto<GetOpportunityUserForViewDto>(
                totalCount,
                results
            );

        }

        /// <summary>
        /// Get opportunity user for view mode
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<GetOpportunityUserForViewDto> GetOpportunityUserForView(int id)
        {
            var opportunityUser = await _opportunityUserRepository.GetAsync(id);

            var output = new GetOpportunityUserForViewDto { OpportunityUser = ObjectMapper.Map<OpportunityUserDto>(opportunityUser) };

            if (output.OpportunityUser.UserId != null)
            {
                var _lookupUser = await _lookup_userRepository.FirstOrDefaultAsync((long)output.OpportunityUser.UserId);
                output.UserName = _lookupUser?.Name?.ToString();
            }

            if (output.OpportunityUser.OpportunityId != null)
            {
                var _lookupOpportunity = await _lookup_opportunityRepository.FirstOrDefaultAsync((int)output.OpportunityUser.OpportunityId);
                output.OpportunityName = _lookupOpportunity?.Name?.ToString();
            }

            return output;
        }


        /// <summary>
        /// Get opportunity user for view mode
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [AbpAuthorize(AppPermissions.Pages_OpportunityUsers_Edit)]
        public async Task<GetOpportunityUserForEditOutput> GetOpportunityUserForEdit(EntityDto input)
        {
            var opportunityUser = await _opportunityUserRepository.FirstOrDefaultAsync(input.Id);

            var output = new GetOpportunityUserForEditOutput { OpportunityUser = ObjectMapper.Map<CreateOrEditOpportunityUserDto>(opportunityUser) };

            if (output.OpportunityUser.UserId != null)
            {
                var _lookupUser = await _lookup_userRepository.FirstOrDefaultAsync((long)output.OpportunityUser.UserId);
                output.UserName = _lookupUser?.Name?.ToString();
            }

            if (output.OpportunityUser.OpportunityId != null)
            {
                var _lookupOpportunity = await _lookup_opportunityRepository.FirstOrDefaultAsync((int)output.OpportunityUser.OpportunityId);
                output.OpportunityName = _lookupOpportunity?.Name?.ToString();
            }

            return output;
        }


        /// <summary>
        /// Create or edit opportunity user
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task CreateOrEdit(CreateOrEditOpportunityUserDto input)
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


        /// <summary>
        /// Creates opportunity user
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [AbpAuthorize(AppPermissions.Pages_OpportunityUsers_Create)]
        protected virtual async Task Create(CreateOrEditOpportunityUserDto input)
        {
            var opportunityUser = ObjectMapper.Map<OpportunityUser>(input);

            if (AbpSession.TenantId != null)
            {
                opportunityUser.TenantId = AbpSession.TenantId;
            }

            await _opportunityUserRepository.InsertAsync(opportunityUser);

        }


        /// <summary>
        /// Updates a opportunity user
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [AbpAuthorize(AppPermissions.Pages_OpportunityUsers_Edit)]
        protected virtual async Task Update(CreateOrEditOpportunityUserDto input)
        {
            var opportunityUser = await _opportunityUserRepository.FirstOrDefaultAsync((int)input.Id);
            ObjectMapper.Map(input, opportunityUser);

        }

        /// <summary>
        /// Deletes a opportunity user
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [AbpAuthorize(AppPermissions.Pages_OpportunityUsers_Delete)]
        public async Task Delete(EntityDto input)
        {
            await _opportunityUserRepository.DeleteAsync(input.Id);
        }

        /// <summary>
        /// Get Opportunity User Lead for dropdown
        /// </summary>
        /// <returns></returns>
        [AbpAuthorize(AppPermissions.Pages_OpportunityUsers)]
        public async Task<List<OpportunityUserUserLookupTableDto>> GetAllUserForTableDropdown()
        {
            return await _lookup_userRepository.GetAll()
                .Select(user => new OpportunityUserUserLookupTableDto
                {
                    Id = user.Id,
                    DisplayName = user == null || user.Name == null ? "" : user.Name.ToString()
                }).ToListAsync();
        }


        /// <summary>
        /// Get Opportunity User User for table
        /// </summary>
        /// <returns></returns>
        [AbpAuthorize(AppPermissions.Pages_OpportunityUsers)]
        public async Task<List<OpportunityUserOpportunityLookupTableDto>> GetAllOpportunityForTableDropdown()
        {
            return await _lookup_opportunityRepository.GetAll()
                .Select(opportunity => new OpportunityUserOpportunityLookupTableDto
                {
                    Id = opportunity.Id,
                    DisplayName = opportunity == null || opportunity.Name == null ? "" : opportunity.Name.ToString()
                }).ToListAsync();
        }


        /// <summary>
        /// This method save a list of users connected with an specific Opportunity
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [AbpAuthorize(AppPermissions.Pages_OpportunityUsers_Create)]
        public async Task CreateMultipleOpportunityUsers(List<CreateOrEditOpportunityUserDto> input)
        {
            using (_reasonProvider.Use("Users were assigned to Opportunity"))
            {
                foreach (var item in input)
                {
                    var opportunityUserExists = _opportunityUserRepository.FirstOrDefault(p => p.UserId == item.UserId
                        && p.OpportunityId == item.OpportunityId
                        && p.IsDeleted);

                    if (opportunityUserExists == null)
                    {
                        var opportunityUser = ObjectMapper.Map<OpportunityUser>(item);

                        await _opportunityUserRepository.InsertAsync(opportunityUser);
                    }
                    else
                    {
                        opportunityUserExists.IsDeleted = false;
                        var leadUserInDatabase = ObjectMapper.Map<CreateOrEditLeadUserDto>(opportunityUserExists);
                        var accountUser = await _opportunityUserRepository.FirstOrDefaultAsync(leadUserInDatabase.Id.Value);
                        ObjectMapper.Map(input, accountUser);
                    }
                }

                await _unitOfWorkManager.Current.SaveChangesAsync();
            }
        }

    }
}