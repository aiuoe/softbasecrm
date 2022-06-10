using Abp.AspNetCore.Mvc.Views;

namespace SBCRM.Web.Views
{
    public abstract class SBCRMRazorPage<TModel> : AbpRazorPage<TModel>
    {
        protected SBCRMRazorPage()
        {
            LocalizationSourceName = SBCRMConsts.LocalizationSourceName;
        }
    }
}
