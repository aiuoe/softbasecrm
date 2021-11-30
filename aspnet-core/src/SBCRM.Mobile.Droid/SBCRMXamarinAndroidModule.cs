using Abp.Modules;
using Abp.Reflection.Extensions;

namespace SBCRM
{
    [DependsOn(typeof(SBCRMXamarinSharedModule))]
    public class SBCRMXamarinAndroidModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(SBCRMXamarinAndroidModule).GetAssembly());
        }
    }
}