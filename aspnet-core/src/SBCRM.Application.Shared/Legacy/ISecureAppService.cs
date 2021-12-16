using System;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using SBCRM.Legacy.Dtos;
using SBCRM.Dto;

namespace SBCRM.Legacy
{
    public interface ISecureAppService : IApplicationService
    {
        Task<PagedResultDto<GetSecureForViewDto>> GetAll(GetAllSecureInput input);

        Task<GetSecureForEditOutput> GetSecureForEdit(EntityDto input);

        Task CreateOrEdit(CreateOrEditSecureDto input);

        Task Delete(EntityDto input);

    }
}