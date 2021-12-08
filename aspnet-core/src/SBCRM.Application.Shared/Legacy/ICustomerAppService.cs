using System;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using SBCRM.Legacy.Dtos;
using SBCRM.Dto;
using System.Collections.Generic;

namespace SBCRM.Legacy
{
    public interface ICustomerAppService : IApplicationService
    {
        Task<PagedResultDto<GetCustomerForViewDto>> GetAll(GetAllCustomerInput input);

        Task<GetCustomerForViewDto> GetCustomerForView(string customerNumber);

        Task<GetCustomerForEditOutput> GetCustomerForEdit(GetCustomerForEditInput input);

        Task CreateOrEdit(CreateOrEditCustomerDto input);

        Task Delete(DeleteCustomerInput input);

        Task<FileDto> GetCustomerToExcel(GetAllCustomerForExcelInput input);

        Task<List<CustomerAccountTypeLookupTableDto>> GetAllAccountTypeForTableDropdown();

    }
}