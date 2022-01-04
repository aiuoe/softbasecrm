using Abp.Application.Services.Dto;
using Abp.Collections.Extensions;
using Abp.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using SBCRM.Authorization;
using SBCRM.Authorization.Users;
using SBCRM.Crm.Dtos;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using Abp.Linq.Extensions;
using System.Threading.Tasks;
using Abp.Application.Services;
using SBCRM.Legacy;

namespace SBCRM.Crm
{
    /// <summary>
    /// App service for handling CRUD operations of Activities
    /// </summary>
    [RemoteService(false)]
    public class ActivitiesService: SBCRMAppServiceBase, IActivitiesService
    {
        private readonly IRepository<Activity, long> _activityRepository;
        private readonly IRepository<User, long> _lookupUserRepository;
        private readonly IRepository<ActivitySourceType, int> _lookupActivitySourceTypeRepository;
        private readonly IRepository<ActivityTaskType, int> _lookupActivityTaskTypeRepository;
        private readonly IRepository<ActivityStatus, int> _lookupActivityStatusRepository;
        private readonly IRepository<ActivityPriority, int> _lookupActivityPriorityRepository;
        private readonly IRepository<Customer, int> _lookupCustomerRepository;
        private readonly IRepository<Lead, int> _lookupLeadRepository;
        private readonly IRepository<Opportunity, int> _lookupOpportunityRepository;


        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="activityRepository"></param>
        /// <param name="lookupUserRepository"></param>
        /// <param name="lookupActivitySourceTypeRepository"></param>
        /// <param name="lookupActivityTaskTypeRepository"></param>
        /// <param name="lookupActivityStatusRepository"></param>
        /// <param name="lookupActivityPriorityRepository"></param>
        /// <param name="lookupCustomerRepository"></param>
        /// <param name="lookupLeadRepository"></param>
        /// <param name="lookupOpportunityRepository"></param>
        public ActivitiesService(
            IRepository<Activity, long> activityRepository,
            IRepository<User, long> lookupUserRepository,
            IRepository<ActivitySourceType, int> lookupActivitySourceTypeRepository,
            IRepository<ActivityTaskType, int> lookupActivityTaskTypeRepository,
            IRepository<ActivityStatus, int> lookupActivityStatusRepository,
            IRepository<ActivityPriority, int> lookupActivityPriorityRepository,
            IRepository<Customer, int> lookupCustomerRepository,
            IRepository<Lead, int> lookupLeadRepository,
            IRepository<Opportunity, int> lookupOpportunityRepository)
        {
            _activityRepository = activityRepository;
            _lookupUserRepository = lookupUserRepository;
            _lookupActivitySourceTypeRepository = lookupActivitySourceTypeRepository;
            _lookupActivityTaskTypeRepository = lookupActivityTaskTypeRepository;
            _lookupActivityStatusRepository = lookupActivityStatusRepository;
            _lookupActivityPriorityRepository = lookupActivityPriorityRepository;
            _lookupCustomerRepository = lookupCustomerRepository;
            _lookupLeadRepository = lookupLeadRepository;
            _lookupOpportunityRepository = lookupOpportunityRepository;
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
        protected virtual async Task Create(CreateOrEditActivityDto input)
        {
            var activity = ObjectMapper.Map<Activity>(input);
            activity.StartsAt = activity.StartsAt.ToUniversalTime();
            activity.DueDate = activity.DueDate.ToUniversalTime();

            activity.TenantId = GetTenantId();

            await _activityRepository.InsertAsync(activity);
        }

        /// <summary>
        /// Updates an existing activity
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        protected virtual async Task Update(CreateOrEditActivityDto input)
        {
            var activity = await _activityRepository.FirstOrDefaultAsync((long)input.Id);
            input.StartsAt = input.StartsAt.ToUniversalTime();
            input.DueDate = input.DueDate.ToUniversalTime();
            ObjectMapper.Map(input, activity);

        }

        /// <summary>
        /// Deletes an activity
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task Delete(EntityDto<long> input)
        {
            await _activityRepository.DeleteAsync(input.Id);
        }

        /// <summary>
        /// Get all users for table dropdown
        /// </summary>
        /// <returns></returns>
        public async Task<List<ActivityUserLookupTableDto>> GetAllUserForTableDropdown()
        {
            var currentUser = await GetCurrentUserAsync();
            var canAssignOthers = await UserManager.IsGrantedAsync(currentUser.Id, AppPermissions.Pages_Activities_Create_Assign_Other_Users__Dynamic);

            return await _lookupUserRepository.GetAll()
                .WhereIf(!canAssignOthers, x => x.Id == currentUser.Id)
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
        public async Task<List<ActivityActivityTaskTypeLookupTableDto>> GetAllActivityTaskTypeForTableDropdown()
        {
            return await _lookupActivityTaskTypeRepository.GetAll()
                .OrderBy(x => x.Order)
                .Select(activityTaskType => new ActivityActivityTaskTypeLookupTableDto
                {
                    Id = activityTaskType.Id,
                    IsDefault = activityTaskType.IsDefault,
                    Code = activityTaskType.Code,
                    DisplayName = activityTaskType == null || activityTaskType.Description == null ? "" : activityTaskType.Description.ToString(),
                    Color = activityTaskType == null || activityTaskType.Color == null ? "" : activityTaskType.Color.ToString()
                }).ToListAsync();
        }

        /// <summary>
        /// Get all activity status for table dropdown
        /// </summary>
        /// <returns></returns>
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
        /// View details of an activity used for editing/updating based on the provided input which includes the id of the activity
        /// </summary>
        /// <param name="input">Input from http header query which includes the id of the activity</param>
        /// <returns></returns>
        public async Task<GetActivityForEditOutput> GetActivityForEdit(EntityDto<long> input)
        {
            var activity = await _activityRepository.FirstOrDefaultAsync(input.Id);

            if (activity is null)
                return null;

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
            output.SourceTypeCode = lookupActivitySourceType.Code;

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

    }
}
