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
    /// App Service for handling CRUD operations of Activity Source Types
    /// </summary>
    [AbpAuthorize(AppPermissions.Pages_ActivitySourceTypes)]
    public class ActivitySourceTypesAppService : SBCRMAppServiceBase, IActivitySourceTypesAppService
    {
        private readonly IRepository<ActivitySourceType> _activitySourceTypeRepository;

        /// <summary>
        /// Constructor method
        /// </summary>
        /// <param name="activitySourceTypeRepository"></param>
        public ActivitySourceTypesAppService(IRepository<ActivitySourceType> activitySourceTypeRepository)
        {
            _activitySourceTypeRepository = activitySourceTypeRepository;

        }

        /// <summary>
        /// Get all activity source types
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<PagedResultDto<GetActivitySourceTypeForViewDto>> GetAll(GetAllActivitySourceTypesInput input)
        {

            var filteredActivitySourceTypes = _activitySourceTypeRepository.GetAll()
                        .WhereIf(!string.IsNullOrWhiteSpace(input.Filter), e => false || e.Description.Contains(input.Filter) || e.Code.Contains(input.Filter))
                        .WhereIf(!string.IsNullOrWhiteSpace(input.DescriptionFilter), e => e.Description == input.DescriptionFilter);

            var pagedAndFilteredActivitySourceTypes = filteredActivitySourceTypes
                .OrderBy(input.Sorting ?? "id asc")
                .PageBy(input);

            var activitySourceTypes = from o in pagedAndFilteredActivitySourceTypes
                                      select new
                                      {

                                          o.Description,
                                          o.Order,
                                          o.Code,
                                          Id = o.Id
                                      };

            var totalCount = await filteredActivitySourceTypes.CountAsync();

            var dbList = await activitySourceTypes.ToListAsync();
            var results = new List<GetActivitySourceTypeForViewDto>();

            foreach (var o in dbList)
            {
                var res = new GetActivitySourceTypeForViewDto()
                {
                    ActivitySourceType = new ActivitySourceTypeDto
                    {

                        Description = o.Description,
                        Order = o.Order,
                        Code = o.Code,
                        Id = o.Id,
                    }
                };

                results.Add(res);
            }

            return new PagedResultDto<GetActivitySourceTypeForViewDto>(
                totalCount,
                results
            );

        }

        /// <summary>
        /// Get an activity source type for viewing
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<GetActivitySourceTypeForViewDto> GetActivitySourceTypeForView(int id)
        {
            var activitySourceType = await _activitySourceTypeRepository.GetAsync(id);

            var output = new GetActivitySourceTypeForViewDto { ActivitySourceType = ObjectMapper.Map<ActivitySourceTypeDto>(activitySourceType) };

            return output;
        }

        /// <summary>
        /// Get activity source type for editing
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [AbpAuthorize(AppPermissions.Pages_ActivitySourceTypes_Edit)]
        public async Task<GetActivitySourceTypeForEditOutput> GetActivitySourceTypeForEdit(EntityDto input)
        {
            var activitySourceType = await _activitySourceTypeRepository.FirstOrDefaultAsync(input.Id);

            var output = new GetActivitySourceTypeForEditOutput { ActivitySourceType = ObjectMapper.Map<CreateOrEditActivitySourceTypeDto>(activitySourceType) };

            return output;
        }
        
        /// <summary>
        /// Create or edit an activity source type
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task CreateOrEdit(CreateOrEditActivitySourceTypeDto input)
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
        /// Create an activity source type
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [AbpAuthorize(AppPermissions.Pages_ActivitySourceTypes_Create)]
        protected virtual async Task Create(CreateOrEditActivitySourceTypeDto input)
        {
            var activitySourceType = ObjectMapper.Map<ActivitySourceType>(input);

            await _activitySourceTypeRepository.InsertAsync(activitySourceType);

        }

        /// <summary>
        /// Update an activity source type
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [AbpAuthorize(AppPermissions.Pages_ActivitySourceTypes_Edit)]
        protected virtual async Task Update(CreateOrEditActivitySourceTypeDto input)
        {
            var activitySourceType = await _activitySourceTypeRepository.FirstOrDefaultAsync((int)input.Id);
            ObjectMapper.Map(input, activitySourceType);

        }

        /// <summary>
        /// Delete an activity source type
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [AbpAuthorize(AppPermissions.Pages_ActivitySourceTypes_Delete)]
        public async Task Delete(EntityDto input)
        {
            await _activitySourceTypeRepository.DeleteAsync(input.Id);
        }

    }
}