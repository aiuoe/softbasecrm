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
    [AbpAuthorize(AppPermissions.Pages_OpportunityStages)]
    public class OpportunityStagesAppService : SBCRMAppServiceBase, IOpportunityStagesAppService
    {
        private readonly IRepository<OpportunityStage> _opportunityStageRepository;
        private readonly IOpportunityStagesExcelExporter _opportunityStagesExcelExporter;

        public OpportunityStagesAppService(IRepository<OpportunityStage> opportunityStageRepository, IOpportunityStagesExcelExporter opportunityStagesExcelExporter)
        {
            _opportunityStageRepository = opportunityStageRepository;
            _opportunityStagesExcelExporter = opportunityStagesExcelExporter;
        }

        public async Task<PagedResultDto<GetOpportunityStageForViewDto>> GetAll(GetAllOpportunityStagesInput input)
        {
            IQueryable<OpportunityStage> filteredOpportunityStages = _opportunityStageRepository.GetAll()
                        .WhereIf(!string.IsNullOrWhiteSpace(input.Filter), e => false || e.Description.Contains(input.Filter))
                        .WhereIf(!string.IsNullOrWhiteSpace(input.DescriptionFilter), e => e.Description == input.DescriptionFilter);

            IQueryable<OpportunityStage> pagedAndFilteredOpportunityStages = filteredOpportunityStages
                .OrderBy(input.Sorting ?? "id asc")
                .PageBy(input);

            var opportunityStages = from o in pagedAndFilteredOpportunityStages
                                    select new
                                    {
                                        o.Description,
                                        o.Order,
                                        Id = o.Id
                                    };

            int totalCount = await filteredOpportunityStages.CountAsync();

            var dbList = await opportunityStages.OrderBy(x => x.Order).ToListAsync();
            List<GetOpportunityStageForViewDto> results = new List<GetOpportunityStageForViewDto>();

            foreach (var o in dbList)
            {
                GetOpportunityStageForViewDto res = new GetOpportunityStageForViewDto()
                {
                    OpportunityStage = new OpportunityStageDto
                    {
                        Description = o.Description,
                        Order = o.Order,
                        Id = o.Id,
                    }
                };

                results.Add(res);
            }

            return new PagedResultDto<GetOpportunityStageForViewDto>(
                totalCount,
                results
            );
        }

        public async Task<GetOpportunityStageForViewDto> GetOpportunityStageForView(int id)
        {
            OpportunityStage opportunityStage = await _opportunityStageRepository.GetAsync(id);

            GetOpportunityStageForViewDto output = new GetOpportunityStageForViewDto { OpportunityStage = ObjectMapper.Map<OpportunityStageDto>(opportunityStage) };

            return output;
        }

        [AbpAuthorize(AppPermissions.Pages_OpportunityStages_Edit)]
        public async Task<GetOpportunityStageForEditOutput> GetOpportunityStageForEdit(EntityDto input)
        {
            OpportunityStage opportunityStage = await _opportunityStageRepository.FirstOrDefaultAsync(input.Id);

            GetOpportunityStageForEditOutput output = new GetOpportunityStageForEditOutput { OpportunityStage = ObjectMapper.Map<CreateOrEditOpportunityStageDto>(opportunityStage) };

            return output;
        }

        public async Task CreateOrEdit(CreateOrEditOpportunityStageDto input)
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

        [AbpAuthorize(AppPermissions.Pages_OpportunityStages_Create)]
        protected virtual async Task Create(CreateOrEditOpportunityStageDto input)
        {
            input.Order = _opportunityStageRepository.GetAll().Count() + 1;

            OpportunityStage opportunityStage = ObjectMapper.Map<OpportunityStage>(input);

            await _opportunityStageRepository.InsertAsync(opportunityStage);
        }

        [AbpAuthorize(AppPermissions.Pages_OpportunityStages_Edit)]
        protected virtual async Task Update(CreateOrEditOpportunityStageDto input)
        {
            OpportunityStage opportunityStage = await _opportunityStageRepository.FirstOrDefaultAsync((int)input.Id);
            ObjectMapper.Map(input, opportunityStage);
        }

        [AbpAuthorize(AppPermissions.Pages_OpportunityStages_Edit)]
        public virtual async Task UpdateOrder(List<UpdateOrderOpportunityStageDto> input)
        {
            int orderSrc = input[0].Order + 1;
            int orderDst = input[1].Order + 1;

            OpportunityStage opportunityStageSrc = await _opportunityStageRepository.FirstOrDefaultAsync(x => x.Order == orderSrc);
            opportunityStageSrc.Order = orderDst;
            await _opportunityStageRepository.FirstOrDefaultAsync(opportunityStageSrc.Id);

            List<OpportunityStage> allOpportunityStage = _opportunityStageRepository.GetAll().OrderBy(x => x.Order).ToList();
            allOpportunityStage.Remove(opportunityStageSrc);

            int i = orderDst + 1;
            foreach (OpportunityStage item in allOpportunityStage)
            {
                if (item.Order >= orderDst && item.Order <= orderSrc)
                {
                    item.Order = i;
                    await _opportunityStageRepository.FirstOrDefaultAsync(item.Id);
                    i++;
                }
            }
        }

        [AbpAuthorize(AppPermissions.Pages_OpportunityStages_Delete)]
        public async Task Delete(EntityDto input)
        {
            _opportunityStageRepository.Delete(input.Id);

            UpdateOrderAfterDelete();
        }

        public async Task<FileDto> GetOpportunityStagesToExcel(GetAllOpportunityStagesForExcelInput input)
        {
            IQueryable<OpportunityStage> filteredOpportunityStages = _opportunityStageRepository.GetAll()
                        .WhereIf(!string.IsNullOrWhiteSpace(input.Filter), e => false || e.Description.Contains(input.Filter))
                        .WhereIf(!string.IsNullOrWhiteSpace(input.DescriptionFilter), e => e.Description == input.DescriptionFilter);

            IQueryable<GetOpportunityStageForViewDto> query = from o in filteredOpportunityStages
                                                              select new GetOpportunityStageForViewDto()
                                                              {
                                                                  OpportunityStage = new OpportunityStageDto
                                                                  {
                                                                      Description = o.Description,
                                                                      Order = o.Order,
                                                                      Id = o.Id
                                                                  }
                                                              };

            List<GetOpportunityStageForViewDto> opportunityStageListDtos = await query.ToListAsync();

            return _opportunityStagesExcelExporter.ExportToFile(opportunityStageListDtos);
        }

        private void UpdateOrderAfterDelete()
        {
            List<OpportunityStage> ListOpportunityStage = _opportunityStageRepository.GetAll().ToList();

            int order = 1;
            foreach (OpportunityStage opportunityStage in ListOpportunityStage)
            {
                opportunityStage.Order = order;
                order++;
                _opportunityStageRepository.FirstOrDefault(opportunityStage.Id);
            }
        }
    }
}