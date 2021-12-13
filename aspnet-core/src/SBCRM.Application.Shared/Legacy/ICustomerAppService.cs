using System;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using SBCRM.Legacy.Dtos;
using SBCRM.Dto;
using System.Collections.Generic;

namespace SBCRM.Legacy
{
    /// <summary>
    /// App service to handle customer information
    /// </summary>
    public interface ICustomerAppService : IApplicationService
    {
        /// <summary>
        /// Get all customers
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<PagedResultDto<GetCustomerForViewDto>> GetAll(GetAllCustomerInput input);

        Task<GetCustomerForViewDto> GetCustomerForView(string customerNumber);

        Task<GetCustomerForEditOutput> GetCustomerForEdit(GetCustomerForEditInput input);

        Task CreateOrEdit(CreateOrEditCustomerDto input);

        Task Delete(DeleteCustomerInput input);

        /// <summary>
        /// Get Customers for excel export
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<FileDto> GetCustomerToExcel(GetAllCustomerForExcelInput input);

        Task<List<CustomerAccountTypeLookupTableDto>> GetAllAccountTypeForTableDropdown();

    }
}