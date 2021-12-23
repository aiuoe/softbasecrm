using SBCRM.Crm;
using SBCRM.Authorization.Users;

using System;
using System.Linq;
using System.Linq.Dynamic.Core;
using Abp.Linq.Extensions;
using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using SBCRM.Crm.Exporting;
using SBCRM.Crm.Dtos;
using SBCRM.Dto;
using Abp.Application.Services.Dto;
using SBCRM.Authorization;
using Abp.Extensions;
using Abp.Authorization;
using Microsoft.EntityFrameworkCore;
using Abp.UI;
using SBCRM.Storage;
using SBCRM.Legacy;

namespace SBCRM.Crm
{
    /// <summary>
    /// App service for handling CRUD operations of Activities
    /// </summary>
    [AbpAuthorize(AppPermissions.Pages_Activities)]
    public class ActivitiesAppService : SBCRMAppServiceBase, IActivitiesAppService
    {
        private readonly IRepository<Activity, long> _activityRepository;
        private readonly IActivitiesExcelExporter _activitiesExcelExporter;
        private readonly IRepository<Opportunity, int> _lookup_opportunityRepository;
        private readonly IRepository<Lead, int> _lookup_leadRepository;
        private readonly IRepository<User, long> _lookup_userRepository;
        private readonly IRepository<ActivitySourceType, int> _lookup_activitySourceTypeRepository;
        private readonly IRepository<ActivityTaskType, int> _lookup_activityTaskTypeRepository;
        private readonly IRepository<ActivityStatus, int> _lookup_activityStatusRepository;
        private readonly IRepository<ActivityPriority, int> _lookup_activityPriorityRepository;
        private readonly IRepository<Customer, int> _lookup_customerRepository;

        public ActivitiesAppService(IRepository<Activity, long> activityRepository, IActivitiesExcelExporter activitiesExcelExporter, IRepository<Opportunity, int> lookup_opportunityRepository, IRepository<Lead, int> lookup_leadRepository, IRepository<User, long> lookup_userRepository, IRepository<ActivitySourceType, int> lookup_activitySourceTypeRepository, IRepository<ActivityTaskType, int> lookup_activityTaskTypeRepository, IRepository<ActivityStatus, int> lookup_activityStatusRepository, IRepository<ActivityPriority, int> lookup_activityPriorityRepository, IRepository<Customer, int> lookup_customerRepository)
        {
            _activityRepository = activityRepository;
            _activitiesExcelExporter = activitiesExcelExporter;
            _lookup_opportunityRepository = lookup_opportunityRepository;
            _lookup_leadRepository = lookup_leadRepository;
            _lookup_userRepository = lookup_userRepository;
            _lookup_activitySourceTypeRepository = lookup_activitySourceTypeRepository;
            _lookup_activityTaskTypeRepository = lookup_activityTaskTypeRepository;
            _lookup_activityStatusRepository = lookup_activityStatusRepository;
            _lookup_activityPriorityRepository = lookup_activityPriorityRepository;
            _lookup_customerRepository = lookup_customerRepository;
        }

        public async Task<PagedResultDto<GetActivityForViewDto>> GetAll(GetAllActivitiesInput input)
        {
            var currentUser = await GetCurrentUserAsync();
            var isUserCanFilterByAssignee = await UserManager.IsGrantedAsync(currentUser.Id, AppPermissions.Pages_Activities_View_AssignedUserFilter);

            var filteredActivities = _activityRepository.GetAll()
                        .Include(e => e.OpportunityFk)
                            .ThenInclude(e => e.CustomerFk)
                        .Include(e => e.LeadFk)
                        .Include(e => e.UserFk)
                        .Include(e => e.ActivitySourceTypeFk)
                        .Include(e => e.ActivityTaskTypeFk)
                        .Include(e => e.ActivityStatusFk)
                        .Include(e => e.ActivityPriorityFk)
                        .Include(e => e.CustomerFk)
                        .WhereIf(isUserCanFilterByAssignee && input.UserIds.Any(), x => input.UserIds.Contains(x.UserId))
                        .WhereIf(!isUserCanFilterByAssignee, x => x.UserId == currentUser.Id)
                        .WhereIf(input.ExcludeCompleted, x => !x.ActivityStatusFk.IsCompletedStatus)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.Filter), e => false || e.CustomerFk.Name.Contains(input.Filter) || e.LeadFk.CompanyName.Contains(input.Filter) || e.OpportunityFk.CustomerFk.Name.Contains(input.Filter))
                        .WhereIf(!string.IsNullOrWhiteSpace(input.OpportunityNameFilter), e => e.OpportunityFk != null && e.OpportunityFk.Name == input.OpportunityNameFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.LeadCompanyNameFilter), e => e.LeadFk != null && e.LeadFk.CompanyName == input.LeadCompanyNameFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.UserNameFilter), e => e.UserFk != null && e.UserFk.Name == input.UserNameFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.ActivitySourceTypeDescriptionFilter), e => e.ActivitySourceTypeFk != null && e.ActivitySourceTypeFk.Description == input.ActivitySourceTypeDescriptionFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.ActivityTaskTypeDescriptionFilter), e => e.ActivityTaskTypeFk != null && e.ActivityTaskTypeFk.Description == input.ActivityTaskTypeDescriptionFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.ActivityStatusDescriptionFilter), e => e.ActivityStatusFk != null && e.ActivityStatusFk.Description == input.ActivityStatusDescriptionFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.ActivityPriorityDescriptionFilter), e => e.ActivityPriorityFk != null && e.ActivityPriorityFk.Description == input.ActivityPriorityDescriptionFilter);

            var pagedAndFilteredActivities = filteredActivities
                .OrderBy(input.Sorting ?? "ActivityStatusFk.Order ASC")
                .PageBy(input);

            var activities = from o in pagedAndFilteredActivities
                             join o1 in _lookup_opportunityRepository.GetAll() on o.OpportunityId equals o1.Id into j1
                             from s1 in j1.DefaultIfEmpty()

                             join o2 in _lookup_leadRepository.GetAll() on o.LeadId equals o2.Id into j2
                             from s2 in j2.DefaultIfEmpty()

                             join o3 in _lookup_userRepository.GetAll() on o.UserId equals o3.Id into j3
                             from s3 in j3.DefaultIfEmpty()

                             join o4 in _lookup_activitySourceTypeRepository.GetAll() on o.ActivitySourceTypeId equals o4.Id into j4
                             from s4 in j4.DefaultIfEmpty()

                             join o5 in _lookup_activityTaskTypeRepository.GetAll() on o.ActivityTaskTypeId equals o5.Id into j5
                             from s5 in j5.DefaultIfEmpty()

                             join o6 in _lookup_activityStatusRepository.GetAll() on o.ActivityStatusId equals o6.Id into j6
                             from s6 in j6.DefaultIfEmpty()

                             join o7 in _lookup_activityPriorityRepository.GetAll() on o.ActivityPriorityId equals o7.Id into j7
                             from s7 in j7.DefaultIfEmpty()

                             join o8 in _lookup_customerRepository.GetAll() on o.CustomerNumber equals o8.Number into j8
                             from s8 in j8.DefaultIfEmpty()

                             select new
                             {

                                 o.Id,
                                 o.UserId,
                                 o.DueDate,
                                 o.StartsAt,
                                 OpportunityName = s1 == null || s1.CustomerFk == null || s1.CustomerFk.Name == null ? "" : s1.CustomerFk.Name,
                                 LeadCompanyName = s2 == null || s2.CompanyName == null ? "" : s2.CompanyName.ToString(),
                                 UserName = s3 == null || s3.Name == null && s3.Surname == null ? "" : $"{s3.Name} {s3.Surname}",
                                 ActivitySourceTypeDescription = s4 == null || s4.Description == null ? "" : s4.Description.ToString(),
                                 ActivityTaskTypeDescription = s5 == null || s5.Description == null ? "" : s5.Description.ToString(),
                                 ActivityStatusDescription = s6 == null || s6.Description == null ? "" : s6.Description.ToString(),
                                 ActivityStatusColor = s6 == null || s6.Color == null ? "" : s6.Color,
                                 ActivityPriorityDescription = s7 == null || s7.Description == null ? "" : s7.Description.ToString(),
                                 ActivityPriorityColor = s7 == null || s7.Color == null ? "" : s7.Color,
                                 CustomerName = s8 == null || s8.Name == null ? "" : s8.Name,
                             };

            var totalCount = await filteredActivities.CountAsync();

            var dbList = await activities.ToListAsync();
            var results = new List<GetActivityForViewDto>();

            foreach (var o in dbList)
            {
                var res = new GetActivityForViewDto()
                {
                    Activity = new ActivityDto
                    {

                        Id = o.Id,
                        UserId = o.UserId,
                        DueDate = o.DueDate,
                        StartsAt = o.StartsAt,
                    },
                    OpportunityName = o.OpportunityName,
                    LeadCompanyName = o.LeadCompanyName,
                    UserName = o.UserName,
                    ActivitySourceTypeDescription = o.ActivitySourceTypeDescription,
                    ActivityTaskTypeDescription = o.ActivityTaskTypeDescription,
                    ActivityStatusDescription = o.ActivityStatusDescription,
                    ActivityStatusColor = o.ActivityStatusColor,
                    ActivityPriorityDescription = o.ActivityPriorityDescription,
                    ActivityPriorityColor = o.ActivityPriorityColor,
                    CustomerName = o.CustomerName
                };

                results.Add(res);
            }

            return new PagedResultDto<GetActivityForViewDto>(
                totalCount,
                results
            );

        }

        public async Task<GetActivityForViewDto> GetActivityForView(long id)
        {
            var activity = await _activityRepository.GetAsync(id);

            var output = new GetActivityForViewDto { Activity = ObjectMapper.Map<ActivityDto>(activity) };

            if (output.Activity.OpportunityId != null)
            {
                var _lookupOpportunity = await _lookup_opportunityRepository.FirstOrDefaultAsync((int)output.Activity.OpportunityId);
                output.OpportunityName = _lookupOpportunity?.Name?.ToString();
            }

            if (output.Activity.LeadId != null)
            {
                var _lookupLead = await _lookup_leadRepository.FirstOrDefaultAsync((int)output.Activity.LeadId);
                output.LeadCompanyName = _lookupLead?.CompanyName?.ToString();
            }

            if (output.Activity.UserId != null)
            {
                var _lookupUser = await _lookup_userRepository.FirstOrDefaultAsync((long)output.Activity.UserId);
                output.UserName = _lookupUser?.Name?.ToString();
            }

            if (output.Activity.ActivitySourceTypeId != null)
            {
                var _lookupActivitySourceType = await _lookup_activitySourceTypeRepository.FirstOrDefaultAsync((int)output.Activity.ActivitySourceTypeId);
                output.ActivitySourceTypeDescription = _lookupActivitySourceType?.Description?.ToString();
            }

            if (output.Activity.ActivityTaskTypeId != null)
            {
                var _lookupActivityTaskType = await _lookup_activityTaskTypeRepository.FirstOrDefaultAsync((int)output.Activity.ActivityTaskTypeId);
                output.ActivityTaskTypeDescription = _lookupActivityTaskType?.Description?.ToString();
            }

            if (output.Activity.ActivityStatusId != null)
            {
                var _lookupActivityStatus = await _lookup_activityStatusRepository.FirstOrDefaultAsync((int)output.Activity.ActivityStatusId);
                output.ActivityStatusDescription = _lookupActivityStatus?.Description?.ToString();
            }

            if (output.Activity.ActivityPriorityId != null)
            {
                var _lookupActivityPriority = await _lookup_activityPriorityRepository.FirstOrDefaultAsync((int)output.Activity.ActivityPriorityId);
                output.ActivityPriorityDescription = _lookupActivityPriority?.Description?.ToString();
            }

            if (output.Activity.CustomerNumber != null)
            {
                var _lookupActivityPriority = await _lookup_customerRepository.FirstOrDefaultAsync(x => x.Number == output.Activity.CustomerNumber);
                output.CustomerName = _lookupActivityPriority?.Name?.ToString();
            }

            return output;
        }

        [AbpAuthorize(AppPermissions.Pages_Activities_Edit)]
        public async Task<GetActivityForEditOutput> GetActivityForEdit(EntityDto<long> input)
        {
            var activity = await _activityRepository.FirstOrDefaultAsync(input.Id);

            var output = new GetActivityForEditOutput { Activity = ObjectMapper.Map<CreateOrEditActivityDto>(activity) };

            if (output.Activity.OpportunityId != null)
            {
                var _lookupOpportunity = await _lookup_opportunityRepository.FirstOrDefaultAsync((int)output.Activity.OpportunityId);
                output.OpportunityName = _lookupOpportunity?.Name?.ToString();
            }

            if (output.Activity.LeadId != null)
            {
                var _lookupLead = await _lookup_leadRepository.FirstOrDefaultAsync((int)output.Activity.LeadId);
                output.LeadCompanyName = _lookupLead?.CompanyName?.ToString();
            }

            if (output.Activity.UserId != null)
            {
                var _lookupUser = await _lookup_userRepository.FirstOrDefaultAsync((long)output.Activity.UserId);
                output.UserName = _lookupUser?.Name?.ToString();
            }

            if (output.Activity.ActivitySourceTypeId != null)
            {
                var _lookupActivitySourceType = await _lookup_activitySourceTypeRepository.FirstOrDefaultAsync((int)output.Activity.ActivitySourceTypeId);
                output.ActivitySourceTypeDescription = _lookupActivitySourceType?.Description?.ToString();
            }

            if (output.Activity.ActivityTaskTypeId != null)
            {
                var _lookupActivityTaskType = await _lookup_activityTaskTypeRepository.FirstOrDefaultAsync((int)output.Activity.ActivityTaskTypeId);
                output.ActivityTaskTypeDescription = _lookupActivityTaskType?.Description?.ToString();
            }

            if (output.Activity.ActivityStatusId != null)
            {
                var _lookupActivityStatus = await _lookup_activityStatusRepository.FirstOrDefaultAsync((int)output.Activity.ActivityStatusId);
                output.ActivityStatusDescription = _lookupActivityStatus?.Description?.ToString();
            }

            if (output.Activity.ActivityPriorityId != null)
            {
                var _lookupActivityPriority = await _lookup_activityPriorityRepository.FirstOrDefaultAsync((int)output.Activity.ActivityPriorityId);
                output.ActivityPriorityDescription = _lookupActivityPriority?.Description?.ToString();
            }

            if (output.Activity.CustomerNumber != null)
            {
                var _lookupActivityPriority = await _lookup_customerRepository.FirstOrDefaultAsync(x => x.Number == output.Activity.CustomerNumber);
                output.CustomerName = _lookupActivityPriority?.Name?.ToString();
            }

            return output;
        }

        public async Task CreateOrEdit(CreateOrEditActivityDto input)
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

        [AbpAuthorize(AppPermissions.Pages_Activities_Create)]
        protected virtual async Task Create(CreateOrEditActivityDto input)
        {
            var activity = ObjectMapper.Map<Activity>(input);

            await _activityRepository.InsertAsync(activity);

        }

        [AbpAuthorize(AppPermissions.Pages_Activities_Edit)]
        protected virtual async Task Update(CreateOrEditActivityDto input)
        {
            var activity = await _activityRepository.FirstOrDefaultAsync((long)input.Id);
            ObjectMapper.Map(input, activity);

        }

        [AbpAuthorize(AppPermissions.Pages_Activities_Delete)]
        public async Task Delete(EntityDto<long> input)
        {
            await _activityRepository.DeleteAsync(input.Id);
        }

        public async Task<FileDto> GetActivitiesToExcel(GetAllActivitiesForExcelInput input)
        {
            var currentUser = await GetCurrentUserAsync();
            var isUserCanFilterByAssignee = await UserManager.IsGrantedAsync(currentUser.Id, AppPermissions.Pages_Activities_View_AssignedUserFilter);

            var filteredActivities = _activityRepository.GetAll()
                        .Include(e => e.OpportunityFk)
                            .ThenInclude(e => e.CustomerFk)
                        .Include(e => e.LeadFk)
                        .Include(e => e.UserFk)
                        .Include(e => e.ActivitySourceTypeFk)
                        .Include(e => e.ActivityTaskTypeFk)
                        .Include(e => e.ActivityStatusFk)
                        .Include(e => e.ActivityPriorityFk)
                        .Include(e => e.CustomerFk)
                        .WhereIf(isUserCanFilterByAssignee && input.UserIds.Any(), x => input.UserIds.Contains(x.UserId))
                        .WhereIf(!isUserCanFilterByAssignee, x => x.UserId == currentUser.Id)
                        .WhereIf(input.ExcludeCompleted, x => !x.ActivityStatusFk.IsCompletedStatus)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.Filter), e => false || e.CustomerFk.Name.Contains(input.Filter) || e.LeadFk.CompanyName.Contains(input.Filter) || e.OpportunityFk.CustomerFk.Name.Contains(input.Filter))
                        .WhereIf(!string.IsNullOrWhiteSpace(input.OpportunityNameFilter), e => e.OpportunityFk != null && e.OpportunityFk.Name == input.OpportunityNameFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.LeadCompanyNameFilter), e => e.LeadFk != null && e.LeadFk.CompanyName == input.LeadCompanyNameFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.UserNameFilter), e => e.UserFk != null && e.UserFk.Name == input.UserNameFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.ActivitySourceTypeDescriptionFilter), e => e.ActivitySourceTypeFk != null && e.ActivitySourceTypeFk.Description == input.ActivitySourceTypeDescriptionFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.ActivityTaskTypeDescriptionFilter), e => e.ActivityTaskTypeFk != null && e.ActivityTaskTypeFk.Description == input.ActivityTaskTypeDescriptionFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.ActivityStatusDescriptionFilter), e => e.ActivityStatusFk != null && e.ActivityStatusFk.Description == input.ActivityStatusDescriptionFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.ActivityPriorityDescriptionFilter), e => e.ActivityPriorityFk != null && e.ActivityPriorityFk.Description == input.ActivityPriorityDescriptionFilter);

            var pagedAndFilteredActivities = filteredActivities
                .OrderBy(input.Sorting ?? "ActivityStatusFk.Order ASC")
                .PageBy(input);

            var query = (from o in pagedAndFilteredActivities
                         join o1 in _lookup_opportunityRepository.GetAll() on o.OpportunityId equals o1.Id into j1
                         from s1 in j1.DefaultIfEmpty()

                         join o2 in _lookup_leadRepository.GetAll() on o.LeadId equals o2.Id into j2
                         from s2 in j2.DefaultIfEmpty()

                         join o3 in _lookup_userRepository.GetAll() on o.UserId equals o3.Id into j3
                         from s3 in j3.DefaultIfEmpty()

                         join o4 in _lookup_activitySourceTypeRepository.GetAll() on o.ActivitySourceTypeId equals o4.Id into j4
                         from s4 in j4.DefaultIfEmpty()

                         join o5 in _lookup_activityTaskTypeRepository.GetAll() on o.ActivityTaskTypeId equals o5.Id into j5
                         from s5 in j5.DefaultIfEmpty()

                         join o6 in _lookup_activityStatusRepository.GetAll() on o.ActivityStatusId equals o6.Id into j6
                         from s6 in j6.DefaultIfEmpty()

                         join o7 in _lookup_activityPriorityRepository.GetAll() on o.ActivityPriorityId equals o7.Id into j7
                         from s7 in j7.DefaultIfEmpty()

                         join o8 in _lookup_customerRepository.GetAll() on o.CustomerNumber equals o8.Number into j8
                         from s8 in j8.DefaultIfEmpty()

                         select new GetActivityForViewDto()
                         {
                             Activity = new ActivityDto
                             {
                                 Id = o.Id,
                                 DueDate = o.DueDate,
                                 StartsAt = o.StartsAt,
                             },
                             OpportunityName = s1 == null || s1.CustomerFk == null ? null : s1.CustomerFk.Name,
                             LeadCompanyName = s2 == null ? null : s2.CompanyName,
                             UserName = s3 == null || s3.Name == null && s3.Surname == null ? "" : $"{s3.Name} {s3.Surname}",
                             ActivitySourceTypeDescription = s4 == null || s4.Description == null ? "" : s4.Description.ToString(),
                             ActivityTaskTypeDescription = s5 == null || s5.Description == null ? "" : s5.Description.ToString(),
                             ActivityStatusDescription = s6 == null || s6.Description == null ? "" : s6.Description.ToString(),
                             ActivityPriorityDescription = s7 == null || s7.Description == null ? "" : s7.Description.ToString(),
                             CustomerName = s8 == null ? null : s8.Name,
                         });

            var activityListDtos = await query.ToListAsync();

            return _activitiesExcelExporter.ExportToFile(activityListDtos);
        }

        [AbpAuthorize(AppPermissions.Pages_Activities)]
        public async Task<List<ActivityOpportunityLookupTableDto>> GetAllOpportunityForTableDropdown()
        {
            return await _lookup_opportunityRepository.GetAll()
                .Select(opportunity => new ActivityOpportunityLookupTableDto
                {
                    Id = opportunity.Id,
                    DisplayName = opportunity == null || opportunity.Name == null ? "" : opportunity.Name.ToString()
                }).ToListAsync();
        }

        [AbpAuthorize(AppPermissions.Pages_Activities)]
        public async Task<List<ActivityLeadLookupTableDto>> GetAllLeadForTableDropdown()
        {
            return await _lookup_leadRepository.GetAll()
                .Select(lead => new ActivityLeadLookupTableDto
                {
                    Id = lead.Id,
                    DisplayName = lead == null || lead.CompanyName == null ? "" : lead.CompanyName.ToString()
                }).ToListAsync();
        }

        [AbpAuthorize(AppPermissions.Pages_Activities)]
        public async Task<List<ActivityUserLookupTableDto>> GetAllUserForTableDropdown()
        {
            return await _lookup_userRepository.GetAll()
                .Select(user => new ActivityUserLookupTableDto
                {
                    Id = user.Id,
                    DisplayName = user == null || user.Name == null ? "" : user.Name.ToString()
                }).ToListAsync();
        }

        [AbpAuthorize(AppPermissions.Pages_Activities)]
        public async Task<List<ActivityActivitySourceTypeLookupTableDto>> GetAllActivitySourceTypeForTableDropdown()
        {
            return await _lookup_activitySourceTypeRepository.GetAll()
                .Select(activitySourceType => new ActivityActivitySourceTypeLookupTableDto
                {
                    Id = activitySourceType.Id,
                    DisplayName = activitySourceType == null || activitySourceType.Description == null ? "" : activitySourceType.Description.ToString()
                }).ToListAsync();
        }

        [AbpAuthorize(AppPermissions.Pages_Activities)]
        public async Task<List<ActivityActivityTaskTypeLookupTableDto>> GetAllActivityTaskTypeForTableDropdown()
        {
            return await _lookup_activityTaskTypeRepository.GetAll()
                .Select(activityTaskType => new ActivityActivityTaskTypeLookupTableDto
                {
                    Id = activityTaskType.Id,
                    DisplayName = activityTaskType == null || activityTaskType.Description == null ? "" : activityTaskType.Description.ToString()
                }).ToListAsync();
        }

        [AbpAuthorize(AppPermissions.Pages_Activities)]
        public async Task<List<ActivityActivityStatusLookupTableDto>> GetAllActivityStatusForTableDropdown()
        {
            return await _lookup_activityStatusRepository.GetAll()
                .Select(activityStatus => new ActivityActivityStatusLookupTableDto
                {
                    Id = activityStatus.Id,
                    DisplayName = activityStatus == null || activityStatus.Description == null ? "" : activityStatus.Description.ToString()
                }).ToListAsync();
        }

        [AbpAuthorize(AppPermissions.Pages_Activities)]
        public async Task<List<ActivityActivityPriorityLookupTableDto>> GetAllActivityPriorityForTableDropdown()
        {
            return await _lookup_activityPriorityRepository.GetAll()
                .Select(activityPriority => new ActivityActivityPriorityLookupTableDto
                {
                    Id = activityPriority.Id,
                    DisplayName = activityPriority == null || activityPriority.Description == null ? "" : activityPriority.Description.ToString()
                }).ToListAsync();
        }

        [AbpAuthorize(AppPermissions.Pages_Activities)]
        public async Task<List<ActivityCustomerLookupTableDto>> GetAllActivityCustomerForTableDropdown()
        {
            return await _lookup_customerRepository.GetAll()
                .Select(customer => new ActivityCustomerLookupTableDto
                {
                    Number = customer.Number,
                    Name = customer == null || customer.Name == null ? "" : customer.Name.ToString()
                }).ToListAsync();
        }

    }
}