using SBCRM.Crm;
using Microsoft.Extensions.Hosting;
using Abp.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Configuration;

namespace SBCRM.Web.Controllers { 

    /// <summary>
    /// Opportunity Controller to manage specific methods as endpoints
    /// </summary>
    [AbpMvcAuthorize]
    public class OpportunityAttachmentController : OpportunityAttachmentControllerBase
    {

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="opportunityAttachmentAppService"></param>
        /// <param name="env"></param>
        /// <param name="configuration"></param>
        public OpportunityAttachmentController(
            IOpportunityAttachmentsAppService opportunityAttachmentAppService,
            IHostEnvironment env,
            IConfiguration configuration) :
            base(opportunityAttachmentAppService, env, configuration)
        {
        }
    }
}
