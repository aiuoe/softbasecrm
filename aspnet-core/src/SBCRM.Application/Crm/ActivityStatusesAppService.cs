using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using Microsoft.EntityFrameworkCore;
using SBCRM.Authorization;
using SBCRM.Crm.Dtos;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;

namespace SBCRM.Crm
{
    /// <summary>
    /// App Service for handling CRUD operations of Activity Statuses
    /// </summary>
    [AbpAuthorize(AppPermissions.Pages_ActivityStatuses)]
    public class ActivityStatusesAppService : SBCRMAppServiceBase, IActivityStatusesAppService
    {
        private readonly IRepository<ActivityStatus> _activityStatusRepository;

        /// <summary>
        /// Constructor method
        /// </summary>
        /// <param name="activityStatusRepository"></param>
        public ActivityStatusesAppService(IRepository<ActivityStatus> activityStatusRepository)
        {
            _activityStatusRepository = activityStatusRepository;
        }

        /// <summary>
        /// Get all activity statuses
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<PagedResultDto<GetActivityStatusForViewDto>> GetAll(GetAllActivityStatusesInput input)
        {
            IQueryable<ActivityStatus> filteredActivityStatuses = _activityStatusRepository.GetAll()
                        .WhereIf(!string.IsNullOrWhiteSpace(input.Filter), e => false || e.Description.Contains(input.Filter) || e.Color.Contains(input.Filter))
                        .WhereIf(!string.IsNullOrWhiteSpace(input.DescriptionFilter), e => e.Description == input.DescriptionFilter);

            IQueryable<ActivityStatus> pagedAndFilteredActivityStatuses = filteredActivityStatuses
                .OrderBy(input.Sorting ?? "id asc")
                .PageBy(input);

            var activityStatuses = from o in pagedAndFilteredActivityStatuses
                                   select new
                                   {
                                       o.Description,
                                       o.Order,
                                       o.Color,
                                       o.IsCompletedStatus,
                                       o.IsDefault,
                                       Id = o.Id
                                   };

            int totalCount = await filteredActivityStatuses.CountAsync();

            var dbList = await activityStatuses.OrderBy(x => x.Order).ToListAsync();
            List<GetActivityStatusForViewDto> results = new List<GetActivityStatusForViewDto>();

            foreach (var o in dbList)
            {
                GetActivityStatusForViewDto res = new GetActivityStatusForViewDto()
                {
                    ActivityStatus = new ActivityStatusDto
                    {
                        Description = o.Description,
                        Order = o.Order,
                        Color = o.Color,
                        IsCompletedStatus = o.IsCompletedStatus,
                        IsDefault = o.IsDefault,
                        Id = o.Id,
                    }
                };

                results.Add(res);
            }

            return new PagedResultDto<GetActivityStatusForViewDto>(
                totalCount,
                results
            );
        }

        /// <summary>
        /// Get the activity status for viewing
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<GetActivityStatusForViewDto> GetActivityStatusForView(int id)
        {
            ActivityStatus activityStatus = await _activityStatusRepository.GetAsync(id);

            GetActivityStatusForViewDto output = new GetActivityStatusForViewDto { ActivityStatus = ObjectMapper.Map<ActivityStatusDto>(activityStatus) };

            return output;
        }

        /// <summary>
        /// Get the activity status for editing
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [AbpAuthorize(AppPermissions.Pages_ActivityStatuses_Edit)]
        public async Task<GetActivityStatusForEditOutput> GetActivityStatusForEdit(EntityDto input)
        {
            ActivityStatus activityStatus = await _activityStatusRepository.FirstOrDefaultAsync(input.Id);

            GetActivityStatusForEditOutput output = new GetActivityStatusForEditOutput { ActivityStatus = ObjectMapper.Map<CreateOrEditActivityStatusDto>(activityStatus) };

            return output;
        }

        /// <summary>
        /// Create or edit an activity status
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task CreateOrEdit(CreateOrEditActivityStatusDto input)
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
        /// Create an activity status
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [AbpAuthorize(AppPermissions.Pages_ActivityStatuses_Create)]
        protected virtual async Task Create(CreateOrEditActivityStatusDto input)
        {
            int lastActivityStatusOrder = _activityStatusRepository.GetAll().Max(x => x.Order);
            input.Order = lastActivityStatusOrder + 1;

            ActivityStatus activityStatus = ObjectMapper.Map<ActivityStatus>(input);

            activityStatus.TenantId = GetTenantId();

            await _activityStatusRepository.InsertAsync(activityStatus);
        }

        /// <summary>
        /// Update an activity status
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [AbpAuthorize(AppPermissions.Pages_ActivityStatuses_Edit)]
        protected virtual async Task Update(CreateOrEditActivityStatusDto input)
        {
            ActivityStatus activityStatus = await _activityStatusRepository.FirstOrDefaultAsync((int)input.Id);
            ObjectMapper.Map(input, activityStatus);
        }

        /// <summary>
        /// Method that updates the order of a list
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [AbpAuthorize(AppPermissions.Pages_LeadStatuses_Edit)]
        public virtual async Task UpdateOrder(List<UpdateOrderActivityStatusDto> input)
        {
            int indexSrc = input[0].Order;
            int indexDst = input[1].Order;

            List<ActivityStatus> allActivityStatuses = _activityStatusRepository.GetAll().OrderBy(x => x.Order).ToList();

            int originalCount = allActivityStatuses.Count;

            ActivityStatus activityStatusSrc = allActivityStatuses[indexSrc];

            List<ActivityStatus> modifiedOrderList = new List<ActivityStatus>();

            allActivityStatuses.RemoveAt(indexSrc);

            int index = 0;
            foreach (ActivityStatus status in allActivityStatuses)
            {
                if (index != indexDst)
                    modifiedOrderList.Add(status);
                else
                {
                    modifiedOrderList.Add(activityStatusSrc);
                    modifiedOrderList.Add(status);
                }
                index++;
            }

            if (modifiedOrderList.Count != originalCount)
                modifiedOrderList.Add(activityStatusSrc);

            int order = 1;
            foreach (ActivityStatus status in modifiedOrderList)
            {
                status.Order = order;
                await _activityStatusRepository.InsertOrUpdateAsync(status);
                order++;
            }
        }

        /// <summary>
        /// Delete an activity status
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [AbpAuthorize(AppPermissions.Pages_ActivityStatuses_Delete)]
        public async Task Delete(EntityDto input)
        {
            await _activityStatusRepository.DeleteAsync(input.Id);
        }
    }
}