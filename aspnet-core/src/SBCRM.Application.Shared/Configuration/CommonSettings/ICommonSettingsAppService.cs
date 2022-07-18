using Abp.Application.Services;
using System.Threading.Tasks;
using SBCRM.Configuration.Dto;

namespace SBCRM.Configuration.CommonSettings
{
    public interface ICommonSettingsAppService : IApplicationService
    {
        Task UpdateTenantLevelSettings(UpdateCommonSettingsInput input);
        Task UpdateUserLevelSettings(UpdateCommonSettingsInput input);
    }
}
