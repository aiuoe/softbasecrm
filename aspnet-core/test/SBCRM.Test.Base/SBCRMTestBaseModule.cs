using System;
using System.IO;
using Abp;
using Abp.AspNetZeroCore;
using Abp.AutoMapper;
using Abp.Configuration.Startup;
using Abp.Dependency;
using Abp.Modules;
using Abp.Net.Mail;
using Abp.TestBase;
using Abp.Zero.Configuration;
using Azure.Storage.Blobs;
using Castle.MicroKernel.Registration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using SBCRM.Authorization.Users;
using SBCRM.Configuration;
using SBCRM.EntityFrameworkCore;
using SBCRM.MultiTenancy;
using SBCRM.Security.Recaptcha;
using SBCRM.Test.Base.DependencyInjection;
using SBCRM.Test.Base.UiCustomization;
using SBCRM.Test.Base.Url;
using SBCRM.Test.Base.Web;
using SBCRM.UiCustomization;
using SBCRM.Url;
using NSubstitute;
using SBCRM.Blob;
using SBCRM.Blob.Dto;
using SBCRM.Infrastructure.BlobStorage;

namespace SBCRM.Test.Base
{
    [DependsOn(
        typeof(SBCRMApplicationModule),
        typeof(SBCRMEntityFrameworkCoreModule),
        typeof(AbpTestBaseModule))]
    public class SBCRMTestBaseModule : AbpModule
    {
        public SBCRMTestBaseModule(SBCRMEntityFrameworkCoreModule abpZeroTemplateEntityFrameworkCoreModule)
        {
            abpZeroTemplateEntityFrameworkCoreModule.SkipDbContextRegistration = true;
        }

        public override void PreInitialize()
        {
            var configuration = GetConfiguration();

            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;

            Configuration.UnitOfWork.Timeout = TimeSpan.FromMinutes(30);
            Configuration.UnitOfWork.IsTransactional = false;

            //Disable static mapper usage since it breaks unit tests (see https://github.com/aspnetboilerplate/aspnetboilerplate/issues/2052)
            Configuration.Modules.AbpAutoMapper().UseStaticMapper = false;

            //Use database for language management
            Configuration.Modules.Zero().LanguageManagement.EnableDbLocalization();

            RegisterFakeService<AbpZeroDbMigrator>();

            IocManager.Register<IAppUrlService, FakeAppUrlService>();
            IocManager.Register<IWebUrlService, FakeWebUrlService>();
            IocManager.Register<IRecaptchaValidator, FakeRecaptchaValidator>();

            Configuration.ReplaceService<IAppConfigurationAccessor, TestAppConfigurationAccessor>();
            Configuration.ReplaceService<IEmailSender, NullEmailSender>(DependencyLifeStyle.Transient);
            Configuration.ReplaceService<IUiThemeCustomizerFactory, NullUiThemeCustomizerFactory>();
            
            IocManager.IocContainer.Register(
                Component.For<BlobServiceClient>()
                    .UsingFactoryMethod(() =>  new BlobServiceClient(configuration["AzureStorage:ConnectionString"]))
                    .LifestyleSingleton()
                );

            var azureSettings = new AzureStorageSettings
            {
                ContainerName = configuration["AzureStorage:ContainerName"],
                RootDirectory = configuration["AzureStorage:RootDirectory"]
            };
            IocManager.IocContainer.Register(
                Component.For<IOptions<AzureStorageSettings>>()
                    .Instance(Options.Create(azureSettings))
                    .LifestyleSingleton()
            );

            IocManager.Register<IBlobStorageService, AzureBlobStorageService>();
            IocManager.Register<IApplicationStorageService, ApplicationStorageService>();

            Configuration.Modules.AspNetZero().LicenseCode = configuration["AbpZeroLicenseCode"];

            //Uncomment below line to write change logs for the entities below:
            Configuration.EntityHistory.IsEnabled = true;
            Configuration.EntityHistory.Selectors.Add("SBCRMEntities", typeof(User), typeof(Tenant));
        }

        public override void Initialize()
        {
            ServiceCollectionRegistrar.Register(IocManager, GetConfiguration());
        }

        private void RegisterFakeService<TService>()
            where TService : class
        {
            IocManager.IocContainer.Register(
                Component.For<TService>()
                    .UsingFactoryMethod(() => Substitute.For<TService>())
                    .LifestyleSingleton()
            );
        }

        private static IConfigurationRoot GetConfiguration()
        {
            return AppConfigurations.Get(Directory.GetCurrentDirectory(), addUserSecrets: true);
        }
    }
}
