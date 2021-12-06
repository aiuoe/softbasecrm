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
    [AbpAuthorize(AppPermissions.Pages_Priorities)]
    public class PrioritiesAppService : SBCRMAppServiceBase, IPrioritiesAppService
    {
        private readonly IRepository<Priority> _priorityRepository;
        private readonly IPrioritiesExcelExporter _prioritiesExcelExporter;

        public PrioritiesAppService(IRepository<Priority> priorityRepository, IPrioritiesExcelExporter prioritiesExcelExporter)
        {
            _priorityRepository = priorityRepository;
            _prioritiesExcelExporter = prioritiesExcelExporter;

        }

        public async Task<PagedResultDto<GetPriorityForViewDto>> GetAll(GetAllPrioritiesInput input)
        {

            var filteredPriorities = _priorityRepository.GetAll()
                        .WhereIf(!string.IsNullOrWhiteSpace(input.Filter), e => false || e.Description.Contains(input.Filter))
                        .WhereIf(!string.IsNullOrWhiteSpace(input.DescriptionFilter), e => e.Description == input.DescriptionFilter);

            var pagedAndFilteredPriorities = filteredPriorities
                .OrderBy(input.Sorting ?? "id asc")
                .PageBy(input);

            var priorities = from o in pagedAndFilteredPriorities
                             select new
                             {

                                 o.Description,
                                 Id = o.Id
                             };

            var totalCount = await filteredPriorities.CountAsync();

            var dbList = await priorities.ToListAsync();
            var results = new List<GetPriorityForViewDto>();

            foreach (var o in dbList)
            {
                var res = new GetPriorityForViewDto()
                {
                    Priority = new PriorityDto
                    {

                        Description = o.Description,
                        Id = o.Id,
                    }
                };

                results.Add(res);
            }

            return new PagedResultDto<GetPriorityForViewDto>(
                totalCount,
                results
            );

        }

        public async Task<GetPriorityForViewDto> GetPriorityForView(int id)
        {
            var priority = await _priorityRepository.GetAsync(id);

            var output = new GetPriorityForViewDto { Priority = ObjectMapper.Map<PriorityDto>(priority) };

            return output;
        }

        [AbpAuthorize(AppPermissions.Pages_Priorities_Edit)]
        public async Task<GetPriorityForEditOutput> GetPriorityForEdit(EntityDto input)
        {
            var priority = await _priorityRepository.FirstOrDefaultAsync(input.Id);

            var output = new GetPriorityForEditOutput { Priority = ObjectMapper.Map<CreateOrEditPriorityDto>(priority) };

            return output;
        }

        public async Task CreateOrEdit(CreateOrEditPriorityDto input)
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

        [AbpAuthorize(AppPermissions.Pages_Priorities_Create)]
        protected virtual async Task Create(CreateOrEditPriorityDto input)
        {
            var priority = ObjectMapper.Map<Priority>(input);

            await _priorityRepository.InsertAsync(priority);

        }

        [AbpAuthorize(AppPermissions.Pages_Priorities_Edit)]
        protected virtual async Task Update(CreateOrEditPriorityDto input)
        {
            var priority = await _priorityRepository.FirstOrDefaultAsync((int)input.Id);
            ObjectMapper.Map(input, priority);

        }

        [AbpAuthorize(AppPermissions.Pages_Priorities_Delete)]
        public async Task Delete(EntityDto input)
        {
            await _priorityRepository.DeleteAsync(input.Id);
        }

        public async Task<FileDto> GetPrioritiesToExcel(GetAllPrioritiesForExcelInput input)
        {

            var filteredPriorities = _priorityRepository.GetAll()
                        .WhereIf(!string.IsNullOrWhiteSpace(input.Filter), e => false || e.Description.Contains(input.Filter))
                        .WhereIf(!string.IsNullOrWhiteSpace(input.DescriptionFilter), e => e.Description == input.DescriptionFilter);

            var query = (from o in filteredPriorities
                         select new GetPriorityForViewDto()
                         {
                             Priority = new PriorityDto
                             {
                                 Description = o.Description,
                                 Id = o.Id
                             }
                         });

            var priorityListDtos = await query.ToListAsync();

            return _prioritiesExcelExporter.ExportToFile(priorityListDtos);
        }

    }
}