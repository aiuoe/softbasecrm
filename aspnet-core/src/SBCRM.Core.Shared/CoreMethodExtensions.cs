using Abp.Localization;
using Abp.Runtime.Validation;

namespace SBCRM
{
    /// <summary>
    /// Global method extensions
    /// </summary>
    public static class CoreMethodExtensions
    {
        /// <summary>
        /// Get localization message from validation context
        /// </summary>
        /// <param name="context"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetLocalizationMessage(this CustomValidationContext context, string key)
        {
            return context.IocResolver.Resolve<ILocalizationManager>().GetString(SBCRMConsts.LocalizationSourceName, key);
        }
    }
}
