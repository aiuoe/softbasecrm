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
    /// <summary>
    /// PrioritiesAppService
    /// </summary>
    [AbpAuthorize(AppPermissions.Pages_Priorities)]
    public class PrioritiesAppService : SBCRMAppServiceBase, IPrioritiesAppService
    {
        private readonly IRepository<Priority> _priorityRepository;
        private readonly IPrioritiesExcelExporter _prioritiesExcelExporter;

        /// <summary>
        /// PrioritiesAppService constructor
        /// </summary>
        /// <param name="priorityRepository"></param>
        /// <param name="prioritiesExcelExporter"></param>
        public PrioritiesAppService(
            IRepository<Priority> priorityRepository,
            IPrioritiesExcelExporter prioritiesExcelExporter)
        {
            _priorityRepository = priorityRepository;
            _prioritiesExcelExporter = prioritiesExcelExporter;

        }

        /// <summary>
        /// Gets all the priorities
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<PagedResultDto<GetPriorityForViewDto>> GetAll(GetAllPrioritiesInput input)
        {

            var filteredPriorities = _priorityRepository.GetAll()
                        .WhereIf(!string.IsNullOrWhiteSpace(input.Filter), e => false || e.Description.Contains(input.Filter))
                        .WhereIf(!string.IsNullOrWhiteSpace(input.Filter), e => false || e.Description.Contains(input.Filter) || e.Color.Contains(input.Filter))
                        .WhereIf(!string.IsNullOrWhiteSpace(input.DescriptionFilter), e => e.Description == input.DescriptionFilter)
                        .WhereIf(input.IsDefaultFilter.HasValue && input.IsDefaultFilter > -1, e => (input.IsDefaultFilter == 1 && e.IsDefault) || (input.IsDefaultFilter == 0 && !e.IsDefault));

            var pagedAndFilteredPriorities = filteredPriorities
                .OrderBy(input.Sorting ?? "id asc")
                .PageBy(input);

            var priorities = from o in pagedAndFilteredPriorities
                             select new
                             {

                                 o.Description,
                                 o.IsDefault,
                                 o.Color,
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
                        IsDefault = o.IsDefault,
                        Color = o.Color,
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

        /// <summary>
        /// Geta a priority for view by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<GetPriorityForViewDto> GetPriorityForView(int id)
        {
            var priority = await _priorityRepository.GetAsync(id);

            var output = new GetPriorityForViewDto { Priority = ObjectMapper.Map<PriorityDto>(priority) };

            return output;
        }

        /// <summary>
        /// Gets a priority to be edited
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [AbpAuthorize(AppPermissions.Pages_Priorities_Edit)]
        public async Task<GetPriorityForEditOutput> GetPriorityForEdit(EntityDto input)
        {
            var priority = await _priorityRepository.FirstOrDefaultAsync(input.Id);

            var output = new GetPriorityForEditOutput { Priority = ObjectMapper.Map<CreateOrEditPriorityDto>(priority) };

            return output;
        }

        /// <summary>
        /// Creates or edits a priority
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Creates a new priority
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [AbpAuthorize(AppPermissions.Pages_Priorities_Create)]
        protected virtual async Task Create(CreateOrEditPriorityDto input)
        {
            var priority = ObjectMapper.Map<Priority>(input);

            await _priorityRepository.InsertAsync(priority);

        }

        /// <summary>
        /// Updates a priority
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [AbpAuthorize(AppPermissions.Pages_Priorities_Edit)]
        protected virtual async Task Update(CreateOrEditPriorityDto input)
        {
            var priority = await _priorityRepository.FirstOrDefaultAsync((int)input.Id);
            ObjectMapper.Map(input, priority);

        }

        /// <summary>
        /// Deletes a priority
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [AbpAuthorize(AppPermissions.Pages_Priorities_Delete)]
        public async Task Delete(EntityDto input)
        {
            await _priorityRepository.DeleteAsync(input.Id);
        }

        /// <summary>
        /// Gets an excel file with a list of priorities
        /// </summary>
        /// <param name="input"></param>
        /// <returns><see cref="FileDto"/></returns>
        public async Task<FileDto> GetPrioritiesToExcel(GetAllPrioritiesForExcelInput input)
        {

            var filteredPriorities = _priorityRepository.GetAll()
                        .WhereIf(!string.IsNullOrWhiteSpace(input.Filter), e => false || e.Description.Contains(input.Filter))
                        .WhereIf(!string.IsNullOrWhiteSpace(input.Filter), e => false || e.Description.Contains(input.Filter) || e.Color.Contains(input.Filter))
                        .WhereIf(!string.IsNullOrWhiteSpace(input.DescriptionFilter), e => e.Description == input.DescriptionFilter)
                        .WhereIf(input.IsDefaultFilter.HasValue && input.IsDefaultFilter > -1, e => (input.IsDefaultFilter == 1 && e.IsDefault) || (input.IsDefaultFilter == 0 && !e.IsDefault));

            var query = (from o in filteredPriorities
                         select new GetPriorityForViewDto()
                         {
                             Priority = new PriorityDto
                             {
                                 Description = o.Description,
                                 IsDefault = o.IsDefault,
                                 Color = o.Color,
                                 Id = o.Id
                             }
                         });

            var priorityListDtos = await query.ToListAsync();

            return _prioritiesExcelExporter.ExportToFile(priorityListDtos);
        }

    }
}