using SBCRM.Crm;
using SBCRM.Dto;
using SBCRM.Web.Common;
using System.Linq;
using System.Threading.Tasks;
using Abp.UI;
using SBCRM.Authorization.Users.Profile;
using SBCRM.Authorization.Users.Profile.Dto;
using SBCRM.Storage;
using System;

namespace SBCRM.Web.Controllers
{
    public abstract class LeadImportControllerBase : SBCRMControllerBase
    {
        public ILeadsAppService _leadsAppService { get; set; }

        public LeadImportControllerBase(
            ILeadsAppService leadsAppService,
            ITempFileCacheManager tempFileCacheManager,
            IProfileAppService profileAppService)
        {
            _leadsAppService = leadsAppService;
        }


        public async Task<UploadLeadOutput> UploadLeads(FileDto input)
        {
            try
            {
                var excelLeads = Request.Form.Files.First();
                var byteArrayFile = await excelLeads.GetBytes();

                int leadSourceId = Convert.ToInt32(Request.Form["SelectedLeadSource"]);
                int assignedUserId = Convert.ToInt32(Request.Form["SelectedLeadSource"]);

                await _leadsAppService.ImportLeadsFromFile(byteArrayFile, leadSourceId, assignedUserId);
                return null;
            }
            catch (UserFriendlyException ex)
            {
                throw;
            }
        }
    }
}