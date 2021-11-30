using Abp.Modules;
using Abp.Reflection.Extensions;
using Castle.Windsor.MsDependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using SBCRM.Configure;
using SBCRM.Startup;
using SBCRM.Test.Base;

namespace SBCRM.GraphQL.Tests
{
    [DependsOn(
        typeof(SBCRMGraphQLModule),
        typeof(SBCRMTestBaseModule))]
    public class SBCRMGraphQLTestModule : AbpModule
    {
        public override void PreInitialize()
        {
            IServiceCollection services = new ServiceCollection();
            
            services.AddAndConfigureGraphQL();

            WindsorRegistrationHelper.CreateServiceProvider(IocManager.IocContainer, services);
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(SBCRMGraphQLTestModule).GetAssembly());
        }
    }
}