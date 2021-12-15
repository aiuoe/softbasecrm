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
    public class SoftBaseCustomerInvoiceRepository : ISoftBaseCustomerInvoiceRepository
    {
        private const int FilteredDisposition = 2;
        private readonly SBCRMDbContext _dbContext;

        /// <summary>
        /// Main constructor
        /// </summary>
        /// <param name="dbContext"></param>
        public SoftBaseCustomerInvoiceRepository(SBCRMDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Get customer invoices
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<PagedResultDto<CustomerInvoiceViewDto>> GetPagedCustomerInvoices(GetAllCustomerInvoicesInput input)
        {
            var filteredCustomerInvoices = from invoiceRegList in _dbContext.Set<InvoiceRegList>()
                join wo in _dbContext.Set<WO>() on invoiceRegList.WONo equals wo.WONo
                join invoiceReg in _dbContext.Set<InvoiceReg>() on invoiceRegList.WONo equals invoiceReg.InvoiceNo
                join equipment in _dbContext.Set<Equipment>() on invoiceRegList.SerialNo equals equipment.SerialNo into e
                from s1 in e.DefaultIfEmpty()
                where FilteredDisposition == invoiceRegList.Disposition
                      && (wo.BillTo  == input.BillTo)
                      && (!input.StartDate.HasValue || invoiceRegList.InvoiceDate >= input.StartDate.Value)
                      && (!input.EndDate.HasValue || invoiceRegList.InvoiceDate <= input.EndDate.Value)
                select new CustomerInvoiceViewDto
                {
                    InvoiceNumber = invoiceReg.InvoiceNo,
                    PoNumber = wo.PoNo,
                    Serial = invoiceRegList.SerialNo,
                    UnitNo = wo.UnitNo,
                    AssociatedWONo = wo.AssociatedWONo,
                    RentalContractNo = wo.RentalContractNo,
                    GrandTotal = invoiceReg.GrandTotal,
                    CustomerFlag = invoiceRegList.CustomerFlag
                };

            var pagedAndFilteredCustomerInvoices = filteredCustomerInvoices
                .OrderBy(input.Sorting ?? $"{nameof(InvoiceRegList.CustomerFlag)} asc")
                .PageBy(input);

            var totalCount = await filteredCustomerInvoices.CountAsync();
            var results = await pagedAndFilteredCustomerInvoices.ToListAsync();

            return new PagedResultDto<CustomerInvoiceViewDto>(
                totalCount,
                results
            );
        }
    }
}
