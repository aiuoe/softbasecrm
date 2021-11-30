using Abp.AspNetCore.Mvc.ViewComponents;

namespace SBCRM.Web.Public.Views
{
    public abstract class SBCRMViewComponent : AbpViewComponent
    {
        protected SBCRMViewComponent()
        {
            LocalizationSourceName = SBCRMConsts.LocalizationSourceName;
        }
    }
}