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
using Abp.Authorization;
using Microsoft.EntityFrameworkCore;
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
        private readonly IRepository<Opportunity, int> _lookupOpportunityRepository;
        private readonly IRepository<OpportunityUser, int> _lookupOpportunityUserRepository;
        private readonly IRepository<Lead, int> _lookupLeadRepository;
        private readonly IRepository<LeadUser, int> _lookupLeadUserRepository;
        private readonly IRepository<User, long> _lookupUserRepository;
        private readonly IRepository<ActivitySourceType, int> _lookupActivitySourceTypeRepository;
        private readonly IRepository<ActivityTaskType, int> _lookupActivityTaskTypeRepository;
        private readonly IRepository<ActivityStatus, int> _lookupActivityStatusRepository;
        private readonly IRepository<ActivityPriority, int> _lookupActivityPriorityRepository;
        private readonly IRepository<Customer, int> _lookupCustomerRepository;
        private readonly IRepository<AccountUser, int> _lookupAccountUserRepository;

        /// <summary>
        /// The constructor method
        /// </summary>
        /// <param name="activityRepository"></param>
        /// <param name="activitiesExcelExporter"></param>
        /// <param name="lookupOpportunityRepository"></param>
        /// <param name="lookupOpportunityUserRepository"></param>
        /// <param name="lookupLeadRepository"></param>
        /// <param name="lookupLeadUserRepository"></param>
        /// <param name="lookupUserRepository"></param>
        /// <param name="lookupActivitySourceTypeRepository"></param>
        /// <param name="lookupActivityTaskTypeRepository"></param>
        /// <param name="lookupActivityStatusRepository"></param>
        /// <param name="lookupActivityPriorityRepository"></param>
        /// <param name="lookupCustomerRepository"></param>
        /// <param name="lookupAccountUserRepository"></param>
        public ActivitiesAppService(
            IRepository<Activity, long> activityRepository,
            IActivitiesExcelExporter activitiesExcelExporter,
            IRepository<Opportunity, int> lookupOpportunityRepository,
            IRepository<OpportunityUser, int> lookupOpportunityUserRepository,
            IRepository<Lead, int> lookupLeadRepository,
            IRepository<LeadUser, int> lookupLeadUserRepository,
            IRepository<User, long> lookupUserRepository,
            IRepository<ActivitySourceType, int> lookupActivitySourceTypeRepository,
            IRepository<ActivityTaskType, int> lookupActivityTaskTypeRepository,
            IRepository<ActivityStatus, int> lookupActivityStatusRepository,
            IRepository<ActivityPriority, int> lookupActivityPriorityRepository,
            IRepository<Customer, int> lookupCustomerRepository,
            IRepository<AccountUser, int> lookupAccountUserRepository)
        {
            _activityRepository = activityRepository;
            _activitiesExcelExporter = activitiesExcelExporter;
            _lookupOpportunityRepository = lookupOpportunityRepository;
            _lookupOpportunityUserRepository = lookupOpportunityUserRepository;
            _lookupLeadRepository = lookupLeadRepository;
            _lookupLeadUserRepository = lookupLeadUserRepository;
            _lookupUserRepository = lookupUserRepository;
            _lookupActivitySourceTypeRepository = lookupActivitySourceTypeRepository;
            _lookupActivityTaskTypeRepository = lookupActivityTaskTypeRepository;
            _lookupActivityStatusRepository = lookupActivityStatusRepository;
            _lookupActivityPriorityRepository = lookupActivityPriorityRepository;
            _lookupCustomerRepository = lookupCustomerRepository;
            _lookupAccountUserRepository = lookupAccountUserRepository;
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
                             join o1 in _lookupOpportunityRepository.GetAll() on activity.OpportunityId equals o1.Id into j1
                             from opportunity in j1.DefaultIfEmpty()
                             join o2 in _lookupLeadRepository.GetAll() on activity.LeadId equals o2.Id into j2
                             from lead in j2.DefaultIfEmpty()
                             join o3 in _lookupUserRepository.GetAll() on activity.UserId equals o3.Id into j3
                             from user in j3.DefaultIfEmpty()
                             join o4 in _lookupActivitySourceTypeRepository.GetAll() on activity.ActivitySourceTypeId equals o4.Id into j4
                             from sourceType in j4.DefaultIfEmpty()
                             join o5 in _lookupActivityTaskTypeRepository.GetAll() on activity.ActivityTaskTypeId equals o5.Id into j5
                             from type in j5.DefaultIfEmpty()
                             join o6 in _lookupActivityStatusRepository.GetAll() on activity.ActivityStatusId equals o6.Id into j6
                             from status in j6.DefaultIfEmpty()
                             join o7 in _lookupActivityPriorityRepository.GetAll() on activity.ActivityPriorityId equals o7.Id into j7
                             from priority in j7.DefaultIfEmpty()
                             join o8 in _lookupCustomerRepository.GetAll() on activity.CustomerNumber equals o8.Number into j8
                             from customer in j8.DefaultIfEmpty()
                             select new
                             {
                                 activity.Id,
                                 activity.UserId,
                                 activity.DueDate,
                                 activity.StartsAt,
                                 User = user,
                                 SourceTypeCode = sourceType.Code,
                                 UserName = user != null ? user.Name + " " + user.Surname : string.Empty,
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
                    CompanyName = o.CompanyName,
                    SourceTypeCode = o.SourceTypeCode,
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
                var _lookupOpportunity = await _lookupOpportunityRepository.FirstOrDefaultAsync((int)output.Activity.OpportunityId);
                output.OpportunityName = _lookupOpportunity?.Name?.ToString();
            }

            if (output.Activity.LeadId != null)
            {
                var _lookupLead = await _lookupLeadRepository.FirstOrDefaultAsync((int)output.Activity.LeadId);
                output.LeadCompanyName = _lookupLead?.CompanyName?.ToString();
            }

            var lookupUser = await _lookupUserRepository.FirstOrDefaultAsync((long)output.Activity.UserId);
            output.UserName = lookupUser?.Name?.ToString();

            var lookupActivitySourceType = await _lookupActivitySourceTypeRepository.FirstOrDefaultAsync((int)output.Activity.ActivitySourceTypeId);
            output.ActivitySourceTypeDescription = lookupActivitySourceType?.Description?.ToString();

            var lookupActivityTaskType = await _lookupActivityTaskTypeRepository.FirstOrDefaultAsync((int)output.Activity.ActivityTaskTypeId);
            output.ActivityTaskTypeDescription = lookupActivityTaskType?.Description?.ToString();

            var lookupActivityStatus = await _lookupActivityStatusRepository.FirstOrDefaultAsync((int)output.Activity.ActivityStatusId);
            output.ActivityStatusDescription = lookupActivityStatus?.Description?.ToString();

            var lookupActivityPriority = await _lookupActivityPriorityRepository.FirstOrDefaultAsync((int)output.Activity.ActivityPriorityId);
            output.ActivityPriorityDescription = lookupActivityPriority?.Description?.ToString();

            var lookupCustomer = await _lookupCustomerRepository.FirstOrDefaultAsync(x => x.Number == output.Activity.CustomerNumber);
            output.CustomerName = lookupCustomer?.Name?.ToString();

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
                var lookupOpportunity = await _lookupOpportunityRepository.FirstOrDefaultAsync((int)output.Activity.OpportunityId);
                output.OpportunityName = lookupOpportunity?.Name?.ToString();
            }

            if (output.Activity.LeadId != null)
            {
                var lookupLead = await _lookupLeadRepository.FirstOrDefaultAsync((int)output.Activity.LeadId);
                output.LeadCompanyName = lookupLead?.CompanyName?.ToString();
            }

            var lookupUser = await _lookupUserRepository.FirstOrDefaultAsync((long)output.Activity.UserId);
            output.UserName = lookupUser?.Name?.ToString();

            var lookupActivitySourceType = await _lookupActivitySourceTypeRepository.FirstOrDefaultAsync((int)output.Activity.ActivitySourceTypeId);
            output.ActivitySourceTypeDescription = lookupActivitySourceType?.Description?.ToString();

            var lookupActivityTaskType = await _lookupActivityTaskTypeRepository.FirstOrDefaultAsync((int)output.Activity.ActivityTaskTypeId);
            output.ActivityTaskTypeDescription = lookupActivityTaskType?.Description?.ToString();

            var lookupActivityStatus = await _lookupActivityStatusRepository.FirstOrDefaultAsync((int)output.Activity.ActivityStatusId);
            output.ActivityStatusDescription = lookupActivityStatus?.Description?.ToString();

            var lookupActivityPriority = await _lookupActivityPriorityRepository.FirstOrDefaultAsync((int)output.Activity.ActivityPriorityId);
            output.ActivityPriorityDescription = lookupActivityPriority?.Description?.ToString();

            var lookupCustomer = await _lookupCustomerRepository.FirstOrDefaultAsync(x => x.Number == output.Activity.CustomerNumber);
            output.CustomerName = lookupCustomer?.Name?.ToString();

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
                         join o1 in _lookupOpportunityRepository.GetAll() on activity.OpportunityId equals o1.Id into j1
                         from opportunity in j1.DefaultIfEmpty()

                         join o2 in _lookupLeadRepository.GetAll() on activity.LeadId equals o2.Id into j2
                         from lead in j2.DefaultIfEmpty()

                         join o3 in _lookupUserRepository.GetAll() on activity.UserId equals o3.Id into j3
                         from user in j3.DefaultIfEmpty()

                         join o4 in _lookupActivitySourceTypeRepository.GetAll() on activity.ActivitySourceTypeId equals o4.Id into j4
                         from sourceType in j4.DefaultIfEmpty()

                         join o5 in _lookupActivityTaskTypeRepository.GetAll() on activity.ActivityTaskTypeId equals o5.Id into j5
                         from type in j5.DefaultIfEmpty()

                         join o6 in _lookupActivityStatusRepository.GetAll() on activity.ActivityStatusId equals o6.Id into j6
                         from status in j6.DefaultIfEmpty()

                         join o7 in _lookupActivityPriorityRepository.GetAll() on activity.ActivityPriorityId equals o7.Id into j7
                         from priority in j7.DefaultIfEmpty()

                         join o8 in _lookupCustomerRepository.GetAll() on activity.CustomerNumber equals o8.Number into j8
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
                             UserName = user != null ? user.Name + " " + user.Surname : string.Empty,
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
            else
                query = query
                    .OrderBy(input.Sorting)
                    .PageBy(input);

            var activityListDtos = await query.ToListAsync();

            return _activitiesExcelExporter.ExportToFile(activityListDtos);
        }

        /// <summary>
        /// Get all accounts for table dropdown
        /// </summary>
        /// <returns></returns>
        [AbpAuthorize(AppPermissions.Pages_Activities)]
        public async Task<List<ActivityCustomerLookupTableDto>> GetAllAccountsForTableDropdown()
        {
            var currentUser = await GetCurrentUserAsync();
            var canAssignOthers = await UserManager.IsGrantedAsync(currentUser.Id, AppPermissions.Pages_Activities_View_AssignedUserFilter);

            var userCustomers = new List<string>();

            if (!canAssignOthers)
            {
                userCustomers = await _lookupAccountUserRepository.GetAll()
                    .Where(x => x.UserId == currentUser.Id)
                    .Select(x => x.CustomerNumber)
                    .ToListAsync();
            }

            return await _lookupCustomerRepository.GetAll()
                .Where(x => canAssignOthers || userCustomers.Any(cn => cn == x.Number))
                .Select(account => new ActivityCustomerLookupTableDto
                {
                    Number = account.Number,
                    Name = account == null || account.Name == null ? string.Empty : account.Name
                }).ToListAsync();
        }

        /// <summary>
        /// Get all accounts related to opportunity for table dropdown
        /// </summary>
        /// <returns></returns>
        [AbpAuthorize(AppPermissions.Pages_Activities)]
        public async Task<List<ActivityCustomerLookupTableDto>> GetAllAccountRelatedToOpportunityForTableDropdown()
        {
            var opportunityAccounts = await _lookupOpportunityRepository.GetAll()
                .Select(x => x.CustomerNumber)
                .Distinct()
                .ToListAsync();

            return await _lookupCustomerRepository.GetAll()
                .Where(x => opportunityAccounts.Any(cn => cn == x.Number))
                .Select(account => new ActivityCustomerLookupTableDto
                {
                    Number = account.Number,
                    Name = account == null || account.Name == null ? string.Empty : account.Name
                }).ToListAsync();
        }

        /// <summary>
        /// Get all opportunities or assigned opportunities for table dropdown
        /// </summary>
        /// <returns></returns>
        [AbpAuthorize(AppPermissions.Pages_Activities)]
        public async Task<List<ActivityOpportunityLookupTableDto>> GetAllOpportunityForTableDropdown()
        {
            var currentUser = await GetCurrentUserAsync();
            var canAssignOthers = await UserManager.IsGrantedAsync(currentUser.Id, AppPermissions.Pages_Activities_View_AssignedUserFilter);

            var userOpportunities = new List<int>();

            if (!canAssignOthers)
            {
                userOpportunities = await _lookupOpportunityUserRepository.GetAll()
                    .Where(x => x.UserId == currentUser.Id)
                    .Select(x => x.OpportunityId)
                    .ToListAsync();
            }

            return await _lookupOpportunityRepository.GetAll()
                .Where(x => canAssignOthers || userOpportunities.Any(id => id == x.Id))
                .Select(opportunity => new ActivityOpportunityLookupTableDto
                {
                    Id = opportunity.Id,
                    CustomerNumber = opportunity.CustomerNumber,
                    DisplayName = opportunity == null || opportunity.Name == null ? string.Empty : opportunity.Name
                }).ToListAsync();
        }

        /// <summary>
        /// Get all leads or assigned leads based on permission for table dropdown
        /// </summary>
        /// <returns></returns>
        [AbpAuthorize(AppPermissions.Pages_Activities)]
        public async Task<List<ActivityLeadLookupTableDto>> GetAllLeadForTableDropdown()
        {
            var currentUser = await GetCurrentUserAsync();
            var canAssignOthers = await UserManager.IsGrantedAsync(currentUser.Id, AppPermissions.Pages_Activities_View_AssignedUserFilter);

            var userLeads = new List<int?>();

            if (!canAssignOthers)
            {
                userLeads = await _lookupLeadUserRepository.GetAll()
                    .Where(x => x.UserId == currentUser.Id)
                    .Select(x => x.LeadId)
                    .ToListAsync();
            }

            return await _lookupLeadRepository.GetAll()
                .Where(x => canAssignOthers || userLeads.Any(id => id == x.Id))
                .Select(lead => new ActivityLeadLookupTableDto
                {
                    Id = lead.Id,
                    DisplayName = lead == null || lead.CompanyName == null ? string.Empty : lead.CompanyName
                }).ToListAsync();
        }

        /// <summary>
        /// Get all users for table dropdown
        /// </summary>
        /// <returns></returns>
        [AbpAuthorize(AppPermissions.Pages_Activities)]
        public async Task<List<ActivityUserLookupTableDto>> GetAllUserForTableDropdown()
        {
            var currentUser = await GetCurrentUserAsync();
            var canAssignOthers = await UserManager.IsGrantedAsync(currentUser.Id, AppPermissions.Pages_Activities_View_AssignedUserFilter);

            return await _lookupUserRepository.GetAll()
                .Where(x => canAssignOthers || x.Id == currentUser.Id)
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
            return await _lookupActivitySourceTypeRepository.GetAll()
                .OrderBy(x => x.Order)
                .Select(activitySourceType => new ActivityActivitySourceTypeLookupTableDto
                {
                    Id = activitySourceType.Id,
                    Code = activitySourceType.Code,
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
            return await _lookupActivityTaskTypeRepository.GetAll()
                .OrderBy(x => x.Order)
                .Select(activityTaskType => new ActivityActivityTaskTypeLookupTableDto
                {
                    Id = activityTaskType.Id,
                    IsDefault = activityTaskType.IsDefault,
                    Code = activityTaskType.Code,
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
            return await _lookupActivityStatusRepository.GetAll()
                .OrderBy(x => x.Order)
                .Select(activityStatus => new ActivityActivityStatusLookupTableDto
                {
                    Id = activityStatus.Id,
                    IsDefault = activityStatus.IsDefault,
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
            return await _lookupActivityPriorityRepository.GetAll()
                .OrderBy(x => x.Order)
                .Select(activityPriority => new ActivityActivityPriorityLookupTableDto
                {
                    Id = activityPriority.Id,
                    IsDefault = activityPriority.IsDefault,
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
            return await _lookupCustomerRepository.GetAll()
                .Select(customer => new ActivityCustomerLookupTableDto
                {
                    Number = customer.Number,
                    Name = customer == null || customer.Name == null ? "" : customer.Name.ToString()
                }).ToListAsync();
        }

    }
}