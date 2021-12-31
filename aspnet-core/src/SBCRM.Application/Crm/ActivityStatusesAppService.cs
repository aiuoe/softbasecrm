using System;
using System.Linq;
using System.Linq.Dynamic.Core;
using Abp.Linq.Extensions;
using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using SBCRM.Crm.Dtos;
using SBCRM.Dto;
using Abp.Application.Services.Dto;
using SBCRM.Authorization;
using Abp.Extensions;
using Abp.Authorization;
using Microsoft.EntityFrameworkCore;
using Abp.UI;
using SBCRM.Storage;

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

            var filteredActivityStatuses = _activityStatusRepository.GetAll()
                        .WhereIf(!string.IsNullOrWhiteSpace(input.Filter), e => false || e.Description.Contains(input.Filter) || e.Color.Contains(input.Filter))
                        .WhereIf(!string.IsNullOrWhiteSpace(input.DescriptionFilter), e => e.Description == input.DescriptionFilter);

            var pagedAndFilteredActivityStatuses = filteredActivityStatuses
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

            var totalCount = await filteredActivityStatuses.CountAsync();

            var dbList = await activityStatuses.ToListAsync();
            var results = new List<GetActivityStatusForViewDto>();

            foreach (var o in dbList)
            {
                var res = new GetActivityStatusForViewDto()
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
            var activityStatus = await _activityStatusRepository.GetAsync(id);

            var output = new GetActivityStatusForViewDto { ActivityStatus = ObjectMapper.Map<ActivityStatusDto>(activityStatus) };

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
            var activityStatus = await _activityStatusRepository.FirstOrDefaultAsync(input.Id);

            var output = new GetActivityStatusForEditOutput { ActivityStatus = ObjectMapper.Map<CreateOrEditActivityStatusDto>(activityStatus) };

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
            var activityStatus = ObjectMapper.Map<ActivityStatus>(input);

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
            var activityStatus = await _activityStatusRepository.FirstOrDefaultAsync((int)input.Id);
            ObjectMapper.Map(input, activityStatus);

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