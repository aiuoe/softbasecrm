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
    /// Class app service for Opportunity Stages
    /// </summary>
    [AbpAuthorize(AppPermissions.Pages_OpportunityStages)]
    public class OpportunityStagesAppService : SBCRMAppServiceBase, IOpportunityStagesAppService
    {
        private readonly IRepository<OpportunityStage> _opportunityStageRepository;
        private readonly IOpportunityStagesExcelExporter _opportunityStagesExcelExporter;

        /// <summary>
        /// Class Constructor
        /// </summary>
        /// <param name="opportunityStageRepository"></param>
        /// <param name="opportunityStagesExcelExporter"></param>
        public OpportunityStagesAppService(IRepository<OpportunityStage> opportunityStageRepository, IOpportunityStagesExcelExporter opportunityStagesExcelExporter)
        {
            _opportunityStageRepository = opportunityStageRepository;
            _opportunityStagesExcelExporter = opportunityStagesExcelExporter;
        }

        /// <summary>
        /// Get all opportunity stages
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<PagedResultDto<GetOpportunityStageForViewDto>> GetAll(GetAllOpportunityStagesInput input)
        {
            IQueryable<OpportunityStage> filteredOpportunityStages = _opportunityStageRepository.GetAll()
                        .WhereIf(!string.IsNullOrWhiteSpace(input.Filter), e => false || e.Description.Contains(input.Filter) || e.Color.Contains(input.Filter))
                        .WhereIf(!string.IsNullOrWhiteSpace(input.DescriptionFilter), e => e.Description == input.DescriptionFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.ColorFilter), e => e.Color == input.ColorFilter);

            IQueryable<OpportunityStage> pagedAndFilteredOpportunityStages = filteredOpportunityStages
                .OrderBy(input.Sorting ?? "id asc")
                .PageBy(input);

            var opportunityStages = from o in pagedAndFilteredOpportunityStages
                                    select new
                                    {
                                        o.Description,
                                        o.Order,
                                        o.Color,
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
                        Color = o.Color,
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

        /// <summary>
        /// Get opportunity stage for view mode
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<GetOpportunityStageForViewDto> GetOpportunityStageForView(int id)
        {
            OpportunityStage opportunityStage = await _opportunityStageRepository.GetAsync(id);

            GetOpportunityStageForViewDto output = new GetOpportunityStageForViewDto { OpportunityStage = ObjectMapper.Map<OpportunityStageDto>(opportunityStage) };

            return output;
        }

        /// <summary>
        /// Get opportunity stage for edition mode
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [AbpAuthorize(AppPermissions.Pages_OpportunityStages_Edit)]
        public async Task<GetOpportunityStageForEditOutput> GetOpportunityStageForEdit(EntityDto input)
        {
            OpportunityStage opportunityStage = await _opportunityStageRepository.FirstOrDefaultAsync(input.Id);

            GetOpportunityStageForEditOutput output = new GetOpportunityStageForEditOutput { OpportunityStage = ObjectMapper.Map<CreateOrEditOpportunityStageDto>(opportunityStage) };

            return output;
        }

        /// <summary>
        /// Create or edit opportunity stage
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Method that Create an opportunity stage
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [AbpAuthorize(AppPermissions.Pages_OpportunityStages_Create)]
        protected virtual async Task Create(CreateOrEditOpportunityStageDto input)
        {
            input.Order = _opportunityStageRepository.GetAll().Count() + 1;

            OpportunityStage opportunityStage = ObjectMapper.Map<OpportunityStage>(input);

            opportunityStage.TenantId = GetTenantId();

            await _opportunityStageRepository.InsertAsync(opportunityStage);
        }

        /// <summary>
        /// Method that edit an opportunity stage
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [AbpAuthorize(AppPermissions.Pages_OpportunityStages_Edit)]
        protected virtual async Task Update(CreateOrEditOpportunityStageDto input)
        {
            OpportunityStage opportunityStage = await _opportunityStageRepository.FirstOrDefaultAsync((int)input.Id);
            ObjectMapper.Map(input, opportunityStage);
        }

        /// <summary>
        /// Method that updates the order of a list
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [AbpAuthorize(AppPermissions.Pages_OpportunityStages_Edit)]
        public virtual async Task UpdateOrder(List<UpdateOrderOpportunityStageDto> input)
        {
            int orderSrc = input[0].Order + 1;
            int orderDst = input[1].Order + 1;

            OpportunityStage opportunityStageSrc = await _opportunityStageRepository.FirstOrDefaultAsync(x => x.Order == orderSrc);
            opportunityStageSrc.Order = orderDst;

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

        /// <summary>
        /// Delete opportunity stage
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [AbpAuthorize(AppPermissions.Pages_OpportunityStages_Delete)]
        public async Task Delete(EntityDto input)
        {
            _opportunityStageRepository.Delete(input.Id);

            UpdateOrderAfterDelete();
        }

        /// <summary>
        /// Method that gets the rows to export to Excel
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<FileDto> GetOpportunityStagesToExcel(GetAllOpportunityStagesForExcelInput input)
        {
            IQueryable<OpportunityStage> filteredOpportunityStages = _opportunityStageRepository.GetAll()
                        .WhereIf(!string.IsNullOrWhiteSpace(input.Filter), e => false || e.Description.Contains(input.Filter) || e.Color.Contains(input.Filter))
                        .WhereIf(!string.IsNullOrWhiteSpace(input.DescriptionFilter), e => e.Description == input.DescriptionFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.ColorFilter), e => e.Color == input.ColorFilter);

            IQueryable<GetOpportunityStageForViewDto> query = (from o in filteredOpportunityStages
                                                               select new GetOpportunityStageForViewDto()
                                                               {
                                                                   OpportunityStage = new OpportunityStageDto
                                                                   {
                                                                       Description = o.Description,
                                                                       Order = o.Order,
                                                                       Color = o.Color,
                                                                       Id = o.Id
                                                                   }
                                                               });

            List<GetOpportunityStageForViewDto> opportunityStageListDtos = await query.ToListAsync();

            return _opportunityStagesExcelExporter.ExportToFile(opportunityStageListDtos);
        }

        /// <summary>
        /// Method that update order after delete an item from grid
        /// </summary>
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