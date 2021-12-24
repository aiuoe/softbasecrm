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

        /// <summary>
        /// The constructor method
        /// </summary>
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

        /// <summary>
        /// Get all activities used for list/grid
        /// </summary>
        /// <param name="input">The query of the http header</param>
        /// <returns></returns>
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


            var activities = from activity in filteredActivities
                             join o1 in _lookup_opportunityRepository.GetAll() on activity.OpportunityId equals o1.Id into j1
                             from opportunity in j1.DefaultIfEmpty()
                             join o2 in _lookup_leadRepository.GetAll() on activity.LeadId equals o2.Id into j2
                             from lead in j2.DefaultIfEmpty()
                             join o3 in _lookup_userRepository.GetAll() on activity.UserId equals o3.Id into j3
                             from user in j3.DefaultIfEmpty()
                             join o4 in _lookup_activitySourceTypeRepository.GetAll() on activity.ActivitySourceTypeId equals o4.Id into j4
                             from sourceType in j4.DefaultIfEmpty()
                             join o5 in _lookup_activityTaskTypeRepository.GetAll() on activity.ActivityTaskTypeId equals o5.Id into j5
                             from type in j5.DefaultIfEmpty()
                             join o6 in _lookup_activityStatusRepository.GetAll() on activity.ActivityStatusId equals o6.Id into j6
                             from status in j6.DefaultIfEmpty()
                             join o7 in _lookup_activityPriorityRepository.GetAll() on activity.ActivityPriorityId equals o7.Id into j7
                             from priority in j7.DefaultIfEmpty()
                             join o8 in _lookup_customerRepository.GetAll() on activity.CustomerNumber equals o8.Number into j8
                             from customer in j8.DefaultIfEmpty()
                             select new
                             {
                                 activity.Id,
                                 activity.UserId,
                                 activity.DueDate,
                                 activity.StartsAt,
                                 User = user,
                                 UserName = user != null ? user.FullName : string.Empty,
                                 ActivitySourceTypeDescription = sourceType != null ? sourceType.Description : string.Empty,
                                 ActivityTaskTypeDescription = type != null ? type.Description : string.Empty,
                                 ActivityStatusDescription = status != null ? status.Description : string.Empty,
                                 ActivityStatusColor = status != null ? status.Color : string.Empty,
                                 ActivityPriorityDescription = priority != null ? priority.Description : string.Empty,
                                 ActivityPriorityColor = priority != null ? priority.Color : string.Empty,
                                 CompanyName = lead != null
                                     ? lead.CompanyName
                                     : customer != null
                                         ? customer.Name
                                         : opportunity != null && opportunity.CustomerFk != null
                                             ? opportunity.CustomerFk.Name
                                             : string.Empty
                             };

            if (input.Sorting is null)
                activities = activities
                    .OrderByDescending(e => e.DueDate)
                    .PageBy(input);
            else if (input.Sorting.StartsWith("userName "))
            {
                // This is a temporary fix.
                // We cannot sort the full name of the user because it is not mapped to the database.
                // So we need to use the actual columns which is the Name and Surname.

                if (input.Sorting.EndsWith(" ASC", StringComparison.OrdinalIgnoreCase))
                    activities = activities
                        .OrderBy(x => x.User.Name)
                        .ThenBy(x => x.User.Surname)
                        .PageBy(input);
                else
                    activities = activities
                        .OrderByDescending(x => x.User.Name)
                        .ThenByDescending(x => x.User.Surname)
                        .PageBy(input);
            }
            else
                activities = activities
                    .OrderBy(input.Sorting)
                    .PageBy(input);

            var totalCount = await filteredActivities.CountAsync();

            var dbList = await activities.ToListAsync();
            var results = new List<GetActivityForViewDto>();

            foreach (var o in dbList)
            {
                var res = new GetActivityForViewDto
                {
                    Activity = new ActivityDto
                    {

                        Id = o.Id,
                        UserId = o.UserId,
                        DueDate = o.DueDate,
                        StartsAt = o.StartsAt,
                    },
                    UserName = o.UserName,
                    ActivitySourceTypeDescription = o.ActivitySourceTypeDescription,
                    ActivityTaskTypeDescription = o.ActivityTaskTypeDescription,
                    ActivityStatusDescription = o.ActivityStatusDescription,
                    ActivityStatusColor = o.ActivityStatusColor,
                    ActivityPriorityDescription = o.ActivityPriorityDescription,
                    ActivityPriorityColor = o.ActivityPriorityColor,
                    CompanyName = o.CompanyName
                };

                results.Add(res);
            }

            return new PagedResultDto<GetActivityForViewDto>(
                totalCount,
                results
            );
        }

        /// <summary>
        /// View details of an activity based on the provided id
        /// </summary>
        /// <param name="id">The id of the activity</param>
        /// <returns></returns>
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

            var _lookupUser = await _lookup_userRepository.FirstOrDefaultAsync((long)output.Activity.UserId);
            output.UserName = _lookupUser?.Name?.ToString();

            var _lookupActivitySourceType = await _lookup_activitySourceTypeRepository.FirstOrDefaultAsync((int)output.Activity.ActivitySourceTypeId);
            output.ActivitySourceTypeDescription = _lookupActivitySourceType?.Description?.ToString();

            var _lookupActivityTaskType = await _lookup_activityTaskTypeRepository.FirstOrDefaultAsync((int)output.Activity.ActivityTaskTypeId);
            output.ActivityTaskTypeDescription = _lookupActivityTaskType?.Description?.ToString();

            var _lookupActivityStatus = await _lookup_activityStatusRepository.FirstOrDefaultAsync((int)output.Activity.ActivityStatusId);
            output.ActivityStatusDescription = _lookupActivityStatus?.Description?.ToString();

            var _lookupActivityPriority = await _lookup_activityPriorityRepository.FirstOrDefaultAsync((int)output.Activity.ActivityPriorityId);
            output.ActivityPriorityDescription = _lookupActivityPriority?.Description?.ToString();

            var _lookupCustomer = await _lookup_customerRepository.FirstOrDefaultAsync(x => x.Number == output.Activity.CustomerNumber);
            output.CustomerName = _lookupCustomer?.Name?.ToString();

            return output;
        }

        /// <summary>
        /// View details of an activity used for editing/updating based on the provided input which includes the id of the activity
        /// </summary>
        /// <param name="input">Input from http header query which includes the id of the activity</param>
        /// <returns></returns>
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

            var _lookupUser = await _lookup_userRepository.FirstOrDefaultAsync((long)output.Activity.UserId);
            output.UserName = _lookupUser?.Name?.ToString();

            var _lookupActivitySourceType = await _lookup_activitySourceTypeRepository.FirstOrDefaultAsync((int)output.Activity.ActivitySourceTypeId);
            output.ActivitySourceTypeDescription = _lookupActivitySourceType?.Description?.ToString();

            var _lookupActivityTaskType = await _lookup_activityTaskTypeRepository.FirstOrDefaultAsync((int)output.Activity.ActivityTaskTypeId);
            output.ActivityTaskTypeDescription = _lookupActivityTaskType?.Description?.ToString();

            var _lookupActivityStatus = await _lookup_activityStatusRepository.FirstOrDefaultAsync((int)output.Activity.ActivityStatusId);
            output.ActivityStatusDescription = _lookupActivityStatus?.Description?.ToString();

            var _lookupActivityPriority = await _lookup_activityPriorityRepository.FirstOrDefaultAsync((int)output.Activity.ActivityPriorityId);
            output.ActivityPriorityDescription = _lookupActivityPriority?.Description?.ToString();

            var _lookupCustomer = await _lookup_customerRepository.FirstOrDefaultAsync(x => x.Number == output.Activity.CustomerNumber);
            output.CustomerName = _lookupCustomer?.Name?.ToString();

            return output;
        }

        /// <summary>
        /// Updates an activity if the id of the input has a value, otherwise creates it.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Creates a new activity
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [AbpAuthorize(AppPermissions.Pages_Activities_Create)]
        protected virtual async Task Create(CreateOrEditActivityDto input)
        {
            var activity = ObjectMapper.Map<Activity>(input);

            await _activityRepository.InsertAsync(activity);

        }

        /// <summary>
        /// Updates an existing activity
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [AbpAuthorize(AppPermissions.Pages_Activities_Edit)]
        protected virtual async Task Update(CreateOrEditActivityDto input)
        {
            var activity = await _activityRepository.FirstOrDefaultAsync((long)input.Id);
            ObjectMapper.Map(input, activity);

        }

        /// <summary>
        /// Deletes an activity
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [AbpAuthorize(AppPermissions.Pages_Activities_Delete)]
        public async Task Delete(EntityDto<long> input)
        {
            await _activityRepository.DeleteAsync(input.Id);
        }

        /// <summary>
        /// Generates an excel file that contains the list of activities based on the input.
        /// </summary>
        /// <param name="input">The http query header used for filtering, pagination, and sorting. This should exactly match the query of the GetAll method.</param>
        /// <returns></returns>
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

            var query = (from activity in filteredActivities
                         join o1 in _lookup_opportunityRepository.GetAll() on activity.OpportunityId equals o1.Id into j1
                         from opportunity in j1.DefaultIfEmpty()

                         join o2 in _lookup_leadRepository.GetAll() on activity.LeadId equals o2.Id into j2
                         from lead in j2.DefaultIfEmpty()

                         join o3 in _lookup_userRepository.GetAll() on activity.UserId equals o3.Id into j3
                         from user in j3.DefaultIfEmpty()

                         join o4 in _lookup_activitySourceTypeRepository.GetAll() on activity.ActivitySourceTypeId equals o4.Id into j4
                         from sourceType in j4.DefaultIfEmpty()

                         join o5 in _lookup_activityTaskTypeRepository.GetAll() on activity.ActivityTaskTypeId equals o5.Id into j5
                         from type in j5.DefaultIfEmpty()

                         join o6 in _lookup_activityStatusRepository.GetAll() on activity.ActivityStatusId equals o6.Id into j6
                         from status in j6.DefaultIfEmpty()

                         join o7 in _lookup_activityPriorityRepository.GetAll() on activity.ActivityPriorityId equals o7.Id into j7
                         from priority in j7.DefaultIfEmpty()

                         join o8 in _lookup_customerRepository.GetAll() on activity.CustomerNumber equals o8.Number into j8
                         from customer in j8.DefaultIfEmpty()

                         select new GetActivityForViewExportDto()
                         {
                             Activity = new ActivityDto
                             {
                                 Id = activity.Id,
                                 // Due date needs to be a direct child of the model in order to make custom sorting work.
                             },
                             DueDate = activity.DueDate,
                             StartsAt = activity.StartsAt,
                             UserFirstName = user != null ? user.Name : string.Empty,
                             UserLastName = user != null ? user.Surname : string.Empty,
                             UserName = user != null ? user.FullName : string.Empty,
                             ActivitySourceTypeDescription = sourceType != null ? sourceType.Description : string.Empty,
                             ActivityTaskTypeDescription = type != null ? type.Description : string.Empty,
                             ActivityStatusDescription = status != null ? status.Description : string.Empty,
                             ActivityPriorityDescription = priority != null ? priority.Description : string.Empty,
                             CompanyName = lead != null
                                     ? lead.CompanyName
                                     : customer != null
                                         ? customer.Name
                                         : opportunity != null && opportunity.CustomerFk != null
                                             ? opportunity.CustomerFk.Name
                                             : string.Empty,
                         });

            if (input.Sorting is null)
                query = query
                    .OrderByDescending(e => e.DueDate)
                    .PageBy(input);
            else if (input.Sorting.StartsWith("userName "))
            {
                // This is a temporary fix.
                // We cannot sort the full name of the user because it is not mapped to the database.
                // So we need to use the actual columns which is the Name and Surname.

                if (input.Sorting.EndsWith(" ASC", StringComparison.OrdinalIgnoreCase))
                    query = query
                        .OrderBy(x => x.UserFirstName)
                        .ThenBy(x => x.UserLastName)
                        .PageBy(input);
                else
                    query = query
                        .OrderByDescending(x => x.UserFirstName)
                        .ThenByDescending(x => x.UserLastName)
                        .PageBy(input);
            }
            else
                query = query
                    .OrderBy(input.Sorting)
                    .PageBy(input);

            var activityListDtos = await query.ToListAsync();

            return _activitiesExcelExporter.ExportToFile(activityListDtos);
        }

        /// <summary>
        /// Get all opportunities for table dropdown
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Get all leads for table dropdown
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Get all users for table dropdown
        /// </summary>
        /// <returns></returns>
        [AbpAuthorize(AppPermissions.Pages_Activities)]
        public async Task<List<ActivityUserLookupTableDto>> GetAllUserForTableDropdown()
        {
            return await _lookup_userRepository.GetAll()
                .Select(user => new ActivityUserLookupTableDto
                {
                    Id = user.Id,
                    DisplayName = user != null ? user.FullName : string.Empty
                }).ToListAsync();
        }

        /// <summary>
        /// Get all activity source type for table dropdown
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Get all activity task type for table dropdown
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Get all activity status for table dropdown
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Get all activity priority for table dropdown
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Get all customer for table dropdown
        /// </summary>
        /// <returns></returns>
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