using SBCRM.Crm;
using Microsoft.Extensions.Hosting;
using Abp.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Configuration;

namespace SBCRM.Web.Controllers
{
    /// <summary>
    /// Customers Controller to manage specific methods as endpoints
    /// </summary>
    [AbpMvcAuthorize]
    public class CustomerImportController : CustomerImportControllerBase
    {
        /// <summary>
        /// Base constructor
        /// </summary>
        /// <param name="customerAttachmentAppService"></param>
        /// <param name="env"></param>
        public CustomerImportController(
            ICustomerAttachmentsAppService customerAttachmentAppService,
            IHostEnvironment env,
            IConfiguration configuration) :
            base(customerAttachmentAppService, env, configuration)
        {
        }
    }
}
