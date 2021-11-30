using Abp.AspNetCore.Mvc.Views;
using Abp.Runtime.Session;
using Microsoft.AspNetCore.Mvc.Razor.Internal;

namespace SBCRM.Web.Public.Views
{
    public abstract class SBCRMRazorPage<TModel> : AbpRazorPage<TModel>
    {
        [RazorInject]
        public IAbpSession AbpSession { get; set; }

        protected SBCRMRazorPage()
        {
            LocalizationSourceName = SBCRMConsts.LocalizationSourceName;
        }
    }
}
