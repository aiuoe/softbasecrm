using System;
using SBCRM.Crm;
using System.Linq;
using System.Linq.Dynamic.Core;
using Abp.Linq.Extensions;
using System.Collections.Generic;
using System.Threading.Tasks;
using SBCRM.Legacy.Exporting;
using SBCRM.Legacy.Dtos;
using SBCRM.Dto;
using Abp.Application.Services.Dto;
using SBCRM.Authorization;
using Abp.Authorization;
using Abp.UI;
using Microsoft.EntityFrameworkCore;
using SBCRM.Base;

namespace SBCRM.Legacy
{
    /// <summary>
    /// App service to handle Accounts(Customers) information
    /// </summary>
    [AbpAuthorize(AppPermissions.Pages_Customer)]
    public class CustomerAppService : SBCRMAppServiceBase, ICustomerAppService
    {
        private readonly ICustomerExcelExporter _customerExcelExporter;
        private readonly IRepository<Customer> _customerRepository;
        private readonly IRepository<AccountType> _lookupAccountTypeRepository;
        private readonly IRepository<LeadSource> _lookupLeadSourceRepository;
        private readonly ISoftBaseCustomerInvoiceRepository _customerCustomerInvoiceRepository;
        private readonly ISoftBaseCustomerEquipmentRepository _customerEquipmentRepository;
        private readonly ISoftBaseCustomerWipRepository _customerWipRepository;

        /// <summary>
        /// Base constructor
        /// </summary>
        /// <param name="customerRepository"></param>
        /// <param name="customerExcelExporter"></param>
        /// <param name="lookupAccountTypeRepository"></param>
        /// <param name="lookupLeadSourceRepository"></param>
        /// <param name="customerCustomerInvoiceRepository"></param>
        /// <param name="customerEquipmentRepository"></param>
        /// <param name="customerWipRepository"></param>
        /// <param name="unitOfWorkManager"></param>
        public CustomerAppService(
            IRepository<Customer> customerRepository,
            ICustomerExcelExporter customerExcelExporter,
            IRepository<AccountType> lookupAccountTypeRepository,
            IRepository<LeadSource> lookupLeadSourceRepository,
            ISoftBaseCustomerInvoiceRepository customerCustomerInvoiceRepository,
            ISoftBaseCustomerEquipmentRepository customerEquipmentRepository,
            ISoftBaseCustomerWipRepository customerWipRepository)
        {
            _customerRepository = customerRepository;
            _customerExcelExporter = customerExcelExporter;
            _lookupAccountTypeRepository = lookupAccountTypeRepository;
            _lookupLeadSourceRepository = lookupLeadSourceRepository;
            _customerCustomerInvoiceRepository = customerCustomerInvoiceRepository;
            _customerEquipmentRepository = customerEquipmentRepository;
            _customerWipRepository = customerWipRepository;
        }

        /// <summary>
        /// Get all customers
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<PagedResultDto<GetCustomerForViewDto>> GetAll(GetAllCustomerInput input)
        {
            try
            {
                var filteredCustomer = _customerRepository.GetAll()
                    .Include(e => e.AccountTypeFk)
                    .WhereIf(!string.IsNullOrWhiteSpace(input.Filter),
                        e => e.Number.Contains(input.Filter) || e.BillTo.Contains(input.Filter) ||
                             e.Number.Equals(input.Filter) ||
                             e.Name.Contains(input.Filter) ||
                             e.Address.Contains(input.Filter) ||
                             e.City.Contains(input.Filter) ||
                             e.Phone.Contains(input.Filter))
                    .WhereIf(input.AccountTypeId.Any(), x => input.AccountTypeId.Contains(x.AccountTypeFk.Id))
                    ;

                var pagedAndFilteredCustomer = filteredCustomer
                    .OrderBy(input.Sorting ?? $"{nameof(Customer.Name)} asc")
                    .PageBy(input);

                var customer = from o in pagedAndFilteredCustomer
                    join o1 in _lookupAccountTypeRepository.GetAll() on o.AccountTypeId equals o1.Id into j1
                    from s1 in j1.DefaultIfEmpty()
                    select new
                    {
                        o.Number,
                        o.BillTo,
                        o.Name,
                        o.Address,
                        o.Phone,
                        o.AddedBy,
                        o.Added,
                        o.ChangedBy,
                        o.Changed,
                        AccountTypeDescription = s1 == null || s1.Description == null ? "" : s1.Description.ToString()
                    };

                var totalCount = await filteredCustomer.CountAsync();

                var dbList = await customer.ToListAsync();
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
                            ChangedBy = o.ChangedBy
                        },
                        AccountTypeDescription = o.AccountTypeDescription
                    };

                    results.Add(res);
                }

                return new PagedResultDto<GetCustomerForViewDto>(
                    totalCount,
                    results
                );
            }
            catch (Exception e)
            {
                Logger.Error("Error in CustomerAppService.GetAll -> ", e);
                throw;
            }

        }

        /// <summary>
        /// Get customer for view mode by number
        /// </summary>
        /// <param name="customerNumber"></param>
        /// <returns></returns>
        public async Task<GetCustomerForViewDto> GetCustomerForView(string customerNumber)
        {
            var customer = await _customerRepository.FirstOrDefaultAsync(x => x.Number.Equals(customerNumber));

            var output = new GetCustomerForViewDto { Customer = ObjectMapper.Map<CustomerDto>(customer) };

            if (output.Customer.AccountTypeId != null)
            {
                var lookupAccountType = await _lookupAccountTypeRepository.FirstOrDefaultAsync((x => x.Id == output.Customer.AccountTypeId));
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
            var customer = await _customerRepository.FirstOrDefaultAsync(x => x.Number.Equals(input.CustomerNumber));

            var output = new GetCustomerForEditOutput { Customer = ObjectMapper.Map<CreateOrEditCustomerDto>(customer) };

            if (output.Customer.AccountTypeId != null)
            {
                var lookupAccountType = await _lookupAccountTypeRepository.FirstOrDefaultAsync(x => x.Id == output.Customer.AccountTypeId);
                output.AccountTypeDescription = lookupAccountType?.Description;
            }

            return output;
        }

        /// <summary>
        /// Create or edit customer
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
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

            if (customerSameName.Any())
            {
                throw new UserFriendlyException(L("CustomerNameAlreadyExist"));
            }

            var defaultAccountType = await _lookupAccountTypeRepository.FirstOrDefaultAsync(x => x.IsDefault.HasValue && x.IsDefault.Value);
            customer.Terms = defaultAccountType.Description;

            var currentUser = await GetCurrentUserAsync();

            customer.IsCreatedFromWebCrm = true;
            customer.AddedBy = currentUser.Name;
            customer.Added = DateTime.UtcNow;
            customer = await _customerRepository.InsertAsync(customer);

            customer.BillTo = customer.Number;
            customer.ChangedBy = currentUser.Name;
            customer.Changed = DateTime.UtcNow;
            await _customerRepository.UpdateAsync(customer);
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
            ObjectMapper.Map(input, customer);

            var currentUser = await GetCurrentUserAsync();
            customer.ChangedBy = currentUser.Name;
            customer.Changed = DateTime.UtcNow;
            await _customerRepository.UpdateAsync(customer);
        }

        /// <summary>
        /// Get Customers for excel export
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<FileDto> GetCustomerToExcel(GetAllCustomerForExcelInput input)
        {
            var filteredCustomer = _customerRepository.GetAll()
                .Include(e => e.AccountTypeFk)
                .WhereIf(!string.IsNullOrWhiteSpace(input.Filter),
                    e => e.Number.Contains(input.Filter) || e.BillTo.Contains(input.Filter) ||
                         e.Number.Equals(input.Filter) ||
                         e.Name.Contains(input.Filter) ||
                         e.Address.Contains(input.Filter) ||
                         e.City.Contains(input.Filter) ||
                         e.Phone.Contains(input.Filter))
                .WhereIf(input.AccountTypeId.Any(), x => input.AccountTypeId.Contains(x.AccountTypeFk.Id));

            var query = (from o in filteredCustomer
                         join o1 in _lookupAccountTypeRepository.GetAll() on o.AccountTypeId equals o1.Id into j1
                         from s1 in j1.DefaultIfEmpty()

                         select new GetCustomerForViewDto
                         {
                             Customer = new CustomerDto
                             {
                                 Number = o.Number,
                                 BillTo = o.BillTo,
                                 Name = o.Name,
                                 Address = o.Address,
                                 Phone = o.Phone
                             },
                             AccountTypeDescription = s1 == null || s1.Description == null ? "" : s1.Description.ToString()
                         });

            var customers = await query.ToListAsync();

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
                .Select(accountType => new CustomerLeadSourceLookupTableDto
                {
                    Id = accountType.Id,
                    DisplayName = accountType == null || accountType.Description == null ? "" : accountType.Description.ToString()
                }).ToListAsync();
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

    }
}