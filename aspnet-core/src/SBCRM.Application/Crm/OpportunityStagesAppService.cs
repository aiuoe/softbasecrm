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

namespace SBCRM.Crm;

[AbpAuthorize(AppPermissions.Pages_OpportunityStages)]
public class OpportunityStagesAppService : SBCRMAppServiceBase, IOpportunityStagesAppService
{
    private readonly IRepository<OpportunityStage> _opportunityStageRepository;
    private readonly IOpportunityStagesExcelExporter _opportunityStagesExcelExporter;

    /// <summary>
    /// Class constructor
    /// </summary>
    /// <param name="opportunityStageRepository"></param>
    /// <param name="opportunityStagesExcelExporter"></param>
    public OpportunityStagesAppService(IRepository<OpportunityStage> opportunityStageRepository,
        IOpportunityStagesExcelExporter opportunityStagesExcelExporter)
    {
        _opportunityStageRepository = opportunityStageRepository;
        _opportunityStagesExcelExporter = opportunityStagesExcelExporter;
    }

    /// <summary>
    /// Method that create or edit tOpportunityStage
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
    /// Method that delete tOpportunityStage
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [AbpAuthorize(AppPermissions.Pages_OpportunityStages_Delete)]
    public async Task Delete(EntityDto input)
    {
        await _opportunityStageRepository.DeleteAsync(input.Id);
    }

    /// <summary>
    /// Method that get a list Opportunity Stage
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<PagedResultDto<GetOpportunityStageForViewDto>> GetAll(GetAllOpportunityStagesInput input)
    {
        var filteredOpportunityStages = _opportunityStageRepository.GetAll()
            .WhereIf(!string.IsNullOrWhiteSpace(input.Filter), e => false || e.Description.Contains(input.Filter))
            .WhereIf(!string.IsNullOrWhiteSpace(input.DescriptionFilter),
                e => e.Description == input.DescriptionFilter);

        var pagedAndFilteredOpportunityStages = filteredOpportunityStages
            .OrderBy(input.Sorting ?? "id asc")
            .PageBy(input);

        var opportunityStages = from o in pagedAndFilteredOpportunityStages
                                select new
                                {
                                    o.Description,
                                    o.Id
                                };

        var totalCount = await filteredOpportunityStages.CountAsync();

        var dbList = await opportunityStages.ToListAsync();
        var results = new List<GetOpportunityStageForViewDto>();

        foreach (var o in dbList)
        {
            var res = new GetOpportunityStageForViewDto
            {
                OpportunityStage = new OpportunityStageDto
                {
                    Description = o.Description,
                    Id = o.Id
                }
            };

            results.Add(res);
        }

        return new PagedResultDto<GetOpportunityStageForViewDto>(
            totalCount,
            results
        );
    }

    [AbpAuthorize(AppPermissions.Pages_OpportunityStages_Edit)]
    public async Task<GetOpportunityStageForEditOutput> GetOpportunityStageForEdit(EntityDto input)
    {
        var opportunityStage = await _opportunityStageRepository.FirstOrDefaultAsync(input.Id);

        var output = new GetOpportunityStageForEditOutput
        { OpportunityStage = ObjectMapper.Map<CreateOrEditOpportunityStageDto>(opportunityStage) };

        return output;
    }

    public async Task<GetOpportunityStageForViewDto> GetOpportunityStageForView(int id)
    {
        var opportunityStage = await _opportunityStageRepository.GetAsync(id);

        var output = new GetOpportunityStageForViewDto
        { OpportunityStage = ObjectMapper.Map<OpportunityStageDto>(opportunityStage) };

        return output;
    }

    public async Task<FileDto> GetOpportunityStagesToExcel(GetAllOpportunityStagesForExcelInput input)
    {
        var filteredOpportunityStages = _opportunityStageRepository.GetAll()
            .WhereIf(!string.IsNullOrWhiteSpace(input.Filter), e => false || e.Description.Contains(input.Filter))
            .WhereIf(!string.IsNullOrWhiteSpace(input.DescriptionFilter),
                e => e.Description == input.DescriptionFilter);

        var query = from o in filteredOpportunityStages
                    select new GetOpportunityStageForViewDto
                    {
                        OpportunityStage = new OpportunityStageDto
                        {
                            Description = o.Description,
                            Id = o.Id
                        }
                    };

        var opportunityStageListDtos = await query.ToListAsync();

        return _opportunityStagesExcelExporter.ExportToFile(opportunityStageListDtos);
    }

    [AbpAuthorize(AppPermissions.Pages_OpportunityStages_Create)]
    protected virtual async Task Create(CreateOrEditOpportunityStageDto input)
    {
        var opportunityStage = ObjectMapper.Map<OpportunityStage>(input);

        await _opportunityStageRepository.InsertAsync(opportunityStage);
    }

    [AbpAuthorize(AppPermissions.Pages_OpportunityStages_Edit)]
    protected virtual async Task Update(CreateOrEditOpportunityStageDto input)
    {
        var opportunityStage = await _opportunityStageRepository.FirstOrDefaultAsync((int)input.Id);
        ObjectMapper.Map(input, opportunityStage);
    }
}