using System;
using SBCRM.Crm;
using System.Linq;
using System.Linq.Dynamic.Core;
using Abp.Linq.Extensions;
using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using SBCRM.Legacy.Exporting;
using SBCRM.Legacy.Dtos;
using SBCRM.Dto;
using Abp.Application.Services.Dto;
using SBCRM.Authorization;
using Abp.Authorization;
using Abp.Domain.Uow;
using Abp.EntityHistory;
using Abp.UI;
using Microsoft.EntityFrameworkCore;
using SBCRM.Auditing;
using SBCRM.Auditing.Dto;
using SBCRM.Authorization.Users;
using SBCRM.Base;
using SBCRM.Common;
using SBCRM.Crm.Dtos;
using SBCRM.Legacy.Dto;
using BaseRepo = Abp.Domain.Repositories;

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
            IAuditEventsService auditEventsService)
        {
            _customerRepository = customerRepository;
            _customerExcelExporter = customerExcelExporter;
            _auditEventsService = auditEventsService;
            _lookupUserRepository = lookupUserRepository;
            _opportunityRepository = opportunityRepository;
            _lookupAccountTypeRepository = lookupAccountTypeRepository;
            _lookupLeadSourceRepository = lookupLeadSourceRepository;
            _customerCustomerInvoiceRepository = customerCustomerInvoiceRepository;
            _customerEquipmentRepository = customerEquipmentRepository;
            _customerWipRepository = customerWipRepository;
            _accountUserRepository = accountUserRepository;
            _reasonProvider = reasonProvider;
            _unitOfWorkManager = unitOfWorkManager;
            _customerSequenceRepository = customerSequenceRepository;
            _contactsAppService = contactsAppService;
            _lookupCountryRepository = lookupCountryRepository;
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
                        .WhereIf(!string.IsNullOrWhiteSpace(input.Filter),
                            e => e.Number.Contains(input.Filter) || e.BillTo.Contains(input.Filter) ||
                                 e.Number.Equals(input.Filter) ||
                                 e.Name.Contains(input.Filter) ||
                                 e.Address.Contains(input.Filter) ||
                                 e.City.Contains(input.Filter) ||
                                 e.Phone.Contains(input.Filter))
                        .WhereIf(input.AccountTypeId.Any(), x => input.AccountTypeId.Contains(x.AccountTypeFk.Id))
                        .WhereIf(input.UserIds.Any(), x => x.Users.Any(y => input.UserIds.Contains(y.UserId)))
                    ;

                var isAssignedUserSorting = input.Sorting != null && input.Sorting.StartsWith(_assignedUserSortKey);

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
            var results = new List<GetCustomerForViewDto>();

            foreach (var o in dbList)
            {
                var res = new GetCustomerForViewDto
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
                    AccountTypeDescription = o.AccountTypeDescription
                };

                if (o.Users.Any())
                {
                    var accountUsers = o.Users
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
                    var accountUser = accountUsers.OrderBy(x => x.Name).First();
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
            var customer = await _customerRepository.FirstOrDefaultAsync(x => x.Number.Equals(customerNumber));

            var output = new GetCustomerForViewOutput { Customer = ObjectMapper.Map<CreateOrEditCustomerDto>(customer) };

            if (output.Customer.AccountTypeId != null)
            {
                var lookupAccountType = await _lookupAccountTypeRepository.FirstOrDefaultAsync(x => x.Id == output.Customer.AccountTypeId);
                output.AccountTypeDescription = lookupAccountType?.Description;
            }

            return output;
        }
        
        /// <summary>
        /// Get customer for edition mode
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [AbpAuthorize(AppPermissions.Pages_Customer_Edit)]
        public async Task<GetCustomerForEditOutput> GetCustomerForEdit(GetCustomerForEditInput input)
        {
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

            var customerSameName = await _customerRepository.GetAll()
                .Where(x => !string.IsNullOrEmpty(x.Name))
                .Where(x => input.Name.ToLower().Trim() == x.Name.ToLower().Trim())
                .ToListAsync();

            GuardHelper.ThrowIf(customerSameName.Any(), new UserFriendlyException(L("CustomerNameAlreadyExist")));

            var defaultAccountType = await _lookupAccountTypeRepository.FirstOrDefaultAsync(x => x.IsDefault.HasValue && x.IsDefault.Value);
            GuardHelper.ThrowIf(defaultAccountType == null, new UserFriendlyException(L("DefaultAccountTypeNotExist")));

            customer.Terms = defaultAccountType.Description;

            var currentUser = await GetCurrentUserAsync();
            
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
            }
        }

        /// <summary>
        /// Update customer
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [AbpAuthorize(AppPermissions.Pages_Customer_Edit)]
        protected virtual async Task Update(CreateOrEditCustomerDto input)
        {
            var customer = await _customerRepository.FirstOrDefaultAsync(x => x.Number.Equals(input.Number));
            var currentUser = await GetCurrentUserAsync();

            using (_reasonProvider.Use("Account updated"))
            {
                // Set internal audit fields
                customer.ChangedBy = currentUser.Name;
                customer.Changed = DateTime.UtcNow;

                ObjectMapper.Map(input, customer);
                await _unitOfWorkManager.Current.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Get Customers for excel export
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [AbpAuthorize(AppPermissions.Pages_Customer)]
        public async Task<FileDto> GetCustomerToExcel(GetAllCustomerForExcelInput input)
        {
            var filteredCustomer = _customerRepository.GetAll()
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

            var query = (from o in filteredCustomer
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

            var dbList = await query.ToListAsync();
            var customers = GetCustomerForViewDtos(dbList);

            return _customerExcelExporter.ExportToFile(customers);
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
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [AbpAuthorize(AppPermissions.Pages_Customer)]
        public async Task<PagedResultDto<CustomerOpportunityViewDto>> GetAllOpportunities(GetAllCustomerOpportunitiesInput input)
        {
            var opportunities = _opportunityRepository.GetAll()
                .Include(x => x.OpportunityStageFk)
                .Where(x => x.CustomerNumber == input.CustomerNumber);

            IQueryable<Opportunity> pagedAndFilteredOpportunities;

            if (input.Sorting != null)
                pagedAndFilteredOpportunities = opportunities
                    .OrderBy(input.Sorting)
                    .PageBy(input);
            else
                pagedAndFilteredOpportunities = opportunities
                    .OrderByDescending(o => o.CloseDate)
                    .ThenBy(o => o.Name)
                    .ThenBy(o => o.Branch)
                    .ThenBy(o => o.Department)
                    .PageBy(input);

            var totalCount = await opportunities.CountAsync();

            var dbList = await pagedAndFilteredOpportunities.ToListAsync();
            var results = new List<CustomerOpportunityViewDto>();

            foreach (var o in dbList)
            {
                var res = new CustomerOpportunityViewDto {
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
        [AbpAuthorize(AppPermissions.Pages_Customer_View_Events)]
        public async Task<PagedResultDto<EntityChangeListDto>> GetEntityTypeChanges(GetEntityTypeChangeInput input)
        {
            input.EntityTypeFullName = typeof(Customer).FullName;
            return await _auditEventsService.GetEntityTypeChanges(input);
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
            var currentUser = await GetCurrentUserAsync();
            
            GuardHelper.ThrowIf(input.Lead is null, new UserFriendlyException(L("CustomerNotExist")));
            GuardHelper.ThrowIf(await CheckIfExistByName(input.Lead.CompanyName), new UserFriendlyException(L("CustomerWithSameNameAlreadyExists")));

            var customer = new Customer();

            var defaultAccountType = await _lookupAccountTypeRepository.FirstOrDefaultAsync(x => x.Id == input.ConversionAccountTypeId);
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
                var contact = new CreateOrEditContactDto();
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
        
    }
}