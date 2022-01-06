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
    /// App Service that manages the OpportunityUsers transactions
    /// </summary>
    public class OpportunityUsersAppService : SBCRMAppServiceBase, IOpportunityUsersAppService
    {
        private readonly IRepository<OpportunityUser> _opportunityUserRepository;
        private readonly IRepository<User, long> _lookupUserRepository;
        private readonly IRepository<Opportunity, int> _lookupOpportunityRepository;
        private readonly IOpportunityAutomateAssignmentService _opportunityAutomateAssignment;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="opportunityUserRepository"></param>
        /// <param name="lookupUserRepository"></param>
        /// <param name="lookupOpportunityRepository"></param>
        /// <param name="opportunityAutomateAssignment"></param>
        public OpportunityUsersAppService(IRepository<OpportunityUser> opportunityUserRepository,
            IRepository<User, long> lookupUserRepository,
            IRepository<Opportunity, int> lookupOpportunityRepository,
            IOpportunityAutomateAssignmentService opportunityAutomateAssignment)
        {
            _lookupOpportunityRepository = lookupOpportunityRepository;
            _lookupUserRepository = lookupUserRepository;
            _opportunityAutomateAssignment = opportunityAutomateAssignment;
            _opportunityUserRepository = opportunityUserRepository;
        }

        /// <summary>
        /// Method to get permission to VIEW Assigned Users widget in Opportunities
        /// The user can see the widget if meet these 2 conditions:
        /// 1. The current user has <see cref="AppPermissions.Pages_OpportunityUsers"/>  permission, oriented for Managers
        /// 2. The current user has <see cref="AppPermissions.Pages_OpportunityUsers_View__Dynamic"/> permission and is assigned in the Opportunity
        /// </summary>
        /// <param name="opportunityId"></param>
        /// <returns></returns>
        [AbpAllowAnonymous]
        public async Task<bool> GetCanViewAssignedUsersWidget(int opportunityId)
        {
            var currentUser = await GetCurrentUserAsync();
            var hasDynamicPermission =
                await UserManager.IsGrantedAsync(currentUser.Id, AppPermissions.Pages_OpportunityUsers_View__Dynamic);
            var hasStaticPermission = await UserManager.IsGrantedAsync(currentUser.Id, AppPermissions.Pages_OpportunityUsers);

            var currentUserIsAssignedInCustomer = _opportunityUserRepository
                .GetAll()
                .Where(x => x.OpportunityId == opportunityId)
                .Any(x => x.UserId == currentUser.Id);

            var canViewAssignedUsersDynamic = hasDynamicPermission && currentUserIsAssignedInCustomer;
            return canViewAssignedUsersDynamic || hasStaticPermission;
        }

        /// <summary>
        /// Get all opportunity users
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [AbpAuthorize(
            permissions: new[]
            {
                AppPermissions.Pages_OpportunityUsers,
                AppPermissions.Pages_OpportunityUsers_View__Dynamic
            },
            RequireAllPermissions = false
        )]
        public async Task<PagedResultDto<GetOpportunityUserForViewDto>> GetAll(GetAllOpportunityUsersInput input)
        {
            var filteredOpportunityUsers = _opportunityUserRepository.GetAll()
                .Include(e => e.UserFk)
                .Include(e => e.OpportunityFk)
                .WhereIf(!string.IsNullOrWhiteSpace(input.Filter), e => false)
                .WhereIf(!string.IsNullOrWhiteSpace(input.UserNameFilter),
                    e => e.UserFk != null && e.UserFk.Name == input.UserNameFilter)
                .WhereIf(!string.IsNullOrWhiteSpace(input.OpportunityNameFilter),
                    e => e.OpportunityFk != null && e.OpportunityFk.Name == input.OpportunityNameFilter)
                .Where(e => e.OpportunityFk != null && e.OpportunityFk.Id == input.OpportunityId)
                .Where(e => !e.IsDeleted);

            var pagedAndFilteredOpportunityUsers = filteredOpportunityUsers
                .OrderBy(input.Sorting ?? "id asc")
                .PageBy(input);

            var opportunityUsers = from o in pagedAndFilteredOpportunityUsers
                                   join o1 in _lookupUserRepository.GetAll() on o.UserId equals o1.Id into j1
                                   from s1 in j1.DefaultIfEmpty()
                                   join o2 in _lookupOpportunityRepository.GetAll() on o.OpportunityId equals o2.Id into j2
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
        [AbpAuthorize(AppPermissions.Pages_OpportunityUsers)]
        public async Task<GetOpportunityUserForViewDto> GetOpportunityUserForView(int id)
        {
            var opportunityUser = await _opportunityUserRepository.GetAsync(id);

            var output = new GetOpportunityUserForViewDto
            { OpportunityUser = ObjectMapper.Map<OpportunityUserDto>(opportunityUser) };

            if (output.OpportunityUser.UserId != null)
            {
                var _lookupUser = await _lookupUserRepository.FirstOrDefaultAsync((long)output.OpportunityUser.UserId);
                output.UserName = _lookupUser?.Name?.ToString();
            }

            if (output.OpportunityUser.OpportunityId != null)
            {
                var _lookupOpportunity =
                    await _lookupOpportunityRepository.FirstOrDefaultAsync((int)output.OpportunityUser.OpportunityId);
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

            var output = new GetOpportunityUserForEditOutput
            { OpportunityUser = ObjectMapper.Map<CreateOrEditOpportunityUserDto>(opportunityUser) };

            if (output.OpportunityUser.UserId != null)
            {
                var _lookupUser = await _lookupUserRepository.FirstOrDefaultAsync((long)output.OpportunityUser.UserId);
                output.UserName = _lookupUser?.Name?.ToString();
            }

            if (output.OpportunityUser.OpportunityId != null)
            {
                var _lookupOpportunity =
                    await _lookupOpportunityRepository.FirstOrDefaultAsync((int)output.OpportunityUser.OpportunityId);
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

            opportunityUser.TenantId = GetTenantId();

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
            return await _lookupUserRepository.GetAll()
                .Select(user => new OpportunityUserUserLookupTableDto
                {
                    Id = user.Id,
                    DisplayName = user == null || user.FullName == null ? "" : user.FullName.ToString()
                }).ToListAsync();
        }

        /// <summary>
        /// Get Opportunity User User for table
        /// </summary>
        /// <returns></returns>
        [AbpAuthorize(AppPermissions.Pages_OpportunityUsers)]
        public async Task<List<OpportunityUserOpportunityLookupTableDto>> GetAllOpportunityForTableDropdown()
        {
            return await _lookupOpportunityRepository.GetAll()
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
            await _opportunityAutomateAssignment.AssignOpportunityUsersAsync(input);
        }
    }
}