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
using SBCRM.Infrastructure.Excel;
using SBCRM.DataImporting;

namespace SBCRM.Crm
{
    [AbpAuthorize(AppPermissions.Pages_Leads)]
    public class LeadsAppService : SBCRMAppServiceBase, ILeadsAppService
    {
        private readonly IRepository<Lead> _leadRepository;
        private readonly ILeadsExcelExporter _leadsExcelExporter;
        private readonly IRepository<LeadSource, int> _lookup_leadSourceRepository;
        private readonly IRepository<LeadStatus, int> _lookup_leadStatusRepository;
        private readonly IRepository<Priority, int> _lookup_priorityRepository;

        public LeadsAppService(IRepository<Lead> leadRepository, ILeadsExcelExporter leadsExcelExporter, IRepository<LeadSource, int> lookup_leadSourceRepository, IRepository<LeadStatus, int> lookup_leadStatusRepository, IRepository<Priority, int> lookup_priorityRepository)
        {
            _leadRepository = leadRepository;
            _leadsExcelExporter = leadsExcelExporter;
            _lookup_leadSourceRepository = lookup_leadSourceRepository;
            _lookup_leadStatusRepository = lookup_leadStatusRepository;
            _lookup_priorityRepository = lookup_priorityRepository;

        }

        public async Task<PagedResultDto<GetLeadForViewDto>> GetAll(GetAllLeadsInput input)
        {

            var filteredLeads = _leadRepository.GetAll()
                        .Include(e => e.LeadSourceFk)
                        .Include(e => e.LeadStatusFk)
                        .Include(e => e.PriorityFk)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.Filter), e => false || e.ContactName.Contains(input.Filter) || e.CompanyName.Contains(input.Filter))
                        .WhereIf(!string.IsNullOrWhiteSpace(input.CompanyOrContactNameFilter), e => e.CompanyName.Contains(input.CompanyOrContactNameFilter) || e.ContactName.Contains(input.CompanyOrContactNameFilter))
                        .WhereIf(!string.IsNullOrWhiteSpace(input.ContactNameFilter), e => e.ContactName == input.ContactNameFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.ContactPositionFilter), e => e.ContactPosition == input.ContactPositionFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.WebSiteFilter), e => e.WebSite == input.WebSiteFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.AddressFilter), e => e.Address == input.AddressFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.CountryFilter), e => e.Country == input.CountryFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.StateFilter), e => e.State == input.StateFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.CityFilter), e => e.State == input.CityFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.DescriptionFilter), e => e.Description == input.DescriptionFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.CompanyPhoneFilter), e => e.CompanyPhone == input.CompanyPhoneFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.CompanyEmailFilter), e => e.CompanyEmail == input.CompanyEmailFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.PoBoxFilter), e => e.PoBox == input.PoBoxFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.ZipCodeFilter), e => e.ZipCode == input.ZipCodeFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.ContactPhoneFilter), e => e.ContactPhone == input.ContactPhoneFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.ContactPhoneExtensionFilter), e => e.ContactPhoneExtension == input.ContactPhoneExtensionFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.ContactCellPhoneFilter), e => e.ContactCellPhone == input.ContactCellPhoneFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.ContactFaxNumberFilter), e => e.ContactFaxNumber == input.ContactFaxNumberFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.PagerNumberFilter), e => e.PagerNumber == input.PagerNumberFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.ContactEmailFilter), e => e.ContactEmail == input.ContactEmailFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.LeadSourceDescriptionFilter), e => e.LeadSourceFk != null && e.LeadSourceFk.Description == input.LeadSourceDescriptionFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.LeadStatusDescriptionFilter), e => e.LeadStatusFk != null && e.LeadStatusFk.Description == input.LeadStatusDescriptionFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.PriorityDescriptionFilter), e => e.PriorityFk != null && e.PriorityFk.Description == input.PriorityDescriptionFilter);

            var pagedAndFilteredLeads = filteredLeads
                .OrderBy(input.Sorting ?? "id asc")
                .PageBy(input);

            var leads = from o in pagedAndFilteredLeads
                        join o1 in _lookup_leadSourceRepository.GetAll() on o.LeadSourceId equals o1.Id into j1
                        from s1 in j1.DefaultIfEmpty()

                        join o2 in _lookup_leadStatusRepository.GetAll() on o.LeadStatusId equals o2.Id into j2
                        from s2 in j2.DefaultIfEmpty()

                        join o3 in _lookup_priorityRepository.GetAll() on o.PriorityId equals o3.Id into j3
                        from s3 in j3.DefaultIfEmpty()

                        select new
                        {

                            o.CompanyName,
                            o.ContactName,
                            o.ContactPosition,
                            o.WebSite,
                            o.Address,
                            o.Country,
                            o.State,
                            o.City,
                            o.Description,
                            o.CompanyPhone,
                            o.CompanyEmail,
                            o.PoBox,
                            o.ZipCode,
                            o.ContactPhone,
                            o.ContactPhoneExtension,
                            o.ContactCellPhone,
                            o.ContactFaxNumber,
                            o.PagerNumber,
                            o.ContactEmail,
                            Id = o.Id,
                            LeadSourceDescription = s1 == null || s1.Description == null ? "" : s1.Description.ToString(),
                            LeadStatusDescription = s2 == null || s2.Description == null ? "" : s2.Description.ToString(),
                            PriorityDescription = s3 == null || s3.Description == null ? "" : s3.Description.ToString(),
                            o.CreationTime
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
                        ContactName = o.ContactName,
                        ContactPosition = o.ContactPosition,
                        WebSite = o.WebSite,
                        Address = o.Address,
                        Country = o.Country,
                        State = o.State,
                        City = o.City,
                        Description = o.Description,
                        CompanyPhone = o.CompanyPhone,
                        CompanyEmail = o.CompanyEmail,
                        PoBox = o.PoBox,
                        ZipCode = o.ZipCode,
                        ContactPhone = o.ContactPhone,
                        ContactPhoneExtension = o.ContactPhoneExtension,
                        ContactCellPhone = o.ContactCellPhone,
                        ContactFaxNumber = o.ContactFaxNumber,
                        PagerNumber = o.PagerNumber,
                        ContactEmail = o.ContactEmail,
                        Id = o.Id,
                        CreationTime = o.CreationTime
                    },
                    LeadSourceDescription = o.LeadSourceDescription,
                    LeadStatusDescription = o.LeadStatusDescription,
                    PriorityDescription = o.PriorityDescription
                };

                results.Add(res);
            }

            return new PagedResultDto<GetLeadForViewDto>(
                totalCount,
                results
            );

        }

        /// <summary>
        /// This method allows to upload imported leads from an excel file
        /// </summary>
        /// <param name="inputFile"></param>
        /// <param name="leadSourceId"></param>
        /// <param name="assignedUserId"></param>
        /// <returns></returns>
        public async Task ImportLeadsFromFile(byte[] inputFile, int leadSourceId, int assignedUserId)
        {
            var leadsToImport = await ExcelHandler.ReadIntoList<LeadImportedInputDto>(inputFile, startFromRow: 2);

            // Defining default status and priority
            var leadStatusId = _lookup_leadStatusRepository.FirstOrDefault(p => p.Description == "New");
            var leadPriorityId = _lookup_priorityRepository.FirstOrDefault(p => p.Description == "Low");

            int duplicatedLeads = 0;

            foreach (var item in leadsToImport)
            {
                CreateOrEditLeadDto leadAux = new CreateOrEditLeadDto();
                leadAux.CompanyName = item.CompanyName;
                leadAux.CompanyPhone = item.Phone;
                leadAux.LeadSourceId = leadSourceId;
                leadAux.LeadStatusId = leadStatusId.Id;
                leadAux.PriorityId = leadPriorityId.Id;


                var storedLead = _leadRepository.GetAllList().Find(l => l.CompanyName == leadAux.CompanyName && l.CompanyPhone == leadAux.CompanyPhone);
                if (storedLead == null)
                {
                    var lead = ObjectMapper.Map<Lead>(leadAux);
                    await _leadRepository.InsertAsync(lead);
                }
                else
                {
                    duplicatedLeads++;
                }
            }
            
        }

        public async Task<GetLeadForViewDto> GetLeadForView(int id)
        {
            var lead = await _leadRepository.GetAsync(id);

            var output = new GetLeadForViewDto { Lead = ObjectMapper.Map<LeadDto>(lead) };

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

            if (output.Lead.PriorityId != null)
            {
                var _lookupPriority = await _lookup_priorityRepository.FirstOrDefaultAsync((int)output.Lead.PriorityId);
                output.PriorityDescription = _lookupPriority?.Description?.ToString();
            }
            
            return output;
        }

        [AbpAuthorize(AppPermissions.Pages_Leads_Edit)]
        public async Task<GetLeadForEditOutput> GetLeadForEdit(EntityDto input)
        {
            var lead = await _leadRepository.FirstOrDefaultAsync(input.Id);

            var output = new GetLeadForEditOutput { Lead = ObjectMapper.Map<CreateOrEditLeadDto>(lead) };

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

            if (output.Lead.PriorityId != null)
            {
                var _lookupPriority = await _lookup_priorityRepository.FirstOrDefaultAsync((int)output.Lead.PriorityId);
                output.PriorityDescription = _lookupPriority?.Description?.ToString();
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
                        .Include(e => e.LeadSourceFk)
                        .Include(e => e.LeadStatusFk)
                        .Include(e => e.PriorityFk)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.Filter), e => false || e.CompanyName.Contains(input.Filter) || e.ContactName.Contains(input.Filter) || e.ContactPosition.Contains(input.Filter) || e.WebSite.Contains(input.Filter) || e.Address.Contains(input.Filter) || e.Country.Contains(input.Filter) || e.State.Contains(input.Filter) || e.Description.Contains(input.Filter) || e.CompanyPhone.Contains(input.Filter) || e.CompanyEmail.Contains(input.Filter) || e.PoBox.Contains(input.Filter) || e.ZipCode.Contains(input.Filter) || e.ContactPhone.Contains(input.Filter) || e.ContactPhoneExtension.Contains(input.Filter) || e.ContactCellPhone.Contains(input.Filter) || e.ContactFaxNumber.Contains(input.Filter) || e.PagerNumber.Contains(input.Filter) || e.ContactEmail.Contains(input.Filter))
                        .WhereIf(!string.IsNullOrWhiteSpace(input.CompanyNameFilter), e => e.CompanyName == input.CompanyNameFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.ContactNameFilter), e => e.ContactName == input.ContactNameFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.ContactPositionFilter), e => e.ContactPosition == input.ContactPositionFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.WebSiteFilter), e => e.WebSite == input.WebSiteFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.AddressFilter), e => e.Address == input.AddressFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.CountryFilter), e => e.Country == input.CountryFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.StateFilter), e => e.State == input.StateFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.CityFilter), e => e.State == input.CityFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.DescriptionFilter), e => e.Description == input.DescriptionFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.CompanyPhoneFilter), e => e.CompanyPhone == input.CompanyPhoneFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.CompanyEmailFilter), e => e.CompanyEmail == input.CompanyEmailFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.PoBoxFilter), e => e.PoBox == input.PoBoxFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.ZipCodeFilter), e => e.ZipCode == input.ZipCodeFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.ContactPhoneFilter), e => e.ContactPhone == input.ContactPhoneFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.ContactPhoneExtensionFilter), e => e.ContactPhoneExtension == input.ContactPhoneExtensionFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.ContactCellPhoneFilter), e => e.ContactCellPhone == input.ContactCellPhoneFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.ContactFaxNumberFilter), e => e.ContactFaxNumber == input.ContactFaxNumberFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.PagerNumberFilter), e => e.PagerNumber == input.PagerNumberFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.ContactEmailFilter), e => e.ContactEmail == input.ContactEmailFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.LeadSourceDescriptionFilter), e => e.LeadSourceFk != null && e.LeadSourceFk.Description == input.LeadSourceDescriptionFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.LeadStatusDescriptionFilter), e => e.LeadStatusFk != null && e.LeadStatusFk.Description == input.LeadStatusDescriptionFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.PriorityDescriptionFilter), e => e.PriorityFk != null && e.PriorityFk.Description == input.PriorityDescriptionFilter);

            var query = (from o in filteredLeads
                         join o1 in _lookup_leadSourceRepository.GetAll() on o.LeadSourceId equals o1.Id into j1
                         from s1 in j1.DefaultIfEmpty()

                         join o2 in _lookup_leadStatusRepository.GetAll() on o.LeadStatusId equals o2.Id into j2
                         from s2 in j2.DefaultIfEmpty()

                         join o3 in _lookup_priorityRepository.GetAll() on o.PriorityId equals o3.Id into j3
                         from s3 in j3.DefaultIfEmpty()

                         select new GetLeadForViewDto()
                         {
                             Lead = new LeadDto
                             {
                                 CompanyName = o.CompanyName,
                                 ContactName = o.ContactName,
                                 ContactPosition = o.ContactPosition,
                                 WebSite = o.WebSite,
                                 Address = o.Address,
                                 Country = o.Country,
                                 State = o.State,
                                 City = o.City,
                                 Description = o.Description,
                                 CompanyPhone = o.CompanyPhone,
                                 CompanyEmail = o.CompanyEmail,
                                 PoBox = o.PoBox,
                                 ZipCode = o.ZipCode,
                                 ContactPhone = o.ContactPhone,
                                 ContactPhoneExtension = o.ContactPhoneExtension,
                                 ContactCellPhone = o.ContactCellPhone,
                                 ContactFaxNumber = o.ContactFaxNumber,
                                 PagerNumber = o.PagerNumber,
                                 ContactEmail = o.ContactEmail,
                                 Id = o.Id
                             },
                             LeadSourceDescription = s1 == null || s1.Description == null ? "" : s1.Description.ToString(),
                             LeadStatusDescription = s2 == null || s2.Description == null ? "" : s2.Description.ToString(),
                             PriorityDescription = s3 == null || s3.Description == null ? "" : s3.Description.ToString()
                         });

            var leadListDtos = await query.ToListAsync();

            return _leadsExcelExporter.ExportToFile(leadListDtos);
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

        [AbpAuthorize(AppPermissions.Pages_Leads)]
        public async Task<List<LeadPriorityLookupTableDto>> GetAllPriorityForTableDropdown()
        {
            return await _lookup_priorityRepository.GetAll()
                .Select(priority => new LeadPriorityLookupTableDto
                {
                    Id = priority.Id,
                    DisplayName = priority == null || priority.Description == null ? "" : priority.Description.ToString()
                }).ToListAsync();
        }

    }
}