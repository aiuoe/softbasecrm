using Abp.Domain.Services;

namespace SBCRM
{
    public abstract class SBCRMDomainServiceBase : DomainService
    {
        /* Add your common members for all your domain services. */

        protected SBCRMDomainServiceBase()
        {
            LocalizationSourceName = SBCRMConsts.LocalizationSourceName;
        }
    }
}
