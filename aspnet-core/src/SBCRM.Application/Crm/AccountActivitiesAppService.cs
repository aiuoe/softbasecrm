using Abp.Application.Services.Dto;
using Abp.Collections.Extensions;
using Abp.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using SBCRM.Authorization;
using SBCRM.Authorization.Users;
using SBCRM.Crm.Dtos;
using SBCRM.Legacy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using Abp.Linq.Extensions;
using System.Text;
using System.Threading.Tasks;

namespace SBCRM.Crm
{
    /// <summary>
    /// App service for handling CRUD operations of Activities of an Account
    /// </summary>
    public class AccountActivitiesAppService : SBCRMAppServiceBase, IAccountActivitiesAppService
    {

        private readonly IRepository<Activity, long> _activityRepository;
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
        /// Constructor
        /// </summary>
        /// <param name="activityRepository"></param>
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
        public AccountActivitiesAppService(
            IRepository<Activity, long> activityRepository,
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
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<PagedResultDto<GetActivityForViewDto>> GetAll(GetAllActivitiesForWidget input)
        {

            var filteredActivities = _activityRepository.GetAll()
                .Include(e => e.CustomerFk)
                .Include(e => e.UserFk)
                .Include(e => e.ActivitySourceTypeFk)
                .Include(e => e.ActivityTaskTypeFk)
                .Include(e => e.ActivityStatusFk)
                .Include(e => e.ActivityPriorityFk)
                .Where(e => e.CustomerFk != null && e.CustomerFk.Number == input.IdToFilter)
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
                                 ActivityTaskTypeColor = type != null ? type.Color : string.Empty,
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
                    ActivityTaskTypeColor = o.ActivityTaskTypeColor,
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
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task CreateOrEdit(CreateOrEditActivityDto input)
        {
            var activity = ObjectMapper.Map<Activity>(input);
            activity.StartsAt = activity.StartsAt.ToUniversalTime();
            activity.DueDate = activity.DueDate.ToUniversalTime();

            activity.TenantId = GetTenantId();

            await _activityRepository.InsertAsync(activity);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task Delete(EntityDto<long> input)
        {
            await _activityRepository.DeleteAsync(input.Id);
        }
    }
}
