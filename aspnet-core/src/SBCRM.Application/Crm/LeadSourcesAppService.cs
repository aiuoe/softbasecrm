using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using Microsoft.EntityFrameworkCore;
using SBCRM.Authorization;
using SBCRM.Crm.Dtos;
using SBCRM.Crm.Exporting;
using SBCRM.Dto;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;

namespace SBCRM.Crm
{
    /// <summary>
    /// Class app service for lead source
    /// </summary>
    [AbpAuthorize(AppPermissions.Pages_LeadSources)]
    public class LeadSourcesAppService : SBCRMAppServiceBase, ILeadSourcesAppService
    {
        private readonly IRepository<LeadSource> _leadSourceRepository;
        private readonly ILeadSourcesExcelExporter _leadSourcesExcelExporter;

        /// <summary>
        /// Class constructor
        /// </summary>
        /// <param name="leadSourceRepository"></param>
        /// <param name="leadSourcesExcelExporter"></param>
        public LeadSourcesAppService(IRepository<LeadSource> leadSourceRepository, ILeadSourcesExcelExporter leadSourcesExcelExporter)
        {
            _leadSourceRepository = leadSourceRepository;
            _leadSourcesExcelExporter = leadSourcesExcelExporter;
        }

        /// <summary>
        /// Get all lead sources
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<PagedResultDto<GetLeadSourceForViewDto>> GetAll(GetAllLeadSourcesInput input)
        {
            IQueryable<LeadSource> filteredLeadSources = _leadSourceRepository.GetAll()
                        .WhereIf(!string.IsNullOrWhiteSpace(input.Filter), e => false || e.Description.Contains(input.Filter))
                        .WhereIf(!string.IsNullOrWhiteSpace(input.DescriptionFilter), e => e.Description == input.DescriptionFilter);

            IQueryable<LeadSource> pagedAndFilteredLeadSources = filteredLeadSources
                .OrderBy(input.Sorting ?? "id asc")
                .PageBy(input);

            var leadSources = from o in pagedAndFilteredLeadSources
                              select new
                              {
                                  o.Description,
                                  o.Order,
                                  Id = o.Id
                              };

            int totalCount = await filteredLeadSources.CountAsync();

            var dbList = await leadSources.OrderBy(x => x.Order).ToListAsync();
            List<GetLeadSourceForViewDto> results = new List<GetLeadSourceForViewDto>();

            foreach (var o in dbList)
            {
                GetLeadSourceForViewDto res = new GetLeadSourceForViewDto()
                {
                    LeadSource = new LeadSourceDto
                    {
                        Description = o.Description,
                        Order = o.Order,
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
        /// Get lead source for view mode
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<GetLeadSourceForViewDto> GetLeadSourceForView(int id)
        {
            LeadSource leadSource = await _leadSourceRepository.GetAsync(id);

            GetLeadSourceForViewDto output = new GetLeadSourceForViewDto { LeadSource = ObjectMapper.Map<LeadSourceDto>(leadSource) };

            return output;
        }

        /// <summary>
        /// Get lead source for edition mode
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [AbpAuthorize(AppPermissions.Pages_LeadSources_Edit)]
        public async Task<GetLeadSourceForEditOutput> GetLeadSourceForEdit(EntityDto input)
        {
            LeadSource leadSource = await _leadSourceRepository.FirstOrDefaultAsync(input.Id);

            GetLeadSourceForEditOutput output = new GetLeadSourceForEditOutput { LeadSource = ObjectMapper.Map<CreateOrEditLeadSourceDto>(leadSource) };

            return output;
        }

        /// <summary>
        /// Create or edit a lead source
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
        /// Method that Create a lead source
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [AbpAuthorize(AppPermissions.Pages_LeadSources_Create)]
        protected virtual async Task Create(CreateOrEditLeadSourceDto input)
        {
            int lastLeadSourceOrder = _leadSourceRepository.GetAll().Max(x => x.Order);
            input.Order = lastLeadSourceOrder + 1;

            input.IsDefault = false;

            LeadSource leadSource = ObjectMapper.Map<LeadSource>(input);

            leadSource.TenantId = GetTenantId();

            await _leadSourceRepository.InsertAsync(leadSource);
        }

        /// <summary>
        /// Method that edit an opportunity stage
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [AbpAuthorize(AppPermissions.Pages_LeadSources_Edit)]
        protected virtual async Task Update(CreateOrEditLeadSourceDto input)
        {
            LeadSource leadSource = await _leadSourceRepository.FirstOrDefaultAsync((int)input.Id);
            ObjectMapper.Map(input, leadSource);
        }

        /// <summary>
        /// Method that updates the order of a list
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [AbpAuthorize(AppPermissions.Pages_LeadSources_Edit)]
        public virtual async Task UpdateOrder(List<UpdateOrderleadSourceDto> input)
        {
            int indexSrc = input[0].Order;
            int indexDst = input[1].Order;

            List<LeadSource> allLeadSources = _leadSourceRepository.GetAll().OrderBy(x => x.Order).ToList();

            int originalCount = allLeadSources.Count;

            LeadSource leadSourceSrc = allLeadSources[indexSrc];

            List<LeadSource> modifiedOrderList = new List<LeadSource>();

            allLeadSources.RemoveAt(indexSrc);

            int index = 0;
            foreach (LeadSource source in allLeadSources)
            {
                if (index != indexDst)
                    modifiedOrderList.Add(source);
                else
                {
                    modifiedOrderList.Add(leadSourceSrc);
                    modifiedOrderList.Add(source);
                }
                index++;
            }

            if (modifiedOrderList.Count != originalCount)
                modifiedOrderList.Add(leadSourceSrc);

            int order = 1;
            foreach (LeadSource source in modifiedOrderList)
            {
                source.Order = order;
                await _leadSourceRepository.InsertOrUpdateAsync(source);
                order++;

            }
        }

        /// <summary>
        /// Delete opportunity stage
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [AbpAuthorize(AppPermissions.Pages_LeadSources_Delete)]
        public async Task Delete(EntityDto input)
        {
            await _leadSourceRepository.DeleteAsync(input.Id);            
        }

        /// <summary>
        /// Method that gets the rows to export to Excel
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<FileDto> GetLeadSourcesToExcel(GetAllLeadSourcesForExcelInput input)
        {
            IQueryable<LeadSource> filteredLeadSources = _leadSourceRepository.GetAll()
                        .WhereIf(!string.IsNullOrWhiteSpace(input.Filter), e => false || e.Description.Contains(input.Filter))
                        .WhereIf(!string.IsNullOrWhiteSpace(input.DescriptionFilter), e => e.Description == input.DescriptionFilter);

            IQueryable<GetLeadSourceForViewDto> query = (from o in filteredLeadSources
                                                         select new GetLeadSourceForViewDto()
                                                         {
                                                             LeadSource = new LeadSourceDto
                                                             {
                                                                 Description = o.Description,
                                                                 Order = o.Order,
                                                                 Id = o.Id
                                                             }
                                                         });

            List<GetLeadSourceForViewDto> leadSourceListDtos = await query.ToListAsync();

            return _leadSourcesExcelExporter.ExportToFile(leadSourceListDtos);
        }
    }
}