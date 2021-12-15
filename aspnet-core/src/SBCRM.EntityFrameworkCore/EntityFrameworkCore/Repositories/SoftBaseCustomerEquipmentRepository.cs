using System;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Microsoft.EntityFrameworkCore;
using SBCRM.Base;
using SBCRM.Legacy;
using System.Linq.Dynamic.Core;
using Abp.Linq.Extensions;

namespace SBCRM.EntityFrameworkCore.Repositories
{
    /// <summary>
    /// Repository to manage the customer invoices information
    /// </summary>
    public class SoftBaseCustomerEquipmentRepository : ISoftBaseCustomerEquipmentRepository
    {
        private const short FilterCustomer = -1;
        private readonly SBCRMDbContext _dbContext;

        /// <summary>
        /// Main constructor
        /// </summary>
        /// <param name="dbContext"></param>
        public SoftBaseCustomerEquipmentRepository(SBCRMDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Get customer equipments
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<PagedResultDto<CustomerEquipmentViewDto>> GetPagedCustomerEquipment(GetAllCustomerEquipmentInput input)
        {
            try
            {
                var invoiceRegQuery = from invoiceReg in _dbContext.Set<InvoiceReg>() select invoiceReg;

                var filteredCustomerInvoices = from equipment in _dbContext.Set<Equipment>()
                    join customer in _dbContext.Set<Customer>() on equipment.CustomerNo equals customer.Number
                    join eqCustomFields in _dbContext.Set<EQCustomFields>() on equipment.SerialNo equals eqCustomFields.SerialNo into e
                    from s1 in e.DefaultIfEmpty()
                    where equipment.Customer == FilterCustomer && equipment.CustomerNo == input.CustomerNumber
                    select new CustomerEquipmentViewDto
                    {
                        UnitNo = equipment.UnitNo,
                        Serial = equipment.SerialNo,
                        ModelYear = equipment.ModelYear,
                        Make = equipment.Make,
                        Model = equipment.Model,
                        Meter = equipment.LastHourMeter,
                        TotalExp = invoiceRegQuery.Where(x => x.SerialNo == equipment.SerialNo && x.Customer == FilterCustomer)
                            .Sum(x => x.GrandTotal - x.TotalTax - x.RentalTaxable - x.RentalNonTax - x.EquipmentTaxable - x.EquipmentNonTax),
                    };

                var pagedAndFilteredCustomerInvoices = filteredCustomerInvoices
                    .OrderBy(input.Sorting ?? $"{nameof(CustomerEquipmentViewDto.Serial)} asc")
                    .PageBy(input);

                var totalCount = await filteredCustomerInvoices.CountAsync();
                var results = await pagedAndFilteredCustomerInvoices.ToListAsync();
                results.ForEach(x =>
                {
                    x.TotalExp = x.TotalExp is null or 0 ? 0 : x.TotalExp;
                    x.Meter = x.Meter is null or 0 ? 0 : x.Meter;
                    x.ExpMeter = x.Meter.Value == 0 ? 0 : x.TotalExp / (decimal?) x.Meter;
                });

                return new PagedResultDto<CustomerEquipmentViewDto>(
                    totalCount,
                    results
                );
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
