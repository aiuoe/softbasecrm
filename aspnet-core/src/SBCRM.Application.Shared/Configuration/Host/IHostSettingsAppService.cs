using System.Threading.Tasks;
using Abp.Application.Services;
using SBCRM.Configuration.Host.Dto;

namespace SBCRM.Configuration.Host
{
    public interface IHostSettingsAppService : IApplicationService
    {
        Task<HostSettingsEditDto> GetAllSettings();

        Task UpdateAllSettings(HostSettingsEditDto input);

        Task SendTestEmail(SendTestEmailInput input);
    }
}
