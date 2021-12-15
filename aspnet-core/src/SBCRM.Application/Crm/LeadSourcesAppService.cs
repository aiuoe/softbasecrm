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
    /// LeadSourcesAppService
    /// </summary>
    [AbpAuthorize(AppPermissions.Pages_LeadSources)]
    public class LeadSourcesAppService : SBCRMAppServiceBase, ILeadSourcesAppService
    {
        private readonly IRepository<LeadSource> _leadSourceRepository;
        private readonly ILeadSourcesExcelExporter _leadSourcesExcelExporter;
        /// <summary>
        /// LeadSourcesAppService constructor
        /// </summary>
        /// <param name="leadSourceRepository"></param>
        /// <param name="leadSourcesExcelExporter"></param>
        public LeadSourcesAppService(
            IRepository<LeadSource> leadSourceRepository,
            ILeadSourcesExcelExporter leadSourcesExcelExporter)
        {
            _leadSourceRepository = leadSourceRepository;
            _leadSourcesExcelExporter = leadSourcesExcelExporter;

        }

        /// <summary>
        /// Gets all the lead sources
        /// </summary>
        /// <param name="input"><see cref="GetAllLeadSourcesInput"/></param>
        /// <returns></returns>
        public async Task<PagedResultDto<GetLeadSourceForViewDto>> GetAll(GetAllLeadSourcesInput input)
        {

            var filteredLeadSources = _leadSourceRepository.GetAll()
                        .WhereIf(!string.IsNullOrWhiteSpace(input.Filter), e => false || e.Description.Contains(input.Filter))
                        .WhereIf(!string.IsNullOrWhiteSpace(input.DescriptionFilter), e => e.Description == input.DescriptionFilter)
                        .WhereIf(input.IsDefaultFilter.HasValue && input.IsDefaultFilter > -1, e => (input.IsDefaultFilter == 1 && e.IsDefault) || (input.IsDefaultFilter == 0 && !e.IsDefault));

            var pagedAndFilteredLeadSources = filteredLeadSources
                .OrderBy(input.Sorting ?? "id asc")
                .PageBy(input);

            var leadSources = from o in pagedAndFilteredLeadSources
                              select new
                              {

                                  o.Description,
                                  o.Order,
                                  o.IsDefault,
                                  Id = o.Id
                              };

            var totalCount = await filteredLeadSources.CountAsync();

            var dbList = await leadSources.ToListAsync();
            var results = new List<GetLeadSourceForViewDto>();

            foreach (var o in dbList)
            {
                var res = new GetLeadSourceForViewDto()
                {
                    LeadSource = new LeadSourceDto
                    {

                        Description = o.Description,
                        Order = o.Order,
                        IsDefault = o.IsDefault,
                        Id = o.Id,
                    }
                };

                results.Add(res);
            }

            return new PagedResultDto<GetLeadSourceForViewDto>(
                totalCount,
                results
            );

        }

        /// <summary>
        /// Gets leads for source view by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<GetLeadSourceForViewDto> GetLeadSourceForView(int id)
        {
            var leadSource = await _leadSourceRepository.GetAsync(id);

            var output = new GetLeadSourceForViewDto { LeadSource = ObjectMapper.Map<LeadSourceDto>(leadSource) };

            return output;
        }

        /// <summary>
        /// Gets a lead soruce object to be edited
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [AbpAuthorize(AppPermissions.Pages_LeadSources_Edit)]
        public async Task<GetLeadSourceForEditOutput> GetLeadSourceForEdit(EntityDto input)
        {
            var leadSource = await _leadSourceRepository.FirstOrDefaultAsync(input.Id);

            var output = new GetLeadSourceForEditOutput { LeadSource = ObjectMapper.Map<CreateOrEditLeadSourceDto>(leadSource) };

            return output;
        }

        /// <summary>
        /// Creates or edits a lead source
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task CreateOrEdit(CreateOrEditLeadSourceDto input)
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
        /// Creates a new lead soruce
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [AbpAuthorize(AppPermissions.Pages_LeadSources_Create)]
        protected virtual async Task Create(CreateOrEditLeadSourceDto input)
        {
            var leadSource = ObjectMapper.Map<LeadSource>(input);

            await _leadSourceRepository.InsertAsync(leadSource);

        }

        /// <summary>
        /// Updates a lead source
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [AbpAuthorize(AppPermissions.Pages_LeadSources_Edit)]
        protected virtual async Task Update(CreateOrEditLeadSourceDto input)
        {
            var leadSource = await _leadSourceRepository.FirstOrDefaultAsync((int)input.Id);
            ObjectMapper.Map(input, leadSource);

        }

        /// <summary>
        /// Deletes a lead source
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [AbpAuthorize(AppPermissions.Pages_LeadSources_Delete)]
        public async Task Delete(EntityDto input)
        {
            await _leadSourceRepository.DeleteAsync(input.Id);
        }

        /// <summary>
        /// Gets an excel file with a list of lead sources
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<FileDto> GetLeadSourcesToExcel(GetAllLeadSourcesForExcelInput input)
        {

            var filteredLeadSources = _leadSourceRepository.GetAll()
                        .WhereIf(!string.IsNullOrWhiteSpace(input.Filter), e => false || e.Description.Contains(input.Filter))
                        .WhereIf(!string.IsNullOrWhiteSpace(input.DescriptionFilter), e => e.Description == input.DescriptionFilter)
                        .WhereIf(input.IsDefaultFilter.HasValue && input.IsDefaultFilter > -1, e => (input.IsDefaultFilter == 1 && e.IsDefault) || (input.IsDefaultFilter == 0 && !e.IsDefault));

            var query = (from o in filteredLeadSources
                         select new GetLeadSourceForViewDto()
                         {
                             LeadSource = new LeadSourceDto
                             {
                                 Description = o.Description,
                                 Order = o.Order,
                                 IsDefault = o.IsDefault,
                                 Id = o.Id
                             }
                         });

            var leadSourceListDtos = await query.ToListAsync();

            return _leadSourcesExcelExporter.ExportToFile(leadSourceListDtos);
        }

    }
}