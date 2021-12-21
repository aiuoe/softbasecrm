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

namespace SBCRM.Crm
{
    [AbpAuthorize(AppPermissions.Pages_ActivityPriorities)]
    public class ActivityPrioritiesAppService : SBCRMAppServiceBase, IActivityPrioritiesAppService
    {
        private readonly IRepository<ActivityPriority> _activityPriorityRepository;
        private readonly IActivityPrioritiesExcelExporter _activityPrioritiesExcelExporter;

        public ActivityPrioritiesAppService(IRepository<ActivityPriority> activityPriorityRepository, IActivityPrioritiesExcelExporter activityPrioritiesExcelExporter)
        {
            _activityPriorityRepository = activityPriorityRepository;
            _activityPrioritiesExcelExporter = activityPrioritiesExcelExporter;

        }

        public async Task<PagedResultDto<GetActivityPriorityForViewDto>> GetAll(GetAllActivityPrioritiesInput input)
        {

            var filteredActivityPriorities = _activityPriorityRepository.GetAll()
                        .WhereIf(!string.IsNullOrWhiteSpace(input.Filter), e => false || e.Description.Contains(input.Filter) || e.Color.Contains(input.Filter))
                        .WhereIf(!string.IsNullOrWhiteSpace(input.DescriptionFilter), e => e.Description == input.DescriptionFilter);

            var pagedAndFilteredActivityPriorities = filteredActivityPriorities
                .OrderBy(input.Sorting ?? "id asc")
                .PageBy(input);

            var activityPriorities = from o in pagedAndFilteredActivityPriorities
                                     select new
                                     {

                                         o.Description,
                                         o.Color,
                                         Id = o.Id
                                     };

            var totalCount = await filteredActivityPriorities.CountAsync();

            var dbList = await activityPriorities.ToListAsync();
            var results = new List<GetActivityPriorityForViewDto>();

            foreach (var o in dbList)
            {
                var res = new GetActivityPriorityForViewDto()
                {
                    ActivityPriority = new ActivityPriorityDto
                    {

                        Description = o.Description,
                        Color = o.Color,
                        Id = o.Id,
                    }
                };

                results.Add(res);
            }

            return new PagedResultDto<GetActivityPriorityForViewDto>(
                totalCount,
                results
            );

        }

        public async Task<GetActivityPriorityForViewDto> GetActivityPriorityForView(int id)
        {
            var activityPriority = await _activityPriorityRepository.GetAsync(id);

            var output = new GetActivityPriorityForViewDto { ActivityPriority = ObjectMapper.Map<ActivityPriorityDto>(activityPriority) };

            return output;
        }

        [AbpAuthorize(AppPermissions.Pages_ActivityPriorities_Edit)]
        public async Task<GetActivityPriorityForEditOutput> GetActivityPriorityForEdit(EntityDto input)
        {
            var activityPriority = await _activityPriorityRepository.FirstOrDefaultAsync(input.Id);

            var output = new GetActivityPriorityForEditOutput { ActivityPriority = ObjectMapper.Map<CreateOrEditActivityPriorityDto>(activityPriority) };

            return output;
        }

        public async Task CreateOrEdit(CreateOrEditActivityPriorityDto input)
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

        [AbpAuthorize(AppPermissions.Pages_ActivityPriorities_Create)]
        protected virtual async Task Create(CreateOrEditActivityPriorityDto input)
        {
            var activityPriority = ObjectMapper.Map<ActivityPriority>(input);

            await _activityPriorityRepository.InsertAsync(activityPriority);

        }

        [AbpAuthorize(AppPermissions.Pages_ActivityPriorities_Edit)]
        protected virtual async Task Update(CreateOrEditActivityPriorityDto input)
        {
            var activityPriority = await _activityPriorityRepository.FirstOrDefaultAsync((int)input.Id);
            ObjectMapper.Map(input, activityPriority);

        }

        [AbpAuthorize(AppPermissions.Pages_ActivityPriorities_Delete)]
        public async Task Delete(EntityDto input)
        {
            await _activityPriorityRepository.DeleteAsync(input.Id);
        }

        public async Task<FileDto> GetActivityPrioritiesToExcel(GetAllActivityPrioritiesForExcelInput input)
        {

            var filteredActivityPriorities = _activityPriorityRepository.GetAll()
                        .WhereIf(!string.IsNullOrWhiteSpace(input.Filter), e => false || e.Description.Contains(input.Filter) || e.Color.Contains(input.Filter))
                        .WhereIf(!string.IsNullOrWhiteSpace(input.DescriptionFilter), e => e.Description == input.DescriptionFilter);

            var query = (from o in filteredActivityPriorities
                         select new GetActivityPriorityForViewDto()
                         {
                             ActivityPriority = new ActivityPriorityDto
                             {
                                 Description = o.Description,
                                 Color = o.Color,
                                 Id = o.Id
                             }
                         });

            var activityPriorityListDtos = await query.ToListAsync();

            return _activityPrioritiesExcelExporter.ExportToFile(activityPriorityListDtos);
        }

    }
}