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

        public async Task<GetLeadSourceForViewDto> GetLeadSourceForView(int id)
        {
            LeadSource leadSource = await _leadSourceRepository.GetAsync(id);

            GetLeadSourceForViewDto output = new GetLeadSourceForViewDto { LeadSource = ObjectMapper.Map<LeadSourceDto>(leadSource) };

            return output;
        }

        [AbpAuthorize(AppPermissions.Pages_LeadSources_Edit)]
        public async Task<GetLeadSourceForEditOutput> GetLeadSourceForEdit(EntityDto input)
        {
            LeadSource leadSource = await _leadSourceRepository.FirstOrDefaultAsync(input.Id);

            GetLeadSourceForEditOutput output = new GetLeadSourceForEditOutput { LeadSource = ObjectMapper.Map<CreateOrEditLeadSourceDto>(leadSource) };

            return output;
        }

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

        [AbpAuthorize(AppPermissions.Pages_LeadSources_Create)]
        protected virtual async Task Create(CreateOrEditLeadSourceDto input)
        {
            input.Order = _leadSourceRepository.GetAll().Count() + 1;

            LeadSource leadSource = ObjectMapper.Map<LeadSource>(input);

            await _leadSourceRepository.InsertAsync(leadSource);
        }

        [AbpAuthorize(AppPermissions.Pages_LeadSources_Edit)]
        protected virtual async Task Update(CreateOrEditLeadSourceDto input)
        {
            LeadSource leadSource = await _leadSourceRepository.FirstOrDefaultAsync((int)input.Id);
            ObjectMapper.Map(input, leadSource);
        }

        [AbpAuthorize(AppPermissions.Pages_LeadSources_Edit)]
        public virtual async Task UpdateOrder(List<UpdateOrderleadSourceDto> input)
        {
            int orderSrc = input[0].Order + 1;
            int orderDst = input[1].Order + 1;

            var leadSourceSrc = await _leadSourceRepository.FirstOrDefaultAsync(x => x.Order == orderSrc);
            leadSourceSrc.Order = orderDst;
            await _leadSourceRepository.FirstOrDefaultAsync(leadSourceSrc.Id);

            List<LeadSource> allLeadSource = _leadSourceRepository.GetAll().OrderBy(x => x.Order).ToList();
            allLeadSource.Remove(leadSourceSrc);

            int i = orderDst + 1;
            foreach (LeadSource item in allLeadSource)
            {
                if (item.Order >= orderDst && item.Order <= orderSrc)
                {
                    item.Order = i;
                    await _leadSourceRepository.FirstOrDefaultAsync(item.Id);
                    i++;
                }
            }
        }

        [AbpAuthorize(AppPermissions.Pages_LeadSources_Delete)]
        public async Task Delete(EntityDto input)
        {
            await _leadSourceRepository.DeleteAsync(input.Id);

            UpdateOrderAfterDelete();
        }

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

        private void UpdateOrderAfterDelete()
        {
            List<LeadSource> listLeadSource = _leadSourceRepository.GetAll().ToList();

            int order = 1;
            foreach (LeadSource leadSource in listLeadSource)
            {
                leadSource.Order = order;
                order++;
                _leadSourceRepository.FirstOrDefault(leadSource.Id);
            }
        }
    }
}