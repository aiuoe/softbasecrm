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
using Abp.EntityHistory;
using Abp.Domain.Uow;

namespace SBCRM.Crm
{
    /// <summary>
    /// App Service that manages the LeadUser transactions
    /// </summary>
    public class LeadUsersAppService : SBCRMAppServiceBase, ILeadUsersAppService
    {
        private readonly IRepository<LeadUser> _leadUserRepository;
        private readonly IRepository<Lead, int> _lookup_leadRepository;
        private readonly IRepository<User, long> _lookup_userRepository;
        private readonly IEntityChangeSetReasonProvider _reasonProvider;
        private readonly IUnitOfWorkManager _unitOfWorkManager;

        /// <summary>
        /// Constructor method
        /// </summary>
        /// <param name="leadUserRepository"></param>
        /// <param name="lookup_leadRepository"></param>
        /// <param name="lookup_userRepository"></param>
        /// <param name="reasonProvider"></param>
        /// <param name="unitOfWorkManager"></param>
        public LeadUsersAppService(IRepository<LeadUser> leadUserRepository, 
                                    IRepository<Lead, int> lookup_leadRepository, 
                                    IRepository<User, long> lookup_userRepository,
                                    IEntityChangeSetReasonProvider reasonProvider,
                                    IUnitOfWorkManager unitOfWorkManager)
        {
            _leadUserRepository = leadUserRepository;
            _lookup_leadRepository = lookup_leadRepository;
            _lookup_userRepository = lookup_userRepository;
            _reasonProvider = reasonProvider;
            _unitOfWorkManager = unitOfWorkManager;
        }

        /// <summary>
        /// Method to get permission to VIEW Assigned Users widget in Leads
        /// The user can see the widget if meet these 2 conditions:
        /// 1. The current user has <see cref="AppPermissions.Pages_LeadUsers"/>  permission, oriented for Managers
        /// 2. The current user has <see cref="AppPermissions.Pages_LeadUsers_View__Dynamic"/> permission and is assigned in the Lead
        /// </summary>
        /// <param name="leadId"></param>
        /// <returns></returns>
        [AbpAllowAnonymous]
        public async Task<bool> GetCanViewAssignedUsersWidget(int leadId)
        {
            var currentUser = await GetCurrentUserAsync();
            var hasDynamicPermission =
                await UserManager.IsGrantedAsync(currentUser.Id, AppPermissions.Pages_LeadUsers_View__Dynamic);
            var hasStaticPermission = await UserManager.IsGrantedAsync(currentUser.Id, AppPermissions.Pages_LeadUsers);

            var currentUserIsAssignedInCustomer = _leadUserRepository
                .GetAll()
                .Where(x => x.LeadId == leadId)
                .Any(x => x.UserId == currentUser.Id);

            var canViewAssignedUsersDynamic = hasDynamicPermission && currentUserIsAssignedInCustomer;
            return canViewAssignedUsersDynamic || hasStaticPermission;
        }

        /// <summary>
        /// Gets all the lead users given a Lead Id
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [AbpAuthorize(
            permissions: new[]
            {
                AppPermissions.Pages_LeadUsers,
                AppPermissions.Pages_LeadUsers_View__Dynamic
            },
            RequireAllPermissions = false
        )]
        public async Task<PagedResultDto<GetLeadUserForViewDto>> GetAll(GetAllLeadUsersInput input)
        {

            var filteredLeadUsers = _leadUserRepository.GetAll()
                        .Include(e => e.LeadFk)
                        .Include(e => e.UserFk)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.Filter), e => false)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.LeadCompanyNameFilter), e => e.LeadFk != null && e.LeadFk.CompanyName == input.LeadCompanyNameFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.UserNameFilter), e => e.UserFk != null && e.UserFk.Name == input.UserNameFilter)
                        .Where(e => e.LeadFk != null && e.LeadFk.Id == input.LeadId)
                        .Where(p => !p.IsDeleted);

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
                                UserName = s2 == null || s2.Name == null ? "" : s2.FullName.ToString(),
                                UserId = o.UserId
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
                        UserId = o.UserId
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

        /// <summary>
        /// Get a Lead user object for edit purposes
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Creates or edites a new user assigned to a lead
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
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


        /// <summary>
        /// Creates a new user assigned to a lead
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [AbpAuthorize(AppPermissions.Pages_LeadUsers_Create)]
        protected virtual async Task Create(CreateOrEditLeadUserDto input)
        {
            var leadUser = ObjectMapper.Map<LeadUser>(input);
            
            leadUser.TenantId = GetTenantId();

            await _leadUserRepository.InsertAsync(leadUser);

        }


        /// <summary>
        /// Edits a new user assigned to a lead
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [AbpAuthorize(AppPermissions.Pages_LeadUsers_Edit)]
        protected virtual async Task Update(CreateOrEditLeadUserDto input)
        {
            var leadUser = await _leadUserRepository.FirstOrDefaultAsync((int)input.Id);
            ObjectMapper.Map(input, leadUser);

        }

        /// <summary>
        /// Deletes a new user assigned to a lead
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [AbpAuthorize(AppPermissions.Pages_LeadUsers_Delete)]
        public async Task Delete(EntityDto input)
        {
            await _leadUserRepository.DeleteAsync(input.Id);
        }

        /// <summary>
        /// Gets a list of al the leads
        /// </summary>
        /// <returns></returns>
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


        /// <summary>
        /// Gets a list of users
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// This method save a list of users connected with an specific Lead
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [AbpAuthorize(AppPermissions.Pages_LeadUsers_Create)]
        public async Task CreateMultipleLeadUsers(List<CreateOrEditLeadUserDto> input)
        {
            using (_reasonProvider.Use("User was assigned to Lead"))
            {
                foreach (var item in input)
                {
                    var leadUserExists = _leadUserRepository.FirstOrDefault(p => p.UserId == item.UserId
                        && p.LeadId == item.LeadId
                        && p.IsDeleted);

                    if (leadUserExists == null)
                    {
                        var leadUser = ObjectMapper.Map<LeadUser>(item);

                        await _leadUserRepository.InsertAsync(leadUser);
                    }
                    else
                    {
                        leadUserExists.IsDeleted = false;
                        var leadUserInDatabase = ObjectMapper.Map<CreateOrEditLeadUserDto>(leadUserExists);
                        var accountUser = await _leadUserRepository.FirstOrDefaultAsync(leadUserInDatabase.Id.Value);
                        ObjectMapper.Map(input, accountUser);
                    }
                }

                await _unitOfWorkManager.Current.SaveChangesAsync();
            }
        }

    }
}