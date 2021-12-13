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
using Microsoft.EntityFrameworkCore;

namespace SBCRM.Legacy
{
    /// <summary>
    /// App service to handle Accounts(Customers) information
    /// </summary>
    [AbpAuthorize(AppPermissions.Pages_Customer)]
    public class CustomerAppService : SBCRMAppServiceBase, ICustomerAppService
    {
        private readonly ICustomerExcelExporter _customerExcelExporter;
        private readonly Base.IRepository<Customer> _customerRepository;
        private readonly Base.IRepository<AccountType> _lookupAccountTypeRepository;

        /// <summary>
        /// Base constructor
        /// </summary>
        /// <param name="customerRepository"></param>
        /// <param name="customerExcelExporter"></param>
        /// <param name="lookupAccountTypeRepository"></param>
        public CustomerAppService(
            Base.IRepository<Customer> customerRepository,
            ICustomerExcelExporter customerExcelExporter,
            Base.IRepository<AccountType> lookupAccountTypeRepository)
        {
            _customerRepository = customerRepository;
            _customerExcelExporter = customerExcelExporter;
            _lookupAccountTypeRepository = lookupAccountTypeRepository;
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
                if (input is {AccountTypeId: 0})
                {
                    input.AccountTypeId = null;
                }

                var filteredCustomer = _customerRepository.GetAll()
                    .Include(e => e.AccountTypeFk)
                    .WhereIf(!string.IsNullOrWhiteSpace(input.Filter),
                        e => false || e.Number.Contains(input.Filter) || e.BillTo.Contains(input.Filter) ||
                             e.Number.Equals(input.Filter) ||
                             e.Name.Contains(input.Filter) ||
                             e.Address.Contains(input.Filter) ||
                             e.City.Contains(input.Filter) ||
                             e.Phone.Contains(input.Filter))
                    .WhereIf(input.AccountTypeId.HasValue, x => x.AccountTypeFk.Id == input.AccountTypeId)
                    ;

                var pagedAndFilteredCustomer = filteredCustomer
                    .OrderBy(input.Sorting ?? $"{nameof(Customer.Number)} asc")
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
                    var res = new GetCustomerForViewDto()
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
                Logger.Error("Error -> ", e);
                throw;
            }

        }

        public async Task<GetCustomerForViewDto> GetCustomerForView(string customerNumber)
        {
            var customer = await _customerRepository.FirstOrDefaultAsync(x => x.Number.Equals(customerNumber));

            var output = new GetCustomerForViewDto { Customer = ObjectMapper.Map<CustomerDto>(customer) };

            //if (output.Customer.AccountTypeId != null)
            //{
            //    var _lookupAccountType = await _lookupAccountTypeRepository.FirstOrDefaultAsync((int)output.Customer.AccountTypeId);
            //    output.AccountTypeDescription = _lookupAccountType?.Description?.ToString();
            //}

            return output;
        }

        [AbpAuthorize(AppPermissions.Pages_Customer_Edit)]
        public async Task<GetCustomerForEditOutput> GetCustomerForEdit(GetCustomerForEditInput input)
        {
            var customer = await _customerRepository.FirstOrDefaultAsync(x => x.Number.Equals(input.CustomerNumber));

            var output = new GetCustomerForEditOutput { Customer = ObjectMapper.Map<CreateOrEditCustomerDto>(customer) };

            //if (output.Customer.AccountTypeId != null)
            //{
            //    var _lookupAccountType = await _lookupAccountTypeRepository.FirstOrDefaultAsync((int)output.Customer.AccountTypeId);
            //    output.AccountTypeDescription = _lookupAccountType?.Description?.ToString();
            //}

            return output;
        }

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

        [AbpAuthorize(AppPermissions.Pages_Customer_Create)]
        protected virtual async Task Create(CreateOrEditCustomerDto input)
        {
            var customer = ObjectMapper.Map<Customer>(input);

            await _customerRepository.InsertAsync(customer);

        }

        [AbpAuthorize(AppPermissions.Pages_Customer_Edit)]
        protected virtual async Task Update(CreateOrEditCustomerDto input)
        {
            var customer = await _customerRepository.FirstOrDefaultAsync(x => x.Number.Equals(input.Number));
            ObjectMapper.Map(input, customer);

        }

        [AbpAuthorize(AppPermissions.Pages_Customer_Delete)]
        public async Task Delete(DeleteCustomerInput input)
        {
            var customer = await _customerRepository.FirstOrDefaultAsync(x => x.Number.Equals(input.CustomerNumber));
            await _customerRepository.DeleteAsync(customer);
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
                        e => false || e.Number.Contains(input.Filter) || e.BillTo.Contains(input.Filter) ||
                             e.Number.Equals(input.Filter) ||
                             e.Name.Contains(input.Filter) ||
                             e.Address.Contains(input.Filter) ||
                             e.City.Contains(input.Filter) ||
                             e.Phone.Contains(input.Filter))
                    .WhereIf(input.AccountTypeId.HasValue, x => x.AccountTypeFk.Id == input.AccountTypeId)
                ;

            var query = (from o in filteredCustomer
                         join o1 in _lookupAccountTypeRepository.GetAll() on o.AccountTypeId equals o1.Id into j1
                         from s1 in j1.DefaultIfEmpty()

                         select new GetCustomerForViewDto()
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

        [AbpAuthorize(AppPermissions.Pages_Customer)]
        public async Task<List<CustomerAccountTypeLookupTableDto>> GetAllAccountTypeForTableDropdown()
        {
            return await _lookupAccountTypeRepository.GetAll()
                .Select(accountType => new CustomerAccountTypeLookupTableDto
                {
                    Id = accountType.Id,
                    DisplayName = accountType == null || accountType.Description == null ? "" : accountType.Description.ToString()
                }).ToListAsync();
        }

    }
}