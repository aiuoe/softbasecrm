using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;

namespace SBCRM.Startup
{
    [DependsOn(typeof(SBCRMCoreModule))]
    public class SBCRMGraphQLModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(SBCRMGraphQLModule).GetAssembly());
        }

        public override void PreInitialize()
        {
            base.PreInitialize();

            //Adding custom AutoMapper configuration
            Configuration.Modules.AbpAutoMapper().Configurators.Add(CustomDtoMapper.CreateMappings);
        }
    }
}