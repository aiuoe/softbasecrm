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
    /// <summary>
    /// Leads Controller to manage specific methods as endpoints
    /// </summary>
    public abstract class LeadImportControllerBase : SBCRMControllerBase
    {
        public ILeadsAppService _leadsAppService { get; set; }

        /// <summary>
        /// Base constructor
        /// </summary>
        /// <param name="leadsAppService"></param>
        /// <param name="tempFileCacheManager"></param>
        /// <param name="profileAppService"></param>
        public LeadImportControllerBase(
            ILeadsAppService leadsAppService,
            ITempFileCacheManager tempFileCacheManager,
            IProfileAppService profileAppService)
        {
            _leadsAppService = leadsAppService;
        }

        /// <summary>
        /// This method recieves an input file with a list of Leads to import and save them on the database
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<UploadLeadOutput> UploadLeads(FileDto input)
        {
            try
            {
                var excelLeads = Request.Form.Files.First();

                if (!excelLeads.FileName.EndsWith(".xlsx") && !excelLeads.FileName.EndsWith(".xls"))
                {
                    throw new UserFriendlyException(L("ErrorUploadingMessage"));
                }
                var byteArrayFile = await excelLeads.GetBytes();

                int leadSourceId = Convert.ToInt32(Request.Form["SelectedLeadSource"]);
                int assignedUserId = Convert.ToInt32(Request.Form["SelectedUser"]);

                var duplicatedLeads = await _leadsAppService.ImportLeadsFromFile(byteArrayFile, leadSourceId, assignedUserId);

                var dataReturn = new UploadLeadOutput
                {
                    FileName = excelLeads.FileName,
                    FileType = excelLeads.ContentType,
                    RepeatedLeads = duplicatedLeads
                };
                return dataReturn;
            }
            catch (UserFriendlyException ex)
            {
                Console.Write(ex.Message);
                throw new UserFriendlyException(L("ErrorUploadingMessage"));
            }
        }
    }
}