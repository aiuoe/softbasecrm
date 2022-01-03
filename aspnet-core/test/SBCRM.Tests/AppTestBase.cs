using Abp.Localization;
using Castle.MicroKernel.Registration;
using SBCRM.Test.Base;

namespace SBCRM.Tests
{
    /// <summary>
    /// Test base class
    /// </summary>
    public class AppTestBase : AppTestBase<SBCRMTestModule>
    {
        protected readonly ILocalizationManager Localization;

        public AppTestBase()
        {
            Localization = Resolve<ILocalizationManager>();
        }

        /// <summary>
        /// Get localization value
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        protected string L(string key)
        {
            return Localization.GetString(SBCRMConsts.LocalizationSourceName, key);
        }

        /// <summary>
        /// Register dependency
        /// </summary>
        /// <param name="registrations"></param>
        protected void Register(params IRegistration[] registrations)
        {
            LocalIocManager.IocContainer.Register(registrations);
        }
    }
}