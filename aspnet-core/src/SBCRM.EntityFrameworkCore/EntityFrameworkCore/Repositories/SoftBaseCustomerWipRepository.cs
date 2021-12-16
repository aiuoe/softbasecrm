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
    /// Repository to manage the customer WIP information
    /// </summary>
    public class SoftBaseCustomerWipRepository : ISoftBaseCustomerWipRepository
    {
        private const short OpenDisposition = 1;
        private const short QuoteDisposition = 11;
        private readonly SBCRMDbContext _dbContext;

        /// <summary>
        /// Main constructor
        /// </summary>
        /// <param name="dbContext"></param>
        public SoftBaseCustomerWipRepository(SBCRMDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Get customer wip
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<PagedResultDto<CustomerWipViewDto>> GetPagedCustomerWip(GetAllCustomerWipInput input)
        {
            var filteredCustomerWip = from wipList in _dbContext.Set<WIPList>()
                    join wo in _dbContext.Set<WO>() on wipList.WONo equals wo.WONo
                    join customers in _dbContext.Set<Customer>() on wo.ShipTo equals customers.Number into c
                    from customer in c.DefaultIfEmpty()
                    join equipments in _dbContext.Set<Equipment>() on wipList.SerialNo equals equipments.SerialNo into e
                    from equipment in e.DefaultIfEmpty()
                    where wo.BillTo == input.CustomerNumber
                          && (!input.AcceptedQuotes || input.AcceptedQuotes && OpenDisposition == wipList.Disposition)
                          && (!input.Quotes || input.Quotes && QuoteDisposition == wipList.Disposition)
                    select new CustomerWipViewDto
                    {
                        DocumentNumber = wo.WONo,
                        PoNumber = wo.PoNo,
                        Serial = wo.SerialNo,
                        UnitNo = wo.UnitNo,
                        Make = wo.Make,
                        Model = wo.Model,
                        Salesman = wo.Salesman,
                        AssociatedWONo = wo.AssociatedWONo,
                        RentalContractNo = wo.RentalContractNo,
                        CustomerFlag = wo.CustomerSale
                    }
                ;

            var pagedAndFilteredCustomerInvoices = filteredCustomerWip
                .OrderBy(input.Sorting ?? $"{nameof(WIPList.CustomerFlag)} asc")
                .PageBy(input);

            var totalCount = await filteredCustomerWip.CountAsync();
            var results = await pagedAndFilteredCustomerInvoices.ToListAsync();

            return new PagedResultDto<CustomerWipViewDto>(
                totalCount,
                results
            );
        }
    }
}
