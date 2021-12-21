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

/// <summary>
///     App service to handle Opportunities information
/// </summary>
[AbpAuthorize(AppPermissions.Pages_Opportunities)]
public class OpportunitiesAppService : SBCRMAppServiceBase, IOpportunitiesAppService
{
    private readonly IRepository<LeadSource, int> _lookup_leadSourceRepository;
    private readonly IRepository<OpportunityStage, int> _lookup_opportunityStageRepository;
    private readonly IRepository<OpportunityType, int> _lookup_opportunityTypeRepository;
    private readonly IOpportunitiesExcelExporter _opportunitiesExcelExporter;
    private readonly IRepository<Opportunity> _opportunityRepository;

    /// <summary>
    ///     Base constructor
    /// </summary>
    /// <param name="opportunityRepository"></param>
    /// <param name="opportunitiesExcelExporter"></param>
    /// <param name="lookup_opportunityStageRepository"></param>
    /// <param name="lookup_leadSourceRepository"></param>
    /// <param name="lookup_opportunityTypeRepository"></param>
    public OpportunitiesAppService(IRepository<Opportunity> opportunityRepository,
        IOpportunitiesExcelExporter opportunitiesExcelExporter,
        IRepository<OpportunityStage, int> lookup_opportunityStageRepository,
        IRepository<LeadSource, int> lookup_leadSourceRepository,
        IRepository<OpportunityType, int> lookup_opportunityTypeRepository)
    {
        _opportunityRepository = opportunityRepository;
        _opportunitiesExcelExporter = opportunitiesExcelExporter;
        _lookup_opportunityStageRepository = lookup_opportunityStageRepository;
        _lookup_leadSourceRepository = lookup_leadSourceRepository;
        _lookup_opportunityTypeRepository = lookup_opportunityTypeRepository;
    }

    /// <summary>
    ///     Create or edit opportunity
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task CreateOrEdit(CreateOrEditOpportunityDto input)
    {
        if (input.Id == null)
            await Create(input);
        else
            await Update(input);
    }

    /// <summary>
    ///  Delete Opportunities
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [AbpAuthorize(AppPermissions.Pages_Opportunities_Delete)]
    public async Task Delete(EntityDto input)
    {
        await _opportunityRepository.DeleteAsync(input.Id);
    }

    /// <summary>
    ///     Get all opportunities
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<PagedResultDto<GetOpportunityForViewDto>> GetAll(GetAllOpportunitiesInput input)
    {
        IQueryable<Opportunity> filteredOpportunities = _opportunityRepository.GetAll()
            .Include(e => e.OpportunityStageFk)
            .Include(e => e.LeadSourceFk)
            .Include(e => e.OpportunityTypeFk)
            .WhereIf(!string.IsNullOrWhiteSpace(input.Filter),
                e => false || e.Name.Contains(input.Filter) || e.Description.Contains(input.Filter) ||
                     e.Branch.Contains(input.Filter) || e.Department.Contains(input.Filter))
            .WhereIf(!string.IsNullOrWhiteSpace(input.NameFilter), e => e.Name.Contains(input.NameFilter))
            .WhereIf(input.MinAmountFilter != null, e => e.Amount >= input.MinAmountFilter)
            .WhereIf(input.MaxAmountFilter != null, e => e.Amount <= input.MaxAmountFilter)
            .WhereIf(input.MinProbabilityFilter != null, e => e.Probability >= input.MinProbabilityFilter)
            .WhereIf(input.MaxProbabilityFilter != null, e => e.Probability <= input.MaxProbabilityFilter)
            .WhereIf(input.MinCloseDateFilter != null, e => e.CloseDate >= input.MinCloseDateFilter)
            .WhereIf(input.MaxCloseDateFilter != null, e => e.CloseDate <= input.MaxCloseDateFilter)
            .WhereIf(!string.IsNullOrWhiteSpace(input.DescriptionFilter), e => e.Description == input.DescriptionFilter)
            .WhereIf(!string.IsNullOrWhiteSpace(input.BranchFilter), e => e.Branch == input.BranchFilter)
            .WhereIf(!string.IsNullOrWhiteSpace(input.DepartmentFilter), e => e.Department == input.DepartmentFilter)
            .WhereIf(!string.IsNullOrWhiteSpace(input.OpportunityStageDescriptionFilter),
                e => e.OpportunityStageFk != null &&
                     e.OpportunityStageFk.Description == input.OpportunityStageDescriptionFilter)
            .WhereIf(!string.IsNullOrWhiteSpace(input.LeadSourceDescriptionFilter),
                e => e.LeadSourceFk != null && e.LeadSourceFk.Description == input.LeadSourceDescriptionFilter)
            .WhereIf(!string.IsNullOrWhiteSpace(input.OpportunityTypeDescriptionFilter),
                e => e.OpportunityTypeFk != null &&
                     e.OpportunityTypeFk.Description == input.OpportunityTypeDescriptionFilter)
            .WhereIf(input.OpportunityStageId.Any(), x => input.OpportunityStageId.Contains(x.OpportunityStageFk.Id));

        IQueryable<Opportunity> pagedAndFilteredOpportunities;

        if (input.Sorting != null)
            pagedAndFilteredOpportunities = filteredOpportunities
                .OrderBy(input.Sorting)
                .PageBy(input);
        else
            pagedAndFilteredOpportunities = filteredOpportunities
                .OrderByDescending(o => o.CloseDate)
                .ThenBy(o => o.Name)
                .ThenBy(o => o.Branch)
                .ThenBy(o => o.Department)
                .PageBy(input);

        pagedAndFilteredOpportunities = filteredOpportunities
            .OrderBy(input.Sorting ?? "id asc")
            .PageBy(input);

        var opportunities = from o in pagedAndFilteredOpportunities
                            join o1 in _lookup_opportunityStageRepository.GetAll() on o.OpportunityStageId equals o1.Id into j1
                            from s1 in j1.DefaultIfEmpty()
                            join o2 in _lookup_leadSourceRepository.GetAll() on o.LeadSourceId equals o2.Id into j2
                            from s2 in j2.DefaultIfEmpty()
                            join o3 in _lookup_opportunityTypeRepository.GetAll() on o.OpportunityTypeId equals o3.Id into j3
                            from s3 in j3.DefaultIfEmpty()
                            select new
                            {
                                o.Name,
                                o.Amount,
                                o.Probability,
                                o.CloseDate,
                                o.Description,
                                o.Branch,
                                o.Department,
                                o.Id,
                                OpportunityStageDescription = s1 == null || s1.Description == null ? "" : s1.Description,
                                LeadSourceDescription = s2 == null || s2.Description == null ? "" : s2.Description,
                                OpportunityTypeDescription = s3 == null || s3.Description == null ? "" : s3.Description.ToString()
                            };

        int totalCount = await filteredOpportunities.CountAsync();

        var dbList = await opportunities.ToListAsync();
        List<GetOpportunityForViewDto> results = new List<GetOpportunityForViewDto>();

        foreach (var o in dbList)
        {
            GetOpportunityForViewDto res = new GetOpportunityForViewDto
            {
                Opportunity = new OpportunityDto
                {
                    Name = o.Name,
                    Amount = o.Amount,
                    Probability = o.Probability,
                    CloseDate = o.CloseDate,
                    Description = o.Description,
                    Branch = o.Branch,
                    Department = o.Department,
                    Id = o.Id
                },
                OpportunityStageDescription = o.OpportunityStageDescription,
                LeadSourceDescription = o.LeadSourceDescription,
                OpportunityTypeDescription = o.OpportunityTypeDescription
            };

            results.Add(res);
        }

        return new PagedResultDto<GetOpportunityForViewDto>(
            totalCount,
            results
        );
    }

    /// <summary>
    /// Get Lead source lookup
    /// </summary>
    /// <returns></returns>
    [AbpAuthorize(AppPermissions.Pages_Opportunities)]
    public async Task<List<OpportunityLeadSourceLookupTableDto>> GetAllLeadSourceForTableDropdown()
    {
        return await _lookup_leadSourceRepository.GetAll()
            .Select(leadSource => new OpportunityLeadSourceLookupTableDto
            {
                Id = leadSource.Id,
                DisplayName = leadSource == null || leadSource.Description == null
                    ? string.Empty
                    : leadSource.Description.ToString()
            }).ToListAsync();
    }

    /// <summary>
    ///  Get Opportunity Stage lookup
    /// </summary>
    /// <returns></returns>
    [AbpAuthorize(AppPermissions.Pages_Opportunities)]
    public async Task<List<OpportunityOpportunityStageLookupTableDto>> GetAllOpportunityStageForTableDropdown()
    {
        return await _lookup_opportunityStageRepository.GetAll()
            .Select(opportunityStage => new OpportunityOpportunityStageLookupTableDto
            {
                Id = opportunityStage.Id,
                DisplayName = opportunityStage == null || opportunityStage.Description == null
                    ? ""
                    : opportunityStage.Description.ToString()
            }).ToListAsync();
    }

    /// <summary>
    /// Get Opportunity type lookup
    /// </summary>
    /// <returns></returns>
    [AbpAuthorize(AppPermissions.Pages_Opportunities)]
    public async Task<List<OpportunityOpportunityTypeLookupTableDto>> GetAllOpportunityTypeForTableDropdown()
    {
        return await _lookup_opportunityTypeRepository.GetAll()
            .Select(opportunityType => new OpportunityOpportunityTypeLookupTableDto
            {
                Id = opportunityType.Id,
                DisplayName = opportunityType == null || opportunityType.Description == null
                    ? string.Empty
                    : opportunityType.Description.ToString()
            }).ToListAsync();
    }

    /// <summary>
    ///  Get Opportunities for excel export
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<FileDto> GetOpportunitiesToExcel(GetAllOpportunitiesForExcelInput input)
    {
        IQueryable<Opportunity> filteredOpportunities = _opportunityRepository.GetAll()
            .Include(e => e.OpportunityStageFk)
            .Include(e => e.LeadSourceFk)
            .Include(e => e.OpportunityTypeFk)
            .WhereIf(!string.IsNullOrWhiteSpace(input.Filter),
                e => false || e.Name.Contains(input.Filter) || e.Description.Contains(input.Filter) ||
                     e.Branch.Contains(input.Filter) || e.Department.Contains(input.Filter))
            .WhereIf(!string.IsNullOrWhiteSpace(input.NameFilter), e => e.Name.Contains(input.NameFilter))
            .WhereIf(input.MinAmountFilter != null, e => e.Amount >= input.MinAmountFilter)
            .WhereIf(input.MaxAmountFilter != null, e => e.Amount <= input.MaxAmountFilter)
            .WhereIf(input.MinProbabilityFilter != null, e => e.Probability >= input.MinProbabilityFilter)
            .WhereIf(input.MaxProbabilityFilter != null, e => e.Probability <= input.MaxProbabilityFilter)
            .WhereIf(input.MinCloseDateFilter != null, e => e.CloseDate >= input.MinCloseDateFilter)
            .WhereIf(input.MaxCloseDateFilter != null, e => e.CloseDate <= input.MaxCloseDateFilter)
            .WhereIf(!string.IsNullOrWhiteSpace(input.DescriptionFilter), e => e.Description == input.DescriptionFilter)
            .WhereIf(!string.IsNullOrWhiteSpace(input.BranchFilter), e => e.Branch == input.BranchFilter)
            .WhereIf(!string.IsNullOrWhiteSpace(input.DepartmentFilter), e => e.Department == input.DepartmentFilter)
            .WhereIf(!string.IsNullOrWhiteSpace(input.OpportunityStageDescriptionFilter),
                e => e.OpportunityStageFk != null &&
                     e.OpportunityStageFk.Description == input.OpportunityStageDescriptionFilter)
            .WhereIf(!string.IsNullOrWhiteSpace(input.LeadSourceDescriptionFilter),
                e => e.LeadSourceFk != null && e.LeadSourceFk.Description == input.LeadSourceDescriptionFilter)
            .WhereIf(!string.IsNullOrWhiteSpace(input.OpportunityTypeDescriptionFilter),
                e => e.OpportunityTypeFk != null &&
                     e.OpportunityTypeFk.Description == input.OpportunityTypeDescriptionFilter)
            .WhereIf(input.OpportunityStageId.Any(), x => input.OpportunityStageId.Contains(x.OpportunityStageFk.Id));

        IQueryable<GetOpportunityForViewDto> query = from o in filteredOpportunities
                                                     join o1 in _lookup_opportunityStageRepository.GetAll() on o.OpportunityStageId equals o1.Id into j1
                                                     from s1 in j1.DefaultIfEmpty()
                                                     join o2 in _lookup_leadSourceRepository.GetAll() on o.LeadSourceId equals o2.Id into j2
                                                     from s2 in j2.DefaultIfEmpty()
                                                     join o3 in _lookup_opportunityTypeRepository.GetAll() on o.OpportunityTypeId equals o3.Id into j3
                                                     from s3 in j3.DefaultIfEmpty()
                                                     select new GetOpportunityForViewDto
                                                     {
                                                         Opportunity = new OpportunityDto
                                                         {
                                                             Name = o.Name,
                                                             Amount = o.Amount,
                                                             Probability = o.Probability,
                                                             CloseDate = o.CloseDate,
                                                             Description = o.Description,
                                                             Branch = o.Branch,
                                                             Department = o.Department,
                                                             Id = o.Id
                                                         },
                                                         OpportunityStageDescription = s1 == null || s1.Description == null ? "" : s1.Description,
                                                         LeadSourceDescription = s2 == null || s2.Description == null ? "" : s2.Description,
                                                         OpportunityTypeDescription = s3 == null || s3.Description == null ? "" : s3.Description.ToString()
                                                     };

        List<GetOpportunityForViewDto> opportunityListDtos = await query.ToListAsync();

        return _opportunitiesExcelExporter.ExportToFile(opportunityListDtos);
    }

    /// <summary>
    ///     Get opportunity for edition mode
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [AbpAuthorize(AppPermissions.Pages_Opportunities_Edit)]
    public async Task<GetOpportunityForEditOutput> GetOpportunityForEdit(EntityDto input)
    {
        Opportunity opportunity = await _opportunityRepository.FirstOrDefaultAsync(input.Id);

        GetOpportunityForEditOutput output = new GetOpportunityForEditOutput
        { Opportunity = ObjectMapper.Map<CreateOrEditOpportunityDto>(opportunity) };

        if (output.Opportunity.OpportunityStageId != null)
        {
            OpportunityStage _lookupOpportunityStage =
                await _lookup_opportunityStageRepository.FirstOrDefaultAsync((int)output.Opportunity
                    .OpportunityStageId);
            output.OpportunityStageDescription = _lookupOpportunityStage?.Description;
        }

        if (output.Opportunity.LeadSourceId != null)
        {
            LeadSource _lookupLeadSource =
                await _lookup_leadSourceRepository.FirstOrDefaultAsync((int)output.Opportunity.LeadSourceId);
            output.LeadSourceDescription = _lookupLeadSource?.Description;
        }

        if (output.Opportunity.OpportunityTypeId != null)
        {
            OpportunityType _lookupOpportunityType =
                await _lookup_opportunityTypeRepository.FirstOrDefaultAsync((int)output.Opportunity.OpportunityTypeId);
            output.OpportunityTypeDescription = _lookupOpportunityType?.Description;
        }

        return output;
    }

    /// <summary>
    ///     Get opportunity for view mode by id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<GetOpportunityForViewDto> GetOpportunityForView(int id)
    {
        Opportunity opportunity = await _opportunityRepository.GetAsync(id);

        GetOpportunityForViewDto output = new GetOpportunityForViewDto { Opportunity = ObjectMapper.Map<OpportunityDto>(opportunity) };

        if (output.Opportunity.OpportunityStageId != null)
        {
            OpportunityStage _lookupOpportunityStage =
                await _lookup_opportunityStageRepository.FirstOrDefaultAsync((int)output.Opportunity
                    .OpportunityStageId);
            output.OpportunityStageDescription = _lookupOpportunityStage?.Description;
        }

        if (output.Opportunity.LeadSourceId != null)
        {
            LeadSource _lookupLeadSource =
                await _lookup_leadSourceRepository.FirstOrDefaultAsync((int)output.Opportunity.LeadSourceId);
            output.LeadSourceDescription = _lookupLeadSource?.Description;
        }

        if (output.Opportunity.OpportunityTypeId != null)
        {
            OpportunityType _lookupOpportunityType =
                await _lookup_opportunityTypeRepository.FirstOrDefaultAsync((int)output.Opportunity.OpportunityTypeId);
            output.OpportunityTypeDescription = _lookupOpportunityType?.Description;
        }

        return output;
    }

    /// <summary>
    /// Create opportunity
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [AbpAuthorize(AppPermissions.Pages_Opportunities_Create)]
    protected virtual async Task Create(CreateOrEditOpportunityDto input)
    {
        Opportunity opportunity = ObjectMapper.Map<Opportunity>(input);

        await _opportunityRepository.InsertAsync(opportunity);
    }

    /// <summary>
    /// Update opportunity
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [AbpAuthorize(AppPermissions.Pages_Opportunities_Edit)]
    protected virtual async Task Update(CreateOrEditOpportunityDto input)
    {
        Opportunity opportunity = await _opportunityRepository.FirstOrDefaultAsync((int)input.Id);
        ObjectMapper.Map(input, opportunity);
    }
}