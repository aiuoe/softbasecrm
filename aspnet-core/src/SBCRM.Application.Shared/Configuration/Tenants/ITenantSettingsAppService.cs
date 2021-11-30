using System.Threading.Tasks;
using Abp.Application.Services;
using SBCRM.Configuration.Tenants.Dto;

namespace SBCRM.Configuration.Tenants
{
    public interface ITenantSettingsAppService : IApplicationService
    {
        Task<TenantSettingsEditDto> GetAllSettings();

        Task UpdateAllSettings(TenantSettingsEditDto input);

        Task ClearLogo();

        Task ClearCustomCss();
    }
}
