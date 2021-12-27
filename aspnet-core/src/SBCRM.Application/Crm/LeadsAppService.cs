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
using Abp.Authorization;
using Abp.Domain.Uow;
using Abp.EntityHistory;
using Abp.UI;
using Microsoft.EntityFrameworkCore;
using SBCRM.Common;
using SBCRM.Infrastructure.Excel;
using SBCRM.DataImporting;
using SBCRM.Legacy;
using SBCRM.Legacy.Dtos;
using System;
using System.ComponentModel.DataAnnotations;
using SBCRM.Authorization.Users;

namespace SBCRM.Crm
{
    /// <summary>
    /// App service to handle Leads information
    /// </summary>
    [AbpAuthorize(AppPermissions.Pages_Leads)]
    public class LeadsAppService : SBCRMAppServiceBase, ILeadsAppService
    {
        private readonly IRepository<Lead> _leadRepository;
        private readonly ILeadsExcelExporter _leadsExcelExporter;
        private readonly IRepository<LeadSource, int> _lookupLeadSourceRepository;
        private readonly IRepository<LeadStatus, int> _lookupLeadStatusRepository;
        private readonly IRepository<Priority, int> _lookupPriorityRepository;
        private readonly ICustomerAppService _customerAppService;
        private readonly IEntityChangeSetReasonProvider _reasonProvider;
        private readonly IUnitOfWorkManager _unitOfWorkManager;
        private readonly IRepository<LeadUser> _leadUserRepository;
        private readonly IRepository<Country> _countryRepository;
        private readonly IRepository<User, long> _lookup_userRepository;

        private readonly string _assignedUserSortKey = "users.userFk.name";

        /// <summary>
        /// Base constructor
        /// </summary>
        /// <param name="leadRepository"></param>
        /// <param name="leadsExcelExporter"></param>
        /// <param name="lookupLeadSourceRepository"></param>
        /// <param name="lookupLeadStatusRepository"></param>
        /// <param name="lookupPriorityRepository"></param>
        /// <param name="customerAppService"></param>
        /// <param name="reasonProvider"></param>
        /// <param name="unitOfWorkManager"></param>
        /// <param name="leadUserRepository"></param>
        /// <param name="countryRepository"></param>
        /// <param name="lookupUserRepository"></param>
        public LeadsAppService(
            IRepository<Lead> leadRepository,
            ILeadsExcelExporter leadsExcelExporter,
            IRepository<LeadSource, int> lookupLeadSourceRepository,
            IRepository<LeadStatus, int> lookupLeadStatusRepository,
            IRepository<Priority, int> lookupPriorityRepository,
            ICustomerAppService customerAppService,
            IEntityChangeSetReasonProvider reasonProvider,
            IUnitOfWorkManager unitOfWorkManager,
            IRepository<LeadUser> leadUserRepository,
            IRepository<Country> countryRepository,
            IRepository<User, long> lookupUserRepository)
        {
            _leadRepository = leadRepository;
            _leadsExcelExporter = leadsExcelExporter;
            _lookupLeadSourceRepository = lookupLeadSourceRepository;
            _lookupLeadStatusRepository = lookupLeadStatusRepository;
            _lookupPriorityRepository = lookupPriorityRepository;
            _customerAppService = customerAppService;
            _reasonProvider = reasonProvider;
            _unitOfWorkManager = unitOfWorkManager;
            _leadUserRepository = leadUserRepository;
            _countryRepository = countryRepository;
            _lookup_userRepository = lookupUserRepository;
        }

        /// <summary>
        /// Gets all leads
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<PagedResultDto<GetLeadForViewDto>> GetAll(GetAllLeadsInput input)
        {
            try
            { 
                var filteredLeads = _leadRepository.GetAll()
                               .Include(e => e.LeadSourceFk)
                               .Include(e => e.LeadStatusFk)
                               .Include(x => x.Users)
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
                               .WhereIf(!string.IsNullOrWhiteSpace(input.NotesFilter), e => e.Notes == input.NotesFilter)
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
                               .WhereIf(!string.IsNullOrWhiteSpace(input.PriorityDescriptionFilter), e => e.PriorityFk != null && e.PriorityFk.Description == input.PriorityDescriptionFilter)
                               .WhereIf(input.LeadStatusId.HasValue, x => input.LeadStatusId == x.LeadStatusFk.Id)
                               .WhereIf(input.PriorityId.HasValue, x => input.PriorityId == x.PriorityFk.Id)
                               .WhereIf(input.UserIds.Any(), x => x.Users.Any(y => input.UserIds.Contains(y.UserId)));

                var isAssignedUserSorting = input.Sorting != null && input.Sorting.StartsWith(_assignedUserSortKey);

                IQueryable<LeadQueryDto> leads;

                if (isAssignedUserSorting)
                {
                    input.Sorting = input.Sorting.Replace(_assignedUserSortKey, $"{nameof(LeadQueryDto.FirstUserAssignedName)}");
                    leads = from o in filteredLeads
                            join o1 in _lookupLeadSourceRepository.GetAll() on o.LeadSourceId equals o1.Id into j1
                            from s1 in j1.DefaultIfEmpty()

                            join o2 in _lookupLeadStatusRepository.GetAll() on o.LeadStatusId equals o2.Id into j2
                            from s2 in j2.DefaultIfEmpty()

                            join o3 in _lookupPriorityRepository.GetAll() on o.PriorityId equals o3.Id into j3
                            from s3 in j3.DefaultIfEmpty()

                            select new LeadQueryDto
                            {
                                CompanyName = o.CompanyName,
                                ContactName = o.ContactName,
                                ContactPosition = o.ContactPosition,
                                WebSite = o.WebSite,
                                Address = o.Address,
                                Country = o.Country,
                                State = o.State,
                                City = o.City,
                                Notes = o.Notes,
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
                                CreationTime = o.CreationTime,
                                Users = o.Users,
                                LeadSourceDescription = s1 == null || s1.Description == null ? "" : s1.Description,
                                LeadStatusDescription = s2 == null || s2.Description == null ? "" : s2.Description,
                                LeadCanBeConvert = s2 != null && s2.IsLeadConversionValid,
                                LeadStatusColor = s2 == null || s2.Color == null ? "" : s2.Color,
                                PriorityDescription = s3 == null || s3.Description == null ? "" : s3.Description.ToString(),
                                PriorityColor = s3 == null || s3.Color == null ? "" : s3.Color,
                                FirstUserAssignedName = (from s in _leadUserRepository.GetAll()
                                            .Include(x => x.UserFk)
                                                         where s.Id == o.Id
                                                         select s.UserFk.Name
                                    ).OrderBy(x => x).FirstOrDefault()
                            };

                    leads = leads
                            .OrderBy(input.Sorting)
                            .PageBy(input);
                }
                else
                {
                    IQueryable<Lead> pagedAndFilteredOpportunities;

                    if (input.Sorting != null)
                        pagedAndFilteredOpportunities = filteredLeads
                            .OrderBy(input.Sorting)
                            .PageBy(input);
                    else
                        pagedAndFilteredOpportunities = filteredLeads
                            .OrderByDescending(o => o.CreationTime)
                            .ThenByDescending(s1 => s1.Notes)
                            .ThenBy(s2 => s2.Notes)
                            .ThenBy(o => o.CompanyName)
                            .ThenBy(o => o.ContactName)
                            .PageBy(input);

                    leads = from o in pagedAndFilteredOpportunities
                            join o1 in _lookupLeadSourceRepository.GetAll() on o.LeadSourceId equals o1.Id into j1
                            from s1 in j1.DefaultIfEmpty()

                            join o2 in _lookupLeadStatusRepository.GetAll() on o.LeadStatusId equals o2.Id into j2
                            from s2 in j2.DefaultIfEmpty()

                            join o3 in _lookupPriorityRepository.GetAll() on o.PriorityId equals o3.Id into j3
                            from s3 in j3.DefaultIfEmpty()

                            select new LeadQueryDto
                            {
                                CompanyName = o.CompanyName,
                                ContactName = o.ContactName,
                                ContactPosition = o.ContactPosition,
                                WebSite = o.WebSite,
                                Address = o.Address,
                                Country = o.Country,
                                State = o.State,
                                City = o.City,
                                Notes = o.Notes,
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
                                CreationTime = o.CreationTime,
                                Users = o.Users,
                                LeadSourceDescription = s1 == null || s1.Description == null ? "" : s1.Description,
                                LeadStatusDescription = s2 == null || s2.Description == null ? "" : s2.Description,
                                LeadCanBeConvert = s2 != null && s2.IsLeadConversionValid,
                                LeadStatusColor = s2 == null || s2.Color == null ? "" : s2.Color,
                                PriorityDescription = s3 == null || s3.Description == null ? "" : s3.Description.ToString(),
                                PriorityColor = s3 == null || s3.Color == null ? "" : s3.Color
                            };
                }

                var totalCount = await filteredLeads.CountAsync();

                var dbList = await leads.ToListAsync();
                var results = GetLeadForViewDtos(dbList);

                return new PagedResultDto<GetLeadForViewDto>(
                    totalCount,
                    results
                );
            }
            catch (Exception e)
            {
                Logger.Error("Error in LeadsAppService -> ", e);
                throw;
            }

        }

        /// <summary>
        /// Method to return an excel file with duplicated leads when Importing Leads 
        /// </summary>
        /// <param name="leads"></param>
        /// <returns></returns>
        public async Task<FileDto> GetDuplicatedLeadsToExcel(List<LeadDto> leads)
        {
            return _leadsExcelExporter.ExportDuplicatedLeadsToExcel(leads); 
        }

        /// <summary>
        /// This method allows to upload imported leads from an excel file
        /// </summary>
        /// <param name="inputFile"></param>
        /// <param name="leadSourceId"></param>
        /// <param name="assignedUserId"></param>
        /// <returns></returns>
        public async Task<List<CreateOrEditLeadDto>> ImportLeadsFromFile(byte[] inputFile, int leadSourceId, int assignedUserId)
        {
            try
            {
                var leadsToImport = await ExcelHandler.ReadIntoList<LeadImportedInputDto>(inputFile, startFromRow: 2);

                var duplicatedLeads = new List<CreateOrEditLeadDto>();

                if (!ValidateLeadsImported(leadsToImport))
                {
                    throw new UserFriendlyException(L("ErrorUploadingMessage"));
                }

                // Default status and priority
                var leadStatusId = _lookupLeadStatusRepository.FirstOrDefault(p => p.Description.ToUpper() == "NEW");
                var leadPriorityId = _lookupPriorityRepository.FirstOrDefault(p => p.Description.ToUpper() == "LOW");


                foreach (var item in leadsToImport)
                {
                    CreateOrEditLeadDto leadAux = new CreateOrEditLeadDto();
                    leadAux.CompanyName = item.CompanyName;
                    leadAux.CompanyPhone = item.Phone;
                    leadAux.CompanyEmail = item.CompanyEmail;
                    leadAux.WebSite = item.Website;
                    leadAux.Address = item.CompanyAdress;
                    leadAux.Country = item.Country;
                    leadAux.City = item.City;
                    leadAux.State = item.StateProvince;
                    leadAux.ZipCode = item.ZipCode;
                    leadAux.PoBox = item.PoBox;
                    leadAux.ContactName = item.ContactName;
                    leadAux.ContactPosition = item.ContactPosition;
                    leadAux.ContactPhone = item.ContactPhone;
                    leadAux.ContactPhoneExtension = item.ContactExtention;
                    leadAux.ContactCellPhone = item.ContactCelphone;
                    leadAux.ContactFaxNumber = item.ContactFax;
                    leadAux.PagerNumber = item.ContactPager;
                    leadAux.ContactEmail = item.ContactEmail;
                    // Default fields
                    leadAux.LeadSourceId = leadSourceId;
                    leadAux.LeadStatusId = leadStatusId.Id;
                    leadAux.PriorityId = leadPriorityId.Id;

                    Lead storedLead = new();

                    if (item.ContactName != null)
                    {
                        storedLead = _leadRepository.GetAllList().Find(l => l.CompanyName == leadAux.CompanyName && l.ContactName == leadAux.ContactName);
                    }
                  
                    if (storedLead == null)
                    {
                        var lead = ObjectMapper.Map<Lead>(leadAux);
                        int leadId = await _leadRepository.InsertAndGetIdAsync(lead);

                        if (leadId != 0)
                        {
                            var leadUser = new LeadUser
                            {
                                LeadId = leadId,
                                UserId = assignedUserId
                            };

                            await _leadUserRepository.InsertAsync(leadUser);
                        }
                    }
                    else
                    {
                        duplicatedLeads.Add(leadAux);
                    }
                }

                return duplicatedLeads;
            }
            catch (Exception)
            {
                throw new UserFriendlyException(L("ErrorUploadingMessage"));
            }

        }

        /// <summary>
        /// Validate every field of a list of imported leads
        /// </summary>
        /// <param name="importedLeads"></param>
        /// <returns></returns>
        private bool ValidateLeadsImported(List<LeadImportedInputDto> importedLeads)
        {
            foreach (var item in importedLeads)
            {
                // Validations for mandarory fields
                if (item.CompanyName == null || (item.Phone == null && item.CompanyEmail == null))
                {
                    return false;
                }

                // Validations for country field
                var existingCountries = _countryRepository.GetAll();
                if (item.Country != null && existingCountries.Any(p => p.Name.ToUpper().Trim() == item.Country.ToUpper().Trim()))
                {
                    return false;
                }

                // Validations for specific format fields 
                var emailValidator = new EmailAddressAttribute();
                if ((item.CompanyEmail != null && !emailValidator.IsValid(item.CompanyEmail)) 
                    || (item.ContactEmail != null && !emailValidator.IsValid(item.ContactEmail)) 
                    || (item.Website != null && !Uri.IsWellFormedUriString(item.Website.ToString(), UriKind.RelativeOrAbsolute)))
                {
                    return false;
                }

                // Validation for limit size in every field (See the SRS to further information about the field limit size)
                var isNotValidLength = new BulkValidations().AppendCondition(item.CompanyName.ExceedLength(250))
                                                 .AppendCondition(item.Phone.ExceedLength(50))
                                                 .AppendCondition(item.CompanyEmail.ExceedLength(100))
                                                 .AppendCondition(item.Website.ExceedLength(100))
                                                 .AppendCondition(item.CompanyAdress.ExceedLength(100))
                                                 .AppendCondition(item.Country.ExceedLength(100))
                                                 .AppendCondition(item.City.ExceedLength(100))
                                                 .AppendCondition(item.ContactName.ExceedLength(50))
                                                 .AppendCondition(item.StateProvince.ExceedLength(100))
                                                 .AppendCondition(item.PoBox.ExceedLength(100))
                                                 .AppendCondition(item.ContactPosition.ExceedLength(50))
                                                 .AppendCondition(item.ContactPhone.ExceedLength(50))
                                                 .AppendCondition(item.ContactFax.ExceedLength(50))
                                                 .AppendCondition(item.ContactPager.ExceedLength(50))
                                                 .AppendCondition(item.ContactEmail.ExceedLength(50))
                                                 .GetAnyTrue();

                if (isNotValidLength)
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Get lead for view mode by lead
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<GetLeadForViewDto> GetLeadForView(int id)
        {
            var lead = await _leadRepository.GetAsync(id);

            var output = new GetLeadForViewDto { Lead = ObjectMapper.Map<LeadDto>(lead) };

            if (output.Lead.LeadSourceId != null)
            {
                var _lookupLeadSource = await _lookupLeadSourceRepository.FirstOrDefaultAsync((int)output.Lead.LeadSourceId);
                output.LeadSourceDescription = _lookupLeadSource?.Description?.ToString();
            }

            if (output.Lead.LeadStatusId != null)
            {
                var _lookupLeadStatus = await _lookupLeadStatusRepository.FirstOrDefaultAsync((int)output.Lead.LeadStatusId);
                output.LeadStatusDescription = _lookupLeadStatus?.Description?.ToString();
            }

            if (output.Lead.PriorityId != null)
            {
                var _lookupPriority = await _lookupPriorityRepository.FirstOrDefaultAsync((int)output.Lead.PriorityId);
                output.PriorityDescription = _lookupPriority?.Description?.ToString();
            }

            return output;
        }

        /// <summary>
        /// Get lead for edition mode
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [AbpAuthorize(AppPermissions.Pages_Leads_Edit)]
        public async Task<GetLeadForEditOutput> GetLeadForEdit(EntityDto input)
        {
            var lead = await _leadRepository.FirstOrDefaultAsync(input.Id);

            var output = new GetLeadForEditOutput { Lead = ObjectMapper.Map<CreateOrEditLeadDto>(lead) };

            if (output.Lead.LeadSourceId != null)
            {
                var _lookupLeadSource = await _lookupLeadSourceRepository.FirstOrDefaultAsync((int)output.Lead.LeadSourceId);
                output.LeadSourceDescription = _lookupLeadSource?.Description?.ToString();
            }

            if (output.Lead.LeadStatusId != null)
            {
                var _lookupLeadStatus = await _lookupLeadStatusRepository.FirstOrDefaultAsync((int)output.Lead.LeadStatusId);
                output.LeadStatusDescription = _lookupLeadStatus?.Description?.ToString();
            }

            if (output.Lead.PriorityId != null)
            {
                var _lookupPriority = await _lookupPriorityRepository.FirstOrDefaultAsync((int)output.Lead.PriorityId);
                output.PriorityDescription = _lookupPriority?.Description?.ToString();
            }

            return output;
        }

        /// <summary>
        /// Create or edit lead
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Create lead
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [AbpAuthorize(AppPermissions.Pages_Leads_Create)]
        protected virtual async Task Create(CreateOrEditLeadDto input)
        {
            var lead = ObjectMapper.Map<Lead>(input);

            if (AbpSession.TenantId != null)
            {
                lead.TenantId = AbpSession.TenantId;
            }

            await _leadRepository.InsertAsync(lead);

        }

        /// <summary>
        /// Update lead
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [AbpAuthorize(AppPermissions.Pages_Leads_Edit)]
        protected virtual async Task Update(CreateOrEditLeadDto input)
        {
            var lead = await _leadRepository.FirstOrDefaultAsync((int)input.Id);
            ObjectMapper.Map(input, lead);

        }

        /// <summary>
        /// Delete lead
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [AbpAuthorize(AppPermissions.Pages_Leads_Delete)]
        public async Task Delete(EntityDto input)
        {
            await _leadRepository.DeleteAsync(input.Id);
        }

        /// <summary>
        /// Get leads to excel
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<FileDto> GetLeadsToExcel(GetAllLeadsForExcelInput input)
        {

            var filteredLeads = _leadRepository.GetAll()
                        .Include(e => e.LeadSourceFk)
                        .Include(e => e.LeadStatusFk)
                        .Include(e => e.PriorityFk)
                        .Include(x => x.Users)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.Filter), e => false || e.ContactName.Contains(input.Filter) || e.CompanyName.Contains(input.Filter))
                        .WhereIf(!string.IsNullOrWhiteSpace(input.CompanyOrContactNameFilter), e => e.CompanyName.Contains(input.CompanyOrContactNameFilter) || e.ContactName.Contains(input.CompanyOrContactNameFilter))
                        .WhereIf(!string.IsNullOrWhiteSpace(input.ContactNameFilter), e => e.ContactName == input.ContactNameFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.ContactPositionFilter), e => e.ContactPosition == input.ContactPositionFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.WebSiteFilter), e => e.WebSite == input.WebSiteFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.AddressFilter), e => e.Address == input.AddressFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.CountryFilter), e => e.Country == input.CountryFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.StateFilter), e => e.State == input.StateFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.CityFilter), e => e.State == input.CityFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.DescriptionFilter), e => e.Notes == input.DescriptionFilter)
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
                        .WhereIf(!string.IsNullOrWhiteSpace(input.PriorityDescriptionFilter), e => e.PriorityFk != null && e.PriorityFk.Description == input.PriorityDescriptionFilter)
                        .WhereIf(input.LeadStatusId.HasValue, x => input.LeadStatusId == x.LeadStatusFk.Id)
                        .WhereIf(input.PriorityId.HasValue, x => input.PriorityId == x.PriorityFk.Id)
                        .WhereIf(input.UserIds.Any(), x => x.Users.Any(y => input.UserIds.Contains(y.UserId)));

            var query = (from o in filteredLeads
                         join o1 in _lookupLeadSourceRepository.GetAll() on o.LeadSourceId equals o1.Id into j1
                         from s1 in j1.DefaultIfEmpty()

                         join o2 in _lookupLeadStatusRepository.GetAll() on o.LeadStatusId equals o2.Id into j2
                         from s2 in j2.DefaultIfEmpty()

                         join o3 in _lookupPriorityRepository.GetAll() on o.PriorityId equals o3.Id into j3
                         from s3 in j3.DefaultIfEmpty()

                         select new LeadQueryDto
                         {
                             CompanyName = o.CompanyName,
                             ContactName = o.ContactName,
                             ContactPosition = o.ContactPosition,
                             WebSite = o.WebSite,
                             Address = o.Address,
                             Country = o.Country,
                             State = o.State,
                             City = o.City,
                             Notes = o.Notes,
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
                             CreationTime = o.CreationTime,
                             Users = o.Users,
                             LeadSourceDescription = s1 == null || s1.Description == null ? "" : s1.Description.ToString(),
                             LeadStatusDescription = s2 == null || s2.Description == null ? "" : s2.Description.ToString(),
                             PriorityDescription = s3 == null || s3.Description == null ? "" : s3.Description.ToString(),
                             PriorityColor = s3 == null || s3.Color == null ? "" : s3.Color
                         });

            var dbList = await query.ToListAsync();
            var leads = GetLeadForViewDtos(dbList);

            return _leadsExcelExporter.ExportToFile(leads);
        }

        /// <summary>
        /// Get list of Lead Query Dtos for view
        /// </summary>
        /// <param name="dbList"></param>
        /// <returns></returns>
        private static List<GetLeadForViewDto> GetLeadForViewDtos(List<LeadQueryDto> dbList)
        {
            var results = new List<GetLeadForViewDto>();

            foreach (var o in dbList)
            {
                var res = new GetLeadForViewDto
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
                        Notes = o.Notes,
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
                    LeadCanBeConvert = o.LeadCanBeConvert,
                    LeadStatusColor = o.LeadStatusColor,
                    PriorityDescription = o.PriorityDescription,
                    PriorityColor = o.PriorityColor
                };

                if (o.Users.Any())
                {
                    var leadUsers = o.Users
                        .Select(x => new LeadUserViewDto
                        {
                            LeadId = x.Id,
                            UserId = x.UserFk.Id,
                            Name = x.UserFk.Name,
                            SurName = x.UserFk.Surname,
                            FullName = x.UserFk.FullName,
                            ProfilePictureUrl = x.UserFk.ProfilePictureId
                        }).ToList();
                    res.Lead.Users = leadUsers;
                    var leadUser = leadUsers.OrderBy(x => x.Name).First();
                    res.FirstUserAssignedName = leadUser.Name;
                    res.FirstUserAssignedSurName = leadUser.SurName;
                    res.FirstUserAssignedFullName = leadUser.FullName;
                    res.FirstUserProfilePictureUrl = leadUser.ProfilePictureUrl;
                    res.FirstUserAssignedId = leadUser.UserId;
                    res.AssignedUsers = leadUsers.Count;
                }

                results.Add(res);
            }

            return results;
        }

        /// <summary>
        /// Get Lead Source type dropdown
        /// </summary>
        /// <returns></returns>
        [AbpAuthorize(AppPermissions.Pages_Leads)]
        public async Task<List<LeadLeadSourceLookupTableDto>> GetAllLeadSourceForTableDropdown()
        {
            return await _lookupLeadSourceRepository.GetAll()
                .Select(leadSource => new LeadLeadSourceLookupTableDto
                {
                    Id = leadSource.Id,
                    DisplayName = leadSource == null || leadSource.Description == null ? "" : leadSource.Description.ToString(),
                    IsDefault = leadSource.IsDefault
                }).ToListAsync();
        }

        /// <summary>
        /// Get Lead Source type dropdown
        /// </summary>
        /// <returns></returns>
        [AbpAuthorize(AppPermissions.Pages_Leads)]
        public async Task<List<LeadUserUserLookupTableDto>> GetAllUsersForTableDropdown()
        {
            return await _lookup_userRepository.GetAll()
                .Select(user => new LeadUserUserLookupTableDto
                {
                    Id = user.Id,
                    DisplayName = user == null || user.FullName == null ? string.Empty : user.FullName
                }).ToListAsync();
        }

        /// <summary>
        /// Get Lead Status type dropdown
        /// </summary>
        /// <returns></returns>
        [AbpAuthorize(AppPermissions.Pages_Leads)]
        public async Task<List<LeadLeadStatusLookupTableDto>> GetAllLeadStatusForTableDropdown()
        {
            return await _lookupLeadStatusRepository.GetAll()
                .Select(leadStatus => new LeadLeadStatusLookupTableDto
                {
                    Id = leadStatus.Id,
                    DisplayName = leadStatus == null || leadStatus.Description == null ? "" : leadStatus.Description.ToString(),
                    IsDefault = leadStatus.IsDefault,
                    isLeadConversionValid = leadStatus.IsLeadConversionValid
                }).ToListAsync();
        }

        /// <summary>
        /// Get Priorities type dropdown
        /// </summary>
        /// <returns></returns>
        [AbpAuthorize(AppPermissions.Pages_Leads)]
        public async Task<List<LeadPriorityLookupTableDto>> GetAllPriorityForTableDropdown()
        {
            return await _lookupPriorityRepository.GetAll()
                .Select(priority => new LeadPriorityLookupTableDto
                {
                    Id = priority.Id,
                    DisplayName = priority == null || priority.Description == null ? "" : priority.Description.ToString(),
                    IsDefault = priority.IsDefault
                }).ToListAsync();
        }
        
        
        /// <summary>
        /// Convert Lead in Account
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [AbpAuthorize(AppPermissions.Pages_Leads_Convert_Account)]
        public async Task ConvertToAccount(ConvertLeadToAccountRequestDto input)
        {
            var lead = await _leadRepository.GetAll()
                .Include(e => e.LeadStatusFk)
                .Where(x => x.Id == input.LeadId)
                .FirstOrDefaultAsync();

            var convertedStatusCode = "CONVERTED";
            var convertedStatus = await _lookupLeadStatusRepository.GetAll()
                .FirstOrDefaultAsync(x => convertedStatusCode == x.Code);

            GuardHelper.ThrowIf(lead is null, new UserFriendlyException(L("LeadNotExist")));
            GuardHelper.ThrowIf(!lead.LeadStatusFk.IsLeadConversionValid, new UserFriendlyException(L("LeadAlreadyConverted")));
            GuardHelper.ThrowIf(await _customerAppService.CheckIfExistByName(lead.CompanyName), new UserFriendlyException(L("CustomerWithSameNameAlreadyExists")));
            GuardHelper.ThrowIf(convertedStatus is null, new UserFriendlyException(L("LeadStatusNotExist", convertedStatusCode)));

            var accountTypes = await _customerAppService.GetAllAccountTypeForTableDropdown();
            var accountType = accountTypes.FirstOrDefault(x => x.IsDefault);

            GuardHelper.ThrowIf(accountType is null, new UserFriendlyException(L("ConvertedAccountTypeNotExist", convertedStatusCode)));
            
            var customerNumber = await _customerAppService.ConvertFromLead(
                new ConvertLeadToAccountDto(
                    lead: ObjectMapper.Map<LeadDto>(lead),
                    conversionAccountTypeId: accountType.Id)
                );

            lead.CustomerNumber = customerNumber;
            lead.LeadStatusId = convertedStatus.Id;

            using (_reasonProvider.Use("Lead converted to Account"))
            {
                await _leadRepository.UpdateAsync(lead);
                await _unitOfWorkManager.Current.SaveChangesAsync();
            }
        }

    }
}