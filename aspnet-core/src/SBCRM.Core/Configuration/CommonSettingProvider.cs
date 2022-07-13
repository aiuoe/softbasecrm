using Abp.Configuration;
using Abp.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBCRM.Configuration
{
    /// <summary>
    /// Defines Common settings for the application.
    /// See <see cref="CommonSettings"/> for setting names.
    /// </summary>
    public class CommonSettingProvider : SettingProvider
    {
        public ILocalizationManager _localizationManager { get; }

        public CommonSettingProvider(ILocalizationManager localizationManager)
        {
            _localizationManager = localizationManager;
        }
        /// <summary>
        /// If no value is found for the settings then default value will be returned
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override IEnumerable<SettingDefinition> GetSettingDefinitions(SettingDefinitionProviderContext context)
        {

            return new[]
                {
                //An application scoped setting is used for user/tenant independent settings
                 new SettingDefinition(
                       name: "ApplicationLevelSettings",
                       defaultValue: "ApplicationDefaultValue",
                        scopes: SettingScopes.Application,
                        clientVisibilityProvider: new VisibleSettingClientVisibilityProvider(),
                        isEncrypted: false
                        ),
                 // If the application is multi-tenant, we can define tenant-specific settings.
                    new SettingDefinition(
                       name: "TenentLevelSettings",
                       defaultValue: "TenantDefaultValue",
                        scopes: SettingScopes.Tenant,
                        clientVisibilityProvider: new VisibleSettingClientVisibilityProvider(),
                        isEncrypted: false
                        ),
                    //We can use a user-scoped setting to store/get the value of the setting specific to each user.
                    new SettingDefinition(
                       name: "UserLevelSettings",
                       defaultValue: "UserDefaultValue",
                        scopes: SettingScopes.User,
                        clientVisibilityProvider: new VisibleSettingClientVisibilityProvider(),
                        isEncrypted: false
                        )

                };
        }
    }
}
