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
using Microsoft.Extensions.Hosting;
using SBCRM.Crm.Dtos;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using Abp.AspNetCore.Mvc.Authorization;

namespace SBCRM.Web.Controllers
{
    /// <summary>
    /// Customers Controller to manage specific methods as endpoints
    /// </summary>
    [AbpMvcAuthorize]
    public class CustomerImportController : SBCRMControllerBase
    {
        private ICustomerAttachmentsAppService _customerAttachmentAppService { get; set; }
        private readonly IHostEnvironment _env;

        /// <summary>
        /// Base constructor
        /// </summary>
        /// <param name="customerAttachmentAppService"></param>
        public CustomerImportController(
            ICustomerAttachmentsAppService customerAttachmentAppService,
            IHostEnvironment env)
        {
            _customerAttachmentAppService = customerAttachmentAppService;
            _env = env;
        }

        /// <summary>
        /// This method recieves an input file as a customer attachment.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<int?> UploadAttachments(CustomerAttachmentDto input)
        {
            var attachment = Request.Form.Files.First();
            var extension = Path.GetExtension(attachment.FileName);

            try
            {
                if (!(string.Equals(extension, ".jpg", StringComparison.OrdinalIgnoreCase)
                    || string.Equals(extension, ".png", StringComparison.OrdinalIgnoreCase)
                    || string.Equals(extension, ".gif", StringComparison.OrdinalIgnoreCase)
                    || string.Equals(extension, ".jpeg", StringComparison.OrdinalIgnoreCase)
                    || string.Equals(extension, ".doc", StringComparison.OrdinalIgnoreCase)
                    || string.Equals(extension, ".pdf", StringComparison.OrdinalIgnoreCase)))
                {
                    throw new UserFriendlyException(L("ErrorUploadingMessage"));
                }

                var dir = Path.Combine(_env.ContentRootPath, "Attachments");
                if (!Directory.Exists(dir))
                {
                    Directory.CreateDirectory(dir);
                }

                var dto = new CreateOrEditCustomerAttachmentDto
                {
                    Name = input.Name,
                    FilePath = Path.Combine(dir, attachment.FileName)
                };

                await attachment.CopyToAsync(new FileStream(dto.FilePath, FileMode.Create));
                await _customerAttachmentAppService.CreateOrEdit(dto);

                return dto.Id;
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                throw new UserFriendlyException(L("ErrorUploadingMessage"));
            }
        }
    }
}
