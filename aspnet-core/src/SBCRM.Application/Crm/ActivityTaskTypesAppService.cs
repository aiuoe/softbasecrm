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
    /// App service for handling CRUD operations of Activity Types
    /// </summary>
    [AbpAuthorize(AppPermissions.Pages_ActivityTaskTypes)]
    public class ActivityTaskTypesAppService : SBCRMAppServiceBase, IActivityTaskTypesAppService
    {
        private readonly IRepository<ActivityTaskType> _activityTaskTypeRepository;

        public ActivityTaskTypesAppService(IRepository<ActivityTaskType> activityTaskTypeRepository)
        {
            _activityTaskTypeRepository = activityTaskTypeRepository;

        }

        /// <summary>
        /// Get all activity types
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<PagedResultDto<GetActivityTaskTypeForViewDto>> GetAll(GetAllActivityTaskTypesInput input)
        {

            var filteredActivityTaskTypes = _activityTaskTypeRepository.GetAll()
                        .WhereIf(!string.IsNullOrWhiteSpace(input.Filter), e => false || e.Description.Contains(input.Filter))
                        .WhereIf(!string.IsNullOrWhiteSpace(input.DescriptionFilter), e => e.Description == input.DescriptionFilter);

            var pagedAndFilteredActivityTaskTypes = filteredActivityTaskTypes
                .OrderBy(input.Sorting ?? "id asc")
                .PageBy(input);

            var activityTaskTypes = from o in pagedAndFilteredActivityTaskTypes
                                    select new
                                    {

                                        o.Description,
                                        o.Order,
                                        o.IsDefault,
                                        o.EnumValue,
                                        Id = o.Id
                                    };

            var totalCount = await filteredActivityTaskTypes.CountAsync();

            var dbList = await activityTaskTypes.ToListAsync();
            var results = new List<GetActivityTaskTypeForViewDto>();

            foreach (var o in dbList)
            {
                var res = new GetActivityTaskTypeForViewDto()
                {
                    ActivityTaskType = new ActivityTaskTypeDto
                    {

                        Description = o.Description,
                        Order = o.Order,
                        IsDefault = o.IsDefault,
                        EnumValue = o.EnumValue,
                        Id = o.Id,
                    }
                };

                results.Add(res);
            }

            return new PagedResultDto<GetActivityTaskTypeForViewDto>(
                totalCount,
                results
            );

        }

        /// <summary>
        /// Get activity type for viewing
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<GetActivityTaskTypeForViewDto> GetActivityTaskTypeForView(int id)
        {
            var activityTaskType = await _activityTaskTypeRepository.GetAsync(id);

            var output = new GetActivityTaskTypeForViewDto { ActivityTaskType = ObjectMapper.Map<ActivityTaskTypeDto>(activityTaskType) };

            return output;
        }

        /// <summary>
        /// Get activity type for editing
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [AbpAuthorize(AppPermissions.Pages_ActivityTaskTypes_Edit)]
        public async Task<GetActivityTaskTypeForEditOutput> GetActivityTaskTypeForEdit(EntityDto input)
        {
            var activityTaskType = await _activityTaskTypeRepository.FirstOrDefaultAsync(input.Id);

            var output = new GetActivityTaskTypeForEditOutput { ActivityTaskType = ObjectMapper.Map<CreateOrEditActivityTaskTypeDto>(activityTaskType) };

            return output;
        }

        /// <summary>
        /// Create or edit an activity type
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task CreateOrEdit(CreateOrEditActivityTaskTypeDto input)
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
        /// Creates an activity type
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [AbpAuthorize(AppPermissions.Pages_ActivityTaskTypes_Create)]
        protected virtual async Task Create(CreateOrEditActivityTaskTypeDto input)
        {
            var activityTaskType = ObjectMapper.Map<ActivityTaskType>(input);

            await _activityTaskTypeRepository.InsertAsync(activityTaskType);

        }

        /// <summary>
        /// Updates an activity type
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [AbpAuthorize(AppPermissions.Pages_ActivityTaskTypes_Edit)]
        protected virtual async Task Update(CreateOrEditActivityTaskTypeDto input)
        {
            var activityTaskType = await _activityTaskTypeRepository.FirstOrDefaultAsync((int)input.Id);
            ObjectMapper.Map(input, activityTaskType);

        }
        
        /// <summary>
        /// Deletes an activity type
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [AbpAuthorize(AppPermissions.Pages_ActivityTaskTypes_Delete)]
        public async Task Delete(EntityDto input)
        {
            await _activityTaskTypeRepository.DeleteAsync(input.Id);
        }

    }
}