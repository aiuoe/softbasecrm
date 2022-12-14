using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Entities;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Abp.EntityHistory;
using Abp.Linq.Extensions;
using Abp.UI;
using Microsoft.EntityFrameworkCore;
using SBCRM.Auditing;
using SBCRM.Auditing.Dto;
using SBCRM.Authorization;
using SBCRM.Authorization.Users;
using SBCRM.Common;
using SBCRM.Crm.Dtos;
using SBCRM.Crm.Exporting;
using SBCRM.DataImporting;
using SBCRM.Dto;
using SBCRM.Infrastructure.Excel;
using SBCRM.Legacy;
using SBCRM.Legacy.Dtos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Net;
using System.Threading.Tasks;

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
        private readonly ILeadAutomateAssignmentService _leadAutomateAssignment;

        private readonly string _assignedUserSortKey = "users.userFk.name";
        private readonly string _convertedStatusCode = "CONVERTED";
        private readonly IAuditEventsService _auditEventsService;

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
        /// <param name="auditEventsService"></param>
        /// <param name="leadAutomateAssignment"></param>
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
            IRepository<User, long> lookupUserRepository,
            IAuditEventsService auditEventsService,
            ILeadAutomateAssignmentService leadAutomateAssignment)
        {
            _auditEventsService = auditEventsService;
            _countryRepository = countryRepository;
            _customerAppService = customerAppService;
            _leadAutomateAssignment = leadAutomateAssignment;
            _leadRepository = leadRepository;
            _leadsExcelExporter = leadsExcelExporter;
            _leadUserRepository = leadUserRepository;
            _lookup_userRepository = lookupUserRepository;
            _lookupLeadSourceRepository = lookupLeadSourceRepository;
            _lookupLeadStatusRepository = lookupLeadStatusRepository;
            _lookupPriorityRepository = lookupPriorityRepository;
            _reasonProvider = reasonProvider;
            _unitOfWorkManager = unitOfWorkManager;
        }

        /// <summary>
        /// Get visibility for Lead Tabs based on permissions
        /// </summary>
        /// <param name="leadId"></param>
        /// <returns></returns>
        [AbpAllowAnonymous]
        public async Task<LeadVisibilityTabDto> GetVisibilityTabsPermissions(int leadId)
        {
            var visibilityTabs = new LeadVisibilityTabDto();

            var currentUser = await GetCurrentUserAsync();
            var lead = await _leadRepository
                .GetAll()
                .Include(x => x.LeadStatusFk)
                .Include(x => x.Users)
                .Where(x => x.Id == leadId)
                .Select(x => x).FirstOrDefaultAsync();

            if (lead != null)
            {
                var leadIsConverted = lead.LeadStatusFk.Code == _convertedStatusCode;
                var currentUserIsAssignedInLead = lead.Users.Any(x => x.UserId == currentUser.Id);

                // Analyze permission for Edit of Overview Tab
                var hasEditOverviewStaticPermission = await UserManager.IsGrantedAsync(currentUser.Id, AppPermissions.Pages_Leads_Edit);
                visibilityTabs.CanEditOverviewTab = !leadIsConverted && (hasEditOverviewStaticPermission || currentUserIsAssignedInLead);
            }

            return visibilityTabs;
        }

        /// <summary>
        /// Get the dynamic permission based on the current user.
        /// The user will be shown all the leads if he has permission for it
        /// </summary>
        /// <returns></returns>
        public bool CurrentUserCanSeeAllLeads()
        {
            User currentUser = GetCurrentUser();
            return UserManager.IsGranted(
                currentUser.Id, AppPermissions.Pages_Leads_ViewAllLeads__Dynamic);
        }

        /// <summary>
        /// Get the id of the current user.
        /// </summary>
        /// <returns></returns>
        public long GetCurrentUserId()
        {
            User currentUser = GetCurrentUser();
            return currentUser.Id;
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
                               .Include(e => e.PriorityFk)
                               .Include(x => x.Users)
                               .ThenInclude(x => x.UserFk)
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
                               .WhereIf(!string.IsNullOrWhiteSpace(input.PriorityDescriptionFilter), e => e.PriorityFk != null && e.PriorityFk.Description == input.PriorityDescriptionFilter)
                               .WhereIf(input.LeadStatusId.HasValue, x => input.LeadStatusId == x.LeadStatusFk.Id)
                               .WhereIf(input.PriorityId.HasValue, x => input.PriorityId == x.PriorityFk.Id)
                               .WhereIf(!CurrentUserCanSeeAllLeads(), x => x.Users != null && x.Users.Select(y => y.UserId).Contains(GetCurrentUserId()))
                               .WhereIf(input.UserIds.Any() && !input.UserIds.Contains(-1), x => x.Users.Any(y => input.UserIds.Contains(y.UserId)))
                               .WhereIf(input.UserIds.Contains(-1), x => !x.Users.Any());

                bool isAssignedUserSorting = input.Sorting != null && input.Sorting.StartsWith(_assignedUserSortKey);

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
                                CreationTime = o.CreationTime,
                                Users = ObjectMapper.Map<List<LeadUserDto>>(o.Users),
                                LeadSourceDescription = s1 == null || s1.Description == null ? "" : s1.Description.ToString(),
                                LeadStatusDescription = s2 == null || s2.Description == null ? "" : s2.Description.ToString(),
                                LeadCanBeConvert = s2 != null && s2.IsLeadConversionValid,
                                LeadStatusColor = s2 == null || s2.Color == null ? "" : s2.Color,
                                PriorityDescription = s3 == null || s3.Description == null ? "" : s3.Description.ToString(),
                                PriorityColor = s3 == null || s3.Color == null ? "" : s3.Color,
                                FirstUserAssignedName = (from s in _leadUserRepository.GetAll()
                                            .Include(x => x.UserFk)
                                                         where s.LeadId == o.Id
                                                         select s.UserFk.Name
                                    ).OrderBy(x => x).FirstOrDefault()
                            };

                    leads = leads
                            .OrderBy(input.Sorting)
                            .PageBy(input);
                }
                else
                {
                    if (input.Sorting != null)
                        leads = from o in (filteredLeads
                            .OrderBy(input.Sorting)
                            .PageBy(input))
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
                                CreationTime = o.CreationTime,
                                Users = ObjectMapper.Map<List<LeadUserDto>>(o.Users),
                                LeadSourceDescription = s1 == null || s1.Description == null ? "" : s1.Description.ToString(),
                                LeadStatusDescription = s2 == null || s2.Description == null ? "" : s2.Description.ToString(),
                                LeadCanBeConvert = s2 != null && s2.IsLeadConversionValid,
                                LeadStatusColor = s2 == null || s2.Color == null ? "" : s2.Color,
                                PriorityDescription = s3 == null || s3.Description == null ? "" : s3.Description.ToString(),
                                PriorityColor = s3 == null || s3.Color == null ? "" : s3.Color
                            };

                    else
                        leads = from o in (filteredLeads
                            .OrderByDescending(o => o.CreationTime)
                            .ThenByDescending(o => o.LeadSourceFk.Description)
                            .ThenBy(o => o.LeadStatusFk.Description)
                            .ThenBy(o => o.CompanyName)
                            .ThenBy(o => o.ContactName)
                            .PageBy(input))   
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
                                CreationTime = o.CreationTime,
                                Users = ObjectMapper.Map<List<LeadUserDto>>(o.Users),
                                LeadSourceDescription = s1 == null || s1.Description == null ? "" : s1.Description.ToString(),
                                LeadStatusDescription = s2 == null || s2.Description == null ? "" : s2.Description.ToString(),
                                LeadCanBeConvert = s2 != null && s2.IsLeadConversionValid,
                                LeadStatusColor = s2 == null || s2.Color == null ? "" : s2.Color,
                                PriorityDescription = s3 == null || s3.Description == null ? "" : s3.Description.ToString(),
                                PriorityColor = s3 == null || s3.Color == null ? "" : s3.Color
                            };


                }

                int totalCount = await filteredLeads.CountAsync();

                List<LeadQueryDto> dbList = await leads.ToListAsync();
                List<GetLeadForViewDto> results = GetLeadForViewDtos(dbList);

                foreach (GetLeadForViewDto result in results)
                {
                    var isUserAssignedToLead = VerifyUserIsAssignedLead(result);
                    result.CanViewActivityWidget = HasAccessActivityWidget(isUserAssignedToLead);
                    result.CanCreateActivity = HasAccessCreateActivity(isUserAssignedToLead);
                    result.CanViewScheduleMeetingOption = HasAccessToScheduleMeeting(isUserAssignedToLead);
                    result.CanViewScheduleCallOption = HasAccessToScheduleCall(isUserAssignedToLead);
                    result.CanViewEmailReminderOption = HasAccessToEmailReminder(isUserAssignedToLead);
                    result.CanViewToDoReminderOption = HasAccessToDoReminder(isUserAssignedToLead);
                    result.CanEditActivity = HasAccessEditActivity(isUserAssignedToLead);
                    result.CanAssignAnyUserInActivity = CanAssignAnyUserWhenCreatingOrUpdatingAnActivity();
                    result.CanViewAttachmentsWidget = CanViewAttachmentsWidget(isUserAssignedToLead);
                }

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
        public FileDto GetDuplicatedLeadsToExcel(List<LeadDto> leads)
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
                List<LeadImportedInputDto> leadsToImport = ExcelHandler.ReadIntoList<LeadImportedInputDto>(inputFile, startFromRow: 2, allowEverySheet: false);

                List<CreateOrEditLeadDto> duplicatedLeads = new List<CreateOrEditLeadDto>();

                if (!await ValidateLeadsImported(leadsToImport))
                {
                    throw new UserFriendlyException(L("ErrorUploadingMessage"));
                }

                // Default status and priority
                LeadStatus leadStatusId = await _lookupLeadStatusRepository.FirstOrDefaultAsync(p => p.IsDefault);
                Priority leadPriorityId = await _lookupPriorityRepository.FirstOrDefaultAsync(p => p.IsDefault);

                foreach (LeadImportedInputDto item in leadsToImport)
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

                    Lead storedLead = null;

                    if (item.ContactName != null)
                    {
                        storedLead = _leadRepository.GetAllList().Find(l => l.CompanyName == leadAux.CompanyName && l.ContactName == leadAux.ContactName);
                    }

                    if (storedLead == null)
                    {
                        Lead lead = ObjectMapper.Map<Lead>(leadAux);
                        int leadId = 0;
                        using (_reasonProvider.Use("Lead saved from an import file"))
                        {
                            leadId = await _leadRepository.InsertAndGetIdAsync(lead);
                            await _unitOfWorkManager.Current.SaveChangesAsync();
                        }

                        if (assignedUserId != 0)
                        {
                            LeadUser leadUser = new LeadUser
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
        private async Task<bool> ValidateLeadsImported(List<LeadImportedInputDto> importedLeads)
        {
            foreach (LeadImportedInputDto item in importedLeads)
            {
                // Validations for mandarory fields
                if (item.CompanyName == null || (item.Phone == null && item.CompanyEmail == null))
                {
                    return false;
                }

                // Validations for country field
                List<Country> existingCountries = await _countryRepository.GetAllListAsync();
                if (item.Country != null && !existingCountries.Any(p => p.Name.ToUpper().Trim() == item.Country.ToUpper().Trim()))
                {
                    return false;
                }

                // Validations for specific format fields
                EmailAddressAttribute emailValidator = new EmailAddressAttribute();
                if ((item.CompanyEmail != null && !emailValidator.IsValid(item.CompanyEmail))
                    || (item.ContactEmail != null && !emailValidator.IsValid(item.ContactEmail))
                    || (item.Website != null && !Uri.IsWellFormedUriString(item.Website.ToString(), UriKind.RelativeOrAbsolute)))
                {
                    return false;
                }

                // Validation for limit size in every field (See the SRS to further information about the field limit size)
                bool isNotValidLength = new BulkValidations().AppendCondition(item.CompanyName.ExceedLength(250))
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
            Lead lead = await _leadRepository.GetAsync(id);
            await _leadRepository.EnsureCollectionLoadedAsync(lead, x => x.Users);

            GetLeadForViewDto output = new GetLeadForViewDto { Lead = ObjectMapper.Map<LeadDto>(lead) };

            if (output.Lead.LeadSourceId != null)
            {
                LeadSource _lookupLeadSource = await _lookupLeadSourceRepository.FirstOrDefaultAsync((int)output.Lead.LeadSourceId);
                output.LeadSourceDescription = _lookupLeadSource?.Description?.ToString();
            }

            if (output.Lead.LeadStatusId != null)
            {
                LeadStatus _lookupLeadStatus = await _lookupLeadStatusRepository.FirstOrDefaultAsync((int)output.Lead.LeadStatusId);
                output.LeadStatusDescription = _lookupLeadStatus?.Description?.ToString();
            }

            if (output.Lead.PriorityId != null)
            {
                Priority _lookupPriority = await _lookupPriorityRepository.FirstOrDefaultAsync((int)output.Lead.PriorityId);
                output.PriorityDescription = _lookupPriority?.Description?.ToString();
            }

            var isUserAssignedToLead = VerifyUserIsAssignedLead(output);
            output.CanViewActivityWidget = HasAccessActivityWidget(isUserAssignedToLead);
            output.CanCreateActivity = HasAccessCreateActivity(isUserAssignedToLead);
            output.CanViewScheduleMeetingOption = HasAccessToScheduleMeeting(isUserAssignedToLead);
            output.CanViewScheduleCallOption = HasAccessToScheduleCall(isUserAssignedToLead);
            output.CanViewEmailReminderOption = HasAccessToEmailReminder(isUserAssignedToLead);
            output.CanViewToDoReminderOption = HasAccessToDoReminder(isUserAssignedToLead);
            output.CanEditActivity = HasAccessEditActivity(isUserAssignedToLead);
            output.CanAssignAnyUserInActivity = CanAssignAnyUserWhenCreatingOrUpdatingAnActivity();
            output.CanViewAttachmentsWidget = CanViewAttachmentsWidget(isUserAssignedToLead);

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
            Lead lead;

            if (CurrentUserCanSeeAllLeads())
            {
                lead = await _leadRepository.FirstOrDefaultAsync(input.Id);
            }
            else
            {
                lead = await _leadUserRepository.GetAll()
                    .Include(x => x.UserFk)
                    .Include(x => x.LeadFk)
                    .Where(x => x.UserId == GetCurrentUser().Id && x.LeadId == input.Id)
                    .Select(x => x.LeadFk)
                    .FirstOrDefaultAsync();
            }

            GuardHelper.ThrowIf(lead == null, new EntityNotFoundException(L("LeadNotExist")));

            await _leadRepository.EnsurePropertyLoadedAsync(lead, x => x.LeadStatusFk);
            await _leadRepository.EnsureCollectionLoadedAsync(lead, x => x.Users);

            //GuardHelper.ThrowIf(lead.LeadStatusFk.Code == _convertedStatusCode, new UserFriendlyException(L("LeadAlreadyConvertedForEdit")));

            GetLeadForEditOutput output = new GetLeadForEditOutput { Lead = ObjectMapper.Map<CreateOrEditLeadDto>(lead) };

            if (output.Lead.LeadSourceId != null)
            {
                LeadSource _lookupLeadSource = await _lookupLeadSourceRepository.FirstOrDefaultAsync((int)output.Lead.LeadSourceId);
                output.LeadSourceDescription = _lookupLeadSource?.Description;
            }

            if (output.Lead.LeadStatusId != null)
            {
                LeadStatus _lookupLeadStatus = await _lookupLeadStatusRepository.FirstOrDefaultAsync((int)output.Lead.LeadStatusId);
                output.LeadStatusDescription = _lookupLeadStatus?.Description;
            }

            if (output.Lead.PriorityId != null)
            {
                Priority _lookupPriority = await _lookupPriorityRepository.FirstOrDefaultAsync((int)output.Lead.PriorityId);
                output.PriorityDescription = _lookupPriority?.Description;
            }

            var isUserAssignedToLead = lead.Users?.Any(x => x.UserId == GetCurrentUserId()) ?? false;
            output.CanViewActivityWidget = HasAccessActivityWidget(isUserAssignedToLead);
            output.CanCreateActivity = HasAccessCreateActivity(isUserAssignedToLead);
            output.CanViewScheduleMeetingOption = HasAccessToScheduleMeeting(isUserAssignedToLead);
            output.CanViewScheduleCallOption = HasAccessToScheduleCall(isUserAssignedToLead);
            output.CanViewEmailReminderOption = HasAccessToEmailReminder(isUserAssignedToLead);
            output.CanViewToDoReminderOption = HasAccessToDoReminder(isUserAssignedToLead);
            output.CanEditActivity = HasAccessEditActivity(isUserAssignedToLead);
            output.CanAssignAnyUserInActivity = CanAssignAnyUserWhenCreatingOrUpdatingAnActivity();
            output.CanViewAttachmentsWidget = CanViewAttachmentsWidget(isUserAssignedToLead);


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
            Lead lead = ObjectMapper.Map<Lead>(input);

            lead.CreationTime = lead.CreationTime.ToUniversalTime();

            lead.TenantId = GetTenantId();

            using (_reasonProvider.Use("Lead created"))
            {
                Lead existingLead = await _leadRepository
                    .FirstOrDefaultAsync(l => l.CompanyName.ToLower() == lead.CompanyName.ToLower()
                                           && l.ContactName.ToLower() == lead.ContactName.ToLower());

                if (existingLead is not null)
                {
                    throw new UserFriendlyException((int)HttpStatusCode.BadRequest, L("DuplicatedLead"));
                }

                await _leadRepository.InsertAsync(lead);
                await _unitOfWorkManager.Current.SaveChangesAsync();

                // Automate Assignment
                User currentUser = await GetCurrentUserAsync();
                bool hasDynamicPermission = await UserManager.IsGrantedAsync(currentUser.Id, AppPermissions.Pages_LeadUsers_AutomateAssignment__Dynamic);
                if (hasDynamicPermission)
                {
                    List<CreateOrEditLeadUserDto> listLeadUser = new List<CreateOrEditLeadUserDto>
                    {
                        new()
                        {
                            LeadId = lead.Id,
                            UserId = currentUser.Id
                        }
                    };

                    await _leadAutomateAssignment.AssignLeadUsersAsync(listLeadUser);
                }
            }
        }

        /// <summary>
        /// Update lead
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [AbpAuthorize(AppPermissions.Pages_Leads_Edit)]
        protected virtual async Task Update(CreateOrEditLeadDto input)
        {
            Lead lead = await _leadRepository
                .GetAll()
                .Include(x => x.LeadStatusFk)
                .FirstOrDefaultAsync(x => x.Id == input.Id);

            lead.CreationTime = lead.CreationTime.ToUniversalTime();
            Lead existingLead = await _leadRepository
                .FirstOrDefaultAsync(l => l.Id != (int)input.Id && (l.CompanyName.ToLower() == input.CompanyName.ToLower()
                                                                    && l.ContactName.ToLower() == input.ContactName.ToLower()));

            GuardHelper.ThrowIf(existingLead is not null, new UserFriendlyException(L("DuplicatedLead")));
            GuardHelper.ThrowIf(lead.LeadStatusFk.Code == _convertedStatusCode, new UserFriendlyException(L("LeadAlreadyConvertedForEdit")));

            using (_reasonProvider.Use("Lead updated"))
            {
                ObjectMapper.Map(input, lead);
                await _unitOfWorkManager.Current.SaveChangesAsync();
            }
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
            TimeZoneInfo TimeZone =
                    TimeZoneInfo.FindSystemTimeZoneById(input.TimeZone);

            IQueryable<Lead> filteredLeads = _leadRepository.GetAll()
                        .Include(e => e.LeadSourceFk)
                        .Include(e => e.LeadStatusFk)
                        .Include(e => e.PriorityFk)
                        .Include(x => x.Users)
                        .ThenInclude(x => x.UserFk)
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
                        .WhereIf(!string.IsNullOrWhiteSpace(input.PriorityDescriptionFilter), e => e.PriorityFk != null && e.PriorityFk.Description == input.PriorityDescriptionFilter)
                        .WhereIf(input.LeadStatusId.HasValue, x => input.LeadStatusId == x.LeadStatusFk.Id)
                        .WhereIf(input.PriorityId.HasValue, x => input.PriorityId == x.PriorityFk.Id)
                        .WhereIf(!CurrentUserCanSeeAllLeads(), x => x.Users != null && x.Users.Select(y => y.UserId).Contains(GetCurrentUserId()))
                        .WhereIf(input.UserIds.Any(), x => x.Users.Any(y => input.UserIds.Contains(y.UserId)))
                        .WhereIf(input.UserIds.Contains(-1), x => !x.Users.Any());

            IQueryable<LeadQueryDto> query = (from o in filteredLeads
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
                                                  CreationTime = TimeZoneInfo.ConvertTime((DateTime)o.CreationTime, TimeZone),
                                                  Users = ObjectMapper.Map<List<LeadUserDto>>(o.Users),
                                                  LeadSourceDescription = s1 == null || s1.Description == null ? "" : s1.Description.ToString(),
                                                  LeadStatusDescription = s2 == null || s2.Description == null ? "" : s2.Description.ToString(),
                                                  PriorityDescription = s3 == null || s3.Description == null ? "" : s3.Description.ToString(),
                                                  PriorityColor = s3 == null || s3.Color == null ? "" : s3.Color
                                              });

            List<LeadQueryDto> dbList = await query.ToListAsync();
            List<GetLeadForViewDto> leads = GetLeadForViewDtos(dbList);

            return _leadsExcelExporter.ExportToFile(leads);
        }

        /// <summary>
        /// Get list of Lead Query Dtos for view
        /// </summary>
        /// <param name="dbList"></param>
        /// <returns></returns>
        private static List<GetLeadForViewDto> GetLeadForViewDtos(List<LeadQueryDto> dbList)
        {
            List<GetLeadForViewDto> results = new List<GetLeadForViewDto>();

            foreach (LeadQueryDto o in dbList)
            {
                GetLeadForViewDto res = new GetLeadForViewDto
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
                    LeadCanBeConvert = o.LeadCanBeConvert,
                    LeadStatusColor = o.LeadStatusColor,
                    PriorityDescription = o.PriorityDescription,
                    PriorityColor = o.PriorityColor
                };

                if (o.Users.Any())
                {
                    List<LeadUserViewDto> leadUsers = o.Users
                        .Select(x => new LeadUserViewDto
                        {
                            LeadId = x.LeadId,
                            UserId = x.UserId,
                            Name = x.UserFk.Name,
                            SurName = x.UserFk.Surname,
                            FullName = x.UserFk.FullName,
                            ProfilePictureUrl = x.UserFk.ProfilePictureId
                        }).ToList();
                    res.Lead.Users = leadUsers;
                    LeadUserViewDto leadUser = leadUsers.OrderBy(x => x.Name).First();
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
                .OrderBy(o => o.Order)
                .Select(leadSource => new LeadLeadSourceLookupTableDto
                {
                    Id = leadSource.Id,
                    DisplayName = leadSource == null || leadSource.Description == null ? "" : leadSource.Description.ToString()
                }).ToListAsync();
        }

        /// <summary>
        /// Get Lead Users type dropdown
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
                .OrderBy(o => o.Order)
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
            Lead lead = await _leadRepository.GetAll()
                .Include(e => e.LeadStatusFk)
                .Where(x => x.Id == input.LeadId)
                .FirstOrDefaultAsync();
            
            LeadStatus convertedStatus = await _lookupLeadStatusRepository.GetAll()
                .FirstOrDefaultAsync(x => _convertedStatusCode == x.Code);

            GuardHelper.ThrowIf(lead is null, new UserFriendlyException(L("LeadNotExist")));
            GuardHelper.ThrowIf(!lead.LeadStatusFk.IsLeadConversionValid, new UserFriendlyException(L("LeadAlreadyConverted")));
            GuardHelper.ThrowIf(await _customerAppService.CheckIfExistByName(lead.CompanyName), new UserFriendlyException(L("CustomerWithSameNameAlreadyExists")));
            GuardHelper.ThrowIf(convertedStatus is null, new UserFriendlyException(L("LeadStatusNotExist", _convertedStatusCode)));

            List<CustomerAccountTypeLookupTableDto> accountTypes = await _customerAppService.GetAllAccountTypeForTableDropdown();
            CustomerAccountTypeLookupTableDto accountType = accountTypes.FirstOrDefault(x => x.IsDefault);

            GuardHelper.ThrowIf(accountType is null, new UserFriendlyException(L("ConvertedAccountTypeNotExist", _convertedStatusCode)));

            string customerNumber = await _customerAppService.ConvertFromLead(
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

        /// <summary>
        /// Get al events
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [AbpAuthorize(AppPermissions.Pages_Leads_View_Events)]
        public async Task<PagedResultDto<EntityChangeListDto>> GetEntityTypeChanges(GetCrmEntityTypeChangeInput input)
        {
            input.EntityTypeFullName = typeof(Lead).FullName;
            return await _auditEventsService.GetEntityTypeChanges(ObjectMapper.Map<GetEntityTypeChangeInput>(input));
        }

        /// <summary>
        /// Verify if the current user is assigned to the specified Lead
        /// </summary>
        /// <param name="lead"></param>
        /// <returns></returns>
        private bool VerifyUserIsAssignedLead(GetLeadForViewDto lead)
        {
            long currentUserId = GetCurrentUser().Id;
            return lead?.Lead?.Users?.Any(x => x.UserId == currentUserId) ?? false;
        }

        /// <summary>
        /// Get the dynamic permission based on the current user.
        /// </summary>
        /// <returns></returns>
        internal bool HasAccessToScheduleMeeting(bool isUserAssignedToLead)
        {
            var currentUser = GetCurrentUser();
            return UserManager.IsGranted(currentUser.Id, AppPermissions.Pages_Leads_ScheduleMeeting) ||
                (UserManager.IsGranted(currentUser.Id, AppPermissions.Pages_Leads_ScheduleMeeting__Dynamic) && isUserAssignedToLead);
        }

        /// <summary>
        /// Get the dynamic permission based on the current user.
        /// </summary>
        /// <returns></returns>
        internal bool HasAccessToScheduleCall(bool isUserAssignedToLead)
        {
            var currentUser = GetCurrentUser();
            return UserManager.IsGranted(currentUser.Id, AppPermissions.Pages_Leads_ScheduleCall) ||
                (UserManager.IsGranted(currentUser.Id, AppPermissions.Pages_Leads_ScheduleCall__Dynamic) && isUserAssignedToLead);
        }

        /// <summary>
        /// Get the dynamic permission based on the current user.
        /// </summary>
        /// <returns></returns>
        internal bool HasAccessToEmailReminder(bool isUserAssignedToLead)
        {
            var currentUser = GetCurrentUser();
            return UserManager.IsGranted(currentUser.Id, AppPermissions.Pages_Leads_EmailReminder) ||
                (UserManager.IsGranted(currentUser.Id, AppPermissions.Pages_Leads_EmailReminder__Dynamic) && isUserAssignedToLead);
        }

        /// <summary>
        /// Get the dynamic permission based on the current user.
        /// </summary>
        /// <returns></returns>
        internal bool HasAccessToDoReminder(bool isUserAssignedToLead)
        {
            var currentUser = GetCurrentUser();
            return UserManager.IsGranted(currentUser.Id, AppPermissions.Pages_Leads_ToDoReminder) ||
                (UserManager.IsGranted(currentUser.Id, AppPermissions.Pages_Leads_ToDoReminder__Dynamic) && isUserAssignedToLead);
        }

        /// <summary>
        /// Check whether the current user can view the Leads Activity widget.
        /// The user can see the widget if any of these conditions are met:
        /// 1. The current user has <see cref="AppPermissions.Pages_Leads_View_Activities_Of_All_Users"/> permission, which is oriented for Managers., OR...
        /// 2. The current user has <see cref="AppPermissions.Pages_Leads_View_Activities"/> permission and also assigned to the Lead
        /// </summary>
        /// <param name="isUserAssignedToLead">Is the current user assigned to the Lead?</param>
        /// <returns>True or False</returns>
        internal bool HasAccessActivityWidget(bool isUserAssignedToLead)
        {
            var currentUser = GetCurrentUser();

            var canViewAllActivities = UserManager.IsGranted(currentUser.Id, AppPermissions.Pages_Leads_View_Activities_Of_All_Users);
            var canViewActivities = UserManager.IsGranted(currentUser.Id, AppPermissions.Pages_Leads_View_Activities);

            return canViewAllActivities || (canViewActivities && isUserAssignedToLead);
        }

        /// <summary>
        /// Check whether the current user can create an activity for the Leads.
        /// </summary>
        /// <returns>True or False</returns>
        internal bool HasAccessCreateActivity(bool isUserAssignedToLead)
        {
            var currentUser = GetCurrentUser();

            var canCreateActivities = UserManager.IsGranted(currentUser.Id, AppPermissions.Pages_Leads_Create_Activities);
            var canCreateActivitiesDynamic = UserManager.IsGranted(currentUser.Id, AppPermissions.Pages_Leads_Create_Activities__Dynamic);

            return canCreateActivities || (canCreateActivitiesDynamic && isUserAssignedToLead);
        }

        /// <summary>
        /// Check whether the current user can edit an activity of Leads.
        /// </summary>
        /// <returns>True or False</returns>
        internal bool HasAccessEditActivity(bool isUserAssignedToLead)
        {
            var currentUser = GetCurrentUser();

            var canEditActivity = UserManager.IsGranted(currentUser.Id, AppPermissions.Pages_Leads_Edit_Activities);
            var canEditActivityDynamic = UserManager.IsGranted(currentUser.Id, AppPermissions.Pages_Leads_Edit_Activities__Dynamic);

            return canEditActivity || (canEditActivityDynamic && isUserAssignedToLead);
        }

        /// <summary>
        /// Check whether the current user can view all activities of all users in Leads.
        /// </summary>
        /// <returns>True or False</returns>
        internal bool CanViewAllActivitiesOfAllUsers()
        {
            var currentUser = GetCurrentUser();
            return UserManager.IsGranted(currentUser.Id, AppPermissions.Pages_Leads_View_Activities_Of_All_Users);
        }

        /// <summary>
        /// Check whether the current user can assign any user.
        /// </summary>
        /// <returns>True or False</returns>
        internal bool CanAssignAnyUserWhenCreatingOrUpdatingAnActivity()
        {
            var currentUser = GetCurrentUser();
            return UserManager.IsGranted(currentUser.Id, AppPermissions.Pages_Leads_Assign_Activity_To_Any_Users);
        }

        /// <summary>
        /// Check whether the current user can view attachments on Leads.
        /// </summary>
        /// <returns>True or False</returns>
        internal bool CanViewAttachmentsWidget(bool isUserAssignedToLead)
        {
            var currentUser = GetCurrentUser();

            var canViewAttachmentsWidget = UserManager.IsGranted(currentUser.Id, AppPermissions.Pages_Leads_View_Attachments);
            var canViewAttachmentsWidgetDynamic = UserManager.IsGranted(currentUser.Id, AppPermissions.Pages_Leads_View_Attachments__Dynamic);

            return canViewAttachmentsWidget || (canViewAttachmentsWidgetDynamic && isUserAssignedToLead);
        }
    }
}