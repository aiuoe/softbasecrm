using System;
using Abp.Application.Services.Dto;

namespace SBCRM.Legacy
{
    /// <summary>
    /// DTO to manage the filter object to get customer invoices
    /// </summary>
    public class GetAllCustomerInvoicesInput : PagedAndSortedResultRequestDto
    {
        public string BillTo { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
