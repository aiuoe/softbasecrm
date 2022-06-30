using System;
using Abp.Localization;
using Castle.MicroKernel.Registration;
using Microsoft.AspNetCore.StaticFiles;
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
        /// Get the content type from a file
        /// </summary>
        /// <param name="fullPathFile"></param>
        /// <returns></returns>
        public string GetContentType(string fullPathFile)
        {
            var provider = new FileExtensionContentTypeProvider();
            var defaultContentType = "application/octet-stream";
            if (!provider.TryGetContentType(fullPathFile, out string contentType))
            {
                contentType = defaultContentType;
            }
            return contentType;
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

        protected int GetRandom(int maxSize)
        {
            return new Random().Next(maxSize);
        }
    }
}