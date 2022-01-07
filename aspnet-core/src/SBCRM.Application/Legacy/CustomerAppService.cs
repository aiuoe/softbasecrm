using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Uow;
using Abp.EntityHistory;
using Abp.Linq.Extensions;
using Abp.UI;
using Castle.Components.DictionaryAdapter;
using Microsoft.EntityFrameworkCore;
using SBCRM.Auditing;
using SBCRM.Auditing.Dto;
using SBCRM.Authorization;
using SBCRM.Authorization.Users;
using SBCRM.Base;
using SBCRM.Common;
using SBCRM.Crm;
using SBCRM.Crm.Dtos;
using SBCRM.Dto;
using SBCRM.Legacy.Dto;
using SBCRM.Legacy.Dtos;
using SBCRM.Legacy.Exporting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using BaseRepo = Abp.Domain.Repositories;
using Abp.Domain.Entities;

namespace SBCRM.Legacy
{
    /// <summary>
    /// App service to handle Accounts(Customers) information
    /// </summary>
    public class CustomerAppService : SBCRMAppServiceBase, ICustomerAppService
    {
        private readonly BaseRepo.IRepository<Customer> _customerRepository;
        private readonly BaseRepo.IRepository<AccountType> _lookupAccountTypeRepository;
        private readonly BaseRepo.IRepository<LeadSource> _lookupLeadSourceRepository;
        private readonly BaseRepo.IRepository<Country> _lookupCountryRepository;
        private readonly BaseRepo.IRepository<AccountUser> _accountUserRepository;
        private readonly BaseRepo.IRepository<Opportunity> _opportunityRepository;
        private readonly BaseRepo.IRepository<User, long> _lookupUserRepository;
        private readonly ICustomerExcelExporter _customerExcelExporter;
        private readonly ISoftBaseCustomerInvoiceRepository _customerCustomerInvoiceRepository;
        private readonly ISoftBaseCustomerEquipmentRepository _customerEquipmentRepository;
        private readonly ISoftBaseCustomerWipRepository _customerWipRepository;
        private readonly IEntityChangeSetReasonProvider _reasonProvider;
        private readonly IUnitOfWorkManager _unitOfWorkManager;
        private readonly ISoftBaseCustomerSequenceRepository _customerSequenceRepository;
        private readonly IContactsAppService _contactsAppService;
        private readonly IAuditEventsService _auditEventsService;
        private readonly IAccountAutomateAssignmentService _accountAutomateAssignment;

        private readonly string _assignedUserSortKey = "users.userFk.name";

        /// <summary>
        /// Base constructor
        /// </summary>
        /// <param name="customerRepository"></param>
        /// <param name="customerExcelExporter"></param>
        /// <param name="lookupAccountTypeRepository"></param>
        /// <param name="lookupLeadSourceRepository"></param>
        /// <param name="opportunityRepository"></param>
        /// <param name="lookupUserRepository"></param>
        /// <param name="customerCustomerInvoiceRepository"></param>
        /// <param name="customerEquipmentRepository"></param>
        /// <param name="customerWipRepository"></param>
        /// <param name="accountUserRepository"></param>
        /// <param name="reasonProvider"></param>
        /// <param name="unitOfWorkManager"></param>
        /// <param name="customerSequenceRepository"></param>
        /// <param name="contactsAppService"></param>
        /// <param name="lookupCountryRepository"></param>
        /// <param name="auditEventsService"></param>
        /// <param name="accountAutomateAssignment"></param>
        public CustomerAppService(
            BaseRepo.IRepository<Customer> customerRepository,
            BaseRepo.IRepository<Country> lookupCountryRepository,
            BaseRepo.IRepository<AccountType> lookupAccountTypeRepository,
            BaseRepo.IRepository<LeadSource> lookupLeadSourceRepository,
            BaseRepo.IRepository<AccountUser> accountUserRepository,
            BaseRepo.IRepository<Opportunity> opportunityRepository,
            BaseRepo.IRepository<User, long> lookupUserRepository,
            ISoftBaseCustomerInvoiceRepository customerCustomerInvoiceRepository,
            ISoftBaseCustomerEquipmentRepository customerEquipmentRepository,
            ISoftBaseCustomerWipRepository customerWipRepository,
            IEntityChangeSetReasonProvider reasonProvider,
            IUnitOfWorkManager unitOfWorkManager,
            ISoftBaseCustomerSequenceRepository customerSequenceRepository,
            IContactsAppService contactsAppService,
            ICustomerExcelExporter customerExcelExporter,
            IAuditEventsService auditEventsService,
            IAccountAutomateAssignmentService accountAutomateAssignment)
        {
            _accountAutomateAssignment = accountAutomateAssignment;
            _accountUserRepository = accountUserRepository;
            _auditEventsService = auditEventsService;
            _contactsAppService = contactsAppService;
            _customerCustomerInvoiceRepository = customerCustomerInvoiceRepository;
            _customerEquipmentRepository = customerEquipmentRepository;
            _customerExcelExporter = customerExcelExporter;
            _customerRepository = customerRepository;
            _customerSequenceRepository = customerSequenceRepository;
            _customerWipRepository = customerWipRepository;
            _lookupAccountTypeRepository = lookupAccountTypeRepository;
            _lookupCountryRepository = lookupCountryRepository;
            _lookupLeadSourceRepository = lookupLeadSourceRepository;
            _lookupUserRepository = lookupUserRepository;
            _opportunityRepository = opportunityRepository;
            _reasonProvider = reasonProvider;
            _unitOfWorkManager = unitOfWorkManager;
        }

        /// <summary>
        /// Get visibility for Customer Tabs based on dynamic/static permissions
        /// </summary>
        /// <param name="customerNumber"></param>
        /// <returns></returns>
        [AbpAllowAnonymous]
        public async Task<CustomerVisibilityTabsDto> GetVisibilityTabsPermissions(string customerNumber)
        {
            var visibilityTabs = new CustomerVisibilityTabsDto
            {
                CanViewEquipmentsTab = true,
                CanViewInvoicesTab = true,
                CanViewWipTab = true
            };

            var currentUser = await GetCurrentUserAsync();
            var currentUserIsAssignedInCustomer = _accountUserRepository
                .GetAll()
                .Where(x => x.CustomerNumber == customerNumber)
                .Any(x => x.UserId == currentUser.Id);

            // Analyze dynamic permission for Visibility of Overview Tab
            var hasEditOverviewDynamicPermission = await UserManager.IsGrantedAsync(currentUser.Id, AppPermissions.Pages_Customer_Edit__Dynamic);
            var hasEditOverviewStaticPermission = await UserManager.IsGrantedAsync(currentUser.Id, AppPermissions.Pages_Customer_Edit);
            var canEditOverviewAssignedUsersDynamic = hasEditOverviewDynamicPermission && currentUserIsAssignedInCustomer;
            visibilityTabs.CanEditOverviewTab = canEditOverviewAssignedUsersDynamic || hasEditOverviewStaticPermission;

            // Analyze dynamic permission for Visibility of Events Tab
            var hasViewEventsDynamicPermission = await UserManager.IsGrantedAsync(currentUser.Id, AppPermissions.Pages_Customer_View_Events__Dynamic);
            var hasViewEventsStaticPermission = await UserManager.IsGrantedAsync(currentUser.Id, AppPermissions.Pages_Customer_View_Events);
            var canViewEventsAssignedUsersDynamic = hasViewEventsDynamicPermission && currentUserIsAssignedInCustomer;
            visibilityTabs.CanViewEventsTab = canViewEventsAssignedUsersDynamic || hasViewEventsStaticPermission;

            // Analyze dynamic permission for Visibility of Opportunities Tab
            var hasViewOpportunitiesDynamicPermission = await UserManager.IsGrantedAsync(currentUser.Id, AppPermissions.Pages_Customer_View_Opportunities__Dynamic);
            var hasViewOpportunitiesStaticPermission = await UserManager.IsGrantedAsync(currentUser.Id, AppPermissions.Pages_Customer_View_Opportunities);
            var canViewOpportunitiesAssignedUsersDynamic = hasViewOpportunitiesDynamicPermission && currentUserIsAssignedInCustomer;
            visibilityTabs.CanViewOpportunitiesTab = canViewOpportunitiesAssignedUsersDynamic || hasViewOpportunitiesStaticPermission;

            // Analyze dynamic permission for Visibility of Create Opportunity
            var hasCreateOpportunityDynamicPermission = await UserManager.IsGrantedAsync(currentUser.Id, AppPermissions.Pages_Customer_Add_Opportunity__Dynamic);
            var hasCreateOpportunityStaticPermission = await UserManager.IsGrantedAsync(currentUser.Id, AppPermissions.Pages_Customer_Add_Opportunity);
            var canCreateOpportunitiesAssignedUsersDynamic = hasCreateOpportunityDynamicPermission && currentUserIsAssignedInCustomer;
            visibilityTabs.CanCreateOpportunities = canCreateOpportunitiesAssignedUsersDynamic || hasCreateOpportunityStaticPermission;

            // Analyze dynamic permission for Visibility of Edit Opportunity
            var hasEditOpportunityDynamicPermission = await UserManager.IsGrantedAsync(currentUser.Id, AppPermissions.Pages_Customer_Edit_Opportunity__Dynamic);
            var hasEditOpportunityStaticPermission = await UserManager.IsGrantedAsync(currentUser.Id, AppPermissions.Pages_Customer_Edit_Opportunity);
            var canEditOpportunitiesAssignedUsersDynamic = hasEditOpportunityDynamicPermission || currentUserIsAssignedInCustomer;
            visibilityTabs.CanEditOpportunities = canEditOpportunitiesAssignedUsersDynamic || hasEditOpportunityStaticPermission;

            // Analyze dynamic permission for Visibility of View Opportunity
            visibilityTabs.CanViewOpportunities = visibilityTabs.CanEditOpportunities;

            return visibilityTabs;
        }

        /// <summary>
        /// Get all customers
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [AbpAuthorize(AppPermissions.Pages_Customer)]
        public async Task<PagedResultDto<GetCustomerForViewDto>> GetAll(GetAllCustomerInput input)
        {
            try
            {
                var filteredCustomer = _customerRepository.GetAll()
                        .Include(e => e.AccountTypeFk)
                        .Include(x => x.Users)
                        .ThenInclude(x => x.UserFk)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.Filter), e => e.Name.Contains(input.Filter))
                        .WhereIf(input.AccountTypeId.Any(), x => input.AccountTypeId.Contains(x.AccountTypeFk.Id))
                        .WhereIf(input.UserIds.Any(), x => x.Users.Any(y => input.UserIds.Contains(y.UserId)))
                        .Select(x => new
                        {
                            x.AccountTypeId,
                            AccountTypeDescription = x.AccountTypeFk.Description,
                            x.Number,
                            x.BillTo,
                            x.Name,
                            x.Address,
                            x.Phone,
                            x.AddedBy,
                            x.Added,
                            x.ChangedBy,
                            x.Changed,
                            x.Users
                        })
                    ;

                bool isAssignedUserSorting = input.Sorting != null && input.Sorting.StartsWith(_assignedUserSortKey);

                IQueryable<CustomerQueryDto> customer;

                if (isAssignedUserSorting)
                {
                    input.Sorting = input.Sorting.Replace(_assignedUserSortKey, $"{nameof(CustomerQueryDto.FirstUserAssignedName)}");

                    customer = from o in filteredCustomer
                               join o1 in _lookupAccountTypeRepository.GetAll() on o.AccountTypeId equals o1.Id into j1
                               from s1 in j1.DefaultIfEmpty()
                               select new CustomerQueryDto
                               {
                                   Number = o.Number,
                                   BillTo = o.BillTo,
                                   Name = o.Name,
                                   Address = o.Address,
                                   Phone = o.Phone,
                                   AddedBy = o.AddedBy,
                                   Added = o.Added,
                                   ChangedBy = o.ChangedBy,
                                   Changed = o.Changed,
                                   Users = o.Users,
                                   AccountTypeDescription = s1 == null || s1.Description == null ? string.Empty : s1.Description.ToString(),
                                   FirstUserAssignedName = (from s in _accountUserRepository.GetAll()
                                               .Include(x => x.UserFk)
                                                            where s.CustomerNumber == o.Number
                                                            select s.UserFk.Name
                                       ).OrderBy(x => x).FirstOrDefault()
                               };

                    customer = customer
                        .OrderBy(input.Sorting ?? $"{nameof(Customer.Name)} asc")
                        .PageBy(input);
                }
                else
                {
                    customer = from o in (filteredCustomer
                            .OrderBy(input.Sorting ?? $"{nameof(Customer.Name)} asc")
                            .PageBy(input))
                               join o1 in _lookupAccountTypeRepository.GetAll() on o.AccountTypeId equals o1.Id into j1
                               from s1 in j1.DefaultIfEmpty()
                               select new CustomerQueryDto
                               {
                                   Number = o.Number,
                                   BillTo = o.BillTo,
                                   Name = o.Name,
                                   Address = o.Address,
                                   Phone = o.Phone,
                                   AddedBy = o.AddedBy,
                                   Added = o.Added,
                                   ChangedBy = o.ChangedBy,
                                   Changed = o.Changed,
                                   Users = o.Users,
                                   AccountTypeDescription = s1 == null || s1.Description == null ? "" : s1.Description.ToString()
                               };
                }

                var totalCount = await filteredCustomer.CountAsync();

                var dbList = await customer.ToListAsync();
                var results = GetCustomerForViewDtos(dbList);

                foreach (GetCustomerForViewDto result in results)
                {
                    bool userIsAssignedToTheAccount = VerifyUserIsAssignedToAccount(result);
                    result.CanViewEditOption = HasAccessToEdit(userIsAssignedToTheAccount);
                    result.CanViewAddOpportunityOption = HasAccessToAddOpportunity(userIsAssignedToTheAccount);
                    result.CanViewScheduleMeetingOption = HasAccessToScheduleMeeting(userIsAssignedToTheAccount);
                    result.CanViewScheduleCallOption = HasAccessToScheduleCall(userIsAssignedToTheAccount);
                    result.CanViewEmailReminderOption = HasAccessToEmailReminder(userIsAssignedToTheAccount);
                    result.CanViewToDoReminderOption = HasAccessToDoReminder(userIsAssignedToTheAccount);
                }

                return new PagedResultDto<GetCustomerForViewDto>(
                    totalCount,
                    results
                );
            }
            catch (Exception e)
            {
                Logger.Error("Error in CustomerAppService -> ", e);
                throw;
            }
        }

        private static List<GetCustomerForViewDto> GetCustomerForViewDtos(List<CustomerQueryDto> dbList)
        {
            List<GetCustomerForViewDto> results = new List<GetCustomerForViewDto>();

            foreach (CustomerQueryDto o in dbList)
            {
                GetCustomerForViewDto res = new GetCustomerForViewDto
                {
                    Customer = new CustomerDto
                    {
                        Number = o.Number,
                        BillTo = o.BillTo,
                        Name = o.Name,
                        Address = o.Address,
                        Phone = o.Phone,
                        Added = o.Added,
                        AddedBy = o.AddedBy,
                        Changed = o.Changed,
                        ChangedBy = o.ChangedBy,
                    },
                    AccountTypeDescription = o.AccountTypeDescription,
                };

                if (o.Users.Any())
                {
                    List<AccountUserViewDto> accountUsers = o.Users
                        .Select(x => new AccountUserViewDto
                        {
                            Id = x.Id,
                            UserId = x.UserFk.Id,
                            Name = x.UserFk.Name,
                            SurName = x.UserFk.Surname,
                            FullName = x.UserFk.FullName,
                            ProfilePictureUrl = x.UserFk.ProfilePictureId
                        }).ToList();
                    res.Customer.Users = accountUsers;
                    AccountUserViewDto accountUser = accountUsers.OrderBy(x => x.Name).First();
                    res.FirstUserAssignedName = accountUser.Name;
                    res.FirstUserAssignedSurName = accountUser.SurName;
                    res.FirstUserAssignedFullName = accountUser.FullName;
                    res.FirstUserProfilePictureUrl = accountUser.ProfilePictureUrl;
                    res.FirstUserAssignedId = accountUser.UserId;
                    res.AssignedUsers = accountUsers.Count;
                }

                results.Add(res);
            }

            return results;
        }

        /// <summary>
        /// Get customer for view mode by number
        /// </summary>
        /// <param name="customerNumber"></param>
        /// <returns></returns>
        [AbpAuthorize(AppPermissions.Pages_Customer)]
        public async Task<GetCustomerForViewOutput> GetCustomerForView(string customerNumber)
        {
            Customer customer = await _customerRepository.FirstOrDefaultAsync(x => x.Number.Equals(customerNumber));

            GuardHelper.ThrowIf(customer == null, new EntityNotFoundException(L("AccountNotExist")));

            var output = new GetCustomerForViewOutput { Customer = ObjectMapper.Map<CreateOrEditCustomerDto>(customer) };

            if (output.Customer.AccountTypeId != null)
            {
                AccountType lookupAccountType = await _lookupAccountTypeRepository.FirstOrDefaultAsync(x => x.Id == output.Customer.AccountTypeId);
                output.AccountTypeDescription = lookupAccountType?.Description;
            }

            return output;
        }

        /// <summary>
        /// Get customer for edition mode
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [AbpAuthorize(
            permissions: new[]
            {
                AppPermissions.Pages_Customer_Edit,
                AppPermissions.Pages_Customer_Edit__Dynamic
            },
            RequireAllPermissions = false
        )]
        public async Task<GetCustomerForEditOutput> GetCustomerForEdit(GetCustomerForEditInput input)
        {
            long currentUserId = GetCurrentUser().Id;

            if (!UserManager.IsGranted(currentUserId, AppPermissions.Pages_Customer_Edit)
                && UserManager.IsGranted(currentUserId, AppPermissions.Pages_Customer_Edit__Dynamic))
            {
                var customer = await GetCustomerAndUser(input.CustomerNumber, currentUserId);
                GuardHelper.ThrowIf(customer == null, new EntityNotFoundException(L("AccountNotExist")));
            }

            return ObjectMapper.Map<GetCustomerForEditOutput>(await GetCustomerForView(input.CustomerNumber));
        }

        /// <summary>
        /// Create or edit customer
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [AbpAuthorize(AppPermissions.Pages_Customer)]
        public async Task CreateOrEdit(CreateOrEditCustomerDto input)
        {
            if (string.IsNullOrEmpty(input.Number))
            {
                await Create(input);
            }
            else
            {
                await Update(input);
            }
        }

        /// <summary>
        /// Create customer
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [AbpAuthorize(AppPermissions.Pages_Customer_Create)]
        protected virtual async Task Create(CreateOrEditCustomerDto input)
        {
            var customer = ObjectMapper.Map<Customer>(input);

            List<Customer> customerSameName = await _customerRepository.GetAll()
                .Where(x => !string.IsNullOrEmpty(x.Name))
                .Where(x => input.Name.ToLower().Trim() == x.Name.ToLower().Trim())
                .ToListAsync();

            GuardHelper.ThrowIf(customerSameName.Any(), new UserFriendlyException(L("CustomerNameAlreadyExist")));

            AccountType defaultAccountType = await _lookupAccountTypeRepository.FirstOrDefaultAsync(x => x.IsDefault.HasValue && x.IsDefault.Value);
            GuardHelper.ThrowIf(defaultAccountType == null, new UserFriendlyException(L("DefaultAccountTypeNotExist")));

            customer.Terms = defaultAccountType.Description;

            User currentUser = await GetCurrentUserAsync();

            using (_reasonProvider.Use("Account created"))
            {
                // Set internal audit fields
                customer.Number = (await _customerSequenceRepository.GetNextSequence()).ToString();
                customer.BillTo = customer.Number;
                customer.IsCreatedFromWebCrm = true;
                customer.AddedBy = currentUser.Name;
                customer.Added = DateTime.UtcNow;
                await _customerRepository.InsertAsync(customer);
                await _unitOfWorkManager.Current.SaveChangesAsync();

                //Assign Account Users
                List<CreateOrEditAccountUserDto> assignAccountUsers = new EditableList<CreateOrEditAccountUserDto>();
                assignAccountUsers.Add(new CreateOrEditAccountUserDto()
                {
                    CustomerNumber = customer.Number,
                    UserId = currentUser.Id
                });

                // Automate Assignment
                bool hasDynamicPermission = await UserManager.IsGrantedAsync(currentUser.Id, AppPermissions.Pages_AccountUsers_AutomateAssignment__Dynamic);
                if (hasDynamicPermission)
                {
                    await _accountAutomateAssignment.AssignAccountUsersAsync(assignAccountUsers);
                }
            }
        }

        /// <summary>
        /// Update customer
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [AbpAuthorize(
            permissions: new[]
            {
                AppPermissions.Pages_Customer_Edit,
                AppPermissions.Pages_Customer_Edit__Dynamic
            },
            RequireAllPermissions = false
        )]
        protected virtual async Task Update(CreateOrEditCustomerDto input)
        {
            Customer customer;
            User currentUser = await GetCurrentUserAsync();

            // If the user only has the dynamic edit permission, then it needs to be assigned to the account.
            customer = !UserManager.IsGranted(currentUser.Id, AppPermissions.Pages_Customer_Edit)
                       && UserManager.IsGranted(currentUser.Id, AppPermissions.Pages_Customer_Edit__Dynamic)
                ? await GetCustomerAndUser(input.Number, currentUser.Id)
                : await _customerRepository.FirstOrDefaultAsync(x => x.Number.Equals(input.Number));

            GuardHelper.ThrowIf(customer is null, new UserFriendlyException(L("AccountNotExist")));

            using (_reasonProvider.Use("Account updated"))
            {
                // Set internal audit fields
                customer.ChangedBy = currentUser.Name;
                customer.Changed = DateTime.UtcNow;

                ObjectMapper.Map(input, customer);
                await _unitOfWorkManager.Current.SaveChangesAsync();
            }
        }

        private async Task<Customer> GetCustomerAndUser(string customerNumber, long userId)
        {
            var customer = await _accountUserRepository.GetAll()
                .Include(x => x.UserFk)
                .Include(x => x.CustomerFk)
                .Where(x => x.UserId == userId && x.CustomerNumber == customerNumber)
                .Select(x => x.CustomerFk)
                .FirstOrDefaultAsync();
            return customer;
        }

        /// <summary>
        /// Get Customers for excel export
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [AbpAuthorize(AppPermissions.Pages_Customer)]
        public async Task<FileDto> GetCustomerToExcel(GetAllCustomerForExcelInput input)
        {
            IQueryable<Customer> filteredCustomer = _customerRepository.GetAll()
                .Include(e => e.AccountTypeFk)
                .Include(x => x.Users)
                .ThenInclude(x => x.UserFk)
                .WhereIf(!string.IsNullOrWhiteSpace(input.Filter),
                    e => e.Number.Contains(input.Filter) || e.BillTo.Contains(input.Filter) ||
                         e.Number.Equals(input.Filter) ||
                         e.Name.Contains(input.Filter) ||
                         e.Address.Contains(input.Filter) ||
                         e.City.Contains(input.Filter) ||
                         e.Phone.Contains(input.Filter))
                .WhereIf(input.AccountTypeId.Any(), x => input.AccountTypeId.Contains(x.AccountTypeFk.Id))
                .WhereIf(input.UserIds.Any(), x => x.Users.Any(y => input.UserIds.Contains(y.UserId)));

            IQueryable<CustomerQueryDto> query = (from o in filteredCustomer
                                                  join o1 in _lookupAccountTypeRepository.GetAll() on o.AccountTypeId equals o1.Id into j1
                                                  from s1 in j1.DefaultIfEmpty()

                                                  select new CustomerQueryDto
                                                  {
                                                      Number = o.Number,
                                                      BillTo = o.BillTo,
                                                      Name = o.Name,
                                                      Address = o.Address,
                                                      Phone = o.Phone,
                                                      AddedBy = o.AddedBy,
                                                      Added = o.Added,
                                                      ChangedBy = o.ChangedBy,
                                                      Changed = o.Changed,
                                                      Users = o.Users,
                                                      AccountTypeDescription = s1 == null || s1.Description == null ? "" : s1.Description.ToString()
                                                  });

            List<CustomerQueryDto> dbList = await query.ToListAsync();
            List<GetCustomerForViewDto> customers = GetCustomerForViewDtos(dbList);

            return _customerExcelExporter.ExportToFile(customers);
        }

        /// <summary>
        /// Get the current user id
        /// </summary>
        /// <returns></returns>
        [AbpAuthorize(AppPermissions.Pages_Customer)]
        public async Task<long> GetCurrentUserId()
        {
            var currentUser = await GetCurrentUserAsync();
            return currentUser.Id;
        }

        /// <summary>
        /// Get Account type lookup
        /// </summary>
        /// <returns></returns>
        [AbpAuthorize(AppPermissions.Pages_Customer)]
        public async Task<List<CustomerAccountTypeLookupTableDto>> GetAllAccountTypeForTableDropdown()
        {
            return await _lookupAccountTypeRepository.GetAll()
                .Select(accountType => new CustomerAccountTypeLookupTableDto
                {
                    Id = accountType.Id,
                    DisplayName = accountType == null || accountType.Description == null ? "" : accountType.Description.ToString(),
                    IsDefault = accountType.IsDefault ?? false
                }).ToListAsync();
        }

        /// <summary>
        /// Get Account type lookup
        /// </summary>
        /// <returns></returns>
        [AbpAuthorize(AppPermissions.Pages_Customer)]
        public async Task<List<CustomerLeadSourceLookupTableDto>> GetAllLeadSourceForTableDropdown()
        {
            return await _lookupLeadSourceRepository.GetAll()
                .Select(source => new CustomerLeadSourceLookupTableDto
                {
                    Id = source.Id,
                    DisplayName = source == null || source.Description == null ? "" : source.Description.ToString()
                }).ToListAsync();
        }

        /// <summary>
        /// Get Countries lookup
        /// </summary>
        /// <returns></returns>
        [AbpAuthorize(AppPermissions.Pages_Customer)]
        public async Task<List<CustomerCountryLookupTableDto>> GetAllCountriesForTableDropdown()
        {
            return await _lookupCountryRepository.GetAll()
                .Select(country => new CustomerCountryLookupTableDto
                {
                    Id = country.Id,
                    Code = country.Code,
                    DisplayName = country == null || country.Name == null ? "" : country.Name.ToString()
                }).ToListAsync(); ;
        }

        /// <summary>
        /// Get all users for table dropdown
        /// </summary>
        /// <returns></returns>
        [AbpAuthorize(AppPermissions.Pages_Customer)]
        public async Task<List<AccountUserLookupTableDto>> GetAllUserForTableDropdown()
        {
            return await _lookupUserRepository.GetAll()
                .Select(user => new AccountUserLookupTableDto
                {
                    Id = user.Id,
                    DisplayName = user != null ? user.FullName : string.Empty
                }).ToListAsync();
        }

        /// <summary>
        /// Get all customer opportunities
        /// Get all customer opportunities
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [AbpAuthorize(
            permissions: new[]
            {
                AppPermissions.Pages_Customer_View_Opportunities,
                AppPermissions.Pages_Customer_View_Opportunities__Dynamic
            },
            RequireAllPermissions = false
        )]
        public async Task<PagedResultDto<CustomerOpportunityViewDto>> GetCustomerOpportunities(GetCustomerOpportunitiesInput input)
        {
            var currentUser = await GetCurrentUserAsync();
            var hasDynamicPermission = await UserManager.IsGrantedAsync(currentUser.Id, AppPermissions.Pages_Customer_View_Opportunities__Dynamic);
            var hasStaticPermission = await UserManager.IsGrantedAsync(currentUser.Id, AppPermissions.Pages_Customer_View_Opportunities);

            var opportunities = _opportunityRepository.GetAll()
                .Include(x => x.OpportunityStageFk)
                .Include(x => x.Users)
                .Where(x => x.CustomerNumber == input.CustomerNumber)
                .WhereIf(hasDynamicPermission && !hasStaticPermission, x => x.Users.Select(y => y.UserId).Contains(currentUser.Id))
                ;

            IQueryable<Opportunity> pagedAndFilteredOpportunities;

            if (input.Sorting != null)
                pagedAndFilteredOpportunities = opportunities
                    .OrderBy(input.Sorting)
                    .PageBy(input);
            else
                pagedAndFilteredOpportunities = opportunities
                    .OrderByDescending(o => o.CloseDate)
                    .ThenBy(o => o.Name)
                    //.ThenBy(o => o.BranchFk.Name)
                    //.ThenBy(o => o.DepartmentFk.Title)
                    .PageBy(input);

            int totalCount = await opportunities.CountAsync();

            List<Opportunity> dbList = await pagedAndFilteredOpportunities.ToListAsync();
            List<CustomerOpportunityViewDto> results = new List<CustomerOpportunityViewDto>();

            foreach (Opportunity o in dbList)
            {
                CustomerOpportunityViewDto res = new CustomerOpportunityViewDto
                {
                    Id = o.Id,
                    Name = o.Name,
                    Stage = o.OpportunityStageFk?.Description,
                    StageColor = o.OpportunityStageFk?.Color,
                    CloseDate = o.CloseDate,
                    Amount = o.Amount
                };
                results.Add(res);
            }

            return new PagedResultDto<CustomerOpportunityViewDto>(
                totalCount,
                results
            );
        }

        /// <summary>
        /// Get all Customer invoices
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [AbpAuthorize(AppPermissions.Pages_Customer)]
        public async Task<PagedResultDto<CustomerInvoiceViewDto>> GetAllCustomerInvoices(GetAllCustomerInvoicesInput input)
        {
            return await _customerCustomerInvoiceRepository.GetPagedCustomerInvoices(input);
        }

        /// <summary>
        /// Get all Customer equipments
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [AbpAuthorize(AppPermissions.Pages_Customer)]
        public async Task<PagedResultDto<CustomerEquipmentViewDto>> GetAllCustomerEquipments(GetAllCustomerEquipmentInput input)
        {
            return await _customerEquipmentRepository.GetPagedCustomerEquipment(input);
        }

        /// <summary>
        /// Get all Customer WIP
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [AbpAuthorize(AppPermissions.Pages_Customer)]
        public async Task<PagedResultDto<CustomerWipViewDto>> GetAllCustomerWip(GetAllCustomerWipInput input)
        {
            return await _customerWipRepository.GetPagedCustomerWip(input);
        }

        /// <summary>
        /// Get al events
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [AbpAuthorize(
            permissions: new[]
            {
                AppPermissions.Pages_Customer_View_Events,
                AppPermissions.Pages_Customer_View_Events__Dynamic
            },
            RequireAllPermissions = false
        )]
        public async Task<PagedResultDto<EntityChangeListDto>> GetEntityTypeChanges(GetCrmEntityTypeChangeInput input)
        {
            input.EntityTypeFullName = typeof(Customer).FullName;
            return await _auditEventsService.GetEntityTypeChanges(ObjectMapper.Map<GetEntityTypeChangeInput>(input));
        }

        /// <summary>
        /// Check if exist customer by name
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<bool> CheckIfExistByName(string input)
        {
            return await _customerRepository.GetAll()
                .Where(x => !string.IsNullOrEmpty(x.Name))
                .Where(x => x.Name.ToLower().Trim() == input.ToLower().Trim())
                .AnyAsync();
        }

        /// <summary>
        /// Create Account from Lead conversion
        /// </summary>
        /// <param name="input"></param>
        [RemoteService(false)]
        [AbpAuthorize(AppPermissions.Pages_Leads_Convert_Account)]
        public async Task<string> ConvertFromLead(ConvertLeadToAccountDto input)
        {
            User currentUser = await GetCurrentUserAsync();

            GuardHelper.ThrowIf(input.Lead is null, new UserFriendlyException(L("CustomerNotExist")));
            GuardHelper.ThrowIf(await CheckIfExistByName(input.Lead.CompanyName), new UserFriendlyException(L("CustomerWithSameNameAlreadyExists")));

            Customer customer = new Customer();

            AccountType defaultAccountType = await _lookupAccountTypeRepository.FirstOrDefaultAsync(x => x.Id == input.ConversionAccountTypeId);
            GuardHelper.ThrowIf(defaultAccountType == null, new UserFriendlyException(L("DefaultAccountTypeNotExist")));

            using (_reasonProvider.Use("Account created from Lead conversion"))
            {
                // Mapping Overview data
                customer.Name = input.Lead.CompanyName;
                customer.Phone = input.Lead.CompanyPhone;
                customer.EMail = input.Lead.CompanyEmail;
                customer.WWWAddress = input.Lead.WebSite;
                customer.Country = input.Lead.Country;
                customer.City = input.Lead.City;
                customer.State = input.Lead.State;
                customer.ZipCode = input.Lead.ZipCode;
                customer.POBox = input.Lead.PoBox;
                customer.LeadSourceId = input.Lead.LeadSourceId;
                customer.AccountTypeId = input.ConversionAccountTypeId;
                customer.Terms = defaultAccountType.Description;

                // Set internal audit fields
                customer.Number = (await _customerSequenceRepository.GetNextSequence()).ToString();
                customer.BillTo = customer.Number;
                customer.IsCreatedFromWebCrm = true;
                customer.AddedBy = currentUser.Name;
                customer.Added = DateTime.UtcNow;

                customer = await _customerRepository.InsertAsync(customer);
                await _unitOfWorkManager.Current.SaveChangesAsync();
            }

            if (!string.IsNullOrEmpty(input.Lead.ContactName))
            {
                // Mapping contact
                CreateOrEditContactDto contact = new CreateOrEditContactDto();
                contact.CustomerNo = customer.Number;
                contact.Contact = input.Lead.ContactName;
                contact.Position = input.Lead.ContactPosition;
                contact.Phone = input.Lead.ContactPhone;
                contact.Extention = input.Lead.ContactPhoneExtension;
                contact.Cellular = input.Lead.ContactCellPhone;
                contact.Fax = input.Lead.ContactFaxNumber;
                contact.Pager = input.Lead.PagerNumber;
                contact.EMail = input.Lead.ContactEmail;
                await _contactsAppService.CreateOrEdit(contact);
            }

            return customer.Number;
        }

        /// <summary>
        /// Get al events
        /// </summary>
        /// <param name="Customer"></param>
        /// <returns></returns>
        private bool VerifyUserIsAssignedToAccount(GetCustomerForViewDto customer)
        {
            long currentUserId = GetCurrentUser().Id;
            if (customer.Customer.Users != null)
                foreach (AccountUserViewDto user in customer.Customer.Users)
                {
                    if (user.UserId == currentUserId)
                        return true;
                }
            return false;
        }

        /// <summary>
        /// Get the dynamic permission based on the current user.
        /// </summary>
        /// <returns></returns>
        public bool HasAccessToEdit(bool isUserAssignedToCostumer)
        {
            var currentUser = GetCurrentUser();
            return UserManager.IsGranted(
                currentUser.Id, AppPermissions.Pages_Customer_Edit)
                ||
                (UserManager.IsGranted(
                currentUser.Id, AppPermissions.Pages_Customer_Edit__Dynamic)
                &&
                isUserAssignedToCostumer);
        }

        /// <summary>
        /// Get the dynamic permission based on the current user.
        /// </summary>
        /// <returns></returns>
        public bool HasAccessToAddOpportunity(bool isUserAssignedToCostumer)
        {
            var currentUser = GetCurrentUser();
            return UserManager.IsGranted(
                currentUser.Id, AppPermissions.Pages_Customer_Add_Opportunity)
                ||
                (UserManager.IsGranted(
                currentUser.Id, AppPermissions.Pages_Customer_Add_Opportunity__Dynamic)
                &&
                isUserAssignedToCostumer);
        }

        /// <summary>s
        /// Get the dynamic permission based on the current user.
        /// </summary>
        /// <returns></returns>
        public bool HasAccessToScheduleMeeting(bool isUserAssignedToCostumer)
        {
            var currentUser = GetCurrentUser();
            return UserManager.IsGranted(
                currentUser.Id, AppPermissions.Pages_Customer_ScheduleMeeting)
                ||
                (UserManager.IsGranted(currentUser.Id, AppPermissions.Pages_Customer_ScheduleMeeting__Dynamic)
                &&
                isUserAssignedToCostumer);
        }

        /// <summary>
        /// Get the dynamic permission based on the current user.
        /// </summary>
        /// <returns></returns>
        public bool HasAccessToScheduleCall(bool isUserAssignedToCostumer)
        {
            var currentUser = GetCurrentUser();
            return UserManager.IsGranted(
                currentUser.Id, AppPermissions.Pages_Customer_ScheduleCall)
                ||
                (UserManager.IsGranted(
                currentUser.Id, AppPermissions.Pages_Customer_ScheduleCall__Dynamic)
                &&
                isUserAssignedToCostumer);
        }

        /// <summary>
        /// Get the dynamic permission based on the current user.
        /// </summary>
        /// <returns></returns>
        public bool HasAccessToEmailReminder(bool isUserAssignedToCostumer)
        {
            var currentUser = GetCurrentUser();
            return UserManager.IsGranted(
                currentUser.Id, AppPermissions.Pages_Customer_EmailReminder)
                ||
                (UserManager.IsGranted(
                currentUser.Id, AppPermissions.Pages_Customer_EmailReminder__Dynamic)
                &&
                isUserAssignedToCostumer);
        }

        /// <summary>
        /// Get the dynamic permission based on the current user.
        /// </summary>
        /// <returns></returns>
        public bool HasAccessToDoReminder(bool isUserAssignedToCostumer)
        {
            var currentUser = GetCurrentUser();
            return UserManager.IsGranted(
                currentUser.Id, AppPermissions.Pages_Customer_ToDoReminder)
                ||
                (UserManager.IsGranted(
                currentUser.Id, AppPermissions.Pages_Customer_ToDoReminder__Dynamic)
                &&
                isUserAssignedToCostumer);
        }
    }
}