using Abp.Modules;
using Abp.Reflection.Extensions;

namespace SBCRM
{
    public class SBCRMCoreSharedModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(SBCRMCoreSharedModule).GetAssembly());
        }
    }
}