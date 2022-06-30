using Abp;
using Abp.Authorization;
using Abp.Configuration;
using SBCRM.Authorization;
using SBCRM.Configuration.CommonSettings.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBCRM.Configuration.CommonSettings
{
    /// <summary>
    /// Concept implemetation
    /// </summary>
    [AbpAuthorize(AppPermissions.Pages_Leads)]
    public class CommonSettingsAppService: SBCRMAppServiceBase,ICommonSettingsAppService
    {
        private readonly ISettingManager _settingManager;

        //Inject ISettingManager in the constructor
        public CommonSettingsAppService(ISettingManager settingManager)
        {
            _settingManager = settingManager;
        }

        //Updates Tenent Level Settings 
        public async Task UpdateTenentLevelSettings(UpdateCommonSettingsInput input)
        {
                        await _settingManager.ChangeSettingForTenantAsync(AbpSession.TenantId.Value, input.SettingName, input.SettingValue + "Tenant Id:" + AbpSession.TenantId.Value);
        }
        // Updates User Level Settings
        public async Task UpdateUserLevelSettings(UpdateCommonSettingsInput input)
        {
            await _settingManager.ChangeSettingForUserAsync(new UserIdentifier(AbpSession.TenantId.Value, AbpSession.UserId.Value) , input.SettingName, input.SettingValue);
        }

       
    }
}
