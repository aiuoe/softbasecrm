using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;

namespace SBCRM
{
    [DependsOn(typeof(SBCRMClientModule), typeof(AbpAutoMapperModule))]
    public class SBCRMXamarinSharedModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Localization.IsEnabled = false;
            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(SBCRMXamarinSharedModule).GetAssembly());
        }
    }
}