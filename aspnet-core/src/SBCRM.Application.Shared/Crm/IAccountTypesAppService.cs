using System;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using SBCRM.Crm.Dtos;
using SBCRM.Dto;

namespace SBCRM.Crm
{
    public interface IAccountTypesAppService : IApplicationService
    {
        //Task<PagedResultDto<GetAccountTypeForViewDto>> GetAll();

        Task<PagedResultDto<GetAccountTypeForViewDto>> GetAll(GetAllAccountTypesInput input);

        Task<GetAccountTypeForEditOutput> GetAccountTypeForEdit(EntityDto input);

        Task CreateOrEdit(CreateOrEditAccountTypeDto input);

        Task Delete(EntityDto input);

    }
}