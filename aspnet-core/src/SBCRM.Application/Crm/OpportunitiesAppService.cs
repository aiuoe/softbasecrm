using SBCRM.Crm;
using SBCRM.Crm;
using SBCRM.Crm;

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
    [AbpAuthorize(AppPermissions.Pages_Opportunities)]
    public class OpportunitiesAppService : SBCRMAppServiceBase, IOpportunitiesAppService
    {
        private readonly IRepository<Opportunity> _opportunityRepository;
        private readonly IOpportunitiesExcelExporter _opportunitiesExcelExporter;
        private readonly IRepository<OpportunityStage, int> _lookup_opportunityStageRepository;
        private readonly IRepository<LeadSource, int> _lookup_leadSourceRepository;
        private readonly IRepository<OpportunityType, int> _lookup_opportunityTypeRepository;

        public OpportunitiesAppService(IRepository<Opportunity> opportunityRepository, IOpportunitiesExcelExporter opportunitiesExcelExporter, IRepository<OpportunityStage, int> lookup_opportunityStageRepository, IRepository<LeadSource, int> lookup_leadSourceRepository, IRepository<OpportunityType, int> lookup_opportunityTypeRepository)
        {
            _opportunityRepository = opportunityRepository;
            _opportunitiesExcelExporter = opportunitiesExcelExporter;
            _lookup_opportunityStageRepository = lookup_opportunityStageRepository;
            _lookup_leadSourceRepository = lookup_leadSourceRepository;
            _lookup_opportunityTypeRepository = lookup_opportunityTypeRepository;

        }

        public async Task<PagedResultDto<GetOpportunityForViewDto>> GetAll(GetAllOpportunitiesInput input)
        {

            var filteredOpportunities = _opportunityRepository.GetAll()
                        .Include(e => e.OpportunityStageFk)
                        .Include(e => e.LeadSourceFk)
                        .Include(e => e.OpportunityTypeFk)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.Filter), e => false || e.Name.Contains(input.Filter) || e.Description.Contains(input.Filter) || e.Branch.Contains(input.Filter) || e.Department.Contains(input.Filter))
                        .WhereIf(!string.IsNullOrWhiteSpace(input.NameFilter), e => e.Name == input.NameFilter)
                        .WhereIf(input.MinAmountFilter != null, e => e.Amount >= input.MinAmountFilter)
                        .WhereIf(input.MaxAmountFilter != null, e => e.Amount <= input.MaxAmountFilter)
                        .WhereIf(input.MinProbabilityFilter != null, e => e.Probability >= input.MinProbabilityFilter)
                        .WhereIf(input.MaxProbabilityFilter != null, e => e.Probability <= input.MaxProbabilityFilter)
                        .WhereIf(input.MinCloseDateFilter != null, e => e.CloseDate >= input.MinCloseDateFilter)
                        .WhereIf(input.MaxCloseDateFilter != null, e => e.CloseDate <= input.MaxCloseDateFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.DescriptionFilter), e => e.Description == input.DescriptionFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.BranchFilter), e => e.Branch == input.BranchFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.DepartmentFilter), e => e.Department == input.DepartmentFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.OpportunityStageDescriptionFilter), e => e.OpportunityStageFk != null && e.OpportunityStageFk.Description == input.OpportunityStageDescriptionFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.LeadSourceDescriptionFilter), e => e.LeadSourceFk != null && e.LeadSourceFk.Description == input.LeadSourceDescriptionFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.OpportunityTypeDescriptionFilter), e => e.OpportunityTypeFk != null && e.OpportunityTypeFk.Description == input.OpportunityTypeDescriptionFilter);

            var pagedAndFilteredOpportunities = filteredOpportunities
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
                                    Id = o.Id,
                                    OpportunityStageDescription = s1 == null || s1.Description == null ? "" : s1.Description.ToString(),
                                    LeadSourceDescription = s2 == null || s2.Description == null ? "" : s2.Description.ToString(),
                                    OpportunityTypeDescription = s3 == null || s3.Description == null ? "" : s3.Description.ToString()
                                };

            var totalCount = await filteredOpportunities.CountAsync();

            var dbList = await opportunities.ToListAsync();
            var results = new List<GetOpportunityForViewDto>();

            foreach (var o in dbList)
            {
                var res = new GetOpportunityForViewDto()
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
                        Id = o.Id,
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

        public async Task<GetOpportunityForViewDto> GetOpportunityForView(int id)
        {
            var opportunity = await _opportunityRepository.GetAsync(id);

            var output = new GetOpportunityForViewDto { Opportunity = ObjectMapper.Map<OpportunityDto>(opportunity) };

            if (output.Opportunity.OpportunityStageId != null)
            {
                var _lookupOpportunityStage = await _lookup_opportunityStageRepository.FirstOrDefaultAsync((int)output.Opportunity.OpportunityStageId);
                output.OpportunityStageDescription = _lookupOpportunityStage?.Description?.ToString();
            }

            if (output.Opportunity.LeadSourceId != null)
            {
                var _lookupLeadSource = await _lookup_leadSourceRepository.FirstOrDefaultAsync((int)output.Opportunity.LeadSourceId);
                output.LeadSourceDescription = _lookupLeadSource?.Description?.ToString();
            }

            if (output.Opportunity.OpportunityTypeId != null)
            {
                var _lookupOpportunityType = await _lookup_opportunityTypeRepository.FirstOrDefaultAsync((int)output.Opportunity.OpportunityTypeId);
                output.OpportunityTypeDescription = _lookupOpportunityType?.Description?.ToString();
            }

            return output;
        }

        [AbpAuthorize(AppPermissions.Pages_Opportunities_Edit)]
        public async Task<GetOpportunityForEditOutput> GetOpportunityForEdit(EntityDto input)
        {
            var opportunity = await _opportunityRepository.FirstOrDefaultAsync(input.Id);

            var output = new GetOpportunityForEditOutput { Opportunity = ObjectMapper.Map<CreateOrEditOpportunityDto>(opportunity) };

            if (output.Opportunity.OpportunityStageId != null)
            {
                var _lookupOpportunityStage = await _lookup_opportunityStageRepository.FirstOrDefaultAsync((int)output.Opportunity.OpportunityStageId);
                output.OpportunityStageDescription = _lookupOpportunityStage?.Description?.ToString();
            }

            if (output.Opportunity.LeadSourceId != null)
            {
                var _lookupLeadSource = await _lookup_leadSourceRepository.FirstOrDefaultAsync((int)output.Opportunity.LeadSourceId);
                output.LeadSourceDescription = _lookupLeadSource?.Description?.ToString();
            }

            if (output.Opportunity.OpportunityTypeId != null)
            {
                var _lookupOpportunityType = await _lookup_opportunityTypeRepository.FirstOrDefaultAsync((int)output.Opportunity.OpportunityTypeId);
                output.OpportunityTypeDescription = _lookupOpportunityType?.Description?.ToString();
            }

            return output;
        }

        public async Task CreateOrEdit(CreateOrEditOpportunityDto input)
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

        [AbpAuthorize(AppPermissions.Pages_Opportunities_Create)]
        protected virtual async Task Create(CreateOrEditOpportunityDto input)
        {
            var opportunity = ObjectMapper.Map<Opportunity>(input);

            await _opportunityRepository.InsertAsync(opportunity);

        }

        [AbpAuthorize(AppPermissions.Pages_Opportunities_Edit)]
        protected virtual async Task Update(CreateOrEditOpportunityDto input)
        {
            var opportunity = await _opportunityRepository.FirstOrDefaultAsync((int)input.Id);
            ObjectMapper.Map(input, opportunity);

        }

        [AbpAuthorize(AppPermissions.Pages_Opportunities_Delete)]
        public async Task Delete(EntityDto input)
        {
            await _opportunityRepository.DeleteAsync(input.Id);
        }

        public async Task<FileDto> GetOpportunitiesToExcel(GetAllOpportunitiesForExcelInput input)
        {

            var filteredOpportunities = _opportunityRepository.GetAll()
                        .Include(e => e.OpportunityStageFk)
                        .Include(e => e.LeadSourceFk)
                        .Include(e => e.OpportunityTypeFk)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.Filter), e => false || e.Name.Contains(input.Filter) || e.Description.Contains(input.Filter) || e.Branch.Contains(input.Filter) || e.Department.Contains(input.Filter))
                        .WhereIf(!string.IsNullOrWhiteSpace(input.NameFilter), e => e.Name == input.NameFilter)
                        .WhereIf(input.MinAmountFilter != null, e => e.Amount >= input.MinAmountFilter)
                        .WhereIf(input.MaxAmountFilter != null, e => e.Amount <= input.MaxAmountFilter)
                        .WhereIf(input.MinProbabilityFilter != null, e => e.Probability >= input.MinProbabilityFilter)
                        .WhereIf(input.MaxProbabilityFilter != null, e => e.Probability <= input.MaxProbabilityFilter)
                        .WhereIf(input.MinCloseDateFilter != null, e => e.CloseDate >= input.MinCloseDateFilter)
                        .WhereIf(input.MaxCloseDateFilter != null, e => e.CloseDate <= input.MaxCloseDateFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.DescriptionFilter), e => e.Description == input.DescriptionFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.BranchFilter), e => e.Branch == input.BranchFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.DepartmentFilter), e => e.Department == input.DepartmentFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.OpportunityStageDescriptionFilter), e => e.OpportunityStageFk != null && e.OpportunityStageFk.Description == input.OpportunityStageDescriptionFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.LeadSourceDescriptionFilter), e => e.LeadSourceFk != null && e.LeadSourceFk.Description == input.LeadSourceDescriptionFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.OpportunityTypeDescriptionFilter), e => e.OpportunityTypeFk != null && e.OpportunityTypeFk.Description == input.OpportunityTypeDescriptionFilter);

            var query = (from o in filteredOpportunities
                         join o1 in _lookup_opportunityStageRepository.GetAll() on o.OpportunityStageId equals o1.Id into j1
                         from s1 in j1.DefaultIfEmpty()

                         join o2 in _lookup_leadSourceRepository.GetAll() on o.LeadSourceId equals o2.Id into j2
                         from s2 in j2.DefaultIfEmpty()

                         join o3 in _lookup_opportunityTypeRepository.GetAll() on o.OpportunityTypeId equals o3.Id into j3
                         from s3 in j3.DefaultIfEmpty()

                         select new GetOpportunityForViewDto()
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
                             OpportunityStageDescription = s1 == null || s1.Description == null ? "" : s1.Description.ToString(),
                             LeadSourceDescription = s2 == null || s2.Description == null ? "" : s2.Description.ToString(),
                             OpportunityTypeDescription = s3 == null || s3.Description == null ? "" : s3.Description.ToString()
                         });

            var opportunityListDtos = await query.ToListAsync();

            return _opportunitiesExcelExporter.ExportToFile(opportunityListDtos);
        }

        [AbpAuthorize(AppPermissions.Pages_Opportunities)]
        public async Task<PagedResultDto<OpportunityOpportunityStageLookupTableDto>> GetAllOpportunityStageForLookupTable(GetAllForLookupTableInput input)
        {
            var query = _lookup_opportunityStageRepository.GetAll().WhereIf(
                   !string.IsNullOrWhiteSpace(input.Filter),
                  e => e.Description != null && e.Description.Contains(input.Filter)
               );

            var totalCount = await query.CountAsync();

            var opportunityStageList = await query
                .PageBy(input)
                .ToListAsync();

            var lookupTableDtoList = new List<OpportunityOpportunityStageLookupTableDto>();
            foreach (var opportunityStage in opportunityStageList)
            {
                lookupTableDtoList.Add(new OpportunityOpportunityStageLookupTableDto
                {
                    Id = opportunityStage.Id,
                    DisplayName = opportunityStage.Description?.ToString()
                });
            }

            return new PagedResultDto<OpportunityOpportunityStageLookupTableDto>(
                totalCount,
                lookupTableDtoList
            );
        }

        [AbpAuthorize(AppPermissions.Pages_Opportunities)]
        public async Task<PagedResultDto<OpportunityLeadSourceLookupTableDto>> GetAllLeadSourceForLookupTable(GetAllForLookupTableInput input)
        {
            var query = _lookup_leadSourceRepository.GetAll().WhereIf(
                   !string.IsNullOrWhiteSpace(input.Filter),
                  e => e.Description != null && e.Description.Contains(input.Filter)
               );

            var totalCount = await query.CountAsync();

            var leadSourceList = await query
                .PageBy(input)
                .ToListAsync();

            var lookupTableDtoList = new List<OpportunityLeadSourceLookupTableDto>();
            foreach (var leadSource in leadSourceList)
            {
                lookupTableDtoList.Add(new OpportunityLeadSourceLookupTableDto
                {
                    Id = leadSource.Id,
                    DisplayName = leadSource.Description?.ToString()
                });
            }

            return new PagedResultDto<OpportunityLeadSourceLookupTableDto>(
                totalCount,
                lookupTableDtoList
            );
        }

        [AbpAuthorize(AppPermissions.Pages_Opportunities)]
        public async Task<PagedResultDto<OpportunityOpportunityTypeLookupTableDto>> GetAllOpportunityTypeForLookupTable(GetAllForLookupTableInput input)
        {
            var query = _lookup_opportunityTypeRepository.GetAll().WhereIf(
                   !string.IsNullOrWhiteSpace(input.Filter),
                  e => e.Description != null && e.Description.Contains(input.Filter)
               );

            var totalCount = await query.CountAsync();

            var opportunityTypeList = await query
                .PageBy(input)
                .ToListAsync();

            var lookupTableDtoList = new List<OpportunityOpportunityTypeLookupTableDto>();
            foreach (var opportunityType in opportunityTypeList)
            {
                lookupTableDtoList.Add(new OpportunityOpportunityTypeLookupTableDto
                {
                    Id = opportunityType.Id,
                    DisplayName = opportunityType.Description?.ToString()
                });
            }

            return new PagedResultDto<OpportunityOpportunityTypeLookupTableDto>(
                totalCount,
                lookupTableDtoList
            );
        }

    }
}