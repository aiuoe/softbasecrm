using Abp.Modules;
using Abp.Reflection.Extensions;

namespace SBCRM
{
    [DependsOn(typeof(SBCRMXamarinSharedModule))]
    public class SBCRMXamarinIosModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(SBCRMXamarinIosModule).GetAssembly());
        }
    }
}