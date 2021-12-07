using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SBCRM.Crm;
using SBCRM.Dto;
using SBCRM.Web.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SBCRM.Web.Controllers
{
    public class LeadImportController : SBCRMControllerBase
    {
        public ILeadsAppService _leadsAppService { get; set; }

        public LeadImportController(ILeadsAppService leadsAppService)
        {
            _leadsAppService = leadsAppService;
        }

        [HttpPost]
        public async Task UploadLeadsAsync()
        {
            try
            {
                var profilePictureFile = Request.Form.Files.First();
                var byteArrayFile = await profilePictureFile.GetBytes();
                await _leadsAppService.ImportLeadsFromFile(byteArrayFile);
            }
            catch (Exception)
            {

            }

        }
     }
}
