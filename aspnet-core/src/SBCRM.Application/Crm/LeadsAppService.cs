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
    [AbpAuthorize(AppPermissions.Pages_Leads)]
    public class LeadsAppService : SBCRMAppServiceBase, ILeadsAppService
    {
        private readonly IRepository<Lead> _leadRepository;
        private readonly ILeadsExcelExporter _leadsExcelExporter;
        private readonly IRepository<Industry, int> _lookup_industryRepository;
        private readonly IRepository<LeadSource, int> _lookup_leadSourceRepository;
        private readonly IRepository<LeadStatus, int> _lookup_leadStatusRepository;

        public LeadsAppService(IRepository<Lead> leadRepository, ILeadsExcelExporter leadsExcelExporter, IRepository<Industry, int> lookup_industryRepository, IRepository<LeadSource, int> lookup_leadSourceRepository, IRepository<LeadStatus, int> lookup_leadStatusRepository)
        {
            _leadRepository = leadRepository;
            _leadsExcelExporter = leadsExcelExporter;
            _lookup_industryRepository = lookup_industryRepository;
            _lookup_leadSourceRepository = lookup_leadSourceRepository;
            _lookup_leadStatusRepository = lookup_leadStatusRepository;

        }

        public async Task<PagedResultDto<GetLeadForViewDto>> GetAll(GetAllLeadsInput input)
        {

            var filteredLeads = _leadRepository.GetAll()
                        .Include(e => e.IndustryFk)
                        .Include(e => e.LeadSourceFk)
                        .Include(e => e.LeadStatusFk)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.Filter), e => false || e.CompanyName.Contains(input.Filter) || e.FirstName.Contains(input.Filter) || e.LastName.Contains(input.Filter) || e.Title.Contains(input.Filter) || e.WebSite.Contains(input.Filter) || e.Address.Contains(input.Filter) || e.Country.Contains(input.Filter) || e.State.Contains(input.Filter) || e.Description.Contains(input.Filter))
                        .WhereIf(!string.IsNullOrWhiteSpace(input.CompanyNameFilter), e => e.CompanyName == input.CompanyNameFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.FirstNameFilter), e => e.FirstName == input.FirstNameFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.LastNameFilter), e => e.LastName == input.LastNameFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.TitleFilter), e => e.Title == input.TitleFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.WebSiteFilter), e => e.WebSite == input.WebSiteFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.AddressFilter), e => e.Address == input.AddressFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.CountryFilter), e => e.Country == input.CountryFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.StateFilter), e => e.State == input.StateFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.DescriptionFilter), e => e.Description == input.DescriptionFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.IndustryDescriptionFilter), e => e.IndustryFk != null && e.IndustryFk.Description == input.IndustryDescriptionFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.LeadSourceDescriptionFilter), e => e.LeadSourceFk != null && e.LeadSourceFk.Description == input.LeadSourceDescriptionFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.LeadStatusDescriptionFilter), e => e.LeadStatusFk != null && e.LeadStatusFk.Description == input.LeadStatusDescriptionFilter);

            var pagedAndFilteredLeads = filteredLeads
                .OrderBy(input.Sorting ?? "id asc")
                .PageBy(input);

            var leads = from o in pagedAndFilteredLeads
                        join o1 in _lookup_industryRepository.GetAll() on o.IndustryId equals o1.Id into j1
                        from s1 in j1.DefaultIfEmpty()

                        join o2 in _lookup_leadSourceRepository.GetAll() on o.LeadSourceId equals o2.Id into j2
                        from s2 in j2.DefaultIfEmpty()

                        join o3 in _lookup_leadStatusRepository.GetAll() on o.LeadStatusId equals o3.Id into j3
                        from s3 in j3.DefaultIfEmpty()

                        select new
                        {

                            o.CompanyName,
                            o.FirstName,
                            o.LastName,
                            o.Title,
                            o.WebSite,
                            o.Address,
                            o.Country,
                            o.State,
                            o.Description,
                            Id = o.Id,
                            IndustryDescription = s1 == null || s1.Description == null ? "" : s1.Description.ToString(),
                            LeadSourceDescription = s2 == null || s2.Description == null ? "" : s2.Description.ToString(),
                            LeadStatusDescription = s3 == null || s3.Description == null ? "" : s3.Description.ToString()
                        };

            var totalCount = await filteredLeads.CountAsync();

            var dbList = await leads.ToListAsync();
            var results = new List<GetLeadForViewDto>();

            foreach (var o in dbList)
            {
                var res = new GetLeadForViewDto()
                {
                    Lead = new LeadDto
                    {

                        CompanyName = o.CompanyName,
                        FirstName = o.FirstName,
                        LastName = o.LastName,
                        Title = o.Title,
                        WebSite = o.WebSite,
                        Address = o.Address,
                        Country = o.Country,
                        State = o.State,
                        Description = o.Description,
                        Id = o.Id,
                    },
                    IndustryDescription = o.IndustryDescription,
                    LeadSourceDescription = o.LeadSourceDescription,
                    LeadStatusDescription = o.LeadStatusDescription
                };

                results.Add(res);
            }

            return new PagedResultDto<GetLeadForViewDto>(
                totalCount,
                results
            );

        }

        public async Task<GetLeadForViewDto> GetLeadForView(int id)
        {
            var lead = await _leadRepository.GetAsync(id);

            var output = new GetLeadForViewDto { Lead = ObjectMapper.Map<LeadDto>(lead) };

            if (output.Lead.IndustryId != null)
            {
                var _lookupIndustry = await _lookup_industryRepository.FirstOrDefaultAsync((int)output.Lead.IndustryId);
                output.IndustryDescription = _lookupIndustry?.Description?.ToString();
            }

            if (output.Lead.LeadSourceId != null)
            {
                var _lookupLeadSource = await _lookup_leadSourceRepository.FirstOrDefaultAsync((int)output.Lead.LeadSourceId);
                output.LeadSourceDescription = _lookupLeadSource?.Description?.ToString();
            }

            if (output.Lead.LeadStatusId != null)
            {
                var _lookupLeadStatus = await _lookup_leadStatusRepository.FirstOrDefaultAsync((int)output.Lead.LeadStatusId);
                output.LeadStatusDescription = _lookupLeadStatus?.Description?.ToString();
            }

            return output;
        }

        [AbpAuthorize(AppPermissions.Pages_Leads_Edit)]
        public async Task<GetLeadForEditOutput> GetLeadForEdit(EntityDto input)
        {
            var lead = await _leadRepository.FirstOrDefaultAsync(input.Id);

            var output = new GetLeadForEditOutput { Lead = ObjectMapper.Map<CreateOrEditLeadDto>(lead) };

            if (output.Lead.IndustryId != null)
            {
                var _lookupIndustry = await _lookup_industryRepository.FirstOrDefaultAsync((int)output.Lead.IndustryId);
                output.IndustryDescription = _lookupIndustry?.Description?.ToString();
            }

            if (output.Lead.LeadSourceId != null)
            {
                var _lookupLeadSource = await _lookup_leadSourceRepository.FirstOrDefaultAsync((int)output.Lead.LeadSourceId);
                output.LeadSourceDescription = _lookupLeadSource?.Description?.ToString();
            }

            if (output.Lead.LeadStatusId != null)
            {
                var _lookupLeadStatus = await _lookup_leadStatusRepository.FirstOrDefaultAsync((int)output.Lead.LeadStatusId);
                output.LeadStatusDescription = _lookupLeadStatus?.Description?.ToString();
            }

            return output;
        }

        public async Task CreateOrEdit(CreateOrEditLeadDto input)
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

        [AbpAuthorize(AppPermissions.Pages_Leads_Create)]
        protected virtual async Task Create(CreateOrEditLeadDto input)
        {
            var lead = ObjectMapper.Map<Lead>(input);

            await _leadRepository.InsertAsync(lead);

        }

        [AbpAuthorize(AppPermissions.Pages_Leads_Edit)]
        protected virtual async Task Update(CreateOrEditLeadDto input)
        {
            var lead = await _leadRepository.FirstOrDefaultAsync((int)input.Id);
            ObjectMapper.Map(input, lead);

        }

        [AbpAuthorize(AppPermissions.Pages_Leads_Delete)]
        public async Task Delete(EntityDto input)
        {
            await _leadRepository.DeleteAsync(input.Id);
        }

        public async Task<FileDto> GetLeadsToExcel(GetAllLeadsForExcelInput input)
        {

            var filteredLeads = _leadRepository.GetAll()
                        .Include(e => e.IndustryFk)
                        .Include(e => e.LeadSourceFk)
                        .Include(e => e.LeadStatusFk)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.Filter), e => false || e.CompanyName.Contains(input.Filter) || e.FirstName.Contains(input.Filter) || e.LastName.Contains(input.Filter) || e.Title.Contains(input.Filter) || e.WebSite.Contains(input.Filter) || e.Address.Contains(input.Filter) || e.Country.Contains(input.Filter) || e.State.Contains(input.Filter) || e.Description.Contains(input.Filter))
                        .WhereIf(!string.IsNullOrWhiteSpace(input.CompanyNameFilter), e => e.CompanyName == input.CompanyNameFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.FirstNameFilter), e => e.FirstName == input.FirstNameFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.LastNameFilter), e => e.LastName == input.LastNameFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.TitleFilter), e => e.Title == input.TitleFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.WebSiteFilter), e => e.WebSite == input.WebSiteFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.AddressFilter), e => e.Address == input.AddressFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.CountryFilter), e => e.Country == input.CountryFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.StateFilter), e => e.State == input.StateFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.DescriptionFilter), e => e.Description == input.DescriptionFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.IndustryDescriptionFilter), e => e.IndustryFk != null && e.IndustryFk.Description == input.IndustryDescriptionFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.LeadSourceDescriptionFilter), e => e.LeadSourceFk != null && e.LeadSourceFk.Description == input.LeadSourceDescriptionFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.LeadStatusDescriptionFilter), e => e.LeadStatusFk != null && e.LeadStatusFk.Description == input.LeadStatusDescriptionFilter);

            var query = (from o in filteredLeads
                         join o1 in _lookup_industryRepository.GetAll() on o.IndustryId equals o1.Id into j1
                         from s1 in j1.DefaultIfEmpty()

                         join o2 in _lookup_leadSourceRepository.GetAll() on o.LeadSourceId equals o2.Id into j2
                         from s2 in j2.DefaultIfEmpty()

                         join o3 in _lookup_leadStatusRepository.GetAll() on o.LeadStatusId equals o3.Id into j3
                         from s3 in j3.DefaultIfEmpty()

                         select new GetLeadForViewDto()
                         {
                             Lead = new LeadDto
                             {
                                 CompanyName = o.CompanyName,
                                 FirstName = o.FirstName,
                                 LastName = o.LastName,
                                 Title = o.Title,
                                 WebSite = o.WebSite,
                                 Address = o.Address,
                                 Country = o.Country,
                                 State = o.State,
                                 Description = o.Description,
                                 Id = o.Id
                             },
                             IndustryDescription = s1 == null || s1.Description == null ? "" : s1.Description.ToString(),
                             LeadSourceDescription = s2 == null || s2.Description == null ? "" : s2.Description.ToString(),
                             LeadStatusDescription = s3 == null || s3.Description == null ? "" : s3.Description.ToString()
                         });

            var leadListDtos = await query.ToListAsync();

            return _leadsExcelExporter.ExportToFile(leadListDtos);
        }

        [AbpAuthorize(AppPermissions.Pages_Leads)]
        public async Task<List<LeadIndustryLookupTableDto>> GetAllIndustryForTableDropdown()
        {
            return await _lookup_industryRepository.GetAll()
                .Select(industry => new LeadIndustryLookupTableDto
                {
                    Id = industry.Id,
                    DisplayName = industry == null || industry.Description == null ? "" : industry.Description.ToString()
                }).ToListAsync();
        }

        [AbpAuthorize(AppPermissions.Pages_Leads)]
        public async Task<List<LeadLeadSourceLookupTableDto>> GetAllLeadSourceForTableDropdown()
        {
            return await _lookup_leadSourceRepository.GetAll()
                .Select(leadSource => new LeadLeadSourceLookupTableDto
                {
                    Id = leadSource.Id,
                    DisplayName = leadSource == null || leadSource.Description == null ? "" : leadSource.Description.ToString()
                }).ToListAsync();
        }

        [AbpAuthorize(AppPermissions.Pages_Leads)]
        public async Task<List<LeadLeadStatusLookupTableDto>> GetAllLeadStatusForTableDropdown()
        {
            return await _lookup_leadStatusRepository.GetAll()
                .Select(leadStatus => new LeadLeadStatusLookupTableDto
                {
                    Id = leadStatus.Id,
                    DisplayName = leadStatus == null || leadStatus.Description == null ? "" : leadStatus.Description.ToString()
                }).ToListAsync();
        }

    }
}