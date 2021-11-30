using System.Threading.Tasks;
using Abp.Application.Services;
using SBCRM.Editions.Dto;
using SBCRM.MultiTenancy.Dto;

namespace SBCRM.MultiTenancy
{
    public interface ITenantRegistrationAppService: IApplicationService
    {
        Task<RegisterTenantOutput> RegisterTenant(RegisterTenantInput input);

        Task<EditionsSelectOutput> GetEditionsForSelect();

        Task<EditionSelectDto> GetEdition(int editionId);
    }
}