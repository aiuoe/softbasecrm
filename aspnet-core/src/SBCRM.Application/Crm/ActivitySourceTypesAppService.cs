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
    [AbpAuthorize(AppPermissions.Pages_ActivitySourceTypes)]
    public class ActivitySourceTypesAppService : SBCRMAppServiceBase, IActivitySourceTypesAppService
    {
        private readonly IRepository<ActivitySourceType> _activitySourceTypeRepository;

        public ActivitySourceTypesAppService(IRepository<ActivitySourceType> activitySourceTypeRepository)
        {
            _activitySourceTypeRepository = activitySourceTypeRepository;

        }

        public async Task<PagedResultDto<GetActivitySourceTypeForViewDto>> GetAll(GetAllActivitySourceTypesInput input)
        {

            var filteredActivitySourceTypes = _activitySourceTypeRepository.GetAll()
                        .WhereIf(!string.IsNullOrWhiteSpace(input.Filter), e => false || e.Description.Contains(input.Filter))
                        .WhereIf(!string.IsNullOrWhiteSpace(input.DescriptionFilter), e => e.Description == input.DescriptionFilter);

            var pagedAndFilteredActivitySourceTypes = filteredActivitySourceTypes
                .OrderBy(input.Sorting ?? "id asc")
                .PageBy(input);

            var activitySourceTypes = from o in pagedAndFilteredActivitySourceTypes
                                      select new
                                      {

                                          o.Description,
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

        public async Task<GetActivitySourceTypeForViewDto> GetActivitySourceTypeForView(int id)
        {
            var activitySourceType = await _activitySourceTypeRepository.GetAsync(id);

            var output = new GetActivitySourceTypeForViewDto { ActivitySourceType = ObjectMapper.Map<ActivitySourceTypeDto>(activitySourceType) };

            return output;
        }

        [AbpAuthorize(AppPermissions.Pages_ActivitySourceTypes_Edit)]
        public async Task<GetActivitySourceTypeForEditOutput> GetActivitySourceTypeForEdit(EntityDto input)
        {
            var activitySourceType = await _activitySourceTypeRepository.FirstOrDefaultAsync(input.Id);

            var output = new GetActivitySourceTypeForEditOutput { ActivitySourceType = ObjectMapper.Map<CreateOrEditActivitySourceTypeDto>(activitySourceType) };

            return output;
        }

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

        [AbpAuthorize(AppPermissions.Pages_ActivitySourceTypes_Create)]
        protected virtual async Task Create(CreateOrEditActivitySourceTypeDto input)
        {
            var activitySourceType = ObjectMapper.Map<ActivitySourceType>(input);

            await _activitySourceTypeRepository.InsertAsync(activitySourceType);

        }

        [AbpAuthorize(AppPermissions.Pages_ActivitySourceTypes_Edit)]
        protected virtual async Task Update(CreateOrEditActivitySourceTypeDto input)
        {
            var activitySourceType = await _activitySourceTypeRepository.FirstOrDefaultAsync((int)input.Id);
            ObjectMapper.Map(input, activitySourceType);

        }

        [AbpAuthorize(AppPermissions.Pages_ActivitySourceTypes_Delete)]
        public async Task Delete(EntityDto input)
        {
            await _activitySourceTypeRepository.DeleteAsync(input.Id);
        }

    }
}