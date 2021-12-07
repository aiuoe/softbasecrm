using SBCRM.Crm;
using SBCRM.Dto;
using SBCRM.Web.Common;
using System.Linq;
using System.Threading.Tasks;
using Abp.UI;
using SBCRM.Authorization.Users.Profile;
using SBCRM.Authorization.Users.Profile.Dto;
using SBCRM.Storage;

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
                var profilePictureFile = Request.Form.Files.First();
                var byteArrayFile = await profilePictureFile.GetBytes();
                await _leadsAppService.ImportLeadsFromFile(byteArrayFile);
                return null;
            }
            catch (UserFriendlyException ex)
            {
                throw;
            }
        }
    }
}