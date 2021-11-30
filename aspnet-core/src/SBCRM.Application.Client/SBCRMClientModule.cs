using Abp.Modules;
using Abp.Reflection.Extensions;

namespace SBCRM
{
    public class SBCRMClientModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(SBCRMClientModule).GetAssembly());
        }
    }
}
