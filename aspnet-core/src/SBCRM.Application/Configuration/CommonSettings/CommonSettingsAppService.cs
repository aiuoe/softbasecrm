using Abp;
using Abp.Authorization;
using Abp.Configuration;
using SBCRM.Authorization;
using System.Threading.Tasks;
using SBCRM.Configuration.Dto;

namespace SBCRM.Configuration.CommonSettings
{
    /// <summary>
    /// Concept implemetation
    /// </summary>
    [AbpAuthorize(AppPermissions.Pages_Leads)]
    public class CommonSettingsAppService: SBCRMAppServiceBase,ICommonSettingsAppService
    {
        private readonly ISettingManager _settingManager;

        /// <summary>
        /// Inject ISettingManager in the constructor
        /// </summary>
        public CommonSettingsAppService(ISettingManager settingManager)
        {
            _settingManager = settingManager;
        }

        /// <summary>
        /// Updates Tenent Level Settings
        /// </summary>
        public async Task UpdateTenantLevelSettings(UpdateCommonSettingsInput input)
        {
            await _settingManager.ChangeSettingForTenantAsync(AbpSession.TenantId.Value, input.SettingName, input.SettingValue + "Tenant Id:" + AbpSession.TenantId.Value);
        }

        /// <summary>
        /// Updates User Level Settings
        /// </summary>
        public async Task UpdateUserLevelSettings(UpdateCommonSettingsInput input)
        {
            await _settingManager.ChangeSettingForUserAsync(new UserIdentifier(AbpSession.TenantId.Value, AbpSession.UserId.Value) , input.SettingName, input.SettingValue);
        }

       
    }
}
