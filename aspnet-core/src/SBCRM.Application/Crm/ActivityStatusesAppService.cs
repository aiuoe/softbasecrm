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
            input.Order = _activityStatusRepository.GetAll().Count() + 1;

            ActivityStatus activityStatus = ObjectMapper.Map<ActivityStatus>(input);

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
            int orderSrc = input[0].Order + 1;
            int orderDst = input[1].Order + 1;

            ActivityStatus activityStatusSrc = await _activityStatusRepository.FirstOrDefaultAsync(x => x.Order == orderSrc);
            activityStatusSrc.Order = orderDst;

            List<ActivityStatus> allActivityStatus = _activityStatusRepository.GetAll().OrderBy(x => x.Order).ToList();
            allActivityStatus.Remove(activityStatusSrc);

            int i = orderDst + 1;
            foreach (ActivityStatus item in allActivityStatus)
            {
                if (item.Order >= orderDst && item.Order <= orderSrc)
                {
                    item.Order = i;
                    await _activityStatusRepository.FirstOrDefaultAsync(item.Id);
                    i++;
                }
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
            _activityStatusRepository.Delete(input.Id);

            UpdateOrderAfterDelete();
        }

        /// <summary>
        /// Method that update order after delete an item from grid
        /// </summary>
        private void UpdateOrderAfterDelete()
        {
            List<ActivityStatus> listActivityStatus = _activityStatusRepository.GetAll().ToList();

            int order = 1;
            foreach (ActivityStatus activityStatus in listActivityStatus)
            {
                activityStatus.Order = order;
                order++;
                _activityStatusRepository.FirstOrDefault(activityStatus.Id);
            }
        }
    }
}