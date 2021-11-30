using Abp.Modules;
using Abp.Reflection.Extensions;

namespace SBCRM
{
    [DependsOn(typeof(SBCRMCoreSharedModule))]
    public class SBCRMApplicationSharedModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(SBCRMApplicationSharedModule).GetAssembly());
        }
    }
}