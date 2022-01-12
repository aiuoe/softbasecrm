using SBCRM.Crm;
using System.Linq;
using System.Threading.Tasks;
using Abp.UI;
using System;
using Microsoft.Extensions.Hosting;
using System.IO;
using SBCRM.Crm.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using MimeKit;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace SBCRM.Web.Controllers
{
    /// <summary>
    /// Customers Controller to manage specific methods as endpoints
    /// </summary>
    public abstract class CustomerImportControllerBase : SBCRMControllerBase
    {
        private ICustomerAttachmentsAppService _customerAttachmentsAppService;
        private readonly IHostEnvironment _env;
        private readonly IConfiguration _configuration;

        /// <summary>
        /// Base constructor
        /// </summary>
        /// <param name="customerAttachmentAppService"></param>
        /// <param name="env"></param>
        /// <param name="configuration"></param>
        public CustomerImportControllerBase(
            ICustomerAttachmentsAppService customerAttachmentAppService,
            IHostEnvironment env,
            IConfiguration configuration)
        {
            _customerAttachmentsAppService = customerAttachmentAppService;
            _configuration = configuration;
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
            var extensionList = GetExtensionsList();

            try
            {
                if (!extensionList.Any(x => string.Equals(extension, x, StringComparison.OrdinalIgnoreCase)))
                {
                    throw new UserFriendlyException(L("ErrorUploadingMessage"));
                }

                var path = _configuration["Configuration:AttachmentsFolder"];
                var dir = Path.Combine(path, $@"Accounts\{input.CustomerNumber}");
                if (!Directory.Exists(dir))
                {
                    Directory.CreateDirectory(dir);
                }

                var dto = new CreateOrEditCustomerAttachmentDto
                {
                    Id = input.Id,
                    Name = input.Name,
                    FilePath = attachment.FileName,
                    CustomerNumber = input.CustomerNumber
                };

                var filePath = Path.Combine(dir, attachment.FileName);
                using var stream = new FileStream(filePath, FileMode.Create);
                await attachment.CopyToAsync(stream);
                await _customerAttachmentsAppService.CreateOrEdit(dto);

                return dto.Id;
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                throw new UserFriendlyException(L("ErrorUploadingMessage"));
            }
        }

        /// <summary>
        /// Returns the list of extensions allowed for uloading attachments
        /// </summary>
        /// <returns></returns>
        private static List<string> GetExtensionsList()
        {
            return new List<string>
            {
                ".jpg",
                ".png",
                ".gif",
                ".jpeg",
                ".doc",
                ".docx",
                ".pdf", 
                ".ppt", 
                ".pptx", 
                ".xls", 
                ".odt", 
                ".txt", 
                ".xlsm", 
                ".csv",
                ".xlsx"
            };
        }

        /// <summary>
        /// Downloads an exiting attachement
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> GetAttachment(int id)
        {
            var dto = await _customerAttachmentsAppService.GetCustomerAttachmentForView(id);
            var attachment = dto.CustomerAttachment;

            if (attachment != null)
            {
                var dir = Path.Combine(_configuration["Configuration:AttachmentsFolder"], "Accounts");
                var path = Path.Combine(dir, $@"{attachment.CustomerNumber}\{attachment.FilePath}");
                if (System.IO.File.Exists(path))
                {
                    var memory = new MemoryStream();
                    using var stream = new FileStream(path, FileMode.Open);
                    await stream.CopyToAsync(memory);
                    memory.Position = 0;
                    return File(memory, MimeTypes.GetMimeType(attachment.FilePath), attachment.FilePath);
                }
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
            return StatusCode((int)HttpStatusCode.NotFound);
        }
    }
}
