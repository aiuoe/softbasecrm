using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using SBCRM.Crm.Dtos;

namespace SBCRM.Crm
{
    public interface IAccountTypesAppService : IApplicationService
    {
        Task<List<GetAccountTypeForViewDto>> GetAllWithoutPaging();

        Task<PagedResultDto<GetAccountTypeForViewDto>> GetAll(GetAllAccountTypesInput input);

        Task<GetAccountTypeForEditOutput> GetAccountTypeForEdit(EntityDto input);

        Task CreateOrEdit(CreateOrEditAccountTypeDto input);

        Task Delete(EntityDto input);

    }
}